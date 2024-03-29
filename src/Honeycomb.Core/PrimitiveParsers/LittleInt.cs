﻿using System;
using System.Buffers.Binary;


namespace Honeycomb.Core.PrimitiveParsers {

    public class LittleInt : IParser<int> {

        public (int, ReadOnlyMemory<byte>)? Parse(
            ReadOnlyMemory<byte> input
        ) =>
            new IntBytes()
                .Select(bytes => BinaryPrimitives.ReadInt32LittleEndian(bytes.Span)) // need surrounding lambda to get implicit conversion
                .Parse(input);
    }
}
