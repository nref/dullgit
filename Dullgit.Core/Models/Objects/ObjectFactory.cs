namespace Dullgit.Core.Models.Objects
{
  public interface IObjectFactory
  {
    GitObject Create(ObjectType t, string content);
  }

  public class ObjectFactory : IObjectFactory
  {
    public GitObject Create(ObjectType t, string content) => t switch
    {
      ObjectType.Blob => new BlobObject(content),
      _ => default
    };
  }
}
