using System.Drawing;

namespace RenderEngine {
    partial class Sphere {
        Vector _origin;
        double _radius;
        Color _color;
        public Sphere() {
            _origin = new Vector();
            _radius = 1;
        }
        public Sphere(Vector porigin, double pradius, Color pcolor) {
            _origin = porigin;
            _radius = pradius;
            _color = pcolor;
        }
        public Vector origin {
            get => _origin; set => _origin = value;
        }
        public double radius {
            get => _radius; set => _radius = value;
        }
        public Color color {
            get => _color; set => _color = value;
        }
    }
}