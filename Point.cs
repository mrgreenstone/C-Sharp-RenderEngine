using System.Drawing;

namespace RenderEngine {
    partial class Point {
        Vector _origin;
        Color  _color;
        public Point() {
            _origin = new Vector();
            color = Color.FromArgb(0,0,0,0);
        }
        public Point(Vector porigin, Color pcolor)  {
            _origin = porigin;
            _color = pcolor;
        }
        public Vector origin{
            get => _origin; set => _origin = value;
        }
        public Color color{
            get => _color; set => _color = value;
        }
    }
}