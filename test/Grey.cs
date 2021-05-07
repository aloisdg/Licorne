using System;
using Xunit;

namespace Licorne.Tests {
    public class Grey {
        [Theory]
        [InlineData (120, 1, 6, 15, 15, 15)] //grey // rgb(15,15,15) => hsl(0,0%,5.88%)
        [InlineData (0, 0, 0, 0, 0, 0)]
        [InlineData (0, 0, 5, 13, 13, 13)]
        [InlineData (0, 0, 10, 26, 26, 26)]
        [InlineData (0, 0, 15, 38, 38, 38)]
        [InlineData (0, 0, 20, 51, 51, 51)]
        [InlineData (0, 0, 25, 64, 64, 64)]
        [InlineData (0, 0, 30, 77, 77, 77)]
        [InlineData (0, 0, 35, 89, 89, 89)]
        [InlineData (0, 0, 40, 102, 102, 102)]
        [InlineData (0, 0, 45, 115, 115, 115)]
        [InlineData (0, 0, 50, 128, 128, 128)]
        [InlineData (0, 0, 55, 140, 140, 140)]
        [InlineData (0, 0, 60, 153, 153, 153)]
        [InlineData (0, 0, 65, 166, 166, 166)]
        [InlineData (0, 0, 70, 179, 179, 179)]
        [InlineData (0, 0, 75, 191, 191, 191)]
        [InlineData (0, 0, 80, 204, 204, 204)]
        [InlineData (0, 0, 85, 217, 217, 217)]
        [InlineData (0, 0, 90, 230, 230, 230)]
        [InlineData (0, 0, 95, 242, 242, 242)]
        [InlineData (0, 0, 100, 255, 255, 255)]
        [InlineData (0, 25, 0, 0, 0, 0)] // black
        [InlineData (0, 50, 0, 0, 0, 0)]
        [InlineData (0, 75, 0, 0, 0, 0)]
        [InlineData (0, 100, 0, 0, 0, 0)]
        [InlineData (60, 25, 0, 0, 0, 0)]
        [InlineData (60, 50, 0, 0, 0, 0)]
        [InlineData (60, 75, 0, 0, 0, 0)]
        [InlineData (60, 100, 0, 0, 0, 0)]
        [InlineData (120, 25, 0, 0, 0, 0)]
        [InlineData (120, 50, 0, 0, 0, 0)]
        [InlineData (120, 75, 0, 0, 0, 0)]
        [InlineData (120, 100, 0, 0, 0, 0)]
        [InlineData (180, 25, 0, 0, 0, 0)]
        [InlineData (180, 50, 0, 0, 0, 0)]
        [InlineData (180, 75, 0, 0, 0, 0)]
        [InlineData (180, 100, 0, 0, 0, 0)]
        [InlineData (240, 25, 0, 0, 0, 0)]
        [InlineData (240, 50, 0, 0, 0, 0)]
        [InlineData (240, 75, 0, 0, 0, 0)]
        [InlineData (240, 100, 0, 0, 0, 0)]
        [InlineData (300, 25, 0, 0, 0, 0)]
        [InlineData (300, 50, 0, 0, 0, 0)]
        [InlineData (300, 75, 0, 0, 0, 0)]
        [InlineData (300, 100, 0, 0, 0, 0)]
        [InlineData (0, 25, 100, 255, 255, 255)] // white
        [InlineData (0, 50, 100, 255, 255, 255)]
        [InlineData (0, 75, 100, 255, 255, 255)]
        [InlineData (0, 100, 100, 255, 255, 255)]
        [InlineData (60, 25, 100, 255, 255, 255)]
        [InlineData (60, 50, 100, 255, 255, 255)]
        [InlineData (60, 75, 100, 255, 255, 255)]
        [InlineData (60, 100, 100, 255, 255, 255)]
        [InlineData (120, 25, 100, 255, 255, 255)]
        [InlineData (120, 50, 100, 255, 255, 255)]
        [InlineData (120, 75, 100, 255, 255, 255)]
        [InlineData (120, 100, 100, 255, 255, 255)]
        [InlineData (180, 25, 100, 255, 255, 255)]
        [InlineData (180, 50, 100, 255, 255, 255)]
        [InlineData (180, 75, 100, 255, 255, 255)]
        [InlineData (180, 100, 100, 255, 255, 255)]
        [InlineData (240, 25, 100, 255, 255, 255)]
        [InlineData (240, 50, 100, 255, 255, 255)]
        [InlineData (240, 75, 100, 255, 255, 255)]
        [InlineData (240, 100, 100, 255, 255, 255)]
        [InlineData (300, 25, 100, 255, 255, 255)]
        [InlineData (300, 50, 100, 255, 255, 255)]
        [InlineData (300, 75, 100, 255, 255, 255)]
        [InlineData (300, 100, 100, 255, 255, 255)]
        public static void TryGrey(double h, double s, double l, double r, double g, double b) {
            var expected = new Hsl (h, s, l);
            var actual = new Hsl (new Rgb (r, g, b));

            const double greyHue = 0;
            const double greySaturation = 0;
            const double precision = .2;

            Assert.Equal (greyHue, actual.H);
            Assert.Equal (greySaturation, actual.S);
            Assert.True (Math.Abs ((double) (expected.L - actual.L)) <= precision);
        }

        [Theory]
        [InlineData (0, 25, 50, 159, 96, 96)]
        [InlineData (60, 25, 50, 159, 159, 96)]
        [InlineData (120, 25, 50, 96, 159, 96)]
        [InlineData (180, 25, 50, 96, 159, 159)]
        [InlineData (240, 25, 50, 96, 96, 159)]
        [InlineData (300, 25, 50, 159, 96, 159)]
        [InlineData (0, 75, 50, 223, 32, 32)]
        [InlineData (60, 75, 50, 223, 223, 32)]
        [InlineData (120, 75, 50, 32, 223, 32)]
        [InlineData (180, 75, 50, 32, 223, 223)]
        [InlineData (240, 75, 50, 32, 32, 223)]
        [InlineData (300, 75, 50, 223, 32, 223)]
        public static void TryAlmostGrey(double h, double s, double l, double r, double g, double b) {
            var expected = new Hsl (h, s, l);
            var actual = new Hsl (new Rgb (r, g, b));

            const double precision = .3;

            Assert.True (Math.Abs ((double) (expected.H - actual.H)) <= precision);
            Assert.True (Math.Abs ((double) (expected.S - actual.S)) <= precision);
            Assert.True (Math.Abs ((double) (expected.L - actual.L)) <= precision);
        }
    }
}