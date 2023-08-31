using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.Core.PrimitiveParsers {

    public class BigShort : IParser<short> {

        public (short, ReadOnlyMemory<byte>)? Parse(
            ReadOnlyMemory<byte> input
        ) =>
            new ShortBytes()
                .Select(bytes => BinaryPrimitives.ReadInt16BigEndian(bytes.Span)) // need surrounding lambda to get implicit conversion
                .Parse(input);
    }
}
