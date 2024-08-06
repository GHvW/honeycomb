﻿using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.Core.PrimitiveParsers {

    public class BigShort : IParser<short> {

        public ParseResult<short>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) {
            try {
                return new ParseResult<short>(
                    BinaryPrimitives.ReadInt16BigEndian(input.Slice(currentIndex, 2)),
                    currentIndex + 2);
            } catch {
                return null;
            }
        }
    }
}
