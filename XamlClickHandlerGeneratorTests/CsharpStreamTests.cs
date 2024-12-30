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
            string test = string.Empty;

            var stream = new CsharpStream();
            stream.OpenStream(test.ToStream());

            Assert.IsNotNull(stream.Writer);
            stream.Writer.Dispose();
        }

        [TestMethod]
        public void DisposeShouldThrowObjectDisposedException()
        {
            string test = string.Empty;

            var stream = new CsharpStream();
            stream.Writer = new StreamWriter(test.ToStream());
            stream.Dispose();

            Assert.ThrowsException<ObjectDisposedException>(() => stream.Writer.Write(5));
        }

        [TestMethod]
        public async Task WriteLineAsyncShouldWriteHelloWorld()
        {
            string? test = string.Empty;

            var stream = new CsharpStream();
            stream.Writer = new StreamWriter(test.ToStream(), Encoding.UTF8, leaveOpen: true);

            await stream.WriteLineAsync("Hello World");
            stream.Writer.BaseStream.Position = 0;
            test = stream.Writer.BaseStream?.FromStream();
            stream.Writer.Dispose();

            Assert.IsTrue(test?.Contains("Hello World"));
        }
    }
}
