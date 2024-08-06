using System;

namespace Honeycomb.Core.Parsers {

    public class Fail<A> : IParser<A> {

        public ParseResult<A>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) => 
            null;
    }
}