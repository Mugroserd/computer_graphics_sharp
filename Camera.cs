using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomStructures;

namespace Renderer
{
    class Camera
    {
        public readonly TextureBuffer outputBuffer;

        private Point3F position;
        private Matrix4 positionMatrix;

        private Angle3F rotation;
        private Matrix4 rotationMatrix;

        private Matrix4 scaleMatrix;

        private Matrix4 perspectiveMatrix;

        public Camera(int bufferWidth, int bufferHeight, float fov, float nearPlane, float farPlane)
        {
            outputBuffer = new TextureBuffer(bufferWidth, bufferHeight);
            MoveTo(new Point3F(0, 0, 0));
            RotateTo(new Angle3F(0, 0, 0));
            perspectiveMatrix = Matrix4.FromPesrpective(fov, nearPlane, farPlane, bufferWidth/bufferHeight);
        }

        public void Draw(Mesh mesh, Color color)
        {
            mesh.DrawWire(outputBuffer, GetMatrix(), color);
        }

        public void MoveTo(Point3F position)
        {
            this.position = position;
            positionMatrix = Matrix4.FromTranslation(new Point3F(0, 0, 0) - position);
        }

        public void RotateTo(Angle3F rotation)
        {
            this.rotation = rotation;
            rotationMatrix = Matrix4.Multiply(Matrix4.FromYaw(-rotation.yaw), Matrix4.FromPitch(-rotation.pitch));
            rotationMatrix = Matrix4.Multiply(rotationMatrix, Matrix4.FromRoll(-rotation.roll));
        }

        public void ScaleTo(Point3F power)
        {
            scaleMatrix = Matrix4.FromScale(power);
        }

        public Matrix4 GetMatrix()
        {
            // return Matrix4.Multiply(scaleMatrix,  Matrix4.Multiply(positionMatrix, rotationMatrix));
            Matrix4 unoMatrix = new Matrix4();
            unoMatrix.values = new float[,]{
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1}
            };
            unoMatrix = Matrix4.Multiply(unoMatrix, perspectiveMatrix);
            unoMatrix = Matrix4.Multiply(unoMatrix, positionMatrix);
            unoMatrix = Matrix4.Multiply(unoMatrix, rotationMatrix);
            unoMatrix = Matrix4.Multiply(unoMatrix, scaleMatrix);
            return unoMatrix;
        }
    }
}
