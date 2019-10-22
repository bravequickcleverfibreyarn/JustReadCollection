using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Software919.ReaOnlyCollection
{
  static public partial class IListExtensions
  {
    static public JustReadCollection<T> AsJustReadCollection<T>(this IList<T> iList) => new JustReadCollection<T>(iList);
  }

  /// <summary>
  /// Extended read only collection.
  /// </summary>  
  public class JustReadCollection<T> : ReadOnlyCollection<T>
  {
    public JustReadCollection(IList<T> iList) : base(iList) { }

    #region Extract

    /// <summary>
    /// Collection slice in T[].
    /// </summary>    
    public T[] ArrayExtract(int index, int count)
    {
      Validate(index, count);

      T[] extract = new T[count];

      if (Items is T[] items)
      {
        CopyToArrayFromArray(items, extract, index, count);
      }
      else
      {
        CopyToArray(extract, index, count);
      }

      return extract;
    }

    /// <summary>
    /// Collection slice in <see cref="List{T}"/>.
    /// </summary>    
    public List<T> ListExtract(int index, int count)
    {
      Validate(index, count);

      return CopyFromItems(index, count);
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

    #region To new collection

    /// <summary>
    /// Collection in new T[].
    /// </summary>        
    public T[] Array()
    {
      var newArray = new T[Items.Count];
      if (Items is T[] items)
      {
        CopyToArrayFromArray(items, newArray, 0, items.Length);
      }
      else
      {
        CopyToArray(newArray, 0, Items.Count);
      }

      return newArray;
    }

    /// <summary>
    /// Collection in new <see cref="List{T}"/>.
    /// </summary>
    public List<T> List() => CopyFromItems(0, Items.Count);

    #endregion

    /// <summary>
    /// Invokes action for each item in collection.
    /// </summary>
    public void PerEvery(Action<T> action)
    {
      for (var i = 0; i < Items.Count; ++i)
      {
        action(Items[i]);
      }
    }

    #region protected

    /// <summary>
    /// Copies to T[] from T[] items.
    /// </summary> 
    virtual protected void CopyToArrayFromArray(T[] items, T[] arr, int index, int count)
    {
      
#if DEBUG
      Debug.WriteLine("To T[], from T[].");
#endif

      System.Array.Copy(items, index, arr, 0, count);
    }

    /// <summary>
    /// Copies to T[] from non-array Items.
    /// </summary>    
    virtual protected void CopyToArray(T[] arr, int start, int count)
    {
#if DEBUG
      Debug.WriteLine("To T[], from non-array Items.");
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
        Debug.WriteLine("   Iterating.");
#endif
        for (var i = 0; i < count; ++i)
        {
#pragma warning disable CA1062 // Validate arguments of public methods
          arr[i] = Items[start++];
#pragma warning restore CA1062 // Validate arguments of public methods
        }
      }
    }

    /// <summary>
    /// Copies to List<T>.
    /// </summary>    
    virtual protected List<T> CopyFromItems(int start, int count)
    {
      var auxArr = new T[count];

      if (Items is T[] items)
      {
#if DEBUG
        Debug.WriteLine("To List<T>, from T[].");
#endif
        CopyToArrayFromArray(items, auxArr, start, count);
      }
      else
      {
#if DEBUG
        Debug.WriteLine("To List<T>, from non-array Items.");
#endif
        CopyToArray(auxArr, start, count);
      }

      return new List<T>(auxArr);
    }

    #endregion
  }
}