using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software919.ReaOnlyCollection;
using System.Linq;
using TestData;

namespace IListExtensionsTests
{
  [TestClass]
  public class IListExtensionsTests
  {

    [TestMethod]
    public void AsJustReadCollection_CorrectDataProvided_CorrectObjectReturned()
    {
      Assert.IsTrue(List.ints.AsJustReadCollection().SequenceEqual(List.ints));
    }

    [TestMethod]
    public void AsSwiftReadCollection_CorrectDataProvided_CorrectObjectReturned()
    {
      Assert.IsTrue(List.ints.AsSwiftReadCollection().SequenceEqual(List.ints));
    }
  }
}
