using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamlClickHandlerGenerator.Interfaces;

namespace XamlClickHandlerGenerator.Mocks
{
    public class MockCsharpStream : ICsharpStream
    {
        public StreamWriter Writer { get; set; }

        public MockCsharpStream()
        {

        }

        public void Dispose()
        {
            
        }

        public void OpenStream(Stream stream)
        {
            
        }

        public async Task<bool> WriteLineAsync(string? line)
        {
            return false;
        }
    }
}
