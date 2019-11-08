namespace Shipwreck.BitVectors
{
    public static class BitVector
    {
        #region Section8

        public static Section8 CreateSection(byte startIndex, byte length)
            => new Section8(startIndex, length);

        public static Section8 NextSection(this Section8 section, int length)
            => checked(new Section8((byte)section.NextIndex, (byte)length));

        public static Section8 NextSection(this Section8 section, int skip, int length)
            => checked(new Section8((byte)(skip + section.NextIndex), (byte)length));

        #endregion Section8

        #region 8bit

        public static SByteArray Create(sbyte[] array)
            => new SByteArray(array);

        public static ByteArray Create(byte[] array)
            => new ByteArray(array);

        public static unsafe UnsafeByteArray Create(sbyte* pointer, int length)
            => new UnsafeByteArray((byte*)pointer, length);

        public static unsafe UnsafeByteArray Create(byte* pointer, int length)
            => new UnsafeByteArray(pointer, length);

        #endregion 8bit

        #region 16bit

        public static Int16Array Create(short[] array)
            => new Int16Array(array);

        public static UInt16Array Create(ushort[] array)
            => new UInt16Array(array);

        public static unsafe UnsafeInt16Array Create(short* pointer, int length)
            => new UnsafeInt16Array((ushort*)pointer, length);

        public static unsafe UnsafeInt16Array Create(ushort* pointer, int length)
            => new UnsafeInt16Array(pointer, length);

        #endregion 16bit

        #region 32bit

        public static Int32Array Create(int[] array)
            => new Int32Array(array);

        public static UInt32Array Create(uint[] array)
            => new UInt32Array(array);

        public static unsafe UnsafeInt32Array Create(int* pointer, int length)
            => new UnsafeInt32Array((uint*)pointer, length);

        public static unsafe UnsafeInt32Array Create(uint* pointer, int length)
            => new UnsafeInt32Array(pointer, length);

        #endregion 32bit

        #region 64bit

        public static Int64Array Create(long[] array)
            => new Int64Array(array);

        public static UInt64Array Create(ulong[] array)
            => new UInt64Array(array);

        public static unsafe UnsafeInt64Array Create(long* pointer, int length)
            => new UnsafeInt64Array((ulong*)pointer, length);

        public static unsafe UnsafeInt64Array Create(ulong* pointer, int length)
            => new UnsafeInt64Array(pointer, length);

        #endregion 64bit

        #region Extensions

        public static byte GetByte<TVector, TSection>(this TVector vector, TSection section)
            where TVector : IBitVector
            where TSection : ISection
            => vector.GetByte(section.StartIndex, section.Length);

        public static sbyte GetSByte<TVector, TSection>(this TVector vector, TSection section)
            where TVector : IBitVector
            where TSection : ISection
            => unchecked((sbyte)vector.GetByte(section.StartIndex, section.Length));

        public static short GetInt16<TVector, TSection>(this TVector vector, TSection section)
            where TVector : IBitVector
            where TSection : ISection
            => vector.GetInt16(section.StartIndex, section.Length);

        public static ushort GetUInt16<TVector, TSection>(this TVector vector, TSection section)
            where TVector : IBitVector
            where TSection : ISection
            => unchecked((ushort)vector.GetInt16(section.StartIndex, section.Length));

        public static int GetInt32<TVector, TSection>(this TVector vector, TSection section)
            where TVector : IBitVector
            where TSection : ISection
            => vector.GetInt32(section.StartIndex, section.Length);

        public static uint GetUInt32<TVector, TSection>(this TVector vector, TSection section)
            where TVector : IBitVector
            where TSection : ISection
            => unchecked((uint)vector.GetInt32(section.StartIndex, section.Length));

        public static long GetInt64<TVector, TSection>(this TVector vector, TSection section)
            where TVector : IBitVector
            where TSection : ISection
            => vector.GetInt64(section.StartIndex, section.Length);

        public static ulong GetUInt64<TVector, TSection>(this TVector vector, TSection section)
            where TVector : IBitVector
            where TSection : ISection
            => unchecked((ulong)vector.GetInt64(section.StartIndex, section.Length));

        #endregion Extensions
    }
}
