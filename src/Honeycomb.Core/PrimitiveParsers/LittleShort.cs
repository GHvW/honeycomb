using System;
using System.Buffers.Binary;

namespace Honeycomb.Core.PrimitiveParsers {

    public class LittleShort : IParser<short> {

        public ParseResult<short>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) {
            try {
                return new ParseResult<short>(
                    BinaryPrimitives.ReadInt16LittleEndian(input.Slice(currentIndex, 2)),
                    currentIndex + 2);
            } catch {
                return null;
            }
        }
    }
}
