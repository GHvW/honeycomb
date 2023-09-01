using System;
using System.Buffers.Binary;

namespace Honeycomb.Core.PrimitiveParsers;

public class BigFloat : IParser<float> {

    public (float, ReadOnlyMemory<byte>)? Parse(
        ReadOnlyMemory<byte> input
    ) =>
        new IntBytes()
            .Select(it => BinaryPrimitives.ReadSingleBigEndian(it.Span))
            .Parse(input);
}
