// Licorne Is Colors Of Rgb Naturally Easy
// LIght COlor Rendered Naive & Easy

using System;

namespace Licorne {
    public class Rgb : IEquatable<Rgb> {
        public double R { get; }
        public double G { get; }
        public double B { get; }

        public Rgb(double r, double g, double b) {
            R = r;
            G = g;
            B = b;
        }

        public Rgb(Rgb color) : this (color.R, color.G, color.B) { }

        public Rgb(Hsl color) {
            var rangedH = color.H / 360.0;
            var r = 0.0;
            var g = 0.0;
            var b = 0.0;
            var saturation = color.S / 100.0;
            var luminosity = color.L / 100.0;

            if (!luminosity.BasicallyEqualTo (0)) {
                if (saturation.BasicallyEqualTo (0))
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
            }
            R = 255.0 * r;
            G = 255.0 * g;
            B = 255.0 * b;
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

        public override string ToString() {
            return $"rgb({R:#0},{G:#0},{B:#0})";
        }

        public override bool Equals(object obj) {
            if (!(obj is Rgb))
                return false;
            var rgb = (Rgb) obj;
            return R == rgb.R && G == rgb.G && B == rgb.B;
        }

        public bool Equals(Rgb other) {
            if (ReferenceEquals (null, other))
                return false;
            if (ReferenceEquals (this, other))
                return true;
            return R.Equals (other.R) && G.Equals (other.G) && B.Equals (other.B);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = R.GetHashCode ();
                hashCode = (hashCode * 397) ^ G.GetHashCode ();
                hashCode = (hashCode * 397) ^ B.GetHashCode ();
                return hashCode;
            }
        }

        public static bool operator ==(Rgb left, Rgb right) {
            return Equals (left, right);
        }

        public static bool operator !=(Rgb left, Rgb right) {
            return !Equals (left, right);
        }
    }
}