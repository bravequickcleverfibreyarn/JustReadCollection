using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software9119.ReadCollection;
using System.Collections.Generic;
using System.Linq;
using TestData;

namespace CollectionExtensionsTests
{
  [TestClass]
  public class CollectionExtensionsTests
  {

    #region JustReadCollection

    [TestMethod]
    public void ToJustReadCollection_CorrectDataProvided_CorrectObjectReturned()
    {
      Assert.IsTrue(List.ints.ToJustReadCollection(default).SequenceEqual(List.ints));
    }

    [TestMethod]
    public void ToJustReadCollection_ProvidedWithNullExpectsNull_ReturnsNull()
    {
      Assert.IsTrue(((IEnumerable<int>)null).ToJustReadCollection(false) == null);
    }

    [TestMethod]
    public void ToJustReadCollection_ProvidedWithNullExpectsEmpty_ReturnsEmpty()
    {
      JustReadCollection<int> justReadCollection = ((IEnumerable<int>)null).ToJustReadCollection(true);

      Assert.IsTrue(justReadCollection.Count == 0);
    }

    #endregion
    #region SwiftReadCollection

    [TestMethod]
    public void ToSwiftReadCollection_CorrectDataProvided_CorrectObjectReturned()
    {
      Assert.IsTrue(List.ints.ToSwiftReadCollection(default).SequenceEqual(List.ints));
    }
    
    [TestMethod]
    public void ToSwiftReadCollection_ProvidedWithNullExpectsNull_ReturnsNull()
    {
      Assert.IsTrue(((IEnumerable<int>)null).ToSwiftReadCollection(false) == null);
    }

    [TestMethod]
    public void ToSwiftReadCollection_ProvidedWithNullExpectsEmpty_ReturnsEmpty()
    {
      SwiftReadCollection<int> swiftReadCollection = ((IEnumerable<int>)null).ToSwiftReadCollection(true);

      Assert.IsTrue(swiftReadCollection.Count == 0);
    }

    #endregion
  }
}
