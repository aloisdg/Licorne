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
            throw new System.NotImplementedException ();
        }

        public float GetBrightness() {
            var r = (float) R / 255.0f;
            var g = (float) G / 255.0f;
            var b = (float) B / 255.0f;

            float max, min;

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

            return (max + min) / 2;
        }

        ///<summary>
        /// The Hue-Saturation-Brightness (HSB) saturation for this
        ///</summary>
        public float GetSaturation() {
            var r = (float) R / 255.0f;
            var g = (float) G / 255.0f;
            var b = (float) B / 255.0f;

            float max, min;

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

            // if max == min, then there is no color and
            // the saturation is zero.
            if (max == min)
                return 0;
            var l = (max + min) / 2;
            var s = (max - min) / (l <= .5 ? (max + min) : (2 - max - min)); // float
            return s;
        }

        public float GetHue() {
            if (R == G && G == B)
                return 0; // 0 makes as good an UNDEFINED value as any

            var r = (float) R / 255.0f;
            var g = (float) G / 255.0f;
            var b = (float) B / 255.0f;

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
    }
}