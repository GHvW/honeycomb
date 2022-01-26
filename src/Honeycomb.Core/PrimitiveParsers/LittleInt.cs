using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.Core.PrimitiveParsers {

    public record LittleInt() : IParser<int> {

        public (int, ArraySegment<byte>)? Parse(ArraySegment<byte> input) =>
            new IntBytes()
                .Select(bytes => BinaryPrimitives.ReadInt32LittleEndian(bytes)) // need surrounding lambda to get implicit conversion
                .Parse(input);
    }
}
