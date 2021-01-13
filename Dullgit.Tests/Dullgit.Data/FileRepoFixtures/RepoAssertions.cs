using FluentAssertions;
using System.IO;

namespace Dullgit.Tests.Dullgit.Data.FileRepoFixtures
{
  public static class RepoAssertions
  {
    public static void DoesNotExist(string path, string method) => Directory.Exists(path)
    .Should()
    .BeFalse($"{path} shouldn't exist before the call to {method}");

    public static void Exists(string path, string method) => Directory.Exists(path)
      .Should()
      .BeTrue($"{path} should exist after the call to {method}");
  }
}
