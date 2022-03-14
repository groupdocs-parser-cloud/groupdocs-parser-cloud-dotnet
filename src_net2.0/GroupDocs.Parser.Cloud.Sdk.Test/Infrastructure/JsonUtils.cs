using System.IO;
using Newtonsoft.Json;

namespace GroupDocs.Metadata.Cloud.Sdk.Test.Infrastructure
{
    internal static class JsonUtils
    {
        public static string GetErrorMessage(string json)
        {
            var stringReader = new StringReader(json);
            var jsonReader = new JsonTextReader(stringReader);
            while (jsonReader.Read())
            {
                if ((string)jsonReader.Value != "message")
                    continue;
                jsonReader.Read();
                return jsonReader.Value?.ToString();
            }

            return json;
        }
    }
}