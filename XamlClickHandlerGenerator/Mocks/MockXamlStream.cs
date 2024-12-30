using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamlClickHandlerGenerator.Interfaces;

namespace XamlClickHandlerGenerator.Mocks
{
    public class MockXamlStream : IXamlStream
    {
        public StreamReader Reader { get; set; }

        public MockXamlStream()
        {

        }

        public void Dispose()
        {
            
        }

        public void OpenStream(Stream stream)
        {
            
        }

        public async Task<string?> ReadLineAsync()
        {
            return string.Empty; 
        }
    }
}
