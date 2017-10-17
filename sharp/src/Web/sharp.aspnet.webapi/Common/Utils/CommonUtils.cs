using Microsoft.Owin;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace sharp.aspnet.webapi.Common.Utils
{
    public class CommonUtils
    {
        public static async Task<string> GetRequestBodyFromRequestStream(IOwinRequest request)
        {
            string requestData;
            using (StreamReader reader = new StreamReader(request.Body))
            {
                requestData = await reader.ReadToEndAsync();
            }
            request.Body = new MemoryStream(Encoding.UTF8.GetBytes(requestData));
            return requestData;
        }
    }
}