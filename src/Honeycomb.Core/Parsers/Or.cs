using System;

namespace Honeycomb.Core.Parsers {

    public class Or<A> : IParser<A> {

        private readonly IParser<A> first;
        private readonly IParser<A> second;

        public Or(IParser<A> first, IParser<A> second) {
            this.first = first;
            this.second = second;
        }

        public (A, ArraySegment<byte>)? Parse(
            ArraySegment<byte> input
        ) =>
            first.Parse(input) ?? second.Parse(input);
    }
}