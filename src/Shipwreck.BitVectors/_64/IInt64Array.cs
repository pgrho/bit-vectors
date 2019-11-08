namespace Shipwreck.BitVectors
{
    internal interface IInt64Array : IBitVector
    {
        ulong GetElement(int index);
    }
}
