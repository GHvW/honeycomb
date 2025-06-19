using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

using Honeycomb.Core.Parsers;

namespace Honeycomb.Core {

    public readonly record struct ParseResult<A>(A Item, int CurrentIndex);

    public interface IParser<A> {

        public ParseResult<A>? Parse(int currentIndex, ReadOnlySpan<byte> input);
    }
}


namespace Honeycomb.Core {

    public static class ParserOps {

        public static IParser<B> Select<A, B>(
            this IParser<A> @this, 
            Func<A, B> fn
        ) =>
            new Map<A, B>(fn, @this);


        public static IParser<C> Select<A, B, C>(
            this IParser<A> @this,
            IParser<B> second,
            Func<A, B, C> selector
        ) =>
            @this
                .And(second)
                .Select(it => selector(it.Item1, it.Item2));


        public static IParser<D> Select<A, B, C, D>(
            this IParser<A> @this,
            IParser<B> second,
            IParser<C> third,
            Func<A, B, C, D> selector
        ) =>
            @this
                .And(second, third)
                .Select(it => selector(it.Item1, it.Item2, it.Item3));

        public static IParser<D> Select<A, B, C, D, E>(
            this IParser<A> @this,
            IParser<B> second,
            IParser<C> third,
            IParser<D> fourth,
            Func<A, B, C, D> selector
        ) =>
            @this
                .And(second, third, fourth)
                .Select(it => selector(it.Item1, it.Item2, it.Item3));


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


        public static IParser<(A, B, C)> And<A, B, C>(
            this IParser<A> @this,
            IParser<B> second, 
            IParser<C> third
        ) =>
            new And3<A, B, C>(@this, second, third);


        public static IParser<(A, B, C, D)> And<A, B, C, D>(
            this IParser<A> @this,
            IParser<B> second, 
            IParser<C> third,
            IParser<D> fourth
        ) =>
            new And4<A, B, C, D>(@this, second, third, fourth);


        public static IParser<IReadOnlyCollection<A>> Repeat<A>(
            this IParser<A> @this, 
            int times 
        ) =>
            new Repeat<A>(@this, times);

        public static IParser<A> Where<A>(
            this IParser<A> @this,
            Predicate<A> predicate
        ) =>
            new Where<A>(predicate, @this);
    }
}