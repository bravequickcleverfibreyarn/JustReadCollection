using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Software919.ReaOnlyCollection
{
  static public partial class CollectionExtensions
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    static public SwiftReadCollection<T> AsSwiftReadCollection<T>(this IList<T> iList) where T : unmanaged
    {
      return new SwiftReadCollection<T>(iList);
    }

    static public SwiftReadCollection<T> ToSwiftReadCollection<T>(this IEnumerable<T> iEnumerable) where T : unmanaged
    {
      return iEnumerable.ToIList().AsSwiftReadCollection();
    }
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

      unsafe
      {
        long byteSize = count * sizeof(T);

        fixed (T* fixedItems = items)        
        fixed (void* destination = arr)
        {
          void* source = &fixedItems[start];
          Buffer.MemoryCopy(source, destination, byteSize, byteSize);
        }
      }

    }
  }
}
