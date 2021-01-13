namespace Dullgit.Data
{
  public static class StringExtensions
  {
    /// <summary>
    /// Split the given string at the given index. Return the two resulting strings
    /// </summary>
    public static string[] Split(this string s, int index)
    {
      string first = s.Substring(0, index);
      string rest = s.Substring(index, s.Length - index);

      return new[] { first, rest };
    }
  }
}
