using Dullgit.Data;
using FluentAssertions;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace Dullgit.Tests.Dullgit.Data.FileRepoFixtures
{
  [TestFixture]
  public class GetObjectMethod
  {
    public const string AsdfHash1 = "5e";
    public const string AsdfHash2 = "40c0877058c504203932e5136051cf3cd3519b";

    [Test]
    public async Task GetsObject()
    {
      string expected = "asdf";
      string path = $".dg/objects/{AsdfHash1}/{AsdfHash2}";

      // Arrange
      await FileExtensions.WriteFileAsync(path, expected);

      // Act
      string content = await new FileRepo().GetObjectAsync($"{AsdfHash1}{AsdfHash2}");

      // Assert
      content.Should().Be(expected);

      // Cleanup
      File.Delete(path);
    }
  }
}
