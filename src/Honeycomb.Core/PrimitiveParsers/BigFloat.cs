using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.Core.PrimitiveParsers;

public class BigFloat : IParser<float> {

    public (float, ArraySegment<byte>)? Parse(ArraySegment<byte> input) =>
        new IntBytes()
            .Select(it => BinaryPrimitives.ReadSingleBigEndian(it))
            .Parse(input);
}
