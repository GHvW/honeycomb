using System;

namespace Honeycomb.Core.Parsers {

    public class And<A, B> : IParser<(A, B)> {

        private readonly IParser<A> first;
        private readonly IParser<B> second;

        public And(IParser<A> first, IParser<B> second) {
            this.first = first;
            this.second = second;
        }

        public ((A, B), ReadOnlyMemory<byte>)? Parse(
            ReadOnlyMemory<byte> input
        ) =>
            this.first.Parse(input) switch {
                null => null,
                (var data, var rest) => this.second.Parse(rest) switch {
                    null => null,
                    (var data2, var leftover) => ((data, data2), leftover)
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

        public ((A, B, C), ReadOnlyMemory<byte>)? Parse(
            ReadOnlyMemory<byte> input
        ) =>
            this.first.Parse(input) switch {
                null => null,
                (var data, var rest) => this.second.Parse(rest) switch {
                    null => null,
                    (var data2, var leftover) => this.third.Parse(leftover) switch {
                        null => null,
                        (var data3, var leftover2) => ((data, data2, data3), leftover2)
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

        public ((A, B, C, D), ReadOnlyMemory<byte>)? Parse(
            ReadOnlyMemory<byte> input
        ) =>
            this.first.Parse(input) switch {
                null => null,
                (var data, var rest) => this.second.Parse(rest) switch {
                    null => null,
                    (var data2, var leftover) => this.third.Parse(leftover) switch {
                        null => null,
                        (var data3, var leftover2) => this.fourth.Parse(leftover2) switch {
                            null => null,
                            (var data4, var leftover3) => ((data, data2, data3, data4), leftover3)
                        }
                    }
                }
            };
    }
}