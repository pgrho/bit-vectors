namespace Shipwreck.BitVectors
{
    public class UInt32ArrayTest : Int32ArrayTestBase
    {
        internal override IBitVector<uint> GetArray(uint[] data)
            => new UInt32Array(data);
    }
}
