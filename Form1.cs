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
        private Camera camera = new Camera(640, 640, ConvertToRads(90), 1, 200);
        private PointLight light = new PointLight(new Point3F(1, 1, 1), new Color3F(1, 1, 1));
        private TextureBuffer texture = new TextureBuffer(new Bitmap("webber_diffuse4.png"));
        private Mesh mesh = ObjectParser.GetMeshFromObj("webber_cool.obj");
        private Model model;

        private Color newColor = Color.FromArgb(0, 255, 255);

        Rectangle rect = new Rectangle(0, 0, 640, 640);

        private float xOffset = 0;
        private float yOffset = 3;
        private float zOffset = 6;

        private float yawChange = 0;
        private float pitchChange = 0;
        private float rollChange = ConvertToRads(180);

        private SolidBrush backgroundBrush = new SolidBrush(Color.LightGray); // Кисть фона
        private Pen pen = new Pen(Color.White);

        public Form1()
        {
            InitializeComponent();

            model = new Model(mesh, texture);
            camera.RotateTo(new Angle3F(yawChange, pitchChange, rollChange));

            outputBox.Image = camera.outputBuffer.GetBitmap();
        }

        private static float ConvertToRads(int degrees)
        {
            return degrees * (float)Math.PI / 180f;
        }

        private void Redraw()
        {
            //Graphics.FromImage(outputBox.Image).FillRectangle(backgroundBrush, rect);
            //model.MoveTo(new Point3F(0, 0, -6));
            camera.MoveTo(new Point3F(xOffset, yOffset, zOffset));
            //light.MoveTo(new Point3F(xOffset, yOffset, zOffset));
            camera.RotateTo(new Angle3F(yawChange, pitchChange, rollChange));
            camera.outputBuffer.Open();
            camera.Draw(model, light);
            camera.outputBuffer.Close();
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, 640, 640);
            Color newColor = Color.FromArgb(255, 0, 0);

            for (float i = 0f; i < 3.14f * 2; i += 0.1f)
            {
                light.SetColor(new Color3F((float)(192 - 63 * Math.Sin(i * 5)) / 255, 64.0f / 255, (float)(192 - 63 * Math.Cos(i * 5)) / 255));
                Graphics.FromImage(outputBox.Image).FillRectangle(backgroundBrush, rect);
                //for(int j = 0; j < 128; j++)
                //{
                //    float p1 = 640.0f * (float)rand.NextDouble();
                //    float p2 = 640.0f * (float)rand.NextDouble();

                //    Graphics.FromImage(outputBox.Image).DrawLine(pen, p1, p2, p1 + 40, p2);
                //}
                light.MoveTo(new Point3F(2 * (float)Math.Cos(i), 0, 3 * (float)Math.Sin(i)));
                model.MoveTo(new Point3F(2 * (float)Math.Cos(i), 3 * (float)Math.Sin(i), 0));
                // model.RotateTo(new Angle3F(ConvertToRads(90), (float)Math.Sin(i / 2), 0));
                // model.ScaleTo(new Point3F(0.01f * (float)Math.Sin(i) + 0.085f, 0.01f * (float)Math.Sin(i) + 0.085f, 0.01f * (float)Math.Sin(i) + 0.085f));
                camera.MoveTo(new Point3F(xOffset, yOffset, zOffset));
                camera.outputBuffer.Open();
                camera.Draw(model, light);
                camera.outputBuffer.Close();
                Refresh();
            }
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

        private void moveOut_Click(object sender, EventArgs e)
        {
            zOffset += (float)Convert.ToDouble(offsetValue.Text);
            Redraw();
            Refresh();
        }

        private void moveCloser_Click(object sender, EventArgs e)
        {
            zOffset -= (float)Convert.ToDouble(offsetValue.Text);
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
