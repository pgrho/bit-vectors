namespace Shipwreck.BitVectors
{
    public class UInt32ArrayTest : Int32ArrayTestBase
    {
        internal override IInt32Array GetArray(uint[] data)
            => new UInt32Array(data);
    }
}
