using System;
using System.Threading.Tasks;
using Dullgit.Core;
using Dullgit.Data;
using McMaster.Extensions.CommandLineUtils;

namespace Dullgit.App
{
  class Program
  {
    static async Task Main(string[] args)
    {
      ICli cli = new Cli(new FileRepo());
      var app = new CommandLineApplication
      {
        Name = "dullgit",
        Description = "A dull implementation of Git in C#"
      };
      app.HelpOption();

      app.OnExecute(() =>
      {
        Console.WriteLine("Specify a command");
        app.ShowHelp();
        return 1;
      });

      app.Command("init", config =>
      {
        config.Description = "Initialize a repository";
        config.OnExecuteAsync(async ct => await cli
          .InitAsync(ct)
          .ConfigureAwait(false) ? 0 : 1);
      });

      app.Command("hash", config =>
      {
        config.Description = "Compute a hash";
        CommandArgument path = config.Argument("path", "File to hash").IsRequired();
        config.OnExecuteAsync(async ct => await cli
          .Hash(path.Value)
          .ConfigureAwait(false) ? 0 : 1);
      });


      await app
        .ExecuteAsync(args)
        .ConfigureAwait(false);
    }
  }
}
