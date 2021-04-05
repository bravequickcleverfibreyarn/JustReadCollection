using Software9119.ReadCollection;
using System;
using System.Collections.Generic;

namespace Concept.Model
{
  static public partial class IListExtensions
  {
    /// <summary>
    /// <see cref="LockReadCollection{T}"/> by default <see cref="LockReadCollection{T}.LockReadCollection(IList{T})"/> constructor.
    /// </summary>    
    static public LockReadCollection<T> AsLockReadCollection<T>(this IList<T> iList) => new LockReadCollection<T>(iList);

    /// <summary>
    /// <see cref="LockReadCollection{T}"/> by full <see cref="LockReadCollection{T}.LockReadCollection(bool, bool, IList{T})"/> constructor.
    /// </summary>
    static public LockReadCollection<T> AsLockReadCollection<T>(this IList<T> iList, bool autolock, bool initiallyLocked) => new LockReadCollection<T>(autolock, initiallyLocked, iList);
  }

  /// <summary>
  /// Lockable read only collection able to expose internal Items after unlocking.
  /// </summary>  
  public class LockReadCollection<T> : JustReadCollection<T>
  {

    /// <summary>
    /// Default constructor.
    /// </summary>    
    public LockReadCollection(IList<T> iList) : this(true, true, iList) { }

    /// <summary>
    /// Full constructor.
    /// </summary>
    /// <param name="autolock">If set, Items are de-exposed during returning reference.</param>
    /// <param name="initiallyLocked">Initial lock state.</param>    
    public LockReadCollection(bool autolock, bool initiallyLocked, IList<T> iList) : base(iList)
    {
      Autolock = autolock;
      Locked = initiallyLocked;
    }

    public bool Locked { get; private set; }

    public bool Autolock { get; private set; }


    public void Lock()
    {
      if (Locked)
      {
        return;
      }

      Locked = true;
    } 


    public void Unlock()
    {
      if (Locked)
      {
        Locked = false;
      }
    }

    public new IList<T> Items
    {
      get
      {
        if (Locked)
        {
          throw new InvalidOperationException("Items are locked for access!");
        }

        if (Autolock)
        {
          Locked = true;
        }

        return base.Items;
      }
    }
  }
}