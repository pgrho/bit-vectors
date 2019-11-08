using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace Shipwreck.BitVectors
{
    public abstract class ByteArrayTestBase
    {
        internal abstract IByteArray GetArray(byte[] data);

        internal virtual void Release()
        {
        }

        internal sealed class GetBitTestDataAttribute : DataAttribute
        {
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
            {
                yield return new object[] { new byte[] { 0b1000_0000 }, 0, true };
                yield return new object[] { new byte[] { 0b1000_0000 }, 1, false };
                yield return new object[] { new byte[] { 0b0000_0001 }, 6, false };
                yield return new object[] { new byte[] { 0b0000_0001 }, 7, true };
                yield return new object[] { new byte[] { 0, 0b1000_0000 }, 0, false };
                yield return new object[] { new byte[] { 0, 0b1000_0000 }, 1, false };
                yield return new object[] { new byte[] { 0, 0b1000_0000 }, 7, false };
                yield return new object[] { new byte[] { 0, 0b1000_0000 }, 8, true };
                yield return new object[] { new byte[] { 0, 0b1000_0000 }, 9, false };
            }
        }

        [Theory]
        [GetBitTestData]
        public void GetBitTest(byte[] data, int index, bool expected)
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
