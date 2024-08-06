using System;
using System.Collections.Generic;

namespace Honeycomb.Core.Parsers {

    public class Many<A> : IParser<IReadOnlyCollection<A>> {

        private readonly IParser<A> parser;

        public Many(IParser<A> parser) {
            this.parser = parser;
        }

        public ParseResult<IReadOnlyCollection<A>>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) {
            var result = new List<A>();
            var restIndex = currentIndex;
            var parsed = this.parser.Parse(restIndex, input);
            while (parsed is not null) {
                var (item, leftoverIndex) = parsed.Value;
                result.Add(item);
                restIndex = leftoverIndex;
                parsed = this.parser.Parse(restIndex, input);
            }

            return new ParseResult<IReadOnlyCollection<A>>(result, restIndex);
        }
    }
}
