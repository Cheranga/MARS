using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MARS.Core;
using MARS.Core.Interfaces;

namespace MARS.Business
{
    public class D3Handler<T> : I3DHandler<T> where T:ISpeed
    {
        public I3DHandler<T> StartIn(T @object, long x, long y, Direction direction)
        {
            throw new NotImplementedException();
        }

        public I3DHandler<T> TurnLeft()
        {
            throw new NotImplementedException();
        }

        public I3DHandler<T> TurnRight()
        {
            throw new NotImplementedException();
        }

        public I3DHandler<T> TurnUp()
        {
            throw new NotImplementedException();
        }

        public I3DHandler<T> TurnDown()
        {
            throw new NotImplementedException();
        }

        public I3DHandler<T> Move()
        {
            throw new NotImplementedException();
        }

        public string GetStatusMessage()
        {
            throw new NotImplementedException();
        }
    }
}
