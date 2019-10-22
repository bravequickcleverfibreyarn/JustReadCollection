using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest.TestData
{
  static public class IList
  {

    readonly static public List<sbyte> sBytes = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToSByte)
      .ToList();
    readonly static public List<byte> bytes = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToByte)
      .ToList();
    readonly static public List<bool> bools = TestJustReadCollectionFactory.testCollection
      .Select(x => x % 2 == 0 ? true : false)
      .ToList();


    readonly static public List<short> shorts = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToInt16)
      .ToList();
    readonly static public List<ushort> uShorts = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToUInt16)
      .ToList();
    readonly static public List<char> chars = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToChar)
      .ToList();


    readonly static public List<int> ints = TestJustReadCollectionFactory.testCollection.ToList();
    readonly static public List<uint> uints = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToUInt32)
      .ToList();
    readonly static public List<float> floats = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToSingle)
      .ToList();


    readonly static public List<long> longs = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToInt64)
      .ToList();
    readonly static public List<ulong> uLongs = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToUInt64)
      .ToList();
    readonly static public List<double> doubles = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToDouble)
      .ToList();

    readonly static public List<decimal> decimals = TestJustReadCollectionFactory.testCollection
      .Select(Convert.ToDecimal)
      .ToList();
    readonly static public List<IntPtr> intPtrs = TestJustReadCollectionFactory.testCollection
      .Select(x => new IntPtr(x))
      .ToList();
    readonly static public List<UIntPtr> uIntPtrs = TestJustReadCollectionFactory.testCollection
      .Select(x => new UIntPtr(Convert.ToUInt32(x)))
      .ToList();
  }
}
