using System;

namespace Honeycomb.Core.Parsers {

    public record Succeed<A> : IParser<A> {

        private readonly A data;

        public Succeed(A data) {
            this.data = data;
        }

        public (A, ArraySegment<byte>)? Parse(
            ArraySegment<byte> input
        ) => 
            (this.data, input);
    }
}