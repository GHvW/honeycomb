using System;

namespace Honeycomb.Core.PrimitiveParsers {

    public class Octet : IParser<byte> {

        public ParseResult<byte>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) {
            try {
                return new ParseResult<byte>(input[currentIndex], currentIndex + 1);
            } catch {
                return null;
            }
        }
    }
}
