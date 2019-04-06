using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomStructures;
using System.Drawing;

namespace Renderer
{
    class PointLight
    {
        public Point3F position { get; private set; }
        public Color3F color { get; private set; }

        public PointLight(Point3F position, Color3F color)
        {
            this.position = position;
            this.color = color;
        }

        public void MoveTo(Point3F position)
        {
            this.position = position;
        }

        public void SetColor(Color3F color)
        {
            this.color = color;
        }
    }
}
