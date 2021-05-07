using Xunit;

namespace Licorne.Tests {
    public class Hue {
        [Theory]
        [InlineData (0, 50, 50, 191, 64, 64)]
        [InlineData (10, 50, 50, 191, 85, 64)]
        [InlineData (20, 50, 50, 191, 106, 64)]
        [InlineData (30, 50, 50, 191, 128, 64)]
        [InlineData (40, 50, 50, 191, 149, 64)]
        [InlineData (50, 50, 50, 191, 170, 64)]
        [InlineData (60, 50, 50, 191, 191, 64)]
        [InlineData (70, 50, 50, 170, 191, 64)]
        [InlineData (80, 50, 50, 149, 191, 64)]
        [InlineData (90, 50, 50, 128, 191, 64)]
        [InlineData (100, 50, 50, 106, 191, 64)]
        [InlineData (110, 50, 50, 85, 191, 64)]
        [InlineData (120, 50, 50, 64, 191, 64)]
        [InlineData (130, 50, 50, 64, 191, 85)]
        [InlineData (140, 50, 50, 64, 191, 106)]
        [InlineData (150, 50, 50, 64, 191, 128)]
        [InlineData (160, 50, 50, 64, 191, 149)]
        [InlineData (170, 50, 50, 64, 191, 170)]
        [InlineData (180, 50, 50, 64, 191, 191)]
        [InlineData (190, 50, 50, 64, 170, 191)]
        [InlineData (200, 50, 50, 64, 149, 191)]
        [InlineData (210, 50, 50, 64, 128, 191)]
        [InlineData (220, 50, 50, 64, 106, 191)]
        [InlineData (230, 50, 50, 64, 85, 191)]
        [InlineData (240, 50, 50, 64, 64, 191)]
        [InlineData (250, 50, 50, 85, 64, 191)]
        [InlineData (260, 50, 50, 106, 64, 191)]
        [InlineData (270, 50, 50, 128, 64, 191)]
        [InlineData (280, 50, 50, 149, 64, 191)]
        [InlineData (290, 50, 50, 170, 64, 191)]
        [InlineData (300, 50, 50, 191, 64, 191)]
        [InlineData (310, 50, 50, 191, 64, 170)]
        [InlineData (320, 50, 50, 191, 64, 149)]
        [InlineData (330, 50, 50, 191, 64, 128)]
        [InlineData (340, 50, 50, 191, 64, 106)]
        [InlineData (350, 50, 50, 191, 64, 85)]
        [InlineData (0, 50, 50, 191, 64, 64)]
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