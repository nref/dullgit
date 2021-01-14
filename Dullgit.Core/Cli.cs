using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dullgit.Core
{
  public interface ICli
  {
    Task<bool> CatAsync(string oid);
    Task<bool> HashAsync(string path);
    Task<bool> InitAsync(CancellationToken ct = default);
  }

  public class Cli : ICli
  {
    private readonly IRepo _repo;

    public Cli(IRepo repo)
    {
      _repo = repo;
    }

    public async Task<bool> CatAsync(string oid)
    {
      string content = await _repo.GetObjectAsync(oid);
      Log(content);

      return await Task.FromResult(content != default);
    }

    public async Task<bool> HashAsync(string path)
    {
      string oid = await _repo.HashAsync(path).ConfigureAwait(false);
      Log(oid);

      return await Task.FromResult(oid != default);
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
