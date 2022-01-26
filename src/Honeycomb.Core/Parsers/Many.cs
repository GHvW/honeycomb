using System;
using System.Collections.Generic;
using System.Collections.Immutable;


namespace Honeycomb.Core.Parsers {

    public record Many<A>(IParser<A> Parser) : IParser<ImmutableList<A>> {

        public (ImmutableList<A>, ArraySegment<byte>)? Parse(ArraySegment<byte> input) {
            return (from item in this.Parser
                    from rest in new Many<A>(this.Parser)
                    select rest.Add(item))
                   .Or(new Succeed<ImmutableList<A>>(ImmutableList.Create<A>()))
                   .Parse(input);
        }
    }
}
