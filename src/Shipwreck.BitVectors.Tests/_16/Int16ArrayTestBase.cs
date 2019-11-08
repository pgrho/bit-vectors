using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace Shipwreck.BitVectors
{
    public abstract class Int16ArrayTestBase
    {
        internal abstract IBitVector<ushort> GetArray(ushort[] data);

        internal virtual void Release()
        {
        }

        internal sealed class GetBitTestDataAttribute : DataAttribute
        {
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
            {
                yield return new object[] { new ushort[] { 0b1000_0000_0000_0000 }, 0, true };
                yield return new object[] { new ushort[] { 0b1000_0000_0000_0000 }, 1, false };
                yield return new object[] { new ushort[] { 0b0000_0000_0000_0001 }, 14, false };
                yield return new object[] { new ushort[] { 0b0000_0000_0000_0001 }, 15, true };
                yield return new object[] { new ushort[] { 0, 0b1000_0000_0000_0000 }, 0, false };
                yield return new object[] { new ushort[] { 0, 0b1000_0000_0000_0000 }, 1, false };
                yield return new object[] { new ushort[] { 0, 0b1000_0000_0000_0000 }, 15, false };
                yield return new object[] { new ushort[] { 0, 0b1000_0000_0000_0000 }, 16, true };
                yield return new object[] { new ushort[] { 0, 0b1000_0000_0000_0000 }, 17, false };
            }
        }

        [Theory]
        [GetBitTestData]
        public void GetBitTest(ushort[] data, int index, bool expected)
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
