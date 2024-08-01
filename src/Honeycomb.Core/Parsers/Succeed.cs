using System;

namespace Honeycomb.Core.Parsers {

    public record Succeed<A> : IParser<A> {

        private readonly A data;

        public Succeed(A data) {
            this.data = data;
        }

        public ParseResult<A>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) => 
            new ParseResult<A>(this.data, currentIndex);
    }
}