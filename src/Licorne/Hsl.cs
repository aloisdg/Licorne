using System;

namespace Licorne {
    /// <summary>Represents an HSL (hue, saturation, luminosity) color.</summary>
    public struct Hsl : IEquatable<Hsl> {
        /// <summary>Gets the hue component value of this <see cref="T:Licorne.Hsl" /> structure.</summary>
        /// <returns>The hue component value of this <see cref="T:Licorne.Hsl" />.</returns>
        public double H { get; }
        
        /// <summary>Gets the saturation component value of this <see cref="T:Licorne.Hsl" /> structure.</summary>
        /// <returns>The saturation component value of this <see cref="T:Licorne.Hsl" />.</returns>
        public double S { get; }
        
        /// <summary>Gets the luminosity component value of this <see cref="T:Licorne.Hsl" /> structure.</summary>
        /// <returns>The luminosity component value of this <see cref="T:Licorne.Hsl" />.</returns>
        public double L { get; }

        /// <summary>Creates a <see cref="T:Licorne.Hsl" /> structure from the specified color values (hue, luminosity, and saturation).</summary>
        /// <returns>The <see cref="T:Licorne.Hsl" /> that this method creates.</returns>
        /// <param name="hue">The hue component value for the new <see cref="T:Licorne.Hsl" />. Valid values are 0 through 360. </param>
        /// <param name="saturation">The saturation component value for the new <see cref="T:Licorne.Hsl" />. Valid values are 0 through 100. </param>
        /// <param name="luminosity">The luminosity component value for the new <see cref="T:Licorne.Hsl" />. Valid values are 0 through 100. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="hue" />, <paramref name="saturation" />, or <paramref name="luminosity" /> is out of its range.</exception>
        public Hsl(double hue, double saturation, double luminosity) {
            if (hue < 0 || hue > 360)
                throw new ArgumentOutOfRangeException (nameof (hue));
            if (saturation < 0 || saturation > 100)
                throw new ArgumentOutOfRangeException (nameof (saturation));
            if (luminosity < 0 || luminosity > 100)
                throw new ArgumentOutOfRangeException (nameof (luminosity));
            H = hue;
            S = saturation;
            L = luminosity;
        }

        /// <summary>Creates a <see cref="T:Licorne.Hsl" /> structure from the specified <see cref="T:Licorne.Hsl" /> structure.</summary>
        /// <returns>The <see cref="T:Licorne.Hsl" /> that this method creates.</returns>
        /// <param name="color">The <see cref="T:Licorne.Hsl" /> from which to create the new <see cref="T:Licorne.Hsl" />.</param>
        public Hsl(Hsl color) : this (color.H, color.S, color.L) { }

        /// <summary>Creates a <see cref="T:Licorne.Hsl" /> structure from the specified <see cref="T:Licorne.Rgb" /> structure.</summary>
        /// <returns>The <see cref="T:Licorne.Hsl" /> that this method creates.</returns>
        /// <param name="color">The <see cref="T:Licorne.Rgb" /> from which to create the new <see cref="T:Licorne.Hsl" />.</param>
        public Hsl(Rgb color) : this (GetHue (color)
            , GetSaturation (color) * 100d
            , GetBrightness (color) * 100d) { }

        /// <summary>Gets the hue-saturation-brightness (HSB) brightness value for this <see cref="T:Licorne.Hsl" /> structure.</summary>
        /// <returns>The brightness of this <see cref="T:Licorne.Hsl" />. The brightness ranges from 0.0 through 100.0, where 0.0 represents black and 100.0 represents white.</returns>
        private static double GetBrightness(Rgb rgb) {
            var r = rgb.R / 255d;
            var g = rgb.G / 255d;
            var b = rgb.B / 255d;

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
        private static double GetSaturation(Rgb rgb) {
            var r = rgb.R / 255d;
            var g = rgb.G / 255d;
            var b = rgb.B / 255d;

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
            // todo: Fix warning
            // we are using double so we should compare with a BasicallyEquals
            if (max == min)
                return 0;
            var l = (max + min) / 2;
            var s = (max - min) / (l <= .5 ? (max + min) : (2 - max - min)); // double
            return s;
        }

        /// <summary>Gets the hue value, in degrees, for this <see cref="T:Licorne.Hsl" /> structure.</summary>
        /// <returns>The hue, in degrees, of this <see cref="T:Licorne.Hsl" />. The hue is measured in degrees, ranging from 0.0 through 360.0, in HSL color space.</returns>
        private static double GetHue(Rgb rgb) {
            // todo: Fix warning
            // we are using double so we should compare with a BasicallyEquals
            if (rgb.R == rgb.G && rgb.G == rgb.B)
                return 0; // 0 makes as good an UNDEFINED value as any

            var r = rgb.R / 255d;
            var g = rgb.G / 255d;
            var b = rgb.B / 255d;

            double max, min;
            double delta;
            var hue = 0d;

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

            // todo: Fix warning
            // we are using double so we should compare with a BasicallyEquals
            if (r == max) {
                hue = (g - b) / delta;
            }
            // todo: Fix warning
            // we are using double so we should compare with a BasicallyEquals
            else if (g == max) {
                hue = 2 + (b - r) / delta;
            }
            // todo: Fix warning
            // we are using double so we should compare with a BasicallyEquals
            else if (b == max) {
                hue = 4 + (r - g) / delta;
            }
            hue *= 60;

            if (hue < 0d) {
                hue += 360d;
            }
            return hue;
        }

        /// <summary>Converts an instance of a <see cref="T:Licorne.Rgb" /> structure from the specified <see cref="T:Licorne.Hsl" /> structure.</summary>
        /// <returns>The <see cref="T:Licorne.Hsl" /> that this method converts.</returns>
        /// <param name="color">The <see cref="T:Licorne.Rgb" /> from which to convert the new <see cref="T:Licorne.Hsl" />.</param>
        public static implicit operator Hsl(Rgb color) => new Hsl (color);

        /// <summary>Converts this <see cref="T:Licorne.Hsl" /> structure to a human-readable string.</summary>
        /// <returns>A string that consists of the <see cref="T:Licorne.Hsl" /> component names and their values in CSS format.</returns>
        public override string ToString() => $"hsl({H:#0.#},{S:#0.##}%,{L:#0.##}%)";

        /// <summary>Tests whether the specified <see cref="T:Licorne.Hsl" /> is equivalent to this <see cref="T:Licorne.Hsl" /> structure.</summary>
        /// <returns>true if <paramref name="other" /> is equivalent to this <see cref="T:Licorne.Hsl" /> structure; otherwise, false.</returns>
        public bool Equals(Hsl other) => H.Equals (other.H) && S.Equals (other.S) && L.Equals (other.L);

        /// <summary>Tests whether the specified object is a <see cref="T:Licorne.Hsl" /> structure and is equivalent to this <see cref="T:Licorne.Hsl" /> structure.</summary>
        /// <returns>true if <paramref name="obj" /> is a <see cref="T:Licorne.Hsl" /> structure equivalent to this <see cref="T:Licorne.Hsl" /> structure; otherwise, false.</returns>
        public override bool Equals(object obj) => obj is Hsl && Equals ((Hsl) obj);

        /// <summary>Returns a hash code for this <see cref="T:Licorne.Hsl" /> structure.</summary>
        /// <returns>An integer value that specifies the hash code for this <see cref="T:Licorne.Hsl" />.</returns>
        public override int GetHashCode() {
            unchecked {
                var hashCode = H.GetHashCode ();
                hashCode = (hashCode * 397) ^ S.GetHashCode ();
                hashCode = (hashCode * 397) ^ L.GetHashCode ();
                return hashCode;
            }
        }

        /// <summary>Returns a value that indicates whether two specified <see cref="T:Licorne.Hsl" /> values are equal.</summary>
        /// <returns>true if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise, false.</returns>
        /// <param name="left">The first value to compare. </param>
        /// <param name="right">The second value to compare.</param>
        public static bool operator ==(Hsl left, Hsl right) => Equals (left, right);

        /// <summary>Returns a value that indicates whether two specified <see cref="T:Licorne.Hsl" /> values are not equal.</summary>
        /// <returns>true if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, false.</returns>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        public static bool operator !=(Hsl left, Hsl right) => !Equals (left, right);
    }
}