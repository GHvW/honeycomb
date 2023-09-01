using System;


namespace Honeycomb.Core.PrimitiveParsers {

    public class ShortBytes : IParser<ReadOnlyMemory<byte>> {

        public (ReadOnlyMemory<byte>, ReadOnlyMemory<byte>)? Parse(
            ReadOnlyMemory<byte> input
        ) {
            try {
                return (input.Slice(0, 2), input.Slice(2));
            } catch {
                return null;
            }
        }
    }
}
