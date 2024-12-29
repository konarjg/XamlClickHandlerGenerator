using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlClickHandlerGenerator.Interfaces
{
    public interface ICsharpStream : IDisposable
    {
        public StreamWriter Writer { get; set; }

        public void OpenStream(Stream stream);
        public Task<bool> WriteLineAsync(string line);
    }
}
