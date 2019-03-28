using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomStructures;

namespace Renderer
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();
        private Camera camera = new Camera(640, 640, ConvertToRads(60), 1, 100);
        private Mesh mesh = ObjectParser.GetMeshFromObj("webber_triangulated.obj");
        private Color newColor = Color.FromArgb(0, 255, 255);

        Rectangle rect = new Rectangle(0, 0, 640, 640);

        private float xOffset = 0;
        private float yOffset = 0;
        private float zOffset = 0;

        private float yawChange = 0;
        private float pitchChange = 0;
        private float rollChange = 0;

        private SolidBrush backgroundBrush = new SolidBrush(Color.Black); // Кисть фона
        private Pen pen = new Pen(Color.White);

        public Form1()
        {
            InitializeComponent();
            camera.RotateTo(new Angle3F(ConvertToRads(180), 0, ConvertToRads(180)));
            camera.ScaleTo(new Point3F(0.15f, 0.15f, 0.15f));
        }

        private static float ConvertToRads(int degrees)
        {
            return degrees * (float)Math.PI / 180f;
        }

        private void Redraw()
        {
            outputBox.Image = camera.outputBuffer.GetBitmap();
            Graphics.FromImage(outputBox.Image).FillRectangle(backgroundBrush, rect);
            camera.MoveTo(new Point3F(xOffset, yOffset, zOffset));
            camera.RotateTo(new Angle3F(yawChange, pitchChange, rollChange));
            camera.Draw(mesh, newColor);
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Rectangle rect = new Rectangle(0, 0, 640, 640);
            Region region1 = new Region(new Rectangle(0, 0, 640, 640));
            Color newColor = Color.FromArgb(255, 0, 0);

            for (float i = 30f; i < 3.14f * 80; i += 0.1f)
            {
                newColor = Color.FromArgb((int)(192 - 63 * Math.Sin(i)), 64, (int)(192 - 63 * Math.Cos(i)));
                Graphics.FromImage(outputBox.Image).FillRectangle(backgroundBrush, rect);
                for(int j = 0; j < 128; j++)
                {
                    float p1 = 640.0f * (float)rand.NextDouble();
                    float p2 = 640.0f * (float)rand.NextDouble();

                    Graphics.FromImage(outputBox.Image).DrawLine(pen, p1, p2, p1 + 40, p2);
                }
                camera.MoveTo(new Point3F(2 * (float)Math.Cos(i/10), 0, 3 * (float)Math.Sin(i/10)));
                camera.RotateTo(new Angle3F(ConvertToRads(90), (float)Math.Sin(i / 2), 0));
                camera.ScaleTo(new Point3F(0.01f * (float)Math.Sin(i) + 0.085f, 0.01f * (float)Math.Sin(i) + 0.085f, 0.01f * (float)Math.Sin(i) + 0.085f));
                camera.Draw(mesh, newColor);
                Refresh();
            }*/

        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            yOffset += (float)Convert.ToDouble(offsetValue.Text);
            Redraw();
            Refresh();
        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            yOffset -= (float)Convert.ToDouble(offsetValue.Text);
            Redraw();
            Refresh();
        }

        private void moveLeft_Click(object sender, EventArgs e)
        {
            xOffset -= (float)Convert.ToDouble(offsetValue.Text);
            Redraw();
            Refresh();
        }

        private void moveRight_Click(object sender, EventArgs e)
        {
            xOffset += (float)Convert.ToDouble(offsetValue.Text);
            Redraw();
            Refresh();
        }

        private void yawRight_Click(object sender, EventArgs e)
        {
            yawChange += ConvertToRads(Convert.ToInt32(angleChange.Text));
            Redraw();
            Refresh();
        }

        private void yawLeft_Click(object sender, EventArgs e)
        {
            yawChange -= ConvertToRads(Convert.ToInt32(angleChange.Text));
            Redraw();
            Refresh();
        }

        private void pitchUp_Click(object sender, EventArgs e)
        {
            pitchChange += ConvertToRads(Convert.ToInt32(angleChange.Text));
            Redraw();
            Refresh();
        }

        private void pitchDown_Click(object sender, EventArgs e)
        {
            pitchChange -= ConvertToRads(Convert.ToInt32(angleChange.Text));
            Redraw();
            Refresh();
        }

        private void rollUnclockwise_Click(object sender, EventArgs e)
        {
            rollChange += ConvertToRads(Convert.ToInt32(angleChange.Text));
            Redraw();
            Refresh();
        }

        private void rollClockwise_Click(object sender, EventArgs e)
        {
            rollChange -= ConvertToRads(Convert.ToInt32(angleChange.Text));
            Redraw();
            Refresh();
        }
    }
}
