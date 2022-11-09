using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.Core.Parsers {

    public class Repeat<A> : IParser<IReadOnlyCollection<A>> {

        private readonly IParser<A> parser;
        private readonly int count;

        public Repeat(IParser<A> parser, int count) {
            this.parser = parser;
            this.count = count;
        }

        public (IReadOnlyCollection<A>, ArraySegment<byte>)? Parse(
            ArraySegment<byte> input
        ) {
            var data = new List<A>(this.count);
            var bytes = input;

            foreach (var _ in Enumerable.Range(0, this.count)) {
                var result = this.parser.Parse(bytes);
                if (result == null) {
                    return null;
                }

                var (item, rest) = result.Value;

                data.Add(item);
                bytes = rest;
            }

            return (data, bytes);
        }
    }
}
