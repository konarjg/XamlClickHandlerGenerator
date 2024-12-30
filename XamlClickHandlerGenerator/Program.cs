using XamlClickHandlerGenerator;

async void Generate()
{
    var inputPath = "input.xaml";
    var outputPath = "output.cs";

    if (!File.Exists(outputPath))
    {
        File.Create(outputPath).Close();
    }

    var inputStream = File.OpenRead(inputPath);
    var outputStream = File.OpenWrite(outputPath);

    var xamlStream = new XamlStream();
    xamlStream.OpenStream(inputStream);

    var csharpStream = new CsharpStream();
    csharpStream.OpenStream(outputStream);

    var generator = new ClickHandlerGenerator();
    generator.SetStreams(xamlStream, csharpStream);
    await generator.GenerateClickHandlersAsync();

    inputStream.Dispose();
    outputStream.Dispose();

    Console.WriteLine("Generation finished!");
}

Generate();

while (Console.ReadKey().Key != ConsoleKey.Escape)
{

}