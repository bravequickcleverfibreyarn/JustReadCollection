using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TestData;

namespace JustReadCollectionTest
{
  [TestClass]
  public class NewCollectionTests
  {

    static int testRun1 = 1;
    [TestMethod]
    [DataRow(TestJustReadCollectionFactory.ARRAY)]
    [DataRow(TestJustReadCollectionFactory.LIST)]
    [DataRow(TestJustReadCollectionFactory.COLLECTION)]
    public void Array_NormalState_CollectionReturned(string underlayingCollection)
    {
      if (testRun1 == 1)
      {
        Debug.WriteLine(nameof(Array_NormalState_CollectionReturned));
      }
      Debug.WriteLine(testRun1++);

      IList<int> testCollection = TestJustReadCollectionFactory.GetTestCollection(underlayingCollection);

      int[] testArray = TestJustReadCollectionFactory.TestData(testCollection).Array();
      Assert.IsTrue(Enumerable.SequenceEqual(testCollection, testArray));
    }

    static int testRun2 = 1;
    [TestMethod]
    [DataRow(TestJustReadCollectionFactory.ARRAY)]
    [DataRow(TestJustReadCollectionFactory.LIST)]
    [DataRow(TestJustReadCollectionFactory.COLLECTION)]
    public void List_NormalState_CollectionReturned(string underlayingCollection)
    {
      if (testRun2 == 1)
      {
        Debug.WriteLine(nameof(List_NormalState_CollectionReturned));
      }

      Debug.WriteLine(testRun2++);

      IList<int> testCollection = TestJustReadCollectionFactory.GetTestCollection(underlayingCollection);

      List<int> testList = TestJustReadCollectionFactory.TestData(testCollection).List();
      Assert.IsTrue(Enumerable.SequenceEqual(testCollection, testList));
    }    
  }
}
