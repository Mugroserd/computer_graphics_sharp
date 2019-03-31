using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomStructures;

namespace Renderer
{
    class Matrix4
    {
        public float[,] values = new float[4, 4];

        public static Matrix4 Multiply(Matrix4 mat1, Matrix4 mat2)
        {
            Matrix4 result = new Matrix4();
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                {
                    result.values[y, x] = 0;
                    for (int i = 0; i < 4; i++)
                        result.values[y, x] += mat1.values[y, i] * mat2.values[i, x];
                }
            return result;
        }

        public static Matrix4 FromTranslation(Point3F position)
        {
            float[,] values = {
                {1, 0, 0, position.x},
                {0, 1, 0, position.y},
                {0, 0, 1, position.z},
                {0, 0, 0, 1}
            };
            Matrix4 result = new Matrix4();
            result.values = values;
            return result;
        }

        public static Matrix4 FromScale(Point3F power)
        {
            float[,] values = {
                {power.x, 0,       0,       0},
                {0,       power.y, 0,       0},
                {0,       0,       power.z, 0},
                {0,       0,       0,       1}
            };
            Matrix4 result = new Matrix4();
            result.values = values;
            return result;
        }

        public static Matrix4 FromPitch(float angle)
        {
            float[,] values = {
                {  1, 0,                       0,                      0},
                {  0, (float)Math.Cos(angle),  (float)Math.Sin(angle), 0},
                {  0, -(float)Math.Sin(angle), (float)Math.Cos(angle), 0},
                {  0, 0,                       0,                      1}
            };
            Matrix4 result = new Matrix4();
            result.values = values;
            return result;
        }

        public static Matrix4 FromYaw(float angle)
        {
            float[,] values = {
                {  (float)Math.Cos(angle), 0, (float)Math.Sin(angle), 0},
                {  0,                      1, 0,                      0},
                { -(float)Math.Sin(angle), 0, (float)Math.Cos(angle), 0},
                {  0,                      0, 0,                      1}
            };
            Matrix4 result = new Matrix4();
            result.values = values;
            return result;
        }

        public static Matrix4 FromRoll(float angle)
        {
            float[,] values = {
                {  (float)Math.Cos(angle), (float)Math.Sin(angle), 0, 0},
                { -(float)Math.Sin(angle), (float)Math.Cos(angle), 0, 0},
                {  0,                      0,                      1, 0},
                {  0,                      0,                      0, 1}
            };
            Matrix4 result = new Matrix4();
            result.values = values;
            return result;
        }

        public static Matrix4 FromPesrpective(float fov, float near, float far, float aspect)
        {
            float lapis = 1.0f / (float)Math.Tan(fov / 2);
            float peridot = 1.0f / (near - far);
            /*float[,] values = {
                {lapis / aspect, 0,      0,                        0},
                {0,              lapis,  0,                        0},
                {0,              0,      (far + near) * peridot,  -1},
                {0,              0,      2 * far * near * peridot, 0}
            }; */
            float[,] values = {
                {lapis / aspect, 0,      0,                        0},
                {0,              lapis,  0,                        0},
                {0,              0,      (near + far) * peridot,    2 * far * near * peridot},
                {0,              0,      -1, 0}
            };
            /*
            float[,] values = {
                {1,       0,       0,       0},
                {0,       1,       0,       0},
                {0,       0,       1,       0},
                {0,       0,       1,       1}
            }; */
            Matrix4 result = new Matrix4();
            result.values = values;
            return result;
        }
    }
}