// Licorne Is Colors Of Rgb Naturally Easy
// LIght COlor Rendered Naive & Easy

namespace Licorne {
    public class Rgb {
        public double R { get; }
        public double G { get; }
        public double B { get; }

        public Rgb(double r, double g, double b) {
            R = r;
            G = g;
            B = b;
        }

        public Rgb(Rgb color) {
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public Rgb(Hsl color) {
            var rangedH = color.H / 360.0;
            var r = 0.0;
            var g = 0.0;
            var b = 0.0;
            var saturation = color.S / 100.0;
            var luminosity = color.L / 100.0;

            if (BasicallyEqualTo (luminosity, 0)) {
                R = 255.0 * r;
                G = 255.0 * g;
                B = 255.0 * b;
            }
            else {
                if (BasicallyEqualTo (saturation, 0))
                    r = g = b = luminosity;
                else {
                    var temp2 = luminosity * (luminosity < 0.5
                        ? 1.0 + saturation
                        : 1.0 - saturation + saturation / luminosity);
                    var temp1 = 2.0 * luminosity - temp2;

                    r = GetColorComponent (temp1, temp2, rangedH + 1.0 / 3.0);
                    g = GetColorComponent (temp1, temp2, rangedH);
                    b = GetColorComponent (temp1, temp2, rangedH - 1.0 / 3.0);
                }
                R = 255.0 * r;
                G = 255.0 * g;
                B = 255.0 * b;
            }
        }

        private static double GetColorComponent(double temp1, double temp2, double temp3) {
            var temp3InRange = temp3 + (temp3 < 0.0 ? 1 : (temp3 > 1.0 ? -1 : 0));
            if (temp3InRange < 1.0 / 6.0)
                return temp1 + (temp2 - temp1) * 6.0 * temp3InRange;
            if (temp3InRange < 0.5)
                return temp2;
            if (temp3 < 2.0 / 3.0)
                return temp1 + (temp2 - temp1) * 6.0 * (2.0 / 3.0 - temp3InRange);
            return temp1;
        }

        private const double DefaultPrecision = .0001;

        private static bool BasicallyEqualTo(double a, double b, double precision = DefaultPrecision) {
            return System.Math.Abs (a - b) <= precision;
        }
    }
}