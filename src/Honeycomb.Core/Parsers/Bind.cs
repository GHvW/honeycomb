namespace Honeycomb.Core.Parsers
{

    public record Bind<A, B>(Func<A, IParser<B>> fn, IParser<A> parser) : IParser<B>
    {
        public (B, ArraySegment<byte>)? Parse(ArraySegment<byte> input) =>
            parser.Parse(input) switch
            {
                null => null,
                (var data, var rest) => fn(data).Parse(rest)
            };
    }
}