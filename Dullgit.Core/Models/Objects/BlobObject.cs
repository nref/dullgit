namespace Dullgit.Core.Models.Objects
{
  public class BlobObject : GitObject
  {
    private readonly string _content;
    private string Header => $"blob {_content.Length}\0";
    public override string Value => $"{Header}{_content}";

    /// <summary>
    /// Compute the header for the given string.
    /// </summary>
    public BlobObject(string content)
    {
      _content = content;
    }
  }
}
