using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dullgit.Core
{
  public interface ICli
  {
    Task<bool> Hash(string path);
    Task<bool> InitAsync(CancellationToken ct = default);
  }

  public class Cli : ICli
  {
    private readonly IRepo _repo;

    public Cli(IRepo repo)
    {
      _repo = repo;
    }

    public async Task<bool> Hash(string path)
    {
      Log(await _repo.HashAsync(path).ConfigureAwait(false));
      return await Task.FromResult(true).ConfigureAwait(false);
    }

    public async Task<bool> InitAsync(CancellationToken ct = default)
    {
      bool ok = await _repo.InitAsync().ConfigureAwait(false);

      if (ok)
      {
        Log($"Initalized dullgit repository in {_repo.FullPath}");
      }

      return ok;
    }

    private void Log(string message) => Console.WriteLine(message);
  }
}
