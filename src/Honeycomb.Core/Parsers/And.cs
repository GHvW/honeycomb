namespace Honeycomb.Core.Parsers
{
    public record And<A, B>(IParser<A> first, IParser<B> second) : IParser<(A, B)>
    {
        public ((A, B), ArraySegment<byte>)? Parse(ArraySegment<byte> input) =>
            (from a in first
             from b in second
             select (a, b))
            .Parse(input);
    }
}