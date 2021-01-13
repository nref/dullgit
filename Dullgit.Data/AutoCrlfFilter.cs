using Dullgit.Data.Filters;

namespace Dullgit.Data
{
  public class AutoCrlfFilter : IContentFilter
  {
    public string Run(string data) => data?.Replace("\r\n", "\n") ?? string.Empty;
  }
}
