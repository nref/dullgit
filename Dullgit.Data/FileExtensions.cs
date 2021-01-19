using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Dullgit.Data
{
  public static class FileExtensions
  {
    /// <summary>
    /// Write the given contents to the given path. Create the path if it does not exist.
    /// </summary>
    public static async Task WriteFileAsync(string path, string content)
    {
      Directory.CreateDirectory(Path.GetDirectoryName(path));
      using var sw = new StreamWriter(path);
      await sw.WriteAsync(content).ConfigureAwait(false);
    }

    /// <summary>
    /// Read the contents from the file at the given path with the given Encoding.
    /// Then call the given Func.
    /// </summary>
    public static async Task<string> ReadFileAsync(this string path, Encoding encoding)
    {
      try
      {
        {
          using var reader = encoding == default
            ? new StreamReader(path)
            : new StreamReader(path, encoding);

          return await reader.ReadToEndAsync().ConfigureAwait(false);
        }
      }
      catch (Exception)
      {
        return default;
      }
    }
  }
}
