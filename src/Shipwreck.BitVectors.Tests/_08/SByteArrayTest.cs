using System.Linq;

namespace Shipwreck.BitVectors
{
    public class SByteArrayTest : ByteArrayTestBase
    {
        internal override IBitVector<byte> GetArray(byte[] data)
            => new SByteArray(data.Select(e => unchecked((sbyte)e)).ToArray());
    }
}
