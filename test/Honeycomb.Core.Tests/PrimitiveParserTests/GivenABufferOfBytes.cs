using FluentAssertions;

using Honeycomb.Core.PrimitiveParsers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Honeycomb.Core.Tests.PrimitiveParserTests {

    public class GivenABufferOfBytes {

        private readonly ArraySegment<byte> buffer;

        public GivenABufferOfBytes() {
            var bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            this.buffer = new ArraySegment<byte>(bytes);
        }

        [Fact]
        public void WhenParsingASingleByte() {

            var result = new Octet().Parse(this.buffer);

            result.Should().NotBeNull();

            result.Value.Item1.Should().Be(1);

            result.Value.Item2.Count.Should().Be(9);
            result.Value.Item2[0].Should().Be(2);
        }

        [Fact]
        public void WhenParsingBytesToFormAnInt32() {

            var result = new IntBytes().Parse(this.buffer);

            result.Should().NotBeNull();

            result.Value.Item1.Count.Should().Be(4);
            result.Value.Item1[0].Should().Be(1);

            result.Value.Item2.Count.Should().Be(6);
            result.Value.Item2[0].Should().Be(5);
        }

        [Fact]
        public void WhenParsingBytesToFormADouble() {

            var result = new DoubleBytes().Parse(this.buffer);

            result.Should().NotBeNull();

            result.Value.Item1.Count.Should().Be(8);
            result.Value.Item1[0].Should().Be(1);

            result.Value.Item2.Count.Should().Be(2);
            result.Value.Item2[0].Should().Be(9);
        }
    }
}
