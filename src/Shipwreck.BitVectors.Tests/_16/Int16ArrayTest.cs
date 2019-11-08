using System.Linq;

namespace Shipwreck.BitVectors
{
    public class Int16ArrayTest : Int16ArrayTestBase
    {
        internal override IInt16Array GetArray(ushort[] data)
            => new Int16Array(data.Select(e => unchecked((short)e)).ToArray());
    }
}
