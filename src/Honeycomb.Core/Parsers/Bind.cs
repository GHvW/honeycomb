using System;

namespace Honeycomb.Core.Parsers {

    public class Bind<A, B> : IParser<B> {

        private readonly IParser<A> parser;
        private readonly Func<A, IParser<B>> fn;

        public Bind(Func<A, IParser<B>> fn, IParser<A> parser) {

            this.parser = parser;
            this.fn = fn;
        }

        public (B, ArraySegment<byte>)? Parse(
            ArraySegment<byte> input
        ) =>
            this.parser.Parse(input) switch {
                null => null,
                (var data, var rest) => this.fn(data).Parse(rest)
            };
    }
}