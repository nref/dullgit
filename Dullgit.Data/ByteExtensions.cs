using System;
using System.Security.Cryptography;

namespace Dullgit.Data
{
  public static class ByteExtensions
  {
    public static byte[] Hash(this byte[] data) => SHA1.Create().ComputeHash(data);
    public static string AsString(this byte[] data) => BitConverter
      .ToString(data)
      .Replace("-", string.Empty)
      .ToLower();
  }
}
