using System;

namespace Dullgit.Core.Models.Objects
{
  public class ParsedObject
  {
    public ObjectType Type { get; set; }
    public string Content { get; set; }
    public ParsedObject(string obj)
    {
      string[] split = obj.Split('\0');
      string[] split2 = split[0].Split(' ');
      Type = Enum.Parse<ObjectType>(split2[0], ignoreCase: true);
      Content = split[1];
    }
  }
}
