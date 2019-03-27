using System;

namespace CustomStructures
{
    // TODO: Just fix this total mess
    struct Point2N
    {
        public int x, y;

        public Point2N(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point2N operator +(Point2N point1, Point2N point2)
        {
            return new Point2N(point1.x + point2.x, point1.y + point2.y);
        }

        public static Point2N operator -(Point2N point1, Point2N point2)
        {
            return new Point2N(point1.x - point2.x, point1.y - point2.y);
        }
    }

    struct Point2F
    {
        public float x, y;

        public Point2F(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public void Set(Point2F point)
        {
            x = point.x;
            y = point.y;
        }

        public static Point2F operator +(Point2F point1, Point2F point2)
        {
            return new Point2F(point1.x + point2.x, point1.y + point2.y);
        }

        public static Point2F operator -(Point2F point1, Point2F point2)
        {
            return new Point2F(point1.x - point2.x, point1.y - point2.y);
        }

        public static Point2F operator *(Point2F point1, float alpha)
        {
            return new Point2F(point1.x * alpha, point1.y * alpha);
        }

        public static bool operator ==(Point2F point1, Point2F point2)
        {
            if (point1.x == point2.x && point1.y == point2.y)
                return true;
            else
                return false;
        }

        public static bool operator !=(Point2F point1, Point2F point2)
        {
            if (point1.x != point2.x || point1.y != point2.y)
                return true;
            else
                return false;
        }
    }

    struct Point3F
    {
        public float x, y, z;

        public Point3F(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Set(Point3F point)
        {
            x = point.x;
            y = point.y;
            z = point.z;
        }

        public static Point3F operator +(Point3F point1, Point3F point2)
        {
            return new Point3F(point1.x + point2.x, point1.y + point2.y, point1.z + point2.z);
        }

        public static Point3F operator -(Point3F point1, Point3F point2)
        {
            return new Point3F(point1.x - point2.x, point1.y - point2.y, point1.z - point2.z);
        }
		
        public static Point3F operator *(Point3F point1, float alpha)
        {
            return new Point3F(point1.x * alpha, point1.y * alpha, point1.z * alpha);
        }

        public static bool operator ==(Point3F point1, Point3F point2)
        {
            if (point1.x == point2.x && point1.y == point2.y && point1.z == point2.z)
                return true;
            else
                return false;
        }

        public static bool operator !=(Point3F point1, Point3F point2)
        {
            if (point1.x != point2.x || point1.y != point2.y || point1.z != point2.z)
                return true;
            else
                return false;
        }
    }
	
	struct Point3D
    {
        public float x, y, z;

        public Point3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Set(Point3D point)
        {
            x = point.x;
            y = point.y;
            z = point.z;
        }

        public static Point3D operator +(Point3D point1, Point3D point2)
        {
            return new Point3D(point1.x + point2.x, point1.y + point2.y, point1.z + point2.z);
        }

        public static Point3D operator -(Point3D point1, Point3D point2)
        {
            return new Point3D(point1.x - point2.x, point1.y - point2.y, point1.z - point2.z);
        }

        public static Point3D operator *(Point3D point1, float alpha)
        {
            return new Point3D(point1.x * alpha, point1.y * alpha, point1.z * alpha);
        }
		
        public static bool operator ==(Point3D point1, Point3D point2)
        {
            if (point1.x == point2.x && point1.y == point2.y && point1.z == point2.z)
                return true;
            else
                return false;
        }

        public static bool operator !=(Point3D point1, Point3D point2)
        {
            if (point1.x != point2.x || point1.y != point2.y || point1.z != point2.z)
                return true;
            else
                return false;
        }
    }


    struct Angle1F
    {
        private float rotation;

        public float Rotation {
            get { return rotation; }
            set {
                rotation = value;
                FixValue(ref rotation);
            } }

        public Angle1F(float rotation)
        {
            this.rotation = rotation;
            FixValue(ref this.rotation);
        }

        public void Set(Angle1F angle)
        {
            rotation = angle.rotation;
        }

        public static void FixValue(ref float rotation)
        {
            if (rotation < 0)
                rotation = (float)(Math.PI * 2) + rotation;
        }

        public static bool operator ==(Angle1F angle1, Angle1F angle2)
        {
            if (angle1.rotation == angle2.rotation)
                return true;
            else
                return false;
        }

        public static bool operator !=(Angle1F angle1, Angle1F angle2)
        {
            if (angle1.rotation != angle2.rotation)
                return true;
            else
                return false;
        }
    }

    struct Angle2F
    {
        public float yaw, pitch;

        public Angle2F(float yaw, float pitch)
        {
            this.yaw = yaw;
            this.pitch = pitch;
        }
    }

    struct Angle3F
    {
        public float yaw, pitch, roll;

        public Angle3F(float yaw, float pitch, float roll)
        {
            this.yaw = yaw;
            this.pitch = pitch;
            this.roll = roll;
        }

        public void Set(Angle3F angle)
        {
            yaw = angle.yaw;
            pitch = angle.pitch;
            roll = angle.roll;
        }

        public static Angle3F operator +(Angle3F angle1, Angle3F angle2)
        {
            float newYaw = angle1.yaw + angle2.yaw;
            Angle1F.FixValue(ref newYaw);

            float newPitch = angle1.pitch + angle2.pitch;
            Angle1F.FixValue(ref newPitch);

            float newRoll = angle1.roll + angle2.roll;
            Angle1F.FixValue(ref newRoll);

            return new Angle3F(newYaw, newPitch, newRoll);
        }

        public static Angle3F operator -(Angle3F angle1, Angle3F angle2)
        {
            float newYaw = angle1.yaw - angle2.yaw;
            Angle1F.FixValue(ref newYaw);

            float newPitch = angle1.pitch - angle2.pitch;
            Angle1F.FixValue(ref newPitch);

            float newRoll = angle1.roll - angle2.roll;
            Angle1F.FixValue(ref newRoll);

            return new Angle3F(newYaw, newPitch, newRoll);
        }

        public static bool operator ==(Angle3F angle1, Angle3F angle2)
        {
            if (angle1.yaw == angle2.yaw && angle1.pitch == angle2.pitch && angle1.roll == angle2.roll)
                return true;
            else
                return false;
        }

        public static bool operator !=(Angle3F angle1, Angle3F angle2)
        {
            if (angle1.yaw != angle2.yaw || angle1.pitch != angle2.pitch || angle1.roll != angle2.roll)
                return true;
            else
                return false;
        }
    }

    struct Vector2F
    {
        private bool coordinatesActual;
        public float x;
        public float y;

        private bool angleActual;
        private Angle1F angle;
        private float length;

        public Vector2F(float x, float y)
        {
            coordinatesActual = true;
            this.x = x;
            this.y = y;

            angleActual = false;
            angle = new Angle1F(0);
            length = 0;
        }
    }

    struct Vector3F
    {
        private bool coordinatesActual;
        public float x;
        public float y;
        public float z;

        private bool angleActual;
        private Angle2F angle;
        private float length;

        public Vector3F(float x, float y, float z)
        {
            coordinatesActual = true;
            this.x = x;
            this.y = y;
            this.z = z;

            angleActual = false;
            angle = new Angle2F(0, 0);
            length = 0;
        }

        public void Set(Vector3F vector)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;

            angleActual = false;
        }
        
        public static bool operator ==(Vector3F vector1, Vector3F vector2)
        {
            if (vector1.x == vector2.x && vector1.y == vector2.y && vector1.z == vector2.z)
                return true;
            else
                return false;
        }

        public static bool operator !=(Vector3F vector1, Vector3F vector2)
        {
            if (vector1.x != vector2.x || vector1.y != vector2.y || vector1.z != vector2.z)
                return true;
            else
                return false;
        }
    }

    struct Rect2N
    {
        public int width, height;

        public Rect2N(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public float GetRatio()
        {
            return (float)width / height;
        }

        public static Rect2N operator +(Rect2N rect1, Rect2N rect2)
        {
            return new Rect2N(rect1.width + rect2.width, rect1.height + rect2.height);
        }

        public static Rect2N operator -(Rect2N rect1, Rect2N rect2)
        {
            return new Rect2N(rect1.width - rect2.width, rect1.height - rect2.height);
        }

        public static bool operator ==(Rect2N rect1, Rect2N rect2)
        {
            return (rect1.width == rect2.width) && (rect1.height == rect2.height);
        }

        public static bool operator !=(Rect2N rect1, Rect2N rect2)
        {
            return (rect1.width != rect2.width) || (rect1.height != rect2.height);
        }
    }

    struct Rect4N
    {
        public int left, bottom, right, top;

        public Rect4N(int left, int bottom, int right, int top)
        {
            this.left = left;
            this.bottom = bottom;
            this.right = right;
            this.top = top;
        }

        public void MoveBy(Point2N point)
        {
            left += point.x;
            bottom += point.y;
            right += point.x;
            top += point.y;
        }

        public static bool operator ==(Rect4N rect1, Rect4N rect2)
        {
            return (rect1.left == rect2.left) && (rect1.top == rect2.top) && (rect1.right == rect2.right) && (rect1.bottom == rect2.bottom);
        }

        public static bool operator !=(Rect4N rect1, Rect4N rect2)
        {
            return (rect1.left != rect2.left) || (rect1.top != rect2.top) || (rect1.right != rect2.right) || (rect1.bottom != rect2.bottom);
        }
    }

    struct Rect2F
    {
        public float width, height;

        public Rect2F(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        public float GetRatio()
        {
            return width / height;
        }

        public static Rect2F operator /(Rect2F rect1, float divider)
        {
            return new Rect2F(rect1.width / divider, rect1.height / divider);
        }
    }

    struct Rect4F
    {
        public float left, bottom, right, top;

        public Rect4F(float left, float bottom, float right, float top)
        {
            this.left = left;
            this.bottom = bottom;
            this.right = right;
            this.top = top;
        }

        public bool Collides(Rect4F rect)
        {
            return left <= rect.right && bottom <= rect.top && right >= rect.left && top >= rect.bottom;
        }
    }

    struct Color3F
    {
        public float red, green, blue;

        public Color3F(float red, float green, float blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }
    }
}