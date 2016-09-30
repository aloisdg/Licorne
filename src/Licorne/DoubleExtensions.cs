namespace Licorne {
    internal static class DoubleExtensions {
        private const double DefaultPrecision = .0001;

        public static bool BasicallyEqualTo(this double a, double b, double precision = DefaultPrecision) {
            return System.Math.Abs (a - b) <= precision;
        }
    }
}
