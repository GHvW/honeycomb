using FluentAssertions;

using Honeycomb.Core.PrimitiveParsers;

using System;

using Xunit;

namespace Honeycomb.Core.Tests.PrimitiveParserTests {

    public class GivenABufferOfBytes {

        private readonly ArraySegment<byte> buffer;

        public GivenABufferOfBytes() {
            var bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            this.buffer = bytes;
        }

        [Fact]
        public void WhenParsingASingleByte() {

            var result = new Octet().Parse(0, this.buffer);

            result.Should().NotBeNull();

            result!.Value.Item.Should().Be(1);

            result!.Value.CurrentIndex.Should().Be(1);
        }


        [Fact]
        public void WhenParsingToALittleEndianDouble() {
            var result = new LittleDouble().Parse(0, this.buffer);

            result.Should().NotBeNull();

            var actual = BitConverter.GetBytes(result!.Value.Item);

            actual[0].Should().Be(1);
            actual[1].Should().Be(2);
            actual[2].Should().Be(3);
            actual[3].Should().Be(4);
            actual[4].Should().Be(5);
            actual[5].Should().Be(6);
            actual[6].Should().Be(7);
            actual[7].Should().Be(8);
        }


        [Fact]
        public void WhenParsingToABigEndianDouble() {
            var result = new BigDouble().Parse(0, this.buffer);

            result.Should().NotBeNull();

            var actual = BitConverter.GetBytes(result!.Value.Item);

            actual[0].Should().Be(8);
            actual[1].Should().Be(7);
            actual[2].Should().Be(6);
            actual[3].Should().Be(5);
            actual[4].Should().Be(4);
            actual[5].Should().Be(3);
            actual[6].Should().Be(2);
            actual[7].Should().Be(1);
        }
    }
}
