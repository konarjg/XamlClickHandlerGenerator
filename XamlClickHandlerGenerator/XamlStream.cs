using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamlClickHandlerGenerator.Interfaces;

namespace XamlClickHandlerGenerator
{
    public class XamlStream : IXamlStream
    {
        public StreamReader Reader { get; set; }

        public XamlStream()
        {
            
        }

        public void OpenStream(Stream stream)
        {
            Reader = new StreamReader(stream);
        }

        public void Dispose()
        {
            Reader.DiscardBufferedData();
            Reader.Close();
            Reader.Dispose();
        }

        public Task<string?> ReadLineAsync()
        {
            return Reader.ReadLineAsync();
        }
    }
}
