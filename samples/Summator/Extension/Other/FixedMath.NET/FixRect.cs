using System;

namespace FixMath.NET
{
    [Serializable]
    public struct FixRect
    {
        public Fix64 x, y, w, h;

        public FixRect(Fix64 x, Fix64 y, Fix64 w, Fix64 h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public FixVector2 Center()
        {
            return new FixVector2((x + w) / Fix64.Two, (y + h) / Fix64.Two);
        }

        public bool IsOverlapping(FixRect other)
        {
            bool collisionX = x < other.w && w > other.x;
            bool collisionY = y < other.h && h > other.y;

            return collisionX && collisionY;
        }

        public override string ToString()
        {
            return $"({x}, {y}, {w}, {h})";
        }
    }
}
