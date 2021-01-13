using System;
using System.IO;

namespace Dullgit.Data
{
  public static class DirectoryExtensions
  {
    public static void ForceDelete(string path)
    {
      try
      {
        Directory.Delete(path, true);
      }
      catch (DirectoryNotFoundException)
      {
      }
    }

    public static bool CreateSafely(string path)
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
