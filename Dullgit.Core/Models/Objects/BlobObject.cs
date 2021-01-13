namespace Dullgit.Core.Models.Objects
{
  public class BlobObject : GitObject
  {
    /// <summary>
    /// Compute the header for the given string. autocrlf replaces \r\n with \n.
    /// </summary>
    public BlobObject(string data, bool autocrlf = true)
    {
      string filtered = data == default
        ? string.Empty
        : data;

      if (autocrlf)
      {
        filtered = data.Replace("\r\n", "\n");
      }

      Value = $"blob {filtered.Length}\0{filtered}";
    }
  }
}
