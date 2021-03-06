﻿using System;
using System.IO;
using System.Xml.Serialization;
using X.Web.Sitemap.Constants;

namespace X.Web.Sitemap
{
    internal class SerializedXmlSaver<T> : ISerializedXmlSaver<T>
    {
        private readonly IFileSystemWrapper _fileSystemWrapper;

        public SerializedXmlSaver(IFileSystemWrapper fileSystemWrapper)
        {
            _fileSystemWrapper = fileSystemWrapper;
        }

        public FileInfo SerializeAndSave(T objectToSerialize, DirectoryInfo targetDirectory, string targetFileName)
        {
            ValidateArgumentNotNull(objectToSerialize);

            var xmlSerializer = new XmlSerializer(typeof(T));
            var customNamespaces = new XmlSerializerNamespaces();
            customNamespaces.Add(Namespaces.RootNamespacePrefix, Namespaces.RootNamespace);
            customNamespaces.Add(Namespaces.ImageNamespacePrefix, Namespaces.ImageNamespace);

            using (var textWriter = new StringWriterUtf8())
            {
                xmlSerializer.Serialize(textWriter, objectToSerialize, customNamespaces);
                var xmlString = textWriter.ToString();
                var path = Path.Combine(targetDirectory.FullName, targetFileName);

                return _fileSystemWrapper.WriteFile(xmlString, path);
            }
        }

        private static void ValidateArgumentNotNull(T objectToSerialize)
        {
            if (objectToSerialize == null)
            {
                throw new ArgumentNullException(nameof(objectToSerialize));
            }
        }
    }
}