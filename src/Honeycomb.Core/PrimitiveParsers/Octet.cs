using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.Core.PrimitiveParsers {

    public class Octet : IParser<byte> {

        public (byte, ReadOnlyMemory<byte>)? Parse(
            ReadOnlyMemory<byte> input
        ) {
            try {
                return (input.Span[0], input.Slice(1));
            } catch {
                return null;
            }
        }
    }
}
