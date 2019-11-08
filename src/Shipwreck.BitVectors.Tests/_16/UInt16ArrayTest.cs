namespace Shipwreck.BitVectors
{
    public class UInt16ArrayTest : Int16ArrayTestBase
    {
        internal override IBitVector<ushort> GetArray(ushort[] data)
            => new UInt16Array(data);
    }
}
