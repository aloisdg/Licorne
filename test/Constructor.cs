using System;
using System.Linq;
using Licorne;
using Xunit;

namespace Tests {
    public class Constructor {
        [Theory]
        [InlineData (0, 0, 0)]
        [InlineData (42, 42, 42)]
        [InlineData (100, 100, 100)]
        [InlineData (255, 100, 100)]
        public void TryByte(byte a, byte b, byte c) {
            var expected = new[] { a, b, c };
            var hsl = new Hsl (a, b, c);
            var actual = new double[] { hsl.H, hsl.S, hsl.L }.Select (Convert.ToByte).ToArray ();
            Assert.Equal (expected, actual);
        }

        [Theory]
        [InlineData (0, 0, 0)]
        [InlineData (42, 42, 42)]
        [InlineData (100, 100, 100)]
        [InlineData (360, 100, 100)]
        public void TryInt(int a, int b, int c) {
            var expected = new[] { a, b, c };
            var hsl = new Hsl (a, b, c);
            var actual = new double[] { hsl.H, hsl.S, hsl.L }.Select (Convert.ToInt32).ToArray ();
            Assert.Equal (expected, actual);
        }

        [Theory]
        [InlineData (0.0f, 0.0f, 0.0f)]
        [InlineData (42f, 42f, 42f)]
        [InlineData (100f, 100f, 100f)]
        [InlineData (360f, 100f, 100f)]
        public void TryFloat(float a, float b, float c) {
            var expected = new[] { a, b, c };
            var hsl = new Hsl (a, b, c);
            var actual = new double[] { hsl.H, hsl.S, hsl.L }.Select (Convert.ToSingle).ToArray ();
            Assert.Equal (expected, actual);
        }
    }
}