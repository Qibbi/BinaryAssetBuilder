﻿using BinaryAssetBuilder.Core.Xml;
using System;
using System.Xml;

namespace BinaryAssetBuilder.Core.SageXml
{
    public class Definition : ISerializable
    {
        public string Name;
        public string EvaluatedValue;
        public bool IsOverride;
        public string OriginalValue;
        public AssetDeclarationDocument Document;

        public void ReadXml(Node node)
        {
            string[] values = node.GetAttributeValue("d", null).GetText().Split(';');
            Name = values[0];
            EvaluatedValue = values[1];
            IsOverride = Convert.ToBoolean(values[3]);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("d", $"{Name};{EvaluatedValue};{IsOverride}");
        }

        public override string ToString()
        {
            return $"{Name} = {EvaluatedValue ?? OriginalValue}";
        }
    }
}
