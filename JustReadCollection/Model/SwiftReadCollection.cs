using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Software919.ReaOnlyCollection
{
  static public partial class IListExtensions
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    static public SwiftReadCollection<T> AsSwiftReadCollection<T>(this IList<T> iList) where T : unmanaged => new SwiftReadCollection<T>(iList);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
  }

  /// <summary>
  /// Extended read only collection for unmanged types.
  /// </summary>  
  /// <remarks>
  /// Provides performant way for new T[] operations.
  /// </remarks>
  sealed public class SwiftReadCollection<T> : JustReadCollection<T> where T : unmanaged
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public SwiftReadCollection(IList<T> iList) : base(iList) { }

    override protected void CopyFromItems(T[] items, T[] arr, int start, int count)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
#if DEBUG
      Debug.WriteLine("To T[], from T[] (unmanaged way).");
#endif

      int typeSize;
      unsafe
      {
        typeSize = sizeof(T);
      }

      Buffer.BlockCopy(items, start * typeSize, arr, 0, typeSize * count);

    }
  }
}
