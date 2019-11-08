using System;

namespace Shipwreck.BitVectors
{
    public unsafe struct Int64Array : IInt64Array
    {
        private long[] _Array;

        public Int64Array(long[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            _Array = array;
        }

        public int Length => _Array.Length;

        ulong IInt64Array.GetElement(int index)
            => unchecked((ulong)_Array[index]);

        #region Common

        public bool GetBit(int index)
            => this.GetBitCore(index);

        public byte GetByte(int startIndex, int length)
            => this.GetByteCore(startIndex, length);

        public short GetInt16(int startIndex, int length)
            => this.GetInt16Core(startIndex, length);

        public int GetInt32(int startIndex, int length)
            => this.GetInt32Core(startIndex, length);

        public long GetInt64(int startIndex, int length)
            => this.GetInt64Core(startIndex, length);


        #endregion Common
    }
}
