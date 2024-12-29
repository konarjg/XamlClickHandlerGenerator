using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlClickHandlerGeneratorTests
{
    [TestClass]
    public class XamlStreamTests
    {
        private string TestXaml = "<Button Click=\"Test1Click\"></Button>\n<Button Click=\"Test2Click\"></Button>";

        [TestMethod]
        public void OpenStreamStreamReaderShouldNotBeNull()
        {
            var stream = new XamlStream();
            stream.OpenStream(TestXaml.ToStream());

            Assert.IsNotNull(stream.Reader);
            stream.Reader.Dispose();
        }

        [TestMethod]
        public void DisposeStreamReaderShouldBeNull()
        {
            var stream = new XamlStream();
            stream.Reader = new StreamReader(TestXaml.ToStream());
            stream.Dispose();

            Assert.ThrowsException<ObjectDisposedException>(() => stream.Reader.Read());
        }

        [TestMethod]
        public async Task ReadLineAsyncCalledOnceShouldReturnFirstLineOfTestXaml()
        {
            var stream = new XamlStream();
            stream.Reader = new StreamReader(TestXaml.ToStream());

            string? result = await stream.ReadLineAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(TestXaml.Split('\n')[0], result);

            stream.Reader.Dispose();
        }

        [TestMethod]
        public async Task ReadLineAsyncCalledTwiceShouldReturnFirstLineAndThenSecondLineOfTestXaml()
        {
            var stream = new XamlStream();
            stream.Reader = new StreamReader(TestXaml.ToStream());

            string? result1 = await stream.ReadLineAsync();
            string? result2 = await stream.ReadLineAsync();

            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.AreEqual(TestXaml.Split('\n')[0], result1);
            Assert.AreEqual(TestXaml.Split('\n')[1], result2);

            stream.Reader.Dispose();
        }
    }
}
