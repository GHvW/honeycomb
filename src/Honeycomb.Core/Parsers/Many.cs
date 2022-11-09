using System;
using System.Collections.Generic;
using System.Collections.Immutable;


namespace Honeycomb.Core.Parsers {

    public class Many<A> : IParser<ImmutableList<A>> {

        private readonly IParser<A> parser;

        public Many(IParser<A> parser) {
            this.parser = parser;
        }

        public (ImmutableList<A>, ArraySegment<byte>)? Parse(ArraySegment<byte> input) {
            return (from item in this.parser
                    from rest in new Many<A>(this.parser)
                    select rest.Add(item))
                   .Or(new Succeed<ImmutableList<A>>(ImmutableList.Create<A>()))
                   .Parse(input);
        }
    }
}
