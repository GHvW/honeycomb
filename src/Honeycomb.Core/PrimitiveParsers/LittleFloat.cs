using System;
using System.Buffers.Binary;

namespace Honeycomb.Core.PrimitiveParsers;

public class LittleFloat : IParser<float> {

    public ParseResult<float>? Parse(
        int currentIndex,
        ReadOnlySpan<byte> input
    ) {
        try {
            return new ParseResult<float>(
                BinaryPrimitives.ReadSingleLittleEndian(input.Slice(currentIndex, 4)),
                currentIndex + 4);
        } catch {
            return null;
        }
    }
}
