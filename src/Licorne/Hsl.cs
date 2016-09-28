namespace Licorne {
    public class Hsl {
        public double H { get; }
        public double S { get; }
        public double L { get; }

        public Hsl(double h, double s, double l) {
            H = h;
            S = s;
            L = l;
        }

        public Hsl(Hsl color) {
            H = color.H;
            S = color.S;
            L = color.L;
        }

        public Hsl(Rgb rgb) {
            H = GetHue (rgb);
            S = GetSaturation (rgb) * 100.0;
            L = GetBrightness (rgb) * 100.0;
        }

        public float GetBrightness(Rgb rgb) {
            var r = (float) rgb.R / 255.0f;
            var g = (float) rgb.G / 255.0f;
            var b = (float) rgb.B / 255.0f;

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
        public float GetSaturation(Rgb rgb) {
            var r = (float) rgb.R / 255.0f;
            var g = (float) rgb.G / 255.0f;
            var b = (float) rgb.B / 255.0f;

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

        public float GetHue(Rgb rgb) {
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
            return $"hsl (H: {H:#0.##} S: {S:#0.##} L: {L:#0.##})";
        }
    }
}
