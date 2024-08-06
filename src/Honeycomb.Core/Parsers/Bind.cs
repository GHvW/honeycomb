using System;

namespace Honeycomb.Core.Parsers {

    public class Bind<A, B> : IParser<B> {

        private readonly IParser<A> parser;
        private readonly Func<A, IParser<B>> fn;

        public Bind(
            Func<A, IParser<B>> fn, 
            IParser<A> parser
        ) {
            this.parser = parser;
            this.fn = fn;
        }

        public ParseResult<B>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) =>
            this.parser.Parse(currentIndex, input) switch {
                null => null,
                (var data, var restIndex) => this.fn(data).Parse(restIndex, input)
            };
    }
}