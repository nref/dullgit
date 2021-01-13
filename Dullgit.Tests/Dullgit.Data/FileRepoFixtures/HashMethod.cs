using Dullgit.Data;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Dullgit.Tests.Dullgit.Data.FileRepoFixtures
{
  [TestFixture]
  public class HashMethod
  {
    /// <summary>
    /// From git hash-object of an empty file
    /// It always means "empty file"
    /// </summary>
    public const string EmptyFileHash = "e69de29bb2d1d6434b8b29ae775ad8c2e48c5391";

    /// <summary>
    /// From git hash-object of an empty directory.
    /// It always means "empty directory"
    /// </summary>
    public const string EmptyDirHash = "4b825dc642cb6eb9a060e54bf8d69288fbee4904 ";

    /// <summary>
    /// From git hash-object of a file containing "asdf"
    /// </summary>
    public const string AsdfHash = "5e40c0877058c504203932e5136051cf3cd3519b";

    /// <summary>
    /// From git hash-object of a file containing "\r\n" with autocrlf = false
    /// </summary>
    public const string CrlfHash = "d3f5a12faa99758192ecc4ed3fc22c9249232e86";

    /// <summary>
    /// From git hash-object of a file containing "asdf\r\n" with autocrlf = false
    /// </summary>
    public const string AsdfCrlfHash = "a98bf3503443ea6a69779fef1f6204fdae913124";

    /// <summary>
    /// From git hash-object of a file containing "asdf\n"
    /// </summary>
    public const string AsdfLfHash = "8bd6648ed130ac9ece0f89cd9a8fbbfd2608427a";

    [TestCase(EmptyFileHash, "")]
    [TestCase(AsdfHash, "asdf")]
    [TestCase(CrlfHash, "\r\n")]
    [TestCase(AsdfCrlfHash, "asdf\r\n")]
    [TestCase(AsdfLfHash, "asdf\n")]
    public async Task EqualsKnownHash(string expectedHash, string contents)
    {
      string path = $"testdata/HashMethod/EqualsKnownHash/{Guid.NewGuid()}.txt";

      await FileExtensions.WriteFileAsync(path, contents);
      string hash = await new FileRepo().HashAsync(path);
      File.Delete(path);

      hash.Should().Be(expectedHash);
    }
  }
}
