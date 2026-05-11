namespace LW_9
{
    public class LineSegment
    {
        private double _x;
        private double _y;

        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public LineSegment()
        {
            _x = 0;
            _y = 0;
        }

        public LineSegment(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public LineSegment(LineSegment other)
        {
            _x = other._x;
            _y = other._y;
        }

        public bool Intersects(LineSegment other)
        {
            double start1 = System.Math.Min(_x, _y);
            double end1 = System.Math.Max(_x, _y);
            double start2 = System.Math.Min(other._x, other._y);
            double end2 = System.Math.Max(other._x, other._y);

            return start1 <= end2 && start2 <= end1;
        }

        public static double operator !(LineSegment segment)
        {
            return System.Math.Abs(segment._y - segment._x);
        }

        public static LineSegment operator ++(LineSegment segment)
        {
            return new LineSegment(segment._x - 1, segment._y + 1);
        }

        public static implicit operator int(LineSegment segment)
        {
            return (int)segment._x;
        }

        public static explicit operator double(LineSegment segment)
        {
            return segment._y;
        }

        public static LineSegment operator -(LineSegment segment, int value)
        {
            return new LineSegment(segment._x - value, segment._y);
        }

        public static LineSegment operator -(int value, LineSegment segment)
        {
            return new LineSegment(segment._x, segment._y - value);
        }

        public static bool operator <(LineSegment a, LineSegment b)
        {
            return a.Intersects(b);
        }

        public static bool operator >(LineSegment a, LineSegment b)
        {
            return !a.Intersects(b);
        }

        public override string ToString()
        {
            return $"[{_x}; {_y}]";
        }
    }
}