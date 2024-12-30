using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamlClickHandlerGenerator.Interfaces;

namespace XamlClickHandlerGenerator
{
    public class CsharpStream : ICsharpStream
    {
        public StreamWriter Writer { get; set; }

        public CsharpStream()
        {
            
        }

        public void OpenStream(Stream stream)
        {
            Writer = new StreamWriter(stream);
        }

        public void Dispose()
        {
            Writer.Flush();
            Writer.Close();
            Writer.Dispose();
        }

        public async Task<bool> WriteLineAsync(string? line)
        {
            try
            {
                await Writer.WriteLineAsync(line);
                await Writer.FlushAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
