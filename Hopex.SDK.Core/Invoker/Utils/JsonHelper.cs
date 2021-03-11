using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Hopex.SDK.Invoker.Utils
{
    public abstract class JsonHelper
    {
        public static HttpContent CreateJsonContent<T>(T content)
        {
            if (content == null) return null;

            var ms = SerializeJsonIntoStream(content);

            var streamContent = new StreamContent(ms);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return streamContent;
        }

        public static MemoryStream SerializeJsonIntoStream<T>(T value)
        {
            var stream = new MemoryStream();

            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
            {
                var js = JsonSerializer.CreateDefault();
                js.Serialize(jtw, value, typeof(T));
                jtw.Flush();
            }

            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }
    }
}
