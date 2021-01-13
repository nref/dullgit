using Dullgit.Core;
using Dullgit.Data;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Dullgit.Tests.Dullgit.Core.CliFixtures
{
  [TestFixture]
  public class HashMethod
  {
    private const string _method = nameof(Cli.Hash);

    [Test]
    public async Task CallsRepoHash()
    {
      var mock = new Mock<IRepo>();
      var cli = new Cli(mock.Object);

      bool ok = await cli.Hash("asdf");
      mock.Verify(mock => mock.HashAsync(It.Is<string>(s => s == "asdf" )), Times.Once);
    }
  }
}