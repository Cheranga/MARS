using System;
using MARS.Core.Interfaces;

namespace MARS.Business.Models
{
    public class Rover : ISpeed, IDisplay
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public int Speed { get; set; }

        //
        // Can be config driven or provided at runtime conditionally
        //
        public Rover(int speed = 1)
        {
            Speed = speed;
        }

        public string Display()
        {
            return string.Format(@"[{0} :: {1}]", Id, Name);
        }
    }
}