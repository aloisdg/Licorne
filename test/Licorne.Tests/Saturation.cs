using System.Diagnostics;
using Xunit;

namespace Licorne.Tests {
    public class Saturation {
        [Theory]
        //[InlineData (180, 0, 50, 128, 128, 128)]
        [InlineData (180, 5, 50, 121, 134, 134)]
        [InlineData (180, 10, 50, 115, 140, 140)]
        [InlineData (180, 15, 50, 108, 147, 147)]
        [InlineData (180, 20, 50, 102, 153, 153)]
        [InlineData (180, 25, 50, 96, 159, 159)]
        [InlineData (180, 30, 50, 89, 166, 166)]
        [InlineData (180, 35, 50, 83, 172, 172)]
        [InlineData (180, 40, 50, 76, 179, 179)]
        [InlineData (180, 45, 50, 70, 185, 185)]
        [InlineData (180, 50, 50, 64, 191, 191)]
        [InlineData (180, 55, 50, 57, 198, 198)]
        [InlineData (180, 60, 50, 51, 204, 204)]
        [InlineData (180, 65, 50, 45, 210, 210)]
        [InlineData (180, 70, 50, 38, 217, 217)]
        [InlineData (180, 75, 50, 32, 223, 223)]
        [InlineData (180, 80, 50, 25, 230, 230)]
        [InlineData (180, 85, 50, 19, 236, 236)]
        [InlineData (180, 90, 50, 13, 242, 242)]
        [InlineData (180, 95, 50, 6, 249, 249)]
        [InlineData (180, 100, 50, 0, 255, 255)]
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