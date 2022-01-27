using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.Core.PrimitiveParsers {

    public record BigDouble : IParser<double> {

        public (double, ArraySegment<byte>)? Parse(ArraySegment<byte> input) =>
            new DoubleBytes()
                .Select(bytes => BinaryPrimitives.ReadDoubleBigEndian(bytes)) // have to have the lambda to get implicit conversion
                .Parse(input);
    }
}
