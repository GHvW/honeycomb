using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.Core.PrimitiveParsers;

public record NBytes(int Number) : IParser<ArraySegment<byte>> {

    public (ArraySegment<byte>, ArraySegment<byte>)? Parse(ArraySegment<byte> input) {
        try {
            return (input.Slice(0, this.Number), input.Slice(this.Number));
        } catch {
            return null;
        }
    }
}
