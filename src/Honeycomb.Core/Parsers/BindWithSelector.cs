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

        public (C, ReadOnlyMemory<byte>)? Parse(
            ReadOnlyMemory<byte> input
        ) =>
            this.parser.Parse(input) switch {
                null => null,
                (var a, var rest) => this.fn(a).Parse(rest) switch {
                    null => null,
                    (var b, var leftover) => (this.selector(a, b), leftover)
                }
            };
    }
}