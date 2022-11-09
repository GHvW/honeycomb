using System;

namespace Honeycomb.Core.Parsers {

    public class Fail<A> : IParser<A> {

        public (A, ArraySegment<byte>)? Parse(ArraySegment<byte> input) => null;
    }
}