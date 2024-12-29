using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlClickHandlerGeneratorTests
{
    [TestClass]
    public class CsharpStreamTests
    {
        [TestMethod]
        public void OpenStreamStreamWriterShouldNotBeNull()
        {
            var stream = new CsharpStream();
            stream.OpenStream();

            Assert.IsNotNull(stream.Writer);
            stream.Writer.Dispose();
        }
    }
}
