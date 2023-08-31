using System;
using System.Collections.Generic;

namespace Honeycomb.Core.Parsers {

    public class Many<A> : IParser<IReadOnlyCollection<A>> {

        private readonly IParser<A> parser;

        public Many(IParser<A> parser) {
            this.parser = parser;
        }

        public (IReadOnlyCollection<A>, ReadOnlyMemory<byte>)? Parse(
            ReadOnlyMemory<byte> input
        ) {
            var result = new List<A>();
            var rest = input;
            var parsed = this.parser.Parse(rest);
            while (parsed is not null) {
                var (item, leftover) = parsed.Value;
                result.Add(item);
                rest = leftover;
                parsed = this.parser.Parse(rest);
            }

            return (result, rest);
        }
    }
}
