using System;

namespace Honeycomb.Core {

    public interface IParser<A> {

        public (A, ArraySegment<byte>)? Parse(ArraySegment<byte> input);
    }
}