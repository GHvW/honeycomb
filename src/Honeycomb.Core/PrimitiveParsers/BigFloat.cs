using System;
using System.Buffers.Binary;

namespace Honeycomb.Core.PrimitiveParsers;

public class BigFloat : IParser<float> {

    public ParseResult<float>? Parse(
        int currentIndex,
        ReadOnlySpan<byte> input
    ) {
        try {
            return new ParseResult<float>(
                BinaryPrimitives.ReadSingleBigEndian(input.Slice(currentIndex, 4)),
                currentIndex + 4);
        } catch {
            return null;
        }
    }
}
