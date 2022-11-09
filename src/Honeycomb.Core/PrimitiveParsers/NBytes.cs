using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.Core.PrimitiveParsers;

public class NBytes : IParser<ArraySegment<byte>> {

    private readonly int number;

    public NBytes(int number) {
        this.number = number;
    }

    public (ArraySegment<byte>, ArraySegment<byte>)? Parse(ArraySegment<byte> input) {
        try {
            return (input.Slice(0, this.number), input.Slice(this.number));
        } catch {
            return null;
        }
    }
}
