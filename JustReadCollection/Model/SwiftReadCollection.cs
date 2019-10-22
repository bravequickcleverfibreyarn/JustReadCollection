using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Software919.ReaOnlyCollection
{
  static public partial class IListExtensions
  {

#pragma warning disable IDE0022 // Use block body for methods
    static public SwiftReadCollection<T> AsSwiftReadCollection<T>(this IList<T> iList) where T : unmanaged
    {
      return new SwiftReadCollection<T>(iList);
    }
#pragma warning restore IDE0022 // Use block body for methods
  }

  /// <summary>
  /// Extended read only collection for unmanged types.
  /// </summary>  
  public class SwiftReadCollection<T> : JustReadCollection<T> where T : unmanaged
  {
    public SwiftReadCollection(IList<T> iList) : base(iList) { }

    override protected void CopyFromItems(T[] items, T[] arr, int index, int count)
    { 
#if DEBUG
      Debug.WriteLine("To T[], from T[] (unmanaged way).");
#endif

      int typeSize;
      unsafe
      {
        typeSize = sizeof(T);
      }

      Buffer.BlockCopy(items, index * typeSize, arr, 0, typeSize * count);

    }
  }
}
