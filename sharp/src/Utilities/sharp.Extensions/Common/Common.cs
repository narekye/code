using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace sharp.Extensions.Common
{
    public static class Common
    {
        public static string Decompress(this byte[] data)
        {
            using (var msi = new MemoryStream(data))
            using (var mso = new MemoryStream())
            {
                using (var zipStream = new DeflateStream(msi, CompressionMode.Decompress))
                {
                    zipStream.CopyTo(mso);
                }
                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        public static byte[] Compress(this string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var zipStream = new DeflateStream(mso, CompressionMode.Compress))
                {
                    msi.CopyTo(zipStream);
                }
                return mso.ToArray();
            }
        }

        public static string GenerateToken()
        {
            string guid = Guid.NewGuid().ToString();
            MD5 crypto = MD5.Create();
            byte[] guidBytes = Encoding.ASCII.GetBytes(guid);
            byte[] hash = crypto.ComputeHash(guidBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
