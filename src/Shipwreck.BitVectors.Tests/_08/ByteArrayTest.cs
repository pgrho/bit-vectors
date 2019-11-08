namespace Shipwreck.BitVectors
{
    public class ByteArrayTest : ByteArrayTestBase
    {
        internal override IByteArray GetArray(byte[] data)
            => new ByteArray(data);
    }
}
