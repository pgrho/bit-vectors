using System.Linq;

namespace Shipwreck.BitVectors
{
    public class Int32ArrayTest : Int32ArrayTestBase
    {
        internal override IInt32Array GetArray(uint[] data)
            => new Int32Array(data.Select(e => unchecked((int)e)).ToArray());
    }
}
