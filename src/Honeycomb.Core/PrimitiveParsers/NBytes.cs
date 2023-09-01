using System;


namespace Honeycomb.Core.PrimitiveParsers;

public class NBytes : IParser<ReadOnlyMemory<byte>> {

    private readonly int number;

    public NBytes(int number) {
        this.number = number;
    }

    public (ReadOnlyMemory<byte>, ReadOnlyMemory<byte>)? Parse(
        ReadOnlyMemory<byte> input
    ) {
        try {
            return (input.Slice(0, this.number), input.Slice(this.number));
        } catch {
            return null;
        }
    }
}
