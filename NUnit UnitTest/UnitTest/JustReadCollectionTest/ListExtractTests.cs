﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnitTest.TestData;

namespace UnitTest.UnitTest.JustReadCollectionTest
{
  [TestFixture]
  public class ListExtractTests
  {
    static int testRun = 1;

    [Test]
    [TestCase(1, 3, TestJustReadCollectionFactory.ARRAY)]
    [TestCase(0, 3, TestJustReadCollectionFactory.ARRAY)] // min. index
    [TestCase(3, 4, TestJustReadCollectionFactory.ARRAY)] // max. count

    [TestCase(1, 3, TestJustReadCollectionFactory.LIST)]
    [TestCase(0, 3, TestJustReadCollectionFactory.LIST)] // min. index
    [TestCase(3, 4, TestJustReadCollectionFactory.LIST)] // max. count    
    [TestCase(0, 7, TestJustReadCollectionFactory.LIST)] // CopyTo
    public void ListExtract_CorrectDemands_ComplyWithExpectations(int index, int count, string underlayingCollection)
    {
      if (testRun == 1)
      {
        Debug.WriteLine(nameof(ListExtract_CorrectDemands_ComplyWithExpectations));
      }
      Debug.WriteLine(testRun++);

      IList<int> testCollection = underlayingCollection == TestJustReadCollectionFactory.ARRAY ? TestData.Array.ints : (IList<int>)IList.ints;

      List<int> listExtract = TestJustReadCollectionFactory.TestData(testCollection).ListExtract(index, count);
      Assert.IsTrue(Enumerable.SequenceEqual(listExtract, testCollection.Skip(index).Take(count)));
    }

    [Test]
    [TestCase(-1)]
    [TestCase(7)]
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

    [Test]
    [TestCase(1, 7)]
    [TestCase(2, 6)]
    [TestCase(3, 6)]
    [TestCase(3, 1000)]
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