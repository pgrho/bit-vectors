using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace Shipwreck.BitVectors
{
    public abstract class Int64ArrayTestBase
    {
        internal abstract IBitVector<ulong> GetArray(ulong[] data);

        internal virtual void Release()
        {
        }

        internal sealed class GetBitTestDataAttribute : DataAttribute
        {
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
            {
                yield return new object[] { new ulong[] { 1ul << 63 }, 0, true };
                yield return new object[] { new ulong[] { 1ul << 63 }, 1, false };
                yield return new object[] { new ulong[] { 1 }, 62, false };
                yield return new object[] { new ulong[] { 1 }, 63, true };
                yield return new object[] { new ulong[] { 0, 1ul << 63 }, 0, false };
                yield return new object[] { new ulong[] { 0, 1ul << 63 }, 1, false };
                yield return new object[] { new ulong[] { 0, 1ul << 63 }, 63, false };
                yield return new object[] { new ulong[] { 0, 1ul << 63 }, 64, true };
                yield return new object[] { new ulong[] { 0, 1ul << 63 }, 65, false };
            }
        }

        [Theory]
        [GetBitTestData]
        public void GetBitTest(ulong[] data, int index, bool expected)
        {
            try
            {
                Assert.Equal(expected, GetArray(data).GetBit(index));
            }
            finally
            {
                Release();
            }
        }
    }
}
