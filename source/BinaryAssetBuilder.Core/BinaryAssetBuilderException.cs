﻿using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using BinaryAssetBuilder.Core.Diagnostics;

public class BinaryAssetBuilderException : ApplicationException
{
    public ErrorCode ErrorCode { get; }

    public BinaryAssetBuilderException(ErrorCode errorCode, string message, params object[] args) : base(string.Format(CultureInfo.InvariantCulture, message, args))
    {
        ErrorCode = errorCode;
    }

    public BinaryAssetBuilderException(Exception innerException, ErrorCode errorCode, string message, params object[] args) : base(string.Format(CultureInfo.InvariantCulture, message, args), innerException)
    {
        ErrorCode = errorCode;
    }

    public BinaryAssetBuilderException(Exception innerException, ErrorCode errorCode) : base(errorCode.ToString(), innerException)
    {
        ErrorCode = errorCode;
    }

    public void Trace(Tracer tracer)
    {
        if (tracer is null)
        {
            tracer = Tracer.GetTracer("Default Tracer", string.Empty);
        }
        if (InnerException != null)
        {
            if (InnerException is XmlSchemaValidationException xsvException)
            {
                tracer.TraceException($"{Message}:\n   XML validation error encountered in {xsvException.SourceUri} (line {xsvException.LineNumber}, position {xsvException.LinePosition}):\n      {xsvException.Message}");
            }
            else if (InnerException is XmlException xmlException)
            {
                tracer.TraceException($"{Message}:\n   XML formatting error encountered in {xmlException.SourceUri} (line {xmlException.LineNumber}, position {xmlException.LinePosition}):\n      {xmlException.Message}");
            }
            else if (InnerException is XmlSchemaException xsException)
            {
                string name = "<Name not Available>";
                if (xsException.SourceSchemaObject != null)
                {
                    if (xsException.SourceSchemaObject is XmlSchemaAttribute xmlSchemaAttribute)
                    {
                        name = xmlSchemaAttribute.Name;
                    }
                    else if (xsException.SourceSchemaObject is XmlSchemaElement xmlSchemaElement)
                    {
                        name = xmlSchemaElement.Name;
                    }
                }
                tracer.TraceException($"{Message}:\n   Schema error encountered in {xsException.SourceUri} (object: {name}, line {xsException.LineNumber}, position {xsException.LinePosition}):\n      {xsException.Message}");
            }
            else
            {
                tracer.TraceException($"{Message}:\n   {InnerException.Message}");
            }
        }
        else
        {
            tracer.TraceException(Message);
        }
    }
}
