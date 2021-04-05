using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using Software9119.ReadCollection;

namespace TestData
{
  [TestClass]
  public class TestJustReadCollectionFactory
  {
    public const string ARRAY = "Arrray", LIST = "List", COLLECTION = "Collection";

    readonly static public ReadOnlyCollection<int> testCollection = new(new[] { 11, 22, 33, 44, 55, 66, 127 });

    static public JustReadCollection<T> TestData<T>(IList<T> collection) => new(collection);
    //static public JustReadCollection<T> TestData<T>(IList<T> collection) where T : unmanaged => new SwiftReadCollection<T>(collection);

    static public IList<int> GetTestCollection(string collectionType)
    {
      return collectionType switch
      {
        ARRAY => Array.ints,
        LIST => List.ints,
        COLLECTION => Collection.ints,
        _ => throw new ArgumentException("Unknow underlaying collection type!"),
      };
    }

    [TestMethod]
    public void TestTestData()
    {
      Assert.IsTrue(testCollection.Count == 7);
    }
  }
}