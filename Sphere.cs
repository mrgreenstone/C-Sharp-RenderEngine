using System.Drawing;

namespace RenderEngine {
    partial class Sphere {
        Vector _origin;
        double _radius;
        double _specular;
        Color _color;
        public Sphere() {
            _origin = new Vector();
            _radius = 1;
            _specular = 0;
            _color = Color.FromArgb(0,0,0,0);
        }
        public Sphere(Vector porigin, double pradius, double pspecular, Color pcolor) {
            _origin = porigin;
            _radius = pradius;
            _color = pcolor;
            _specular = pspecular;
        }
        public Vector origin {
            get => _origin; set => _origin = value;
        }
        public double radius {
            get => _radius; set => _radius = value;
        }
        public double specular {
            get => _specular; set => _specular = value;
        }
        public Color color {
            get => _color; set => _color = value;
        }
    }
}