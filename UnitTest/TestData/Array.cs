using System;
using System.Linq;

namespace TestData
{
  static public class Array
  {

    readonly static public sbyte[] sBytes = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToSByte)
      .ToArray();
    readonly static public byte[] bytes = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToByte)
      .ToArray();
    readonly static public bool[] bools = TestJustReadCollectionFactory.testCollection
      .Select(x => x % 2 == 0)
      .ToArray();


    readonly static public short[] shorts = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToInt16)
      .ToArray();
    readonly static public ushort[] uShorts = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToUInt16)
      .ToArray();
    readonly static public char[] chars = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToChar)
      .ToArray();


    readonly static public int[] ints = TestJustReadCollectionFactory.testCollection.ToArray();
    readonly static public uint[] uints = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToUInt32)
      .ToArray();
    readonly static public float[] floats = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToSingle)
      .ToArray();


    readonly static public long[] longs = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToInt64)
      .ToArray();
    readonly static public ulong[] uLongs = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToUInt64)
      .ToArray();
    readonly static public double[] doubles = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToDouble)
      .ToArray();


    readonly static public decimal[] decimals = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToDecimal)
      .ToArray();
    readonly static public IntPtr[] intPtrs = TestJustReadCollectionFactory.testCollection
      .Select(x => new IntPtr(x))
      .ToArray();
    readonly static public UIntPtr[] uIntPtrs = TestJustReadCollectionFactory.testCollection
      .Select(x => new UIntPtr(Convert.ToUInt32(x)))
      .ToArray();
  }
}
