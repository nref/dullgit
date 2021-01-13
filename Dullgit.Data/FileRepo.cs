using Dullgit.Core;
using Dullgit.Core.Models.Objects;
using Dullgit.Data.Filters;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dullgit.Data
{
  public class FileRepo : IRepo
  {
    private readonly IContentFilter[] _filters;

    public string Dir => ".dg";
    public string FullPath => Path.Combine(Directory.GetCurrentDirectory(), Dir);
    public Encoding Encoding { get; set; } = Encoding.UTF8;

    public FileRepo(params IContentFilter[] filters)
    {
      _filters = filters;
    }

    public bool Exists() => Directory.Exists(FullPath);

    public async Task<string> HashAsync(string path) 
      => await FileExtensions
        .ReadFileAsync(path, Encoding, async data =>
        {
          string filtered = Filter(data);
          string blob = new BlobObject(filtered).Value;

          string hash = Hash(Encoding.GetBytes(blob));
          string[] split = hash.Split(2);

          await FileExtensions.WriteFileAsync($"{Dir}/objects/{split[0]}/{split[1]}", data);

          return hash;
        })
        .ConfigureAwait(false);

    private string Filter(string data)
    {
      foreach (IContentFilter filter in _filters)
      {
        data = filter.Run(data);
      }

      return data;
    }

    private string Hash(byte[] data) => data.Hash().AsString();

    public async Task<bool> InitAsync(CancellationToken ct = default) 
      => await Task
        .Run(() => DirectoryExtensions.CreateSafely(FullPath), ct)
        .ConfigureAwait(false);
  }
}
