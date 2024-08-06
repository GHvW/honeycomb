using System;

namespace Honeycomb.Core.Parsers {

    public class Map<A, B> : IParser<B> {

        private readonly Func<A, B> fn;
        private readonly IParser<A> parser;

        public Map(Func<A, B> fn, IParser<A> parser) {
            this.parser = parser;
            this.fn = fn;
        }

        public ParseResult<B>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) =>
            this.parser.Parse(currentIndex, input) switch {
                null => null,
                (var data, var nextIndex) => new ParseResult<B>(this.fn(data), nextIndex)
            };
    }
}