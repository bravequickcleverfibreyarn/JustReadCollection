using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TestData;

namespace JustReadCollectionTest
{
  [TestClass]
  public class ListExtractTests
  {
    static int testRun = 1;

    [TestMethod]
    [DataRow(1, 3, TestJustReadCollectionFactory.ARRAY)]
    [DataRow(0, 3, TestJustReadCollectionFactory.ARRAY)] // min. index
    [DataRow(3, 4, TestJustReadCollectionFactory.ARRAY)] // max. count

    [DataRow(1, 3, TestJustReadCollectionFactory.LIST)]
    [DataRow(0, 3, TestJustReadCollectionFactory.LIST)] // min. index
    [DataRow(3, 4, TestJustReadCollectionFactory.LIST)] // max. count    
    [DataRow(0, 7, TestJustReadCollectionFactory.LIST)] // CopyTo

    [DataRow(1, 3, TestJustReadCollectionFactory.COLLECTION)]
    [DataRow(0, 3, TestJustReadCollectionFactory.COLLECTION)] // min. index
    [DataRow(3, 4, TestJustReadCollectionFactory.COLLECTION)] // max. count    
    [DataRow(0, 7, TestJustReadCollectionFactory.COLLECTION)] // CopyTo
    public void ListExtract_CorrectDemands_ComplyWithExpectations(int index, int count, string underlayingCollection)
    {
      if (testRun == 1)
      {
        Debug.WriteLine(nameof(ListExtract_CorrectDemands_ComplyWithExpectations));
      }
      Debug.WriteLine(testRun++);

      IList<int> testCollection = TestJustReadCollectionFactory.GetTestCollection(underlayingCollection);

      List<int> listExtract = TestJustReadCollectionFactory.TestData(testCollection).ListExtract(index, count);
      Assert.IsTrue(Enumerable.SequenceEqual(listExtract, testCollection.Skip(index).Take(count)));
    }

    [TestMethod]
    [DataRow(-1)]
    [DataRow(7)]
    public void ListExtract_ImpossibleIndex_Throws(int index)
    {
      ArgumentOutOfRangeException result = null;
      try
      {
        TestJustReadCollectionFactory.TestData(TestData.Array.ints).ListExtract(index, default);
      }
      catch (ArgumentOutOfRangeException aore)
      {
        result = aore;
      }

      Assert.IsNotNull(result);
      Assert.IsTrue(result.ParamName == "index");
      Assert.IsTrue(result.Message.StartsWith($"Value {index}.", StringComparison.Ordinal));
    }

    [TestMethod]
    [DataRow(1, 7)]
    [DataRow(2, 6)]
    [DataRow(3, 6)]
    [DataRow(3, 1000)]
    public void ListExtract_ImpossibleCount_Throws(int index, int count)
    {
      ArgumentException result = null;
      try
      {
        TestJustReadCollectionFactory.TestData(TestData.Array.ints).ListExtract(index, count);
      }
      catch (ArgumentException ae)
      {
        result = ae;
      }

      Assert.IsNotNull(result);
      Assert.IsTrue(result.Message == $"Specified index and count exceeded collection length! Index {index}, count {count}.");
    }
  }
}