using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayCastingAndPhong.RayCasting
{
    public class Ray
    {
        private SinglePoint _startPoint;
        private SinglePoint _endPoint;


        public SinglePoint StartPoint { get { return _startPoint; } set { _startPoint = value; } }
        public SinglePoint EndPoint { get { return _endPoint; } set { _endPoint =  value; } }
    }
}
