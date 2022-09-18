using NUnit.Framework;

namespace ProjectEuler.XorDecryption
{
    [TestFixture]
    public class DecoderTests
    {
        private Decoder _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Decoder();
        }

        [Test]
        [TestCase(0b00, 0b00, 0b00)]
        [TestCase(0b00, 0b01, 0b01)]
        [TestCase(0b01, 0b00, 0b01)]
        [TestCase(0b01, 0b01, 0b00)]
        [TestCase(0b11, 0b00, 0b11)]
        [TestCase(0b10, 0b01, 0b11)]
        [TestCase(0b10, 0b10, 0b00)]
        public void ShouldDecode(byte cipherByte, byte keyByte, byte expectedByte)
        {
            var actual = new byte[1];

            _sut.Decode(new[] { cipherByte }, new[] { keyByte }, actual);

            Assert.That(actual[0], Is.EqualTo(expectedByte));
        }

        [Test]
        public void ShouldDecode()
        {
            var cipherBytes = new byte[] { 0b00, 0b01, 0b10, 0b11, 0b00, 0b01 };
            var key = new byte[] { 0b10, 0b01, 0b11 };
            var actual = new byte[6];

            var expected = new byte[] { 0b10, 0b00, 0b01, 0b01, 0b01, 0b10 };

            _sut.Decode(cipherBytes, key, actual);

            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}
