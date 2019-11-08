namespace Shipwreck.BitVectors
{
    public class UInt64ArrayTest : Int64ArrayTestBase
    {
        internal override IInt64Array GetArray(ulong[] data)
            => new UInt64Array(data);
    }
}
