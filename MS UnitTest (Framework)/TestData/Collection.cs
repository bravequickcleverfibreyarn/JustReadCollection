using System.Collections.ObjectModel;

namespace TestData
{
  static public class Collection
  {
    readonly static public Collection<int> ints = new Collection<int>(TestJustReadCollectionFactory.testCollection);
  }
}
