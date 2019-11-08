using System;

namespace Shipwreck.BitVectors
{
    public unsafe struct UnsafeInt16Array : IInt16Array
    {
        private ushort* _Pointer;

        public UnsafeInt16Array(ushort* pointer, int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            _Pointer = pointer;
            Length = length;
        }

        public int Length { get; }

        ushort IInt16Array.GetElement(int index)
            => _Pointer[index];

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
