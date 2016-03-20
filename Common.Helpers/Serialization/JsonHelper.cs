namespace Common.Helpers.Serialization
{
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Web.Script.Serialization;

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
            var serializer = new JavaScriptSerializer();
            return (T)serializer.Deserialize<T>(json);
        }
    }
}
