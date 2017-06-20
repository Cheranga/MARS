using MARS.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MARS.Business.Models;
using MARS.Core;

namespace MARS.Apps.Console
{
    class Program
    {
        private static bool sizeSet = false;
        private static int roverCount = 0;
        static long plateauWidth = 0;
        static long plateauHeight = 0;

        static void Main(string[] args)
        {
            //
            // TODO: Validate input, and add a command mapper (a type of IHandler, so that it can be replaced) for the IHandler
            // ASSUMPTION: THE USER ENTERS VALID INPUT SEPARATED BY SPACE
            //
            if (!sizeSet)
            {
                System.Console.Write("Enter Plateau Size (width and height separated by a space): ");
                var sizes = System.Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                
                long.TryParse(sizes[0], out plateauWidth);
                long.TryParse(sizes[1], out plateauHeight);
                sizeSet = true;
            }

            System.Console.Write("\nEnter Rover Position and Direction: ");
            var roverPositionAndOrientation = System.Console.ReadLine().Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries);
            long x;
            long y;
            Direction direction;
            long.TryParse(roverPositionAndOrientation[0], out x);
            long.TryParse(roverPositionAndOrientation[1], out y);
            Enum.TryParse(roverPositionAndOrientation[2],true, out direction);

            System.Console.Write("\nEnter Instructions: ");
            var instructions = System.Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var rover = new Rover { Id = string.Format("MARS_{0}", (roverCount + 1)), Name = string.Format("Hi Marzzz from MARS_{0}", (roverCount + 1)) };

            var handler = new Handler<Rover>(plateauWidth, plateauHeight).StartIn(rover, x, y, direction);

            instructions.ToList().ForEach(instruction =>
            {
                switch (instruction.ToUpper())
                {
                    case "L":
                        handler.TurnLeft();
                        break;

                    case "R":
                        handler.TurnRight();
                        break;

                    case "M":
                        handler.Move();
                        break;
                }
            });

            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write("\nOUTPUT: {0}", handler.GetStatusMessage());

            System.Console.ResetColor();
            System.Console.WriteLine("\n{0}", new string('=', 65));
            System.Console.Write("\n\nDo you want try another ride (Y for yes) ?: ");
            var wantToContinue = string.Equals(System.Console.ReadKey().KeyChar.ToString(), "y", StringComparison.InvariantCultureIgnoreCase);
            if (wantToContinue)
            {
                Main(args);
            }
        }
    }
}
