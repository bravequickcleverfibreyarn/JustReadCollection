﻿using NUnit.Framework;
using Software919.ReaOnlyCollection;
using System.Text;
using UnitTest.TestData;

namespace UnitTest.UnitTest.JustReadCollectionTest
{
  [TestFixture]
  public class PerEveryTests
  {

    [Test]
    public void PerEveryTest1()
    {
      int counter = 0;
      JustReadCollection<int> testCollection =  TestJustReadCollectionFactory.TestData(Array.ints);

      testCollection.PerEvery(elem => counter++);
      Assert.AreEqual(7, counter);
    }

    [Test]
    public void PerEveryTest2()
    {
      const string CAPITAL_A = "A";

      var stringBuilder1 = new StringBuilder();
      var stringBuilder2 = new StringBuilder();

      JustReadCollection<StringBuilder> testCollection = TestJustReadCollectionFactory.TestData(new[] { stringBuilder1, stringBuilder2 });

      testCollection.PerEvery(elem => elem.Append(CAPITAL_A));
      Assert.AreEqual(CAPITAL_A, stringBuilder1.ToString());
      Assert.AreEqual(CAPITAL_A, stringBuilder2.ToString());
    }
  }
}