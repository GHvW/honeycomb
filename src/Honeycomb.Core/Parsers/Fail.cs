namespace Honeycomb.Core.Parsers
{
    public record Fail() : IParser<A>
    {
        public (A, ArraySegment<byte>)? Parse(ArraySegment<byte> input) => null;
    }
}