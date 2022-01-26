using System;

namespace Honeycomb.Core.Parsers {

    public record Fail<A>() : IParser<A> {

        public (A, ArraySegment<byte>)? Parse(ArraySegment<byte> input) => null;
    }
}