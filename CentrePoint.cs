using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom_Program
{
    public class CentrePoint
    {
        private Point2D _point;
        private bool _placed; // This attribute will check if a centrepoint has been placed or not
        public CentrePoint(Point2D point)
        {
            _point = point;
            _placed = false;
        }

        public Point2D Point
        {
            get
            {
                return _point;
            }
        }

        public bool Placed
        {
            get
            {
                return _placed;
            }
            set
            {
                _placed = value;
            }
        }

    }
}
