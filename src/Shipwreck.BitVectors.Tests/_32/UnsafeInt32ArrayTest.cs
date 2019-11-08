using System.Runtime.InteropServices;

namespace Shipwreck.BitVectors
{
    public class UnsafeInt32ArrayTest : Int32ArrayTestBase
    {
        private GCHandle _GCHandle;

        internal override unsafe IInt32Array GetArray(uint[] data)
        {
            if (_GCHandle != default)
            {
                _GCHandle.Free();
            }
            _GCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            return new UnsafeInt32Array((uint*)_GCHandle.AddrOfPinnedObject(), data.Length);
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
