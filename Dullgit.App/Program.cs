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
      var cli = new Cli(new FileRepo());
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
        config.OnExecuteAsync(async ct => await cli.InitAsync(ct) ? 0 : 1);
      });

      await app.ExecuteAsync(args);
    }
  }
}
