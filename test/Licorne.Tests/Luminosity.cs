using Xunit;

namespace Licorne.Tests {
    public class Luminosity {
        [Theory]
        //[InlineData (180, 50, 0, 0, 0, 0)]
        [InlineData (180, 50, 5, 6, 19, 19)]
        [InlineData (180, 50, 10, 13, 38, 38)]
        [InlineData (180, 50, 15, 19, 57, 57)]
        [InlineData (180, 50, 20, 26, 77, 77)]
        [InlineData (180, 50, 25, 32, 96, 96)]
        [InlineData (180, 50, 30, 38, 115, 115)]
        [InlineData (180, 50, 35, 45, 134, 134)]
        [InlineData (180, 50, 40, 51, 153, 153)]
        [InlineData (180, 50, 45, 57, 172, 172)]
        [InlineData (180, 50, 50, 64, 191, 191)]
        [InlineData (180, 50, 55, 83, 198, 198)]
        [InlineData (180, 50, 60, 102, 204, 204)]
        [InlineData (180, 50, 65, 121, 210, 210)]
        [InlineData (180, 50, 70, 140, 217, 217)]
        [InlineData (180, 50, 75, 159, 223, 223)]
        [InlineData (180, 50, 80, 179, 230, 230)]
        [InlineData (180, 50, 85, 198, 236, 236)]
        [InlineData (180, 50, 90, 217, 242, 242)]
        [InlineData (180, 50, 95, 236, 249, 249)]
        //[InlineData (180, 50, 100, 255, 255, 255)]
        public void Convert(double h, double s, double l, double r, double g, double b) {
            var expected = new Hsl (h, s, l);
            var actual = new Hsl (new Rgb (r, g, b));
            // Assert.Equal(expected, actual);

            Assert.True (BasicallyEquals (expected, actual));
        }

        public static bool BasicallyEquals(Hsl one, Hsl two) {
            return one.H - two.H < 1
                   && one.S - two.S < 1
                   && one.L - two.L < 1;
        }
    }
}