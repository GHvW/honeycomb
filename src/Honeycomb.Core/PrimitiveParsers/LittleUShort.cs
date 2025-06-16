using System;
using System.Buffers.Binary;

namespace Honeycomb.Core.PrimitiveParsers;

public class LittleUShort : IParser<ushort> {

    public ParseResult<ushort>? Parse(
        int currentIndex,
        ReadOnlySpan<byte> input
    ) {
        try {
            return new ParseResult<ushort>(
                BinaryPrimitives.ReadUInt16LittleEndian(input.Slice(currentIndex, 2)),
                currentIndex + 2);
        } catch {
            return null;
        }
    }
}
