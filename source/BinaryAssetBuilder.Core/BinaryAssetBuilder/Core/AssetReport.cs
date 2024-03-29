﻿using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using BinaryAssetBuilder.Core.Hashing;
using BinaryAssetBuilder.Core.SageXml;

namespace BinaryAssetBuilder.Core
{
    public static class AssetReport
    {
        public const string FileName = "AssetReport.xml";
        public const string TypeName = "AssetReportTable";

        private static XmlWriter _assetRecordWriter;
        private static SortedDictionary<string, bool> _recordedAssets;

        public static string FileNameFullyQualified;

        private static void RecordAsset(string id, string type, int size, List<InstanceHandle> references)
        {
            string key = MakeAssetReportId(type, id);
            if (_recordedAssets.ContainsKey(key))
            {
                return;
            }
            _recordedAssets.Add(key, true);
            _assetRecordWriter.WriteStartElement(nameof(AssetReport), SchemaSet.XmlNamespace);
            _assetRecordWriter.WriteAttributeString("Id", id.ToLowerInvariant());
            _assetRecordWriter.WriteAttributeString("Type", type);
            _assetRecordWriter.WriteAttributeString("AssetSize", size.ToString(CultureInfo.InvariantCulture));
            if (references is not null)
            {
                foreach (InstanceHandle reference in references)
                {
                    _assetRecordWriter.WriteStartElement("Reference");
                    _assetRecordWriter.WriteAttributeString("Id", reference.InstanceName.ToLowerInvariant());
                    _assetRecordWriter.WriteAttributeString("Type", reference.TypeName);
                    _assetRecordWriter.WriteEndElement();
                }
            }
            _assetRecordWriter.WriteEndElement();
        }

        private static void InitAssetRecordWriter()
        {
            if (!Directory.Exists(Settings.Current.SessionCacheDirectory))
            {
                Directory.CreateDirectory(Settings.Current.SessionCacheDirectory);
            }
            FileNameFullyQualified = Path.Combine(Settings.Current.SessionCacheDirectory, FileName);
            _recordedAssets = new SortedDictionary<string, bool>();
            _assetRecordWriter = XmlWriter.Create(new BufferedStream(new FileStream(FileNameFullyQualified, FileMode.Create, FileAccess.Write, FileShare.None)), new XmlWriterSettings
            {
                CloseOutput = true,
                Indent = true,
                IndentChars = "    "
            });
            _assetRecordWriter.WriteStartDocument();
            _assetRecordWriter.WriteStartElement("AssetDeclaration", SchemaSet.XmlNamespace);
            _assetRecordWriter.WriteStartElement(TypeName);
            _assetRecordWriter.WriteAttributeString("id", "TheAssetReportTable");
        }

        public static string MakeAssetReportId(string typeId, string instanceId)
        {
            return $"{typeId}.{instanceId}.assetreport".ToLowerInvariant();
        }

        public static void RecordAsset(InstanceDeclaration instance, BinaryAsset asset)
        {
            if (instance.Handle is null)
            {
                throw new BinaryAssetBuilderException(ErrorCode.InternalError, "Asset report failure");
            }
            if (instance.Handle.TypeName == TypeName || instance.Handle.TypeName == HashProvider.StringTableAssetName)
            {
                return;
            }
            if (_assetRecordWriter is null)
            {
                InitAssetRecordWriter();
            }
            RecordAsset(instance.Handle.InstanceName, instance.Handle.TypeName, asset.InstanceFileSize, instance.ValidatedReferencedInstances);
        }

        public static void Close()
        {
            if (_assetRecordWriter is null)
            {
                return;
            }
            _assetRecordWriter.WriteEndDocument();
            _assetRecordWriter.Flush();
            _assetRecordWriter.Close();
            _assetRecordWriter = null;
            FileNameFullyQualified = null;
            _recordedAssets = null;
        }

        public static void WriteAssetReportInclude(XmlWriter writer)
        {
            writer.WriteStartElement("Includes");
            writer.WriteStartElement("Include");
            writer.WriteAttributeString("type", "all");
            writer.WriteAttributeString("source", FileName);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
