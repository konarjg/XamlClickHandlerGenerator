using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamlClickHandlerGenerator.Interfaces;

namespace XamlClickHandlerGenerator
{
    public class ClickHandlerGenerator : IClickHandlerGenerator
    {
        public IXamlStream InputStream { get; set; }
        public ICsharpStream OutputStream { get; set; }

        public ClickHandlerGenerator(IXamlStream inputStream, ICsharpStream outputStream)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GenerateClickHandlersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
