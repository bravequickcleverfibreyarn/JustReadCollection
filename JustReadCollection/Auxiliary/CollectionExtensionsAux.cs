using System.Collections;

namespace Software9119.ReadCollection.Auxiliary
{
  static internal class CollectionExtensionsAux
  {
    static public bool ReturnNull(IEnumerable iEnumerable, bool emptyForNull) => !emptyForNull && iEnumerable == null;
  }
}