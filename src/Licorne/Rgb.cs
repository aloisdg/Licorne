// Licorne Is Colors Of Rgb Naturally Easy
// LIght COlor Rendered Naive & Easy

using System;

namespace Licorne {
    /// <summary>Represents an RGB (red, green, blue) color.</summary>
    public struct Rgb : IEquatable<Rgb> {
        /// <summary>Gets the red component value of this <see cref="T:Licorne.Rgb" /> structure.</summary>
        /// <returns>The red component value of this <see cref="T:Licorne.Rgb" />.</returns>
        public double R { get; }

        /// <summary>Gets the green component value of this <see cref="T:Licorne.Rgb" /> structure.</summary>
        /// <returns>The green component value of this <see cref="T:Licorne.Rgb" />.</returns>
        public double G { get; }

        /// <summary>Gets the blue component value of this <see cref="T:Licorne.Rgb" /> structure.</summary>
        /// <returns>The blue component value of this <see cref="T:Licorne.Rgb" />.</returns>
        public double B { get; }

        /// <summary>Creates a <see cref="T:Licorne.Rgb" /> structure from the specified color values (red, green, and blue). Although this method allows a double value to be passed for each color component, the value of each component is limited to 8 bits.</summary>
        /// <returns>The <see cref="T:Licorne.Rgb" /> that this method creates.</returns>
        /// <param name="red">The red component value for the new <see cref="T:Licorne.Rgb" />. Valid values are 0 through 255. </param>
        /// <param name="green">The green component value for the new <see cref="T:Licorne.Rgb" />. Valid values are 0 through 255. </param>
        /// <param name="blue">The blue component value for the new <see cref="T:Licorne.Rgb" />. Valid values are 0 through 255. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="red" />, <paramref name="green" />, or <paramref name="blue" /> is less than 0 or greater than 255.</exception>
        public Rgb(double red, double green, double blue) {
            if (red < byte.MinValue || red > byte.MaxValue)
                throw new ArgumentOutOfRangeException (nameof (red));
            if (green < byte.MinValue || green > byte.MaxValue)
                throw new ArgumentOutOfRangeException (nameof (green));
            if (blue < byte.MinValue || blue > byte.MaxValue)
                throw new ArgumentOutOfRangeException (nameof (blue));
            R = red;
            G = green;
            B = blue;
        }

        /// <summary>Creates a <see cref="T:Licorne.Rgb" /> structure from the specified <see cref="T:Licorne.Rgb" /> structure.</summary>
        /// <returns>The <see cref="T:Licorne.Rgb" /> that this method creates.</returns>
        /// <param name="color">The <see cref="T:Licorne.Rgb" /> from which to create the new <see cref="T:Licorne.Rgb" />.</param>
        public Rgb(Rgb color) : this (color.R, color.G, color.B) { }

        /// <summary>Creates a <see cref="T:Licorne.Rgb" /> structure from the specified <see cref="T:Licorne.Hsl" /> structure.</summary>
        /// <returns>The <see cref="T:Licorne.Rgb" /> that this method creates.</returns>
        /// <param name="color">The <see cref="T:Licorne.Hsl" /> from which to create the new <see cref="T:Licorne.Rgb" />.</param>
        public Rgb(Hsl color) {
            var rangedH = color.H / 360d;
            var red = 0d;
            var green = 0d;
            var blue = 0d;
            var saturation = color.S / 100d;
            var luminosity = color.L / 100d;

            if (!luminosity.BasicallyEqualTo (0)) {
                if (saturation.BasicallyEqualTo (0))
                    red = green = blue = luminosity;
                else {
                    var temp2 = luminosity * (luminosity < .5
                        ? 1d + saturation
                        : 1d - saturation + saturation / luminosity);
                    var temp1 = 2d * luminosity - temp2;

                    red = GetColorComponent (temp1, temp2, rangedH + 1d / 3d);
                    green = GetColorComponent (temp1, temp2, rangedH);
                    blue = GetColorComponent (temp1, temp2, rangedH - 1d / 3d);
                }
            }
            R = 255d * red;
            G = 255d * green;
            B = 255d * blue;
        }

        private static double GetColorComponent(double temp1, double temp2, double temp3) {
            var temp3InRange = temp3 + (temp3 < 0d ? 1 : (temp3 > 1d ? -1d : 0d));
            if (temp3InRange < 1d / 6d) return temp1 + (temp2 - temp1) * 6d * temp3InRange;
            if (temp3InRange < .5) return temp2;
            if (temp3 < 2d / 3d) return temp1 + (temp2 - temp1) * 6d * (2d / 3d - temp3InRange);
            return temp1;
        }

        /// <summary>Converts an instance of a <see cref="T:Licorne.Hsl" /> structure from the specified <see cref="T:Licorne.Rgb" /> structure.</summary>
        /// <returns>The <see cref="T:Licorne.Rgb" /> that this method converts.</returns>
        /// <param name="color">The <see cref="T:Licorne.Hsl" /> from which to convert the new <see cref="T:Licorne.Rgb" />.</param>
        public static implicit operator Rgb(Hsl color) => new Rgb (color);

        /// <summary>Converts this <see cref="T:Licorne.Rgb" /> structure to a human-readable string.</summary>
        /// <returns>A string that consists of the <see cref="T:Licorne.Rgb" /> component names and their values in CSS format.</returns>
        public override string ToString() => $"rgb({R:#0},{G:#0},{B:#0})";

        /// <summary>Tests whether the specified <see cref="T:Licorne.Rgb" /> is equivalent to this <see cref="T:Licorne.Rgb" /> structure.</summary>
        /// <returns>true if <paramref name="other" /> is equivalent to this <see cref="T:Licorne.Rgb" /> structure; otherwise, false.</returns>
        public bool Equals(Rgb other) => R.Equals (other.R) && G.Equals (other.G) && B.Equals (other.B);

        /// <summary>Tests whether the specified object is a <see cref="T:Licorne.Rgb" /> structure and is equivalent to this <see cref="T:Licorne.Rgb" /> structure.</summary>
        /// <returns>true if <paramref name="obj" /> is a <see cref="T:Licorne.Rgb" /> structure equivalent to this <see cref="T:Licorne.Rgb" /> structure; otherwise, false.</returns>
        public override bool Equals(object obj) => obj is Rgb && Equals ((Rgb) obj);

        /// <summary>Returns a hash code for this <see cref="T:Licorne.Rgb" /> structure.</summary>
        /// <returns>An integer value that specifies the hash code for this <see cref="T:Licorne.Rgb" />.</returns>
        public override int GetHashCode() {
            unchecked {
                var hashCode = R.GetHashCode ();
                hashCode = (hashCode * 397) ^ G.GetHashCode ();
                hashCode = (hashCode * 397) ^ B.GetHashCode ();
                return hashCode;
            }
        }

        /// <summary>Returns a value that indicates whether two specified <see cref="T:Licorne.Rgb" /> values are equal.</summary>
        /// <returns>true if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise, false.</returns>
        /// <param name="left">The first value to compare. </param>
        /// <param name="right">The second value to compare.</param>
        public static bool operator ==(Rgb left, Rgb right) => Equals (left, right);

        /// <summary>Returns a value that indicates whether two specified <see cref="T:Licorne.Rgb" /> values are not equal.</summary>
        /// <returns>true if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, false.</returns>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        public static bool operator !=(Rgb left, Rgb right) => !Equals (left, right);
    }
}