using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Donjon
{
    public struct Point : IEquatable<Point>
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object other)
        {
            return ((Point)other) == this;
        }
        public bool Equals(Point other)
        {
            return other == this;
        }
        public override int GetHashCode()
        {
            int hash = 7;
            hash = 71 * hash + X;
            hash = 71 * hash + Y;
            return hash;
        }
        public override string ToString()
        {
            return string.Format("[Y:{0};X:{1}]", Y, X);
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
        public static bool operator ==(Point lhs, Point rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y;
        }
        public static bool operator !=(Point lhs, Point rhs)
        {
            return !(lhs == rhs);
        }
    }
}
