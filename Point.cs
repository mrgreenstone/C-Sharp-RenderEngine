using System.Drawing;

namespace RenderEngine {
    partial class Point {
        Vector _origin;
        Sphere _sphere;
        Color  _color;
        public Point() {
            _origin = new Vector();
            color = Color.FromArgb(0,0,0,0);
            _sphere = new Sphere();
        }
        public Point(Vector porigin, Sphere psphere, Color pcolor)  {
            _origin = porigin;
            _color = pcolor;
            _sphere = psphere;
        }
        public Vector origin{
            get => _origin; set => _origin = value;
        }
        public Sphere sphere{
            get => _sphere; set => _sphere = value;
        }
        public Color color{
            get => _color; set => _color = value;
        }
    }
}