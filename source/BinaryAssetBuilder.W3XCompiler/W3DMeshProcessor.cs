using Relo;
using SageBinaryData;
using System;
using System.Runtime.InteropServices;
using ShortList = System.Collections.Generic.List<ushort>;

public enum UsageType
{
    Vertex,
    Normal,
    Tangent,
    Binormal,
    TexCoord,
    VertexColor,
    BlendIndex,
    BlendWeight
}

public class ConverterData
{
    public ShortList BlendStuff;
    public Tracker Tracker;
}

public class DataMapping
{
    public UsageType UsageType;
    public int UsageIndex;
    public unsafe void* SrcData;
    public int SrcDeltaToNextElement;
    public int Offset;
}

[StructLayout(LayoutKind.Sequential)]
public struct XMHALF2
{
    public ushort X;
    public ushort Y;
}

[StructLayout(LayoutKind.Sequential)]
public struct XMHALF4
{
    public ushort X;
    public ushort Y;
    public ushort Z;
    public ushort W;
}

internal class W3DMeshProcessor : IDisposable
{
    private unsafe RGBAColor* _defaultColor;

    public unsafe W3DMeshProcessor()
    {
        _defaultColor = (RGBAColor*)Marshal.AllocHGlobal(sizeof(RGBAColor));
        _defaultColor->Base.R = 1.0f;
        _defaultColor->Base.G = 1.0f;
        _defaultColor->Base.B = 1.0f;
        _defaultColor->A = 1.0f;
    }

    private static ushort CompressFloatToHalf(uint f)
    {
        uint mask1 = f & int.MaxValue;
        uint mask2 = (uint)(f & int.MinValue) >> 16;
        if (mask1 > 0x47FFEFFFu)
        {
            return (ushort)((int)mask2 | short.MaxValue);
        }
        uint val;
        if (mask1 < 0x38800000u)
        {
            val = (uint)(((int)mask1 & 0x7FFFFF) | 0x800000) >> (int)(113 - (mask1 >> 23));
        }
        else
        {
            val = mask1 + 0xC8000000;
        }
        return (ushort)((int)mask2 | (int)((uint)((int)val + 0xFFF + ((int)(val >> 13) & 1)) >> 13));
    }

    private static unsafe void CopyTexCoord(int numElements, sbyte* srcData, int srcPitch, sbyte* destData, int destPitch, ConverterData converterData)
    {
        for (; numElements != 0; --numElements)
        {
            Vector2* destVec = (Vector2*)destData;
            Vector2* srcVec = (Vector2*)srcData;
            float num = srcVec->X;
            if (converterData.Tracker.IsBigEndian)
            {
                converterData.Tracker.InplaceEndianToPlatform((uint*)&num);
            }
            destVec->X = num;
            num = 1.0f - srcVec->Y;
            if (converterData.Tracker.IsBigEndian)
            {
                converterData.Tracker.InplaceEndianToPlatform((uint*)&num);
            }
            destVec->Y = num;
            srcData += srcPitch;
            destData += destPitch;
        }
    }

    private static unsafe void CompressTexCoord(int numElements, sbyte* srcData, int srcPitch, sbyte* destData, int destPitch, ConverterData converterData)
    {
        for (; numElements != 0; --numElements)
        {
            XMHALF2* destVec = (XMHALF2*)destData;
            Vector2* srcVec = (Vector2*)srcData;
            float x = srcVec->X;
            float y = 1.0f - srcVec->Y;
            ushort iX = CompressFloatToHalf(*(uint*)&x);
            ushort iY = CompressFloatToHalf(*(uint*)&y);
            if (converterData.Tracker.IsBigEndian)
            {
                converterData.Tracker.InplaceEndianToPlatform(&iX);
                converterData.Tracker.InplaceEndianToPlatform(&iY);
            }
            destVec->X = iX;
            destVec->Y = iY;
            srcData += srcPitch;
            destData += destPitch;
        }
    }

    private static unsafe void Vector4ToD3DCOLOR(int numElements, sbyte* srcData, int srcPitch, sbyte* destData, int destPitch, ConverterData converterData)
    {
        for (; numElements != 0; --numElements)
        {
            uint* color = (uint*)destData;
            Vector4* srcVec = (Vector4*)srcData;
            uint result = ((uint)((double)srcVec->W * byte.MaxValue) << 24)
                        | ((uint)((double)srcVec->X * byte.MaxValue) << 16)
                        | ((uint)((double)srcVec->Y * byte.MaxValue) << 8)
                        | (uint)((double)srcVec->Z * byte.MaxValue);
            if (converterData.Tracker.IsBigEndian)
            {
                converterData.Tracker.InplaceEndianToPlatform(&result);
            }
            *color = result;
            srcData += srcPitch;
            destData += destPitch;
        }
    }

    private static unsafe void Vector3ToHalf4(int numElements, sbyte* srcData, int srcPitch, sbyte* destData, int destPitch, ConverterData converterData)
    {
        for (; numElements != 0; --numElements)
        {
            XMHALF4* destVec = (XMHALF4*)destData;
            Vector3* srcVec = (Vector3*)srcData;
            float x = srcVec->X;
            float y = srcVec->Y;
            float z = srcVec->Z;
            float w = 0.0f;
            ushort iX = CompressFloatToHalf(*(uint*)&x);
            ushort iY = CompressFloatToHalf(*(uint*)&y);
            ushort iZ = CompressFloatToHalf(*(uint*)&z);
            ushort iW = CompressFloatToHalf(*(uint*)&w);
            if (converterData.Tracker.IsBigEndian)
            {
                converterData.Tracker.InplaceEndianToPlatform(&iX);
                converterData.Tracker.InplaceEndianToPlatform(&iY);
                converterData.Tracker.InplaceEndianToPlatform(&iZ);
                converterData.Tracker.InplaceEndianToPlatform(&iW);
            }
            destVec->X = iX;
            destVec->Y = iY;
            destVec->Z = iZ;
            destVec->W = iW;
            srcData += srcPitch;
            destData += destPitch;
        }
    }

    private static unsafe void FloatToHalf(int numElements, sbyte* srcData, int srcPitch, sbyte* destData, int destPitch, ConverterData converterData)
    {
        for (; numElements != 0; --numElements)
        {
            ushort* dest = (ushort*)destData;
            float src = *(float*)srcData;
            ushort iSrc = CompressFloatToHalf(*(uint*)&src);
            if (converterData.Tracker.IsBigEndian)
            {
                converterData.Tracker.InplaceEndianToPlatform(&iSrc);
            }
            *dest = iSrc;
            srcData += srcPitch;
            destData += destPitch;
        }
    }

    private static unsafe void ConvertBlendIndex(int numElements, sbyte* srcData, int srcPitch, sbyte* destData, int destPitch, ConverterData converterData)
    {
        for (; numElements != 0; --numElements)
        {
            ushort src = *(ushort*)srcData;
            if (src >= converterData.BlendStuff.Count)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Blend index is too big.");
            }
            *destData = (sbyte)converterData.BlendStuff[src];
            srcData += srcPitch;
            destData += destPitch;
        }
    }

    private static unsafe void CompressNormalizedDirection(int numElements, sbyte* srcData, int srcPitch, sbyte* destData, int destPitch, ConverterData converterData)
    {
        for (; numElements != 0; --numElements)
        {
            // TODO:
            srcData += srcPitch;
            destData += destPitch;
        }
    }

    private unsafe void DetermineVertexDataContents(W3DMeshPipelineVertexData* pipelineData, System.Collections.Generic.List<DataMapping> mappings)
    {
        mappings.Clear();
        for (int idx = 0; idx < pipelineData->Vertices.Count; ++idx)
        {
            mappings.Add(new DataMapping
            {
                UsageType = UsageType.Vertex,
                UsageIndex = idx,
                SrcData = pipelineData->Vertices.Items[idx].V.Items,
                SrcDeltaToNextElement = 12,
                Offset = 0
            });
        }
        for (int idx = 0; idx < pipelineData->Normals.Count; ++idx)
        {
            mappings.Add(new DataMapping
            {
                UsageType = UsageType.Normal,
                UsageIndex = idx,
                SrcData = pipelineData->Normals.Items[idx].N.Items,
                SrcDeltaToNextElement = 12,
                Offset = 0
            });
        }
        if ((IntPtr)pipelineData->VertexColors != IntPtr.Zero)
        {
            mappings.Add(new DataMapping
            {
                UsageType = UsageType.VertexColor,
                UsageIndex = 0,
                SrcData = pipelineData->VertexColors->C.Items,
                SrcDeltaToNextElement = 16,
                Offset = 0
            });
        }
        else
        {
            mappings.Add(new DataMapping
            {
                UsageType = UsageType.VertexColor,
                UsageIndex = 0,
                SrcData = _defaultColor,
                SrcDeltaToNextElement = 0,
                Offset = 0
            });
        }
        if ((IntPtr)pipelineData->Tangents != IntPtr.Zero && (IntPtr)pipelineData->Binormals != IntPtr.Zero)
        {
            mappings.Add(new DataMapping
            {
                UsageType = UsageType.Tangent,
                UsageIndex = 0,
                SrcData = pipelineData->Tangents->T.Items,
                SrcDeltaToNextElement = 12,
                Offset = 0
            });
            mappings.Add(new DataMapping
            {
                UsageType = UsageType.Binormal,
                UsageIndex = 0,
                SrcData = pipelineData->Binormals->B.Items,
                SrcDeltaToNextElement = 12,
                Offset = 0
            });
        }
        for (int idx = 0; idx < pipelineData->TexCoords.Count; ++idx)
        {
            mappings.Add(new DataMapping
            {
                UsageType = UsageType.TexCoord,
                UsageIndex = idx,
                SrcData = pipelineData->TexCoords.Items[idx].T.Items,
                SrcDeltaToNextElement = 8,
                Offset = 0
            });
        }
        int num = (int)(pipelineData->Vertices.Count >= pipelineData->BoneInfluences.Count ? pipelineData->BoneInfluences.Count : pipelineData->Vertices.Count);
        for (int idx = 0; idx < num; ++idx)
        {
            mappings.Add(new DataMapping
            {
                UsageType = UsageType.BlendWeight,
                UsageIndex = idx,
                SrcData = pipelineData->BoneInfluences.Items[idx].I.Items,
                SrcDeltaToNextElement = 8,
                Offset = 0
            });
        }
        if (num <= 1)
        {
            return;
        }
        for (int idx = 0; idx < num; ++idx)
        {
            mappings.Add(new DataMapping
            {
                UsageType = UsageType.BlendIndex,
                UsageIndex = idx,
                SrcData = &pipelineData->BoneInfluences.Items[idx].I.Items->Bone,
                SrcDeltaToNextElement = 8,
                Offset = 0
            });
        }
    }

    private static unsafe int DetermineVertexDataLayout(System.Collections.Generic.List<DataMapping> mappings, Tracker state)
    {
        int result = 0;
        foreach (DataMapping mapping in mappings)
        {
            mapping.Offset = result;
            switch (mapping.UsageType)
            {
                // TODO: get vertex data length and set offset
                case UsageType.Vertex:
                    break;
            }
        }
        return result;
    }

    private static unsafe void ComputeBoneMappingTable(W3DMeshPipelineVertexData* pipelineData, ShortList boneMappingTable, ShortList inverseBoneMappingTable)
    {
        // TODO:
    }

    private static unsafe void BuildVertexDeclaration_Windows(System.Collections.Generic.List<DataMapping> mappings, List<byte>* declaration, Tracker state)
    {

    }

    private static unsafe void BuildVertexDeclaration_Xenon(System.Collections.Generic.List<DataMapping> mappings, List<byte>* declaration, Tracker state)
    {
        throw new NotImplementedException();
    }

    public unsafe void BuildVertexData(W3DMeshPipelineVertexData* pipelineData, W3DMeshVertexData* outputData, Tracker state)
    {
        System.Collections.Generic.List<DataMapping> mappings = new System.Collections.Generic.List<DataMapping>();
        DetermineVertexDataContents(pipelineData, mappings);
        ConverterData converterData = new ConverterData
        {
            Tracker = state
        };
        int vertexDataSize = DetermineVertexDataLayout(mappings, state);
        ShortList boneMap = new ShortList();
        ShortList inverseBoneMap = new ShortList();
        ComputeBoneMappingTable(pipelineData, boneMap, inverseBoneMap);
        int numVertices = (int)pipelineData->Vertices.Items->V.Count;
        int numVerticesOut = numVertices;
        uint binaryVertexDataSize = (uint)(numVertices * vertexDataSize);
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform((uint*)&numVerticesOut);
            state.InplaceEndianToPlatform((uint*)&vertexDataSize);
        }
        outputData->NumVertices = numVerticesOut;
        outputData->VertexElementData.Count = (uint)vertexDataSize;
        using (Tracker.Context context = state.Push((void**)&outputData->VertexElementData.Items, 1u, binaryVertexDataSize))
        {
            foreach (DataMapping mapping in mappings)
            {
                switch (mapping.UsageType)
                {
                    case UsageType.Vertex:
                        Vector3ToHalf4(numVertices, (sbyte*)mapping.SrcData, mapping.SrcDeltaToNextElement, (sbyte*)outputData->VertexElementData.Items + mapping.Offset, 8, converterData);
                        break;
                }
            }
        }
        if (state.IsBigEndian)
        {
            BuildVertexDeclaration_Xenon(mappings, &outputData->VertexDeclaration, state);
        }
        else
        {
            BuildVertexDeclaration_Windows(mappings, &outputData->VertexDeclaration, state);
        }
        uint boneMapCount = (uint)boneMap.Count;
        if (state.IsBigEndian)
        {
            state.InplaceEndianToPlatform(&boneMapCount);
        }
        outputData->Bones.Count = boneMapCount;
        using (Tracker.Context context = state.Push((void**)&outputData->Bones.Items, 2u, (uint)boneMap.Count))
        {
            ushort* boneData = outputData->Bones.Items;
            foreach (ushort bone in boneMap)
            {
                if (state.IsBigEndian)
                {
                    state.InplaceEndianToPlatform(&bone);
                }
                *boneData++ = bone;
            }
        }
    }

    public unsafe void Dispose()
    {
        Marshal.FreeHGlobal((IntPtr)_defaultColor);
    }
}
