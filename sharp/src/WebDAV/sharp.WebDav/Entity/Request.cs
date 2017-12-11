using System;
using System.IO;

namespace sharp.WebDav.Entity
{
    internal class Request
    {
        public int PartnerId { get; set; }
        public int ClientId { get; set; }
        public int Type { get; set; }
        public byte[] Data { get; set; }

        public const string path = @"C:\Users\narek.yegoryan\Desktop\json1600.jpg";

        public static Request Generate()
        {
            var rd = new Random();
            return new Request
            {
                PartnerId = 1000,
                ClientId = 3587,
                Type = rd.Next(0, 10),
                Data = File.ReadAllBytes(path)
            };
        }
    }
}
