namespace HoneyComb.Core
{

    public static class ParserOps
    {

        public static Parser<B> Select<A, B>(this IParser<A> @this, Func<A, B> fn) =>
            new Map(fn, @this);

        public static Parser<B> SelectMany<A, B>(this IParser<A> @this, Func<A, Parser<B>> fn) =>
            new Bind(fn, @this);

        public static Parser<C> SelectMany<A, B, C>(this IParser<A> @this, Func<A, Parser<B>> fn, Func<A, B, C> selector) =>
            new BindWithSelector(fn, selector, @this);

        public static Parser<A> Or<A>(this IParser<A> @this, IParser<A> other) =>
            new Or<A>(@this, other);

        public static Parser<(A, B)> And<A, B>(this IParser<A> @this, IParser<B> other) =>
            new And<A>(@this, other);
    }
}