using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licorne.Sample {
    public class Program {
        public static void Main(string[] args) {
            if (args.Length != 4)
                return;
            //if (args[0] == "rgb") {
            //    var values = Convert (args);
            //    var hsl = new Hsl (new Rgb (values[0], values[1], values[2]));
            //    Console.WriteLine ($"hsl {hsl.H} {hsl.S} {hsl.L}");
            //}
            //if (args[0] == "hsl") {
            //    var values = Convert (args);
            //    var rgb = new Rgb (new Hsl (values[0], values[1], values[2]));
            //    Console.WriteLine ($"rgb {rgb.R} {rgb.G} {rgb.B}");
            //}

            //red
            var expected1 = new Hsl (0.00d, 79.00d, 38.00d);
            var actual1 = new Hsl (new Rgb (177.00d, 20.00d, 20.00d));
            Console.WriteLine(expected1);
            Console.WriteLine(actual1);

            //green
            var expected2 = new Hsl (123.00d, 74.00d, 33.00d);
            var actual2 = new Hsl (new Rgb (22, 149, 30));
            Console.WriteLine (expected2);
            Console.WriteLine (actual2);

            //blue
            var expected3 = new Hsl (225.00d, 79.00d, 45.00d);
            var actual3 = new Hsl (new Rgb (24, 67, 206));
            Console.WriteLine (expected3);
            Console.WriteLine (actual3);

            //black
            var expected4 = new Hsl (0.00d, 0.00d, 0.00d);
            var actual4 = new Hsl (new Rgb (0, 0, 0));
            Console.WriteLine (expected4);
            Console.WriteLine (actual4);

            //white
            var expected5 = new Hsl (0.00d, 0.00d, 100.00d);
            var actual5 = new Hsl (new Rgb (255, 255, 255));
            Console.WriteLine (expected5);
            Console.WriteLine (actual5);


            Console.ReadLine ();
        }

        private static IReadOnlyList<double> Convert(IEnumerable<string> args) {
            return args.Skip (1).Select (double.Parse).ToArray ();
        }
    }
}
