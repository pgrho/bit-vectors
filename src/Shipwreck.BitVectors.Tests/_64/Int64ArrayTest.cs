using System.Linq;

namespace Shipwreck.BitVectors
{
    public class Int64ArrayTest : Int64ArrayTestBase
    {
        internal override IBitVector<ulong> GetArray(ulong[] data)
            => new Int64Array(data.Select(e => unchecked((long)e)).ToArray());
    }
}
