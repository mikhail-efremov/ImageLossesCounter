using System;

namespace nAlpha
{
    public struct PointA : IEquatable<PointA>
    {
        public bool Equals(PointA other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is PointA && Equals((PointA) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode()*397) ^ Y.GetHashCode();
            }
        }

        public static bool operator ==(PointA left, PointA right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PointA left, PointA right)
        {
            return !left.Equals(right);
        }

        public double X { get; private set; }
        public double Y { get; private set; }

        public PointA(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X={X}; Y={Y}";
        }

        public double DistanceTo(PointA p)
        {
            return Math.Sqrt((X - p.X)*(X - p.X) + (Y - p.Y)*(Y - p.Y));
        }

        public PointA CenterTo(PointA p)
        {
            return new PointA((X + p.X)/2, (Y + p.Y)/2);
        }

        public PointA VectorTo(PointA p)
        {
            double d = DistanceTo(p);
            return new PointA((p.X - X)/d, 
                (p.Y - Y)/d);
        }
    }
}