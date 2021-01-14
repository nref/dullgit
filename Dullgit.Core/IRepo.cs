using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dullgit.Core
{
  public interface IRepo
  {
    string Dir { get; }
    string FullPath { get; }
    Encoding Encoding { get; set; }

    Task<string> GetObjectAsync(string oid);
    Task<string> HashAsync(string path);
    bool Exists();
    Task<bool> InitAsync(CancellationToken ct = default);
  }
}
