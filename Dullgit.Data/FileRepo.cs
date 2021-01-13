using Dullgit.Core;
using Dullgit.Core.Models.Objects;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dullgit.Data
{
  public class FileRepo : IRepo
  {
    public string Dir => ".dg";
    public string FullPath => Path.Combine(Directory.GetCurrentDirectory(), Dir);
    public Encoding Encoding { get; set; } = Encoding.UTF8;

    public bool Exists() => Directory.Exists(FullPath);

    public async Task<string> HashAsync(string path) 
      => await FileExtensions
        .ReadFileAsync(path, Encoding, data => Hash(Encoding.GetBytes(new BlobObject(data).Value)))
        .ConfigureAwait(false);

    private string Hash(byte[] data) => data.Hash().AsString();

    public async Task<bool> InitAsync(CancellationToken ct = default) 
      => await Task
        .Run(() => DirectoryExtensions.CreateSafely(FullPath), ct)
        .ConfigureAwait(false);
  }
}
