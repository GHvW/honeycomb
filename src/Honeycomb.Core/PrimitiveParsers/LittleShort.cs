﻿using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.Core.PrimitiveParsers {

    public record LittleShort() : IParser<short> {

        public (short, ArraySegment<byte>)? Parse(ArraySegment<byte> input) =>
            new ShortBytes()
                .Select(bytes => BinaryPrimitives.ReadInt16LittleEndian(bytes)) // need surrounding lambda to get implicit conversion
                .Parse(input);
    }
}