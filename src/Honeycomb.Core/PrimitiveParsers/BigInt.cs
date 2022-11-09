using System;
using System.Buffers.Binary;
using System.Collections.Generic;

namespace Honeycomb.Core.PrimitiveParsers {

    public class BigInt : IParser<int> {

        public (int, ArraySegment<byte>)? Parse(ArraySegment<byte> input) =>
            new IntBytes()
                .Select(bytes => BinaryPrimitives.ReadInt32BigEndian(bytes)) // have to have the lambda to get implicit conversion
                .Parse(input);
    }
}
