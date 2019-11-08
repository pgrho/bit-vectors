using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace Shipwreck.BitVectors
{
    public abstract class Int32ArrayTestBase
    {
        internal abstract IInt32Array GetArray(uint[] data);

        internal virtual void Release()
        {
        }

        internal sealed class GetBitTestDataAttribute : DataAttribute
        {
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
            {
                yield return new object[] { new uint[] { 1u << 31 }, 0, true };
                yield return new object[] { new uint[] { 1u << 31 }, 1, false };
                yield return new object[] { new uint[] { 1 }, 30, false };
                yield return new object[] { new uint[] { 1 }, 31, true };
                yield return new object[] { new uint[] { 0, 1u << 31 }, 0, false };
                yield return new object[] { new uint[] { 0, 1u << 31 }, 1, false };
                yield return new object[] { new uint[] { 0, 1u << 31 }, 31, false };
                yield return new object[] { new uint[] { 0, 1u << 31 }, 32, true };
                yield return new object[] { new uint[] { 0, 1u << 31 }, 33, false };
            }
        }

        [Theory]
        [GetBitTestData]
        public void GetBitTest(uint[] data, int index, bool expected)
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
