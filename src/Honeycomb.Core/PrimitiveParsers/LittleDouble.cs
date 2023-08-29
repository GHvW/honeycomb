using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.Core.PrimitiveParsers {

    public class LittleDouble : IParser<double> {

        public (double, ReadOnlyMemory<byte>)? Parse(
            ReadOnlyMemory<byte> input
        ) =>
            new DoubleBytes()
                .Select(bytes => BinaryPrimitives.ReadDoubleLittleEndian(bytes.Span)) // have to have the lambda to get implicit conversion
                .Parse(input);
    }
}
