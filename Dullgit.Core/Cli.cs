using Dullgit.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dullgit.Core
{
  public interface ICli
  {
    Task<bool> InitAsync(CancellationToken ct = default);
  }

  public class Cli : ICli
  {
    private readonly IRepo _repo;

    public Cli(IRepo repo)
    {
      _repo = repo;
    }

    public async Task<bool> InitAsync(CancellationToken ct = default)
    {
      bool ok = await _repo.InitAsync();

      if (ok)
      {
        Console.WriteLine($"Initalized dullgit repository in {_repo.FullPath}");
      }

      return ok;
    }
  }
}
