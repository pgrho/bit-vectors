using System.Runtime.InteropServices;

namespace Shipwreck.BitVectors
{
    public class UnsafeInt64ArrayTest : Int64ArrayTestBase
    {
        private GCHandle _GCHandle;

        internal override unsafe IInt64Array GetArray(ulong[] data)
        {
            if (_GCHandle != default)
            {
                _GCHandle.Free();
            }
            _GCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            return new UnsafeInt64Array((ulong*)_GCHandle.AddrOfPinnedObject(), data.Length);
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
