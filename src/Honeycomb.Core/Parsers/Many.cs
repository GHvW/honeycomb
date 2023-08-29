using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace Honeycomb.Core.Parsers {

    public class Many<A> : IParser<ReadOnlyCollection<A>> {

        private readonly IParser<A> parser;

        public Many(IParser<A> parser) {
            this.parser = parser;
        }

        public (ImmutableList<A>, ReadOnlyCollection<byte>)? Parse(
            ReadOnlyCollection<byte> input
        ) {
            
        }
    }
}
