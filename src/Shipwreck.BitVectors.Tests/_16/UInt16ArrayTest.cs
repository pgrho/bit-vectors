namespace Shipwreck.BitVectors
{
    public class UInt16ArrayTest : Int16ArrayTestBase
    {
        internal override IInt16Array GetArray(ushort[] data)
            => new UInt16Array(data);
    }
}
