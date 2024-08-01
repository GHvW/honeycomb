using System;
using System.Buffers.Binary;

namespace Honeycomb.Core.PrimitiveParsers {

    public class LittleDouble : IParser<double> {

        public ParseResult<double>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) {
            try {
                return new ParseResult<double>(
                    BinaryPrimitives.ReadDoubleLittleEndian(input.Slice(currentIndex, 8)),
                    currentIndex + 8);
            } catch {
                return null;
            }
        }
    }
}
