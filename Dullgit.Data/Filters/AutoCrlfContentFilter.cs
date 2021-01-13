namespace Dullgit.Data.Filters
{
  /// <summary>
  /// Replaces \r\n with \n.
  /// </summary>
  public class AutoCrlfContentFilter : IContentFilter
  {
    public string Run(string data) => data?.Replace("\r\n", "\n") ?? string.Empty;
  }
}
