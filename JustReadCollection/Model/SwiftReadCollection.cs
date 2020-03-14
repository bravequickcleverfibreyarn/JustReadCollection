using Software9119.Aid.Collection;
using Software9119.ReadCollection.Auxiliary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Software9119.ReadCollection
{
  static public partial class CollectionExtensions
  {

#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
    /// <param name="emptyForNull">Choses null or empty collection for null source.</param>
    static public SwiftReadCollection<T> ToSwiftReadCollection<T>(this IEnumerable<T> iEnumerable, bool emptyForNull = default) where T : unmanaged
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
    {
      return CollectionExtensionsAux.ReturnNull(iEnumerable, emptyForNull) ? null : new SwiftReadCollection<T>(iEnumerable.ToIList(emptyForNull));
    }

  }

  /// <summary>
  /// Extended read only collection for unmanged types.
  /// </summary>  
  /// <remarks>
  /// Provides performant way for T[] operations (if <see cref="ReadOnlyCollection{T}" />.Items is T[]).
  /// </remarks>
  sealed public class SwiftReadCollection<T> : JustReadCollection<T> where T : unmanaged
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public SwiftReadCollection(IList<T> iList) : base(iList) { }

    override private protected void CopyFromItems(T[] items, T[] arr, int start, int count)
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
