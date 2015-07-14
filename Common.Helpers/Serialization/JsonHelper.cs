namespace Common.Helpers.Serialization
{
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;

    public class JsonHelper
    {
        public static string Serialize<T>(T type)
        {
            using (var mstream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(T));

                serializer.WriteObject(mstream, type);

                mstream.Position = 0;

                using (var sreader = new StreamReader(mstream))
                {
                    return sreader.ReadToEnd();
                }
            }
        }

        public static T Deserialize<T>(string json)
        {
            using (var mstream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));

                mstream.Position = 0;

                return (T)serializer.ReadObject(mstream);
            }
        }
    }
}
