using System;
using System.Collections.Generic;

namespace Concept.Model
{
  static public partial class IListExtensions
  {
    /// <summary>
    /// <see cref="LockSwiftReadCollection{T}"/> by default <see cref="LockSwiftReadCollection{T}.LockReadCollection(IList{T})"/> constructor.
    /// </summary>   
    static public LockSwiftReadCollection<T> AsLockSwiftReadCollection<T>(this IList<T> iList) where T : unmanaged => new LockSwiftReadCollection<T>(iList);

    /// <summary>
    /// <see cref="LockSwiftReadCollection{T}"/> by full <see cref="LockSwiftReadCollection{T}.LockReadCollection(bool, bool, IList{T})"/> constructor.
    /// </summary>
    static public LockSwiftReadCollection<T> AsLockSwiftReadCollection<T>(this IList<T> iList, bool autolock, bool initiallyLocked) where T : unmanaged
    {
      return new LockSwiftReadCollection<T>(autolock, initiallyLocked, iList);
    }
  }

  public class LockSwiftReadCollection<T> : LockReadCollection<T> where T : unmanaged
  {
    /// <summary>
    /// Default constructor.
    /// </summary>    
    public LockSwiftReadCollection(IList<T> iList) : this(true, true, iList) { }

    /// <summary>
    /// Full constructor.
    /// </summary>
    /// <param name="autolock">If set, Items are de-exposed during returning reference.</param>
    /// <param name="initiallyLocked">Initial lock state.</param>    
    public LockSwiftReadCollection(bool autolock, bool initiallyLocked, IList<T> iList) : base(autolock, initiallyLocked, iList) { }


    override protected void CopyToArrayFromArray(T[] items, T[] newArr, int index, int count)
    {
      int typeSize;
      unsafe
      {
        typeSize = sizeof(T);
      }

      Buffer.BlockCopy(items, index, newArr, 0, typeSize * count);

    }
  }
}
