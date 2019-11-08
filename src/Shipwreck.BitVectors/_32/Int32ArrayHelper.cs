using System;

namespace Shipwreck.BitVectors
{
    internal static class Int32ArrayHelper
    {
        public static bool GetBitCore<T>(this T array, int index)
            where T : IBitVector<uint>
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var ei = index >> 5;

            if (array.Length <= ei)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return ((array.GetElement(ei) >> (31 - (index & 31))) & 1) == 1;
        }

        // TODO: optimize bit operations
        public static byte GetByteCore<T>(this T array, int startIndex, int length)
            where T : IBitVector<uint>
        {
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (length < 0 || sizeof(byte) * 8 < length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            int r = 0;
            for (var i = 0; i < length; i++)
            {
                r |= array.GetBitCore(startIndex + i) ? 1 << (length - 1 - i) : 0;
            }

            return unchecked((byte)r);
        }

        // TODO: optimize bit operations
        public static short GetInt16Core<T>(this T array, int startIndex, int length)
            where T : IBitVector<uint>
        {
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (length < 0 || sizeof(short) * 8 < length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            int r = 0;
            for (var i = 0; i < length; i++)
            {
                r |= array.GetBitCore(startIndex + i) ? 1 << (length - 1 - i) : 0;
            }

            return unchecked((short)r);
        }

        // TODO: optimize bit operations
        public static int GetInt32Core<T>(this T array, int startIndex, int length)
            where T : IBitVector<uint>
        {
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (length < 0 || sizeof(int) * 8 < length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            int r = 0;
            for (var i = 0; i < length; i++)
            {
                r |= array.GetBitCore(startIndex + i) ? 1 << (length - 1 - i) : 0;
            }

            return r;
        }

        // TODO: optimize bit operations
        public static long GetInt64Core<T>(this T array, int startIndex, int length)
            where T : IBitVector<uint>
        {
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (length < 0 || sizeof(long) * 8 < length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            long r = 0;
            for (var i = 0; i < length; i++)
            {
                r |= array.GetBitCore(startIndex + i) ? 1L << (length - 1 - i) : 0;
            }

            return r;
        }
    }
}
