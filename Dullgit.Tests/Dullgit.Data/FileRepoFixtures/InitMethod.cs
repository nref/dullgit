using Dullgit.Data;
using FluentAssertions;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace Dullgit.Tests.Dullgit.Data.FileRepoFixtures
{
  [TestFixture]
  public class InitMethod
  {
    private string _path => _repo.FullPath;
    private const string _method = nameof(FileRepo.InitAsync);
    private FileRepo _repo;

    [SetUp]
    public void Setup()
    {
      _repo = new FileRepo();
      DirectoryExtensions.ForceDelete(_path);
      RepoAssertions.DoesNotExist(_path, _method);
    }

    [Test]
    public async Task CreatesDirectory_WhenNoRepoExists()
    {
      RepoAssertions.DoesNotExist(_path, _method);
      bool ok = await _repo.InitAsync();
      ok.Should().BeTrue($"{_method} should return true after the repo was created");

      RepoAssertions.Exists(_path, _method);
    }

    [Test]
    public async Task ReturnsTrue_WhenRepoCreated()
    {
      RepoAssertions.DoesNotExist(_path, _method);
      bool ok = await _repo.InitAsync();
      ok.Should().BeTrue($"{_method} should return true after the repo was created");

      RepoAssertions.Exists(_path, _method);
    }

    [Test]
    public async Task ReturnsFalse_WhenRepoExists()
    {
      Directory.CreateDirectory(_path);
      bool ok = await _repo.InitAsync();
      ok.Should().BeFalse($"{_method} should return false if the repo already exists");
    }
  }
}
