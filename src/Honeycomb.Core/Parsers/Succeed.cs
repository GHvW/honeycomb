using System;

namespace Honeycomb.Core.Parsers {

    public record Succeed<A>(A Data) : IParser<A> {

        public (A, ArraySegment<byte>)? Parse(ArraySegment<byte> input) => (this.Data, input);
    }
}