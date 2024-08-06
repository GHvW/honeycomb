using System;

namespace Honeycomb.Core.PrimitiveParsers;

public class NBytes : IParser<ReadOnlyMemory<byte>> {

    private readonly int number;

    public NBytes(int number) {
        this.number = number;
    }

    public ParseResult<ReadOnlyMemory<byte>>? Parse(
        int currentIndex,
        ReadOnlySpan<byte> input
    ) {
        try {
            // TODO - is this the best way?
            return new ParseResult<ReadOnlyMemory<byte>>(
                new ReadOnlyMemory<byte>(input.Slice(currentIndex, this.number).ToArray()), 
                currentIndex + this.number);
        } catch {
            return null;
        }
    }
}
