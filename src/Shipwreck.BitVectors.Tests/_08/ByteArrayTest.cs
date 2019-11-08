namespace Shipwreck.BitVectors
{
    public class ByteArrayTest : ByteArrayTestBase
    {
        internal override IBitVector<byte> GetArray(byte[] data)
            => new ByteArray(data);
    }
}
