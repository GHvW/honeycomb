namespace Honeycomb.Core.Parsers
{

    public record Map<A, B>(Func<A, B> fn, IParser<A> parser) : IParser<B>
    {
        public (B, ArraySegment<byte>)? Parse(ArraySegment<byte> input) =>
            parser.Parse(input) switch
            {
                null => null,
                (var data, var rest) => (fn(data), rest)
            };
    }
}