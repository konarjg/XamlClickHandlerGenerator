using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlClickHandlerGenerator
{
    public static class StringExtensions
    {
        public static MemoryStream ToStream(this string value)
        {
            var buffer = Encoding.UTF8.GetBytes(value);
            var stream = new MemoryStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Position = 0;

            return stream;
        }

        public static string FromStream(this Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
