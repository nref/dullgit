using Dullgit.Core;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Dullgit.Tests.Dullgit.Core.CliFixtures
{
  [TestFixture]
  public class CatMethod
  {
    private const string _method = nameof(Cli.CatAsync);

    [Test]
    public async Task CallsRepoGetObject()
    {
      var mock = new Mock<IRepo>();
      var cli = new Cli(mock.Object);

      const string hash = "8bd6648ed130ac9ece0f89cd9a8fbbfd2608427a";

      bool ok = await cli.CatAsync(hash);
      mock.Verify(mock => mock.GetObjectAsync(It.Is<string>(s => s == hash)), Times.Once);
    }
  }
}