using System;

namespace Shipwreck.BitVectors
{
    public struct Section8 : ISection, IEquatable<Section8>
    {
        private readonly byte _StartIndex;
        private readonly byte _Length;

        public Section8(byte startIndex, byte length)
        {
            _StartIndex = startIndex;
            _Length = length;
        }

        public int StartIndex => _StartIndex;
        public int Length => _Length;
        public int NextIndex => _StartIndex + _Length;

        public override bool Equals(object obj)
            => obj is Section8 other && Equals(other);

        public override int GetHashCode() => (_StartIndex << 16) + _Length;

        public override string ToString()
            => "(" + _StartIndex + ", " + _Length + ")";

        public bool Equals(Section8 other)
            => _StartIndex == other._StartIndex
            && _Length == other._Length;
    }
}
