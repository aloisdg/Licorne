using System;

namespace Licorne {
    public class Hsl : IEquatable<Hsl> {
        public double H { get; }
        public double S { get; }
        public double L { get; }

        public Hsl(double h, double s, double l) {
            H = h;
            S = s;
            L = l;
        }

        public Hsl(Hsl color) : this (color.H, color.S, color.L) { }

        public Hsl(Rgb rgb) : this (GetHue (rgb)
            , GetSaturation (rgb) * 100
            , GetBrightness (rgb) * 100.0) { }

        private static float GetBrightness(Rgb rgb) {
            var r = (float) rgb.R / 255.0f;
            var g = (float) rgb.G / 255.0f;
            var b = (float) rgb.B / 255.0f;

            var max = r;
            var min = r;

            if (g > max)
                max = g;
            if (b > max)
                max = b;

            if (g < min)
                min = g;
            if (b < min)
                min = b;

            return (max + min) / 2;
        }

        ///<summary>
        /// The Hue-Saturation-Brightness (HSB) saturation for this
        ///</summary>
        private static float GetSaturation(Rgb rgb) {
            var r = (float) rgb.R / 255.0f;
            var g = (float) rgb.G / 255.0f;
            var b = (float) rgb.B / 255.0f;

            var max = r;
            var min = r;

            if (g > max)
                max = g;
            if (b > max)
                max = b;

            if (g < min)
                min = g;
            if (b < min)
                min = b;

            // if max == min, then there is no color and
            // the saturation is zero.
            if (max == min)
                return 0;
            var l = (max + min) / 2;
            var s = (max - min) / (l <= .5 ? (max + min) : (2 - max - min)); // float
            return s;
        }

        private static float GetHue(Rgb rgb) {
            if (rgb.R == rgb.G && rgb.G == rgb.B)
                return 0; // 0 makes as good an UNDEFINED value as any

            var r = (float) rgb.R / 255.0f;
            var g = (float) rgb.G / 255.0f;
            var b = (float) rgb.B / 255.0f;

            float max, min;
            float delta;
            var hue = 0.0f;

            max = r;
            min = r;

            if (g > max)
                max = g;
            if (b > max)
                max = b;

            if (g < min)
                min = g;
            if (b < min)
                min = b;

            delta = max - min;

            if (r == max) {
                hue = (g - b) / delta;
            }
            else if (g == max) {
                hue = 2 + (b - r) / delta;
            }
            else if (b == max) {
                hue = 4 + (r - g) / delta;
            }
            hue *= 60;

            if (hue < 0.0f) {
                hue += 360.0f;
            }
            return hue;
        }

        public override string ToString() {
            return $"hsl({H:#0.#},{S:#0.##}%,{L:#0.##}%)";
        }

        public override bool Equals(object obj) {
            if (!(obj is Hsl))
                return false;
            var hsl = (Hsl) obj;
            return H == hsl.H && S == hsl.S && L == hsl.L;
        }

        public bool Equals(Hsl other) {
            if (ReferenceEquals (null, other))
                return false;
            if (ReferenceEquals (this, other))
                return true;
            return H.Equals (other.H) && S.Equals (other.S) && L.Equals (other.L);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = H.GetHashCode ();
                hashCode = (hashCode * 397) ^ S.GetHashCode ();
                hashCode = (hashCode * 397) ^ L.GetHashCode ();
                return hashCode;
            }
        }

        public static bool operator ==(Hsl left, Hsl right) {
            return Equals (left, right);
        }

        public static bool operator !=(Hsl left, Hsl right) {
            return !Equals (left, right);
        }
    }
}
