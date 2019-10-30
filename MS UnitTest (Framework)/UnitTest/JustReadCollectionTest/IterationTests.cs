using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TestData;

namespace JustReadCollectionTest
{
  [TestClass]
  public class IterationTests
  {
    static int testRun = 1;

    [TestMethod]    

    [DataRow(1, 5, TestJustReadCollectionFactory.COLLECTION)] // 1
    [DataRow(2, 5, TestJustReadCollectionFactory.COLLECTION)] // 1 max. count
    [DataRow(0, 5, TestJustReadCollectionFactory.COLLECTION)] // 1 min. index

    [DataRow(1, 2, TestJustReadCollectionFactory.COLLECTION)] // 2
    [DataRow(5, 2, TestJustReadCollectionFactory.COLLECTION)] // 2 max. count
    [DataRow(0, 2, TestJustReadCollectionFactory.COLLECTION)] // 2 min. index

    [DataRow(1, 3, TestJustReadCollectionFactory.COLLECTION)] // 3
    [DataRow(4, 3, TestJustReadCollectionFactory.COLLECTION)] // 3 max. count
    [DataRow(0, 3, TestJustReadCollectionFactory.COLLECTION)] // 3 min. index

    [DataRow(0, 7, TestJustReadCollectionFactory.COLLECTION)] // .CopyTo
    public void IterationsArrayExtract_CorrectDemands_ComplyWithExpectations(int index, int count, string underlayingCollection)
    {
      if (testRun == 1)
      {
        Debug.WriteLine(nameof(IterationsArrayExtract_CorrectDemands_ComplyWithExpectations));
      }
      Debug.WriteLine(testRun++);

      IList<int> testCollection = TestJustReadCollectionFactory.GetTestCollection(underlayingCollection);

      int[] arrayExtract = TestJustReadCollectionFactory.TestData(testCollection).ArrayExtract(index, count);
      Assert.IsTrue(Enumerable.SequenceEqual(arrayExtract, testCollection.Skip(index).Take(count)));
    }


    static int testRun1 = 1;

    [TestMethod]

    [DataRow(1, 5, TestJustReadCollectionFactory.COLLECTION)] // 1
    [DataRow(2, 5, TestJustReadCollectionFactory.COLLECTION)] // 1 max. count
    [DataRow(0, 5, TestJustReadCollectionFactory.COLLECTION)] // 1 min. index

    [DataRow(1, 2, TestJustReadCollectionFactory.COLLECTION)] // 2
    [DataRow(5, 2, TestJustReadCollectionFactory.COLLECTION)] // 2 max. count
    [DataRow(0, 2, TestJustReadCollectionFactory.COLLECTION)] // 2 min. index

    [DataRow(1, 3, TestJustReadCollectionFactory.COLLECTION)] // 3
    [DataRow(4, 3, TestJustReadCollectionFactory.COLLECTION)] // 3 max. count
    [DataRow(0, 3, TestJustReadCollectionFactory.COLLECTION)] // 3 min. index

    [DataRow(0, 7, TestJustReadCollectionFactory.COLLECTION)] // .CopyTo
    public void IterationsListExtract_CorrectDemands_ComplyWithExpectations(int index, int count, string underlayingCollection)
    {
      if (testRun1 == 1)
      {
        Debug.WriteLine(nameof(IterationsListExtract_CorrectDemands_ComplyWithExpectations));
      }
      Debug.WriteLine(testRun1++);

      IList<int> testCollection = TestJustReadCollectionFactory.GetTestCollection(underlayingCollection);

      List<int> listExtract = TestJustReadCollectionFactory.TestData(testCollection).ListExtract(index, count);
      Assert.IsTrue(Enumerable.SequenceEqual(listExtract, testCollection.Skip(index).Take(count)));
    }

    static int testRun2 = 1;

    [TestMethod]    
    [DataRow(TestJustReadCollectionFactory.COLLECTION)] // .CopyTo  
    public void IterationsArray_NormalState_CollectionReturned(string underlayingCollection)
    {
      if (testRun2 == 1)
      {
        Debug.WriteLine(nameof(IterationsArray_NormalState_CollectionReturned));
      }
      Debug.WriteLine(testRun2++);

      IList<int> testCollection = TestJustReadCollectionFactory.GetTestCollection(underlayingCollection);

      int[] testArray = TestJustReadCollectionFactory.TestData(testCollection).Array();
      Assert.IsTrue(Enumerable.SequenceEqual(testCollection, testArray));
    }
  }
}
