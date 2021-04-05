using Software9119.Aid.Collection;
using Software9119.ReadCollection.Auxiliary;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Software9119.ReadCollection
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
  static public partial class CollectionExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
  {

#pragma warning disable CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
    /// <param name="emptyForNull">Choses null or empty collection for null source.</param>
    static public JustReadCollection<T> ToJustReadCollection<T>(this IEnumerable<T> iEnumerable, bool emptyForNull = default)
#pragma warning restore CS1573 // Parameter has no matching param tag in the XML comment (but other parameters do)
    {
      return CollectionExtensionsAux.ReturnNull(iEnumerable, emptyForNull) ? null : new JustReadCollection<T>(iEnumerable.ToIList(emptyForNull));
    }

  }

  /// <summary>
  /// Extended read only collection.
  /// </summary>  
  public class JustReadCollection<T> : ReadOnlyCollection<T>
  {

#if DEBUG
    const string
      toArrayfromArray = "To T[], from T[].",
      toArrayfromNonArray = "To T[], from non-array Items.";
#endif

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    protected bool ItemsIsList => Items is List<T>;

    public JustReadCollection(IList<T> iList) : base(iList) { }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    #region Extract

    /// <summary>
    /// Collection slice in new T[].
    /// </summary>    
    public T[] ArrayExtract(int start, int count)
    {
      Validate(start, count);

      if (ItemsIsList)
      {
        var extract = new T[count];
        ((List<T>)Items).CopyTo(start, extract, 0, count);

        return extract;
      }

      return CopyFromItems(start, count);
    }

    /// <summary>
    /// Collection slice in new List{T}.
    /// </summary>    
    public List<T> ListExtract(int start, int count)
    {
      Validate(start, count);

      return ItemsIsList
        ? ((List<T>)Items).GetRange(start, count)
        : new List<T>(CopyFromItems(start, count));
    }

    void Validate(int index, int count)
    {
      if (index < 0 || index > Items.Count - 1)
      {
        throw new ArgumentOutOfRangeException(nameof(index), $"Value {index}.");
      }

      if (index + count > Items.Count)
      {
        throw new ArgumentException($"Specified index and count exceeded collection length! Index {index}, count {count}.");
      }
    }

    #endregion

    #region New

    /// <summary>
    /// Collection in new T[].
    /// </summary>        
    public T[] Array()
    {
      return ItemsIsList
        ? ((List<T>)Items).ToArray()
        : CopyFromItems(0, Items.Count);
    }

    /// <summary>
    /// Collection in new List{T}.
    /// </summary>
    public List<T> List() => new(Items);

    #endregion

    /// <summary>
    /// Invokes action for each item in collection.
    /// </summary>
    public void PerEvery(Action<T> action)
    {
      if (action is null)
      {
        throw new ArgumentNullException(nameof(action));
      }

      for (int i = 0; i < Items.Count; ++i)
      {
        action(Items[i]);
      }
    }

    /// <summary>
    /// Copies to T[].
    /// </summary>    
    T[] CopyFromItems(int start, int count)
    {
      var newArr = new T[count];

#if DEBUG
      Debug.Write("Choice: ");
#endif

      if (Items is T[] items)
      {
#if DEBUG

        Debug.WriteLine(toArrayfromArray);
#endif
        CopyFromItems(items, newArr, start, count);
      }
      else
      {
#if DEBUG
        Debug.WriteLine(toArrayfromNonArray);
#endif
        CopyFromItems(newArr, start, count);
      }

      return newArr;
    }

    #region protected

    /// <summary>
    /// Copies to T[] from T[] items.
    /// </summary> 
    virtual private protected void CopyFromItems(T[] items, T[] arr, int start, int count)
    {

#if DEBUG
      Debug.WriteLine(toArrayfromArray);
#endif

      System.Array.Copy(items, start, arr, 0, count);
    }

    /// <summary>
    /// Copies to T[] from non-array Items.
    /// </summary>    
    virtual private protected void CopyFromItems(T[] arr, int start, int count)
    {
#if DEBUG
      Debug.WriteLine(toArrayfromNonArray);
#endif
      if (count == Items.Count)
      {
#if DEBUG
        Debug.WriteLine("   .CopyTo");
#endif
        Items.CopyTo(arr, 0);
      }
      else
      {

#if DEBUG
        Debug.Write("   Iterating in mode");
#endif
        if (count % 3 == 0)
        {

#if DEBUG
        Debug.WriteLine(" 3.");
#endif
          for (int i = 0, j = 1, k = 2; k < count; i += 3, j += 3, k += 3)
          {
            arr[i] = Items[start++];
            arr[j] = Items[start++];
            arr[k] = Items[start++];
          }
        }
        else if (count % 2 == 0)
        {

#if DEBUG
        Debug.WriteLine(" 2.");
#endif
          for (int i = 0, j = 1; j < count; i += 2, j += 2)
          {
            arr[i] = Items[start++];
            arr[j] = Items[start++];
          }
        }
        else
        {
#if DEBUG
        Debug.WriteLine(" 1.");
#endif
          for (int i = 0; i < count; ++i)
          {
            arr[i] = Items[start++];
          }
        }
      }
    }

    #endregion
  }
}