using Independentsoft.Webdav;
using sharp.WebDav.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace sharp.WebDav
{
    class Program
    {
        static List<Image> Db = new List<Image>();

        // File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), request.Data);

        static string BaseUrl = @"http://betshopimages.betconstruct.int";

        static void Main()
        {
            var credentials = new NetworkCredential()
            {
                UserName = "lvmnt",
                Password = "Qwsha3_gD4"
            };


            WebdavSession session = new WebdavSession(credentials);



            Resource resource = new Resource(session);

            resource.Delete(BaseUrl + "/x1/");

            //using (Stream str = new FileStream("C:\\Users\\narek.yegoryan\\Desktop\\aa.txt", FileMode.Open, FileAccess.Read))
            //{
            //    resource.Upload(BaseUrl, str);
            //}


            var request = Request.Generate();

            // WebdavUploadFile("http://betshopimages.betconstruct.int:80", credentials, File.ReadAllBytes("C:\\json1600.jpg"));

            SaveToDb(request);

            // UploadFile("C:\\Users\\narek.yegoryan\\Desktop\\aa.txt", "http://betshopimages.betconstruct.int:80/1000/3587/", credentials);

            Console.Read();

        }

        private static void UploadProgress(object sender, ProgressEventArgs e)
        {
            Console.WriteLine(e.Progress);

            if (e.IsComplete)
            {
                Console.WriteLine("Upload completed");
            }
        }

        static List<string> GeneratePath(Request request)
        {
            var partnerId = $"/{request.PartnerId}/";
            var clientId = $"{request.ClientId}";
            return new List<string> { partnerId, clientId };
        }

        static void SaveToDb(Request request)
        {
            var image = new Image
            {
                ClientId = request.ClientId,
                Id = Db.Any() ? Db.LastOrDefault().Id + 1 : 1,
                MediaType = 1,
                PartnerId = request.PartnerId,
                State = State.Added,
                Type = (ImageType)request.Type,
                Size = 200
            };
            Db.Add(image);
        }

        public static void WebdavUploadFile(string url, ICredentials credentials, byte[] fileData)
        {
            var handler = new HttpClientHandler();
            handler.Credentials = credentials;
            handler.PreAuthenticate = true;
            url += "/";
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.ExpectContinue = false;

            var response = client.PutAsync(url, new ByteArrayContent(fileData)).Result;

            if ((int)response.StatusCode < 200 || (int)response.StatusCode >= 300) { }
        }

        static string GenerateFileName(Request request)
        {
            var record = Db.FirstOrDefault(x => x.ClientId == request.ClientId);
            var type = MediaType.Init().Where(x => record.MediaType == x.Id).Select(x => x.Extension).FirstOrDefault();
            var result = $"/{record.ClientId}_{(int)record.Type}_{record.Id}{type}";
            return result;
        }

        public static bool UploadFile(string localFile, string uploadUrl, ICredentials cr)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uploadUrl);

            try
            {
                req.Method = "POST";
                req.AllowWriteStreamBuffering = true;
                // req.UseDefaultCredentials = Program.WebService.UseDefaultCredentials;
                req.Credentials = cr;
                req.SendChunked = false;
                req.KeepAlive = false;

                Stream reqStream = req.GetRequestStream();
                FileStream rdr = new FileStream(localFile, FileMode.Open, FileAccess.Read);
                byte[] inData = new byte[4096];
                int bytesRead = rdr.Read(inData, 0, inData.Length);

                while (bytesRead > 0)
                {
                    reqStream.Write(inData, 0, bytesRead);
                    bytesRead = rdr.Read(inData, 0, inData.Length);
                }

                reqStream.Close();
                rdr.Close();

                System.Net.HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
                {
                    // MessageBox.Show("Couldn't upload file");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }


    }
}
