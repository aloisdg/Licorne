using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licorne.Sample {
    public class Program {
        public static void Main(string[] args) {
            if (args.Length != 4)
                return;
            if (args[0] == "rgb") {
                var values = Convert (args);
                var hsl = new Hsl(new Rgb (values[0], values[1], values[2]));
                Console.WriteLine($"hsl {hsl.H} {hsl.S} {hsl.L}");
            }
            if (args[0] == "hsl") {
                var values = Convert (args);
                var rgb = new Hsl (values[0], values[1], values[2]).ToRgb();
                Console.WriteLine ($"rgb {rgb.R} {rgb.G} {rgb.B}");
            }
            Console.ReadLine();
        }

        private static IReadOnlyList<double> Convert(IEnumerable<string> args) {
            return args.Skip (1).Select (double.Parse).ToArray ();
        }
    }
}
