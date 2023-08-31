﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.Core.PrimitiveParsers {

    public class DoubleBytes : IParser<ReadOnlyMemory<byte>> {

        public (ReadOnlyMemory<byte>, ReadOnlyMemory<byte>)? Parse(
            ReadOnlyMemory<byte> input
        ) {
            try {
                return (input.Slice(0, 8), input.Slice(8));
            } catch {
                return null;
            }
        }
    }
}
