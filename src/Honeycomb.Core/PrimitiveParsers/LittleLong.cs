using System;
using System.Buffers.Binary;

namespace Honeycomb.Core.PrimitiveParsers {

    public class LittleLong : IParser<long> {

        public ParseResult<long>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) {
            try {
                return new ParseResult<long>(
                    BinaryPrimitives.ReadInt64LittleEndian(input.Slice(currentIndex, 8)),
                    currentIndex + 8);
            } catch {
                return null;
            }
        }
    }
}