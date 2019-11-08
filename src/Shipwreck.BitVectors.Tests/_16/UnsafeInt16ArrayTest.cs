using System.Runtime.InteropServices;

namespace Shipwreck.BitVectors
{
    public class UnsafeInt16ArrayTest : Int16ArrayTestBase
    {
        private GCHandle _GCHandle;

        internal override unsafe IBitVector<ushort> GetArray(ushort[] data)
        {
            if (_GCHandle != default)
            {
                _GCHandle.Free();
            }
            _GCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            return new UnsafeInt16Array((ushort*)_GCHandle.AddrOfPinnedObject(), data.Length);
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
