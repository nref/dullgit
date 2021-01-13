using Dullgit.Core;
using Dullgit.Data;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Dullgit.Tests.Dullgit.Core.CliFixtures
{
  [TestFixture]
  public class InitMethod
  {
    private const string _method = nameof(Cli.InitAsync);

    [Test]
    public async Task CallsRepoInit()
    {
      var mock = new Mock<IRepo>();
      var cli = new Cli(mock.Object);

      bool ok = await cli.InitAsync();

      mock.Verify(mock => mock.InitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task ReturnsTrue_WhenRepoReturnsTrue()
    {
      var mock = new Mock<IRepo>();
      mock.Setup(m => m.InitAsync(It.IsAny<CancellationToken>())).ReturnsAsync(false);
      var cli = new Cli(mock.Object);

      bool ok = await cli.InitAsync();
      ok.Should().BeFalse($"{nameof(IRepo.InitAsync)} returned false");
    }

    [Test]
    public async Task ReturnsFalse_WhenRepoReturnsFalse()
    {
      var mock = new Mock<IRepo>();
      mock.Setup(m => m.InitAsync(It.IsAny<CancellationToken>())).ReturnsAsync(true);
      var cli = new Cli(mock.Object);

      bool ok = await cli.InitAsync();
      ok.Should().BeTrue($"{nameof(IRepo.InitAsync)} returned true");
    }
  }
}