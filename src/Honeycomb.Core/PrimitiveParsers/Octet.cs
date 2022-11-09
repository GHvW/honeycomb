using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.Core.PrimitiveParsers {

    public class Octet : IParser<byte> {

        public (byte, ArraySegment<byte>)? Parse(ArraySegment<byte> input) {
            try {
                return (input[0], input.Slice(1));
            } catch {
                return null;
            }
        }
    }
}
