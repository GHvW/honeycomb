using System;
using System.Buffers.Binary;

namespace Honeycomb.Core.PrimitiveParsers {

    public class LittleInt : IParser<int> {

        public ParseResult<int>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) {
            try {
                return new ParseResult<int>(
                    BinaryPrimitives.ReadInt32LittleEndian(input.Slice(currentIndex, 4)), 
                    currentIndex + 4);
            } catch {
                return null;
            }
        }
    }
}
