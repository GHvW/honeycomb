using System;

namespace Honeycomb.Core.Parsers {

    public record Map<A, B>(Func<A, B> Fn, IParser<A> Parser) : IParser<B> {

        public (B, ArraySegment<byte>)? Parse(ArraySegment<byte> input) =>
            this.Parser.Parse(input) switch {
                null => null,
                (var data, var rest) => (this.Fn(data), rest)
            };
    }
}