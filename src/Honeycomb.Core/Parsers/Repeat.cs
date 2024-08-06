using System;
using System.Collections.Generic;
using System.Linq;


namespace Honeycomb.Core.Parsers {

    public class Repeat<A> : IParser<IReadOnlyCollection<A>> {

        private readonly IParser<A> parser;
        private readonly int times;

        public Repeat(IParser<A> parser, int times) {
            this.parser = parser;
            this.times = times;
        }

        public ParseResult<IReadOnlyCollection<A>>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) {
            var data = new List<A>(this.times);
            var bytesIndex = currentIndex;

            foreach (var _ in Enumerable.Range(0, this.times)) {
                var result = this.parser.Parse(bytesIndex, input);
                if (result == null) {
                    return null;
                }

                var (item, restIndex) = result.Value;

                data.Add(item);
                bytesIndex = restIndex;
            }

            return new ParseResult<IReadOnlyCollection<A>>(data, bytesIndex);
        }
    }
}
