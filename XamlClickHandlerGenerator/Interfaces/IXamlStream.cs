using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XamlClickHandlerGenerator.Interfaces
{
    public interface IXamlStream : IDisposable
    {
        public StreamReader Reader { get; set; }

        public void OpenStream(Stream stream);
        public Task<string?> ReadLineAsync();
    }
}
