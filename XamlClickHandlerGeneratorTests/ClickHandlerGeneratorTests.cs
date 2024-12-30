using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamlClickHandlerGenerator.Mocks;

namespace XamlClickHandlerGeneratorTests
{
    [TestClass]
    public class ClickHandlerGeneratorTests
    {
        [TestMethod]
        public void SetStreamsInputAndOutputStreamsShouldNotBeNull()
        {
            var input = new MockXamlStream();
            var output = new MockCsharpStream();

            var generator = new ClickHandlerGenerator();
            generator.SetStreams(input, output);

            Assert.IsNotNull(generator.InputStream);
            Assert.IsNotNull(generator.OutputStream);
        }

        [TestMethod]
        public async Task GenerateClickHandlersAsyncWhenGenerationCompleteShouldReturnTrue()
        {
            string TestXaml = "<Button Click=\"Test1Click\"></Button>\n<Button Click=\"Test2Click\"></Button>";
            string test = "";
            var input = new XamlStream();
            var output = new CsharpStream();

            input.OpenStream(TestXaml.ToStream());
            output.OpenStream(test.ToStream());

            var generator = new ClickHandlerGenerator();
            generator.InputStream = input;
            generator.OutputStream = output;

            Assert.IsTrue(await generator.GenerateClickHandlersAsync());
        }
    }
}
