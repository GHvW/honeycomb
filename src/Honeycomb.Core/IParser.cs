using System;
using System.Collections.Generic;
using Honeycomb.Core.Parsers;

namespace Honeycomb.Core {

    public interface IParser<A> {

        public (A, ReadOnlyMemory<byte>)? Parse(ReadOnlyMemory<byte> input);
    }
}


namespace Honeycomb.Core {

    public static class ParserOps {

        public static IParser<B> Select<A, B>(
            this IParser<A> @this, 
            Func<A, B> fn
        ) =>
            new Map<A, B>(fn, @this);

        public static IParser<B> SelectMany<A, B>(
            this IParser<A> @this, 
            Func<A, IParser<B>> fn
        ) =>
            new Bind<A, B>(fn, @this);

        public static IParser<C> SelectMany<A, B, C>(
            this IParser<A> @this, 
            Func<A, IParser<B>> fn, Func<A, B, C> selector
        ) =>
            new BindWithSelector<A, B, C>(fn, selector, @this);

        public static IParser<A> Or<A>(
            this IParser<A> @this, 
            IParser<A> other
        ) =>
            new Or<A>(@this, other);

        public static IParser<(A, B)> And<A, B>(
            this IParser<A> @this, 
            IParser<B> other
        ) =>
            new And<A, B>(@this, other);

        public static IParser<IReadOnlyCollection<A>> Repeat<A>(
            this IParser<A> @this, 
            int times 
        ) =>
            new Repeat<A>(@this, times);
    }
}