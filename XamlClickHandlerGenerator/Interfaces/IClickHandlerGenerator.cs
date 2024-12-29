using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlClickHandlerGenerator.Interfaces
{
    public interface IClickHandlerGenerator
    {
        public IXamlStream InputStream { get; set; }
        public ICsharpStream OutputStream { get; set; }

        public Task<bool> GenerateClickHandlersAsync();
    }
}
