﻿using System;

namespace Shipwreck.BitVectors
{
    public unsafe struct ByteArray : IBitVector<byte>
    {
        private byte[] _Array;

        public ByteArray(byte[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            _Array = array;
        }

        public int Length => _Array.Length;

        byte IBitVector<byte>.GetElement(int index)
            => _Array[index];

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
