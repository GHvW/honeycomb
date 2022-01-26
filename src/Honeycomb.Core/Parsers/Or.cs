namespace Honeycomb.Core.Parsers
{
    public record Or<A>(IParser<A> first, IParser<A> second) : IParser<A>
    {
        public (A, ArraySegment<byte>)? Parse(ArraySegment<byte> input) =>
            first.Parse(input) ?? second.Parse(input);
    }
}