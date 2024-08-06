using System;

namespace Honeycomb.Core.Parsers {

    public class And<A, B> : IParser<(A, B)> {

        private readonly IParser<A> first;
        private readonly IParser<B> second;

        public And(IParser<A> first, IParser<B> second) {
            this.first = first;
            this.second = second;
        }

        public ParseResult<(A, B)>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) =>
            this.first.Parse(currentIndex, input) switch {
                null => null,
                (var data, var nextIndex) => this.second.Parse(nextIndex, input) switch {
                    null => null,
                    (var data2, var lastIndex) => new ParseResult<(A, B)>((data, data2), lastIndex)
                }
            };
    }

    public class And3<A, B, C> : IParser<(A, B, C)> {

        private readonly IParser<A> first;
        private readonly IParser<B> second;
        private readonly IParser<C> third;

        public And3(
            IParser<A> first, 
            IParser<B> second, 
            IParser<C> third
        ) {
            this.first = first;
            this.second = second;
            this.third = third;
        }

        public ParseResult<(A, B, C)>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) =>
            this.first.Parse(currentIndex, input) switch {
                null => null,
                (var data, var nextIndex) => this.second.Parse(nextIndex, input) switch {
                    null => null,
                    (var data2, var nextIndex2) => this.third.Parse(nextIndex2, input) switch {
                        null => null,
                        (var data3, var nextIndex3) => new ParseResult<(A, B, C)>((data, data2, data3), nextIndex3)
                    }
                }
            };
    }


    public class And4<A, B, C, D> : IParser<(A, B, C, D)> {

        private readonly IParser<A> first;
        private readonly IParser<B> second;
        private readonly IParser<C> third;
        private readonly IParser<D> fourth;

        public And4(
            IParser<A> first,
            IParser<B> second,
            IParser<C> third,
            IParser<D> fourth
        ) {
            this.first = first;
            this.second = second;
            this.third = third;
            this.fourth = fourth;
        }

        public ParseResult<(A, B, C, D)>? Parse(
            int currentIndex,
            ReadOnlySpan<byte> input
        ) =>
            this.first.Parse(currentIndex, input) switch {
                null => null,
                (var data, var nextIndex) => this.second.Parse(nextIndex, input) switch {
                    null => null,
                    (var data2, var nextIndex2) => this.third.Parse(nextIndex2, input) switch {
                        null => null,
                        (var data3, var nextIndex3) => this.fourth.Parse(nextIndex3, input) switch {
                            null => null,
                            (var data4, var lastIndex) => new ParseResult<(A, B, C, D)>((data, data2, data3, data4), lastIndex)
                        }
                    }
                }
            };
    }
}