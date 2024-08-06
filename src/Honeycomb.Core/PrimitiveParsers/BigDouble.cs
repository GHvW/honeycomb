using System;
using System.Buffers.Binary;

namespace Honeycomb.Core.PrimitiveParsers {

    public class BigDouble : IParser<double> {

        public ParseResult<double>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) {
            try {
                return new ParseResult<double>(
                    BinaryPrimitives.ReadDoubleBigEndian(input.Slice(currentIndex, 8)),
                    currentIndex + 8);
            } catch {
                return null;
            }
        }
    }
}
