using System.Runtime.InteropServices;

namespace Shipwreck.BitVectors
{
    public class UnsafeByteArrayTest : ByteArrayTestBase
    {
        private GCHandle _GCHandle;

        internal override unsafe IBitVector<byte> GetArray(byte[] data)
        {
            if (_GCHandle != default)
            {
                _GCHandle.Free();
            }
            _GCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            return new UnsafeByteArray((byte*)_GCHandle.AddrOfPinnedObject(), data.Length);
        }

        internal override void Release()
        {
            if (_GCHandle != default)
            {
                _GCHandle.Free();
                _GCHandle = default;
            }
        }
    }
}
