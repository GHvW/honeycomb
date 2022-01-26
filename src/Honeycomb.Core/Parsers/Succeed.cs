namespace Honeycomb.Core.Parsers
{
    public record Succeed(A data) : IParser<A>
    {
        public (A, ArraySegment<byte>)? Parse(ArraySegment<byte> input) => (data, input);
    }
}