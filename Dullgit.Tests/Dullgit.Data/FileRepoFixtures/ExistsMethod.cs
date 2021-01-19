using Dullgit.Core.Models.Objects;
using Dullgit.Data;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Dullgit.Tests.Dullgit.Data.FileRepoFixtures
{
  [TestFixture]
  public class ExistsMethod
  {
    private string _path => _repo.FullPath;
    private const string _method = nameof(FileRepo.Exists);
    private FileRepo _repo;

    [SetUp]
    public void Setup()
    {
      _repo = new FileRepo(new ObjectFactory());
      DirectoryExtensions.ForceDelete(_path);
    }

    private void ForceDelete(string path)
    {

    }

    [Test]
    public void ReturnsFalse_WhenDirectoryDoesNotExist()
    {
      RepoAssertions.DoesNotExist(_path, _method);
      _repo.Exists().Should().BeFalse();
    }

    [Test]
    public async Task ReturnsTrue_WhenDirectoryExists()
    {
      bool ok = await _repo.InitAsync();
      ok.Should().BeTrue();
      _repo.Exists().Should().BeTrue();
    }
  }
}
