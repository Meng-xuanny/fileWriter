


using System.IO;

var filePath = "file.txt";

using var writer = new FileWriter(filePath);
writer.Write("hello world");
writer.Write("hey now old cow");

using var reader = new LineReader(filePath);
var first=reader.Read(1);
var second=reader.Read(2);

Console.WriteLine(first);
Console.WriteLine(second);

public class FileWriter : IDisposable
{
    private readonly StreamWriter _streamWriter;

    public FileWriter(string filePath)
    {
        _streamWriter = new StreamWriter(filePath, true);
    }

    public void Write(string text)
    {
        _streamWriter.WriteLine(text);
        _streamWriter.Flush();
    }
    public void Dispose()
    {
        _streamWriter.Dispose();
    }
}

public class LineReader : IDisposable
{
    private readonly StreamReader _streamReader;

    public LineReader(string filePath)
    {
        _streamReader = new StreamReader(filePath);
    }

    public string Read(int lineNumber)
    {
        _streamReader.DiscardBufferedData();
        _streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

        for(var i=0;i<lineNumber -1;++i)
        {
            _streamReader.ReadLine();
        }
        return _streamReader.ReadLine();
    }

    public void Dispose()
    {
        _streamReader.Dispose();
    }

}