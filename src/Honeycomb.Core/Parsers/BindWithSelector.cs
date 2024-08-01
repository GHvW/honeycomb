using System;

namespace Honeycomb.Core.Parsers {

    public class BindWithSelector<A, B, C> : IParser<C> {

        private readonly Func<A, IParser<B>> fn;
        private readonly Func<A, B, C> selector;
        private readonly IParser<A> parser;

        public BindWithSelector(
            Func<A, IParser<B>> fn,
            Func<A, B, C> selector,
            IParser<A> parser
        ) {
            this.parser = parser;
            this.selector = selector;
            this.fn = fn;
        }

        public ParseResult<C>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) =>
            this.parser.Parse(currentIndex, input) switch {
                null => null,
                (var a, var restIndex) => this.fn(a).Parse(restIndex, input) switch {
                    null => null,
                    (var b, var leftoverIndex) => new ParseResult<C>(this.selector(a, b), leftoverIndex)
                }
            };
    }
}