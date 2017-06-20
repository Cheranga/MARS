using MARS.Core.Interfaces;

namespace MARS.Business.Models
{
    public class Car : ISpeed, IDisplay
    {
        public string Model { get; set; }

        public int Speed { get; set; }

        public string Display()
        {
            return string.Format("[{0}] with speed [{1}]", Model, Speed);
        }
    }
}