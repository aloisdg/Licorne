using System;
using System.Collections.Generic;
using System.Linq;

namespace Licorne.Sample {
    public class Program {
        public static void Main(string[] args) {
            if (args.Length != 4) {
                Console.WriteLine ("Usage: rgb|hsl r|h g|s b|l");
                Console.WriteLine ("Example: rgb 199 20 240");
                Console.WriteLine ("Example: hsl 288.8 88 51");
                return;
            }
            if (args[0] == "rgb") {
                var values = Convert (args);
                var rgb = new Rgb (values[0], values[1], values[2]);
                var hsl = new Hsl (rgb);
                Console.WriteLine ($"{rgb} => {hsl}");
            }
            if (args[0] == "hsl") {
                var values = Convert (args);
                var hsl = new Hsl (values[0], values[1], values[2]);
                var rgb = new Rgb (hsl);
                Console.WriteLine ($"{hsl} => {rgb}");
            }
        }

        private static IReadOnlyList<double> Convert(IEnumerable<string> args) {
            return args.Skip (1).Select (double.Parse).ToArray ();
        }
    }
}