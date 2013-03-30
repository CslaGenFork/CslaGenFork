using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
namespace CslaGenerator.Util
{
    public class ObjectCloner
    {
        public static Object CloneDeep(object obj)
        {
            using (var buffer = new MemoryStream())
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(buffer, obj);
                buffer.Position = 0;
                var temp = formatter.Deserialize(buffer);
                return temp;
            }
        }

        public static Object CloneShallow(object obj)
        {
            using (var buffer = new MemoryStream())
            {
                var xml = new XmlSerializer(obj.GetType());
                 
                xml.Serialize(buffer, obj);
                buffer.Position = 0;
                var temp = xml.Deserialize(buffer);
                return temp;
            }
        }
    }
}
