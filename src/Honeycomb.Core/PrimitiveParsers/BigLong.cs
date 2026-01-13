using System;
using System.Buffers.Binary;

namespace Honeycomb.Core.PrimitiveParsers {

    public class BigLong : IParser<long> {

        public ParseResult<long>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) {
            try {
                return new ParseResult<long>(
                    BinaryPrimitives.ReadInt64BigEndian(input.Slice(currentIndex, 8)),
                    currentIndex + 8);
            } catch {
                return null;
            }
        }
    }
}