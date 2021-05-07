using System;
using Licorne;
using Xunit;

namespace Tests
{
    public class Range
    {
        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(361, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 101, 0)]
        [InlineData(0, 0, -1)]
        [InlineData(0, 0, 101)]
        public void BreakHsl(double h, double s, double l)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Hsl(h, s, l));
        }

        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(256, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 256, 0)]
        [InlineData(0, 0, -1)]
        [InlineData(0, 0, 256)]
        public void BreakRgb(double r, double g, double b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rgb(r, g, b));
        }
    }
}