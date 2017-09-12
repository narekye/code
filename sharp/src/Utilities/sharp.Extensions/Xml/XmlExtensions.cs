using System;
using System.IO;
using System.Xml.Serialization;

namespace sharp.Extensions.Xml
{
    public static class XmlExtensions
    {
        public static string XmlSerialize<T>(this T obj) where T : class, new()
        {
            if (obj == null) throw new ArgumentNullException($"The argument {nameof(obj)} cannot be null");

            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        public static T XmlDeserializeOrDefault<T>(this string xml) where T : class, new()
        {
            if (xml == null) throw new ArgumentNullException($"The argument {nameof(xml)} cannot be null");

            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(xml))
            {
                try
                {
                    return (T)serializer.Deserialize(reader);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
