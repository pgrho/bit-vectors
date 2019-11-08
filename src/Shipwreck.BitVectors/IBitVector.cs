namespace Shipwreck.BitVectors
{
    public interface IBitVector
    {
        int Length { get; }

        bool GetBit(int index);

        byte GetByte(int startIndex, int length);
        short GetInt16(int startIndex, int length);
        int GetInt32(int startIndex, int length);
        long GetInt64(int startIndex, int length);
    }

    internal interface IBitVector<T> : IBitVector
        where T : struct
    {
        T GetElement(int index);
    }
}
