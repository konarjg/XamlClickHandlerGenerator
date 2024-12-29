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
            throw new NotImplementedException();
        }

        public Task<bool> WriteLineAsync(string line)
        {
            throw new NotImplementedException();
        }
    }
}
