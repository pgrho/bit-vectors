using System.Linq;

namespace Shipwreck.BitVectors
{
    public class SByteArrayTest : ByteArrayTestBase
    {
        internal override IByteArray GetArray(byte[] data)
            => new SByteArray(data.Select(e => unchecked((sbyte)e)).ToArray());
    }
}
