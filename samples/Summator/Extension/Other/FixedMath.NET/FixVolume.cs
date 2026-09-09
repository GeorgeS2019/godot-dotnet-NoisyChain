using System;

namespace FixMath.NET
{
    [Serializable]
    public struct FixVolume
    {
        public Fix64 x, y, z, w, h, d;

        public FixVolume(Fix64 x, Fix64 y, Fix64 z, Fix64 w, Fix64 h, Fix64 d)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
            this.h = h;
            this.d = d;
        }

        public FixVector3 Center()
        {
            return new FixVector3((x + w) / Fix64.Two, (y + h) / Fix64.Two, (z + d) / Fix64.Two);
        }

        public bool IsOverlapping(FixVolume other)
        {
            bool collisionX = x < other.w && w > other.x;
            bool collisionY = y < other.h && h > other.y;
            bool collisionZ = z < other.d && d > other.z;

            return collisionX && collisionY && collisionZ;
        }

        public override string ToString()
        {
            return $"({x}, {y}, {x}, {w}, {h}, {d})";
        }
    }
}
