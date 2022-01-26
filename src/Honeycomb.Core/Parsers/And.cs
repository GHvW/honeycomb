using System;

namespace Honeycomb.Core.Parsers {

    public record And<A, B>(IParser<A> First, IParser<B> Second) : IParser<(A, B)> {

        public ((A, B), ArraySegment<byte>)? Parse(ArraySegment<byte> input) =>
            (from a in this.First
             from b in this.Second
             select (a, b))
            .Parse(input);
    }
}