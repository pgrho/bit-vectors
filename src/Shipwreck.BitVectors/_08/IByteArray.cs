namespace Shipwreck.BitVectors
{
    internal interface IByteArray : IBitVector
    {
        byte GetElement(int index);
    }
}
