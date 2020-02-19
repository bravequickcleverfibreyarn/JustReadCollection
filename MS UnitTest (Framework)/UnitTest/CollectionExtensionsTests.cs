using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software9119.ReaOnlyCollection;
using System.Linq;
using TestData;

namespace CollectionExtensionsTests
{
  [TestClass]
  public class CollectionExtensionsTests
  {

    #region JustReadCollection

    [TestMethod]
    public void AsJustReadCollection_CorrectDataProvided_CorrectObjectReturned()
    {
      Assert.IsTrue(List.ints.AsJustReadCollection().SequenceEqual(List.ints));
    }

    [TestMethod]
    public void ToJustReadCollection_CorrectDataProvided_CorrectObjectReturned()
    {
      Assert.IsTrue(List.ints.ToJustReadCollection().SequenceEqual(List.ints));
    }

    #endregion
    #region SwiftReadCollection

    [TestMethod]
    public void AsSwiftReadCollection_CorrectDataProvided_CorrectObjectReturned()
    {
      Assert.IsTrue(List.ints.AsSwiftReadCollection().SequenceEqual(List.ints));
    }

    [TestMethod]
    public void ToSwiftReadCollection_CorrectDataProvided_CorrectObjectReturned()
    {
      Assert.IsTrue(List.ints.ToSwiftReadCollection().SequenceEqual(List.ints));
    }

    #endregion
  }
}
