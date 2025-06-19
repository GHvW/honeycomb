using System;


namespace Honeycomb.Core.Parsers;

public class Where<A>(Predicate<A> predicate, IParser<A> parser) : IParser<A> {

    public ParseResult<A>? Parse(int currentIndex, ReadOnlySpan<byte> input) {
        var result = parser.Parse(currentIndex, input);

        if (result.HasValue && predicate(result.Value.Item)) {
            return result;
        }

        return null;
    }
}
