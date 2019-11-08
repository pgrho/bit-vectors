using System;

namespace Shipwreck.BitVectors
{
    internal static class ByteArrayHelper
    {
        private static byte GetByteMask(int bits)
        {
            switch (bits)
            {
                case 0: return 0b0000_0000;
                case 1: return 0b0000_0001;
                case 2: return 0b0000_0011;
                case 3: return 0b0000_0111;
                case 4: return 0b0000_1111;
                case 5: return 0b0001_1111;
                case 6: return 0b0011_1111;
                case 7: return 0b0111_1111;
                case 8: return 0b1111_1111;
            }
            throw new ArgumentOutOfRangeException();
        }

        public static bool GetBitCore<T>(this T array, int index)
            where T : IByteArray
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var ei = index >> 3;

            if (array.Length <= ei)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return ((array.GetElement(ei) >> (7 - (index & 7))) & 1) == 1;
        }

        public static byte GetByteCore<T>(this T array, int startIndex, int length)
            where T : IByteArray
        {
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            if (length == 0)
            {
                return 0;
            }
            const int SIZE = sizeof(byte) * 8;
            if (length < 0 || SIZE < length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            var firstElement = startIndex / SIZE;
            var firstBit = startIndex % SIZE;
            var nextBit = firstBit + length;

            var coreValue = nextBit > SIZE ? (array.GetElement(firstElement) << SIZE) + array.GetElement(firstElement + 1) : array.GetElement(firstElement);
            return unchecked((byte)(GetByteMask(length) & (coreValue >> ((SIZE * 2 - nextBit) % SIZE))));
        }

        // TODO: optimize bit operations
        public static short GetInt16Core<T>(this T array, int startIndex, int length)
            where T : IByteArray
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
            where T : IByteArray
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
            where T : IByteArray
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
