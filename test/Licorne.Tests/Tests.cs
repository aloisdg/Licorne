﻿using System;
using Licorne;
using Xunit;

namespace Tests {
    public class Tests {
        [Theory]
        [InlineData (288.8, 88, 51, 199, 20, 240)]
        [InlineData (0, 0, 100, 255, 255, 255)] //white
        [InlineData (0, 0, 0, 0, 0, 0)] //black
        //[InlineData (120, 1, 6, 15, 15, 15)] //grey // rgb(15,15,15) => hsl(0,0%,5.88%)
        //[InlineData (120, 24, 97, 246, 249, 246)] // rgb(246,249,246) => hsl(120,20%,97.06%)
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
        [Theory]
        [InlineData (120, 1, 6, 15, 15, 15)] //grey // rgb(15,15,15) => hsl(0,0%,5.88%)
        public static void TryGrey(double h, double s, double l, double r, double g, double b) {
            var expected = new Hsl (h, s, l);
            var actual = new Hsl (new Rgb (r, g, b));
            // Assert.Equal(expected, actual);

            Assert.Equal (expected.H, actual.H, 1);
            Assert.Equal (expected.S, actual.S, 1);
            Assert.Equal (expected.L, actual.L, 1);
        }
    }
}