namespace Shipwreck.BitVectors
{
    public class UInt64ArrayTest : Int64ArrayTestBase
    {
        internal override IBitVector<ulong> GetArray(ulong[] data)
            => new UInt64Array(data);
    }
}
