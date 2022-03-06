namespace RenderEngine {
    partial class Sphere {
        Vector _origin;
        double _radius;
        public Sphere() {
            _origin = new Vector();
            _radius = 1;
        }
        public Sphere(Vector porigin, double pradius) {
            _origin = porigin;
            _radius = pradius;
        }
        public Vector origin{
            get => _origin; set => _origin = value;
        }
        public double radius{
            get => _radius; set => _radius = value;
        }
    }
}