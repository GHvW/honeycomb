namespace Honeycomb.Core.Parsers
{

    public record BindWithSelector<A, B, C>(Func<A, IParser<B>> fn, Func<A, B, C> selector, IParser<A> parser) : IParser<C>
    {
        public (B, ArraySegment<byte>)? Parse(ArraySegment<byte> input) =>
            parser.Parse(input) switch
            {
                null => null,
                (var a, var rest) => fn(data).Parse(rest) switch
                {
                    null => null,
                    (var b, var leftover) => (selector(a, b), leftover)
                }
            };
    }
}