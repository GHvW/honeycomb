using System;

namespace Honeycomb.Core.Parsers {

    public class Fail<A> : IParser<A> {

        public (A, ReadOnlyMemory<byte>)? Parse(
            ReadOnlyMemory<byte> input
        ) => 
            null;
    }
}