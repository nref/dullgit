using System.IO;

namespace Dullgit.Tests.Dullgit.Data.FileRepoFixtures
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
  }
}
