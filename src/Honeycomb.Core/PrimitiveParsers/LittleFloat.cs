using System;
using System.Buffers.Binary;

namespace Honeycomb.Core.PrimitiveParsers;

public class LittleFloat : IParser<float> {

    public (float, ReadOnlyMemory<byte>)? Parse(
        ReadOnlyMemory<byte> input
    ) =>
        new IntBytes()
            .Select(it => BinaryPrimitives.ReadSingleLittleEndian(it.Span))
            .Parse(input);
}
