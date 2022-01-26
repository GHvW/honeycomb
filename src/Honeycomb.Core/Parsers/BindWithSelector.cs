using System;

namespace Honeycomb.Core.Parsers {

    public record BindWithSelector<A, B, C>(Func<A, IParser<B>> Fn, Func<A, B, C> Selector, IParser<A> Parser) : IParser<C> {

        public (C, ArraySegment<byte>)? Parse(ArraySegment<byte> input) =>
            this.Parser.Parse(input) switch {
                null => null,
                (var a, var rest) => this.Fn(a).Parse(rest) switch {
                    null => null,
                    (var b, var leftover) => (this.Selector(a, b), leftover)
                }
            };
    }
}