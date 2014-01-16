namespace Elis.PCF.Core.Extensions
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public static class Serialization
    {
        public static string XmlSerialize<T>(this T value, XmlWriterSettings settings = null) where T : class
        {
            if (value == null)
            {
                return string.Empty;
            }

            if (settings == null)
                settings = DefaultXmlWriterSettings;

            var serializer = new XmlSerializer(typeof(T));
            using (var textWriter = new CustomStringWriter(settings.Encoding))
            {
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    serializer.Serialize(xmlWriter, value);
                }
                var res = textWriter.ToString();
                return res;
            }
        }

        public static T XmlDeserialize<T>(this T obj, string xml, XmlReaderSettings settings = null)
        {
            return XmlDeserialize<T>(xml, settings);
        }

        public static T XmlDeserialize<T>(string xml, XmlReaderSettings settings = null)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            var serializer = new XmlSerializer(typeof(T));

            if (settings == null)
                settings = new XmlReaderSettings();

            using (var textReader = new StringReader(xml))
            {
                using (var xmlReader = XmlReader.Create(textReader, settings))
                {
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
        }

        private static XmlWriterSettings _defaultXmlWriterSettings;
        public static XmlWriterSettings DefaultXmlWriterSettings
        {
            get
            {
                return _defaultXmlWriterSettings ??
                       (_defaultXmlWriterSettings = new XmlWriterSettings
                       {
                           Encoding = Encoding.UTF8,
                           Indent = false,
                           OmitXmlDeclaration = false,
                           NamespaceHandling = NamespaceHandling.OmitDuplicates,
                           CheckCharacters = false
                       });
            }
        }

        public class CustomStringWriter : StringWriter
        {
            private Encoding _encoding;

            public CustomStringWriter(Encoding encoding)
            {
                this._encoding = encoding;
            }

            public override Encoding Encoding
            {
                get { return this._encoding; }
            }
        }
    }
}
