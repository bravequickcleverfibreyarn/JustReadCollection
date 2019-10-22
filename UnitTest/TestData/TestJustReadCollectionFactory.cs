using Software919.ReaOnlyCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UnitTest.TestData
{
  [TestClass]
  public class TestJustReadCollectionFactory
  {
    public const string ARRAY = "Arrray", LIST = "List";

    readonly static public ReadOnlyCollection<int> testCollection = new ReadOnlyCollection<int>(new[] { 11, 22, 33, 44, 55, 66, 127 });

    static public JustReadCollection<T> TestData<T>(IList<T> collection) => new JustReadCollection<T>(collection);
    //static public JustReadCollection<T> TestData<T>(IList<T> collection) where T : unmanaged => new SwiftReadCollection<T>(collection);

    [TestMethod]
    public void TestTestData()
    {
      Assert.IsTrue(testCollection.Count == 7);
    }
  }
}