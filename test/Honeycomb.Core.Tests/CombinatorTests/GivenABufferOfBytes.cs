using System;
using System.Collections.Generic;
using Xunit;

using FluentAssertions;

using Honeycomb.Core.Parsers;
using Honeycomb.Core.PrimitiveParsers;

namespace Honeycomb.Core.Tests.CombinatorTests {

    public class GivenABufferOfBytes {

        private readonly ReadOnlyMemory<byte> buffer;

        public GivenABufferOfBytes() {
            var bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            this.buffer = new ReadOnlyMemory<byte>(bytes);
        }

        [Fact]
        public void WhenParsing2Bytes() {

            var result = new Octet().Repeat(times: 2).Parse(this.buffer);

            result.Should().NotBeNull();

            result!.Value.Item1.Should().BeEquivalentTo(new List<int>() { 1, 2 });

            result!.Value.Item2.Length.Should().Be(8);
        }

        [Fact]
        public void WhenParsingManyBytesUpToANumber() {

            var parser = 
                new Octet()
                    .Select<byte, int>(it => it)
                    .SelectMany<int, int>(it => it < 3 ? new Succeed<int>(it) : new Fail<int>());

            var result = new Many<int>(parser).Parse(this.buffer);

            result.Should().NotBeNull();

            result!.Value.Item1.Should().BeEquivalentTo(new List<int>() { 1, 2 });

            result!.Value.Item2.Length.Should().Be(8);
        }

        [Fact]
        public void WhenParsingAByteAndAnotherByte() {

            var result = 
                new Octet().And(new Octet()).Parse(this.buffer);;

            result.Should().NotBeNull();

            result!.Value.Item1.Should().Be((1, 2));

            result!.Value.Item2.Length.Should().Be(8);
        }

        [Fact]
        public void WhenParsingAValidFirstByteOrAValidSecondByte() {

            var result = 
                new Octet().Or(new Octet()).Parse(this.buffer);;

            result.Should().NotBeNull();

            result!.Value.Item1.Should().Be(1);

            result!.Value.Item2.Length.Should().Be(9);
        }


        // TODO - find a wayt to do this test better
        [Fact]
        public void WhenParsingAnInvalidFirstByteOrAValidSecondByte() {

            var firstFail = 
                new Octet()
                    .SelectMany<byte, byte>(it => it == 100 ? new Succeed<byte>(it) : new Fail<byte>());

            var result = 
                firstFail.Or(new Octet()).Parse(this.buffer);

            result.Should().NotBeNull();

            result!.Value.Item1.Should().Be(1);

            result!.Value.Item2.Length.Should().Be(9);
        }
    }
}