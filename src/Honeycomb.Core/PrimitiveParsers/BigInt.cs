using System;
using System.Buffers.Binary;

namespace Honeycomb.Core.PrimitiveParsers {

    public class BigInt : IParser<int> {

        public ParseResult<int>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) {
            try {
                return new ParseResult<int>(
                    BinaryPrimitives.ReadInt32BigEndian(input.Slice(currentIndex, 4)),
                    currentIndex + 4);
            } catch {
                return null;
            }
        }
    }
}
