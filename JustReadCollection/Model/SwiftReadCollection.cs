using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Software919.ReaOnlyCollection
{
  static public partial class IListExtensions
  {
    static public SwiftReadCollection<T> AsSwiftReadCollection<T>(this IList<T> iList) where T : unmanaged => new SwiftReadCollection<T>(iList);
  }

  /// <summary>
  /// Extended read only collection for unmanged types.
  /// </summary>  
  sealed public class SwiftReadCollection<T> : JustReadCollection<T> where T : unmanaged
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
