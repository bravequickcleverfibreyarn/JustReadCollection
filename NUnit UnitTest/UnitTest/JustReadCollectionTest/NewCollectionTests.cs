using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnitTest.TestData;

namespace UnitTest.UnitTest.JustReadCollectionTest
{
  [TestFixture]
  public class NewCollectionTests
  {

    static int testRun1 = 1;
    [Test]
    [TestCase(TestJustReadCollectionFactory.ARRAY)]
    [TestCase(TestJustReadCollectionFactory.LIST)]
    public void ToArray_NormalState_CollectionReturned(string underlayingCollection)
    {
      if (testRun1 == 1)
      {
        Debug.WriteLine(nameof(ToArray_NormalState_CollectionReturned));
      }
      Debug.WriteLine(testRun1++);

      IList<int> testCollection = underlayingCollection == TestJustReadCollectionFactory.ARRAY ? Array.ints : (IList<int>)IList.ints;

      int[] testArray = TestJustReadCollectionFactory.TestData(testCollection).Array();
      Assert.IsTrue(Enumerable.SequenceEqual(testCollection, testArray));
    }

    static int testRun2 = 1;
    [Test]
    [TestCase(TestJustReadCollectionFactory.ARRAY)]
    [TestCase(TestJustReadCollectionFactory.LIST)]
    public void ToList_NormalState_CollectionReturned(string underlayingCollection)
    {
      if (testRun2 == 1)
      {
        Debug.WriteLine(nameof(ToList_NormalState_CollectionReturned));
      }

      Debug.WriteLine(testRun2++);

      IList<int> testCollection = underlayingCollection == TestJustReadCollectionFactory.ARRAY ? Array.ints : (IList<int>)IList.ints;

      List<int> testList = TestJustReadCollectionFactory.TestData(testCollection).List();
      Assert.IsTrue(Enumerable.SequenceEqual(testCollection, testList));
    }    
  }
}
