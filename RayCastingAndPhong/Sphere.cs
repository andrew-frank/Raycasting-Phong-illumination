using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RayCastingAndPhong.RayCasting
{
    public class Sphere
    {
        private SinglePoint _center;
        private int _r;
        private int _g;
        private int _b;
        private double _radius;
        private Color _spehereColor;

        public SinglePoint Center { get { return _center; } set { _center = value;} }
        public int R { get { return _r; } set { _r = value; } }
        public int G { get { return _g; } set { _g = value; } }
        public int B { get { return _b; } set { _b = value; } }
        public double Radius { get{ return _radius;} set { _radius = value } }
        public Color SpehereColor { get { return _spehereColor; } set { _spehereColor = value; }; }



    }
}
