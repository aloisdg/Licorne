using System;
using Licorne;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Theory]
        [InlineData (288.8, 88, 51, 199, 20, 240)]
        [InlineData (0, 0, 100, 255, 255, 255)] //white
        [InlineData (0, 0, 0, 0, 0, 0)] //black
        public void MyFirstTheory(double h, double s, double l, double r, double g, double b) {
            var expected = new Hsl (h, s, l);
            var actual = new Hsl (new Rgb (r, g, b));
            // Assert.Equal(expected, actual);
            Assert.True (BasicallyEquals (expected, actual));
        }

        public static bool BasicallyEquals(Hsl one, Hsl two)
        {
           return one.H - two.H < 1
                  && one.S - two.S < 1
                  && one.L - two.L < 1;
        }
    }
}
