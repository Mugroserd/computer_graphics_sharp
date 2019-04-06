using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomStructures;

namespace Renderer
{
    class Model
    {
        private Mesh mesh;
        private TextureBuffer texture;

        private Point3F position = new Point3F(0, 0, 0);
        private Angle3F angle = new Angle3F(0, 0, 0);
        private Point3F power = new Point3F(1, 1, 1);

        private Matrix4 ownMatrix;

        public Model(Mesh mesh, TextureBuffer texture)
        {
            RecalculateMatrix();
            this.mesh = mesh;
            this.texture = texture;
        }

        public void Draw(Matrix4 transformationMatrix, TextureBuffer target, float[,] zbuffer, PointLight light)
        {
            mesh.Draw(Matrix4.Multiply(transformationMatrix, ownMatrix), texture, target, zbuffer, light);
        }

        public void MoveTo(Point3F position)
        {
            this.position = position;
            RecalculateMatrix();
        }

        public void RotateTo(Angle3F angle)
        {
            this.angle = angle;
            RecalculateMatrix();
        }

        public void ScaleTo(Point3F power)
        {
            this.power = power;
            RecalculateMatrix();
        }

        private void RecalculateMatrix()
        {
            ownMatrix = new Matrix4();
            ownMatrix.values = new float[,]{
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1}
            };
            ownMatrix = Matrix4.Multiply(ownMatrix, Matrix4.FromTranslation(position));
            ownMatrix = Matrix4.Multiply(ownMatrix, Matrix4.FromYaw(angle.yaw));
            ownMatrix = Matrix4.Multiply(ownMatrix, Matrix4.FromPitch(angle.pitch));
            ownMatrix = Matrix4.Multiply(ownMatrix, Matrix4.FromRoll(angle.roll));
            ownMatrix = Matrix4.Multiply(ownMatrix, Matrix4.FromScale(power));
        }
    }
}
