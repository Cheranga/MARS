using MARS.Core;
using MARS.Core.Interfaces;
using MARS.Core.States;

namespace MARS.Business.Helpers
{
    public static class ExtensionMethods
    {
        public static IState State(this Direction direction)
        {
            IState state = null;
            switch (direction)
            {
                case Direction.N:
                    state = new NorthState();
                    break;

                case Direction.E:
                    state = new EastState();
                    break;

                case Direction.S:
                    state = new SouthState();
                    break;

                case Direction.W:
                    state = new WestState();
                    break;
            }

            return state;
        }
    }
}