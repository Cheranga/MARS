using MARS.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MARS.Business.Models;

namespace MARS.Apps.Console
{
    class Program
    {
        private static bool sizeSet = false;
        static void Main(string[] args)
        {
            //
            // TODO: Validate input
            // Assuming the user enters valid input
            //
            if (!sizeSet)
            {
                System.Console.Write("Enter Plateau Size (width and height separated by a space): ");
                var sizes = System.Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                long width;
                long height;
                long.TryParse(sizes[0], out width);
                long.TryParse(sizes[1], out height);
                sizeSet = true;
            }

            System.Console.Write("\n\nEnter Rover Position and Direction: ");
            System.Console.Write("Enter Instructions (separated by spaces): ");
            var instructions = System.Console.ReadLine().Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var rover = new Rover {Id = "MARS_001", Name = "Hi Marzzz!"};

            instructions.ToList().ForEach(instruction =>
            {
                
            });
        }
    }
}
