using System;

namespace Honeycomb.Core.Parsers {

    public class Map<A, B> : IParser<B> {

        private readonly Func<A, B> fn;
        private readonly IParser<A> parser;

        public Map(Func<A, B> fn, IParser<A> parser) {
            this.parser = parser;
            this.fn = fn;
        }

        public (B, ArraySegment<byte>)? Parse(
            ArraySegment<byte> input
        ) =>
            this.parser.Parse(input) switch {
                null => null,
                (var data, var rest) => (this.fn(data), rest)
            };
    }
}