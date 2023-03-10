using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software9119.ReadCollection;
using System.Text;
using TestData;

namespace JustReadCollectionTest
{
  [TestClass]
  public class PerEveryTests
  {

    [TestMethod]
    public void PerEveryTest1()
    {
      int counter = 0;
      JustReadCollection<int> testCollection =  TestJustReadCollectionFactory.TestData(Array.ints);

      testCollection.PerEvery(elem => counter++);
      Assert.AreEqual(testCollection.Count, counter);
    }

    [TestMethod]
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
