using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XamlClickHandlerGenerator.Interfaces;

namespace XamlClickHandlerGenerator
{
    public class ClickHandlerGenerator : IClickHandlerGenerator
    {
        public IXamlStream InputStream { get; set; }
        public ICsharpStream OutputStream { get; set; }

        private Regex ClickRegex = new Regex(@"Click\s*=\s*""([^""]+)""");

        public ClickHandlerGenerator()
        {
            
        }

        public void SetStreams(IXamlStream inputStream, ICsharpStream outputStream)
        {
            InputStream = inputStream;
            OutputStream = outputStream;
        }

        public async Task<bool> GenerateClickHandlersAsync()
        {
            var generated = new List<string?>();

            try
            {
                string? line = string.Empty;

                while ((line = await InputStream.ReadLineAsync()) != null)
                {
                    if (!ClickRegex.IsMatch(line))
                    {
                        continue;
                    }

                    var name = ClickRegex.Match(line).Groups[1].Value;

                    if (generated.Contains(name))
                    {
                        continue;
                    }

                    string? outputLine = $"public void {name}(object sender, RoutedEventArgs e)\n{{\n\n}}\n";
                    await OutputStream.WriteLineAsync(outputLine);
                    generated.Add(name);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            InputStream.Dispose();
            OutputStream.Dispose();
        }
    }
}
