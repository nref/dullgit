using Dullgit.Core;
using Dullgit.Core.Models.Objects;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Dullgit.Tests.Dullgit.Core.CliFixtures
{
  [TestFixture]
  public class HashMethod
  {
    private const string _method = nameof(Cli.HashAsync);

    [Test]
    public async Task CallsRepoHash()
    {
      var mock = new Mock<IRepo>();
      var cli = new Cli(mock.Object);

      bool ok = await cli.HashAsync("asdf");
      mock.Verify(
        mock => mock.HashAsync(
          It.Is<string>(s => s == "asdf" ),
          It.IsAny<ObjectType>()), 
        Times.Once);
    }
  }
}