using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Dullgit.Data
{
  public interface IRepo
  {
    string Dir { get; }
    string FullPath { get; }

    bool Exists();
    Task<bool> InitAsync(CancellationToken ct = default);
  }

  public class FileRepo : IRepo
  {
    public string Dir => ".dg";
    public string FullPath => Path.Combine(Directory.GetCurrentDirectory(), Dir);

    public bool Exists() => Directory.Exists(FullPath);

    public async Task<bool> InitAsync(CancellationToken ct = default) 
      => await Task.Run(() => CreateDirectorySafely(FullPath), ct);

    private static bool CreateDirectorySafely(string path)
    {
      if (Directory.Exists(path))
      {
        Console.WriteLine($"{path} already exists");
        return false;
      }

      try
      {
        Directory.CreateDirectory(path);
        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return false;
      }
    }
  }
}
