using System;

namespace Honeycomb.Core.Parsers {

    public class And<A, B> : IParser<(A, B)> {

        private readonly IParser<A> first;
        private readonly IParser<B> second;

        public And(IParser<A> first, IParser<B> second) {
            this.first = first;
            this.second = second;
        }

        public ((A, B), ArraySegment<byte>)? Parse(
            ArraySegment<byte> input
        ) =>
            (from a in this.first
             from b in this.second
             select (a, b))
            .Parse(input);
    }
}