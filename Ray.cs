namespace RenderEngine {
    partial class Ray : Straight {
        public Ray() : base() {}
        public Ray(Vector porigin, Vector pdirection) : base(porigin, pdirection) {}

        public bool Collides(Sphere sphere) {
            double cx = sphere.origin.x;
            double cy = sphere.origin.y;
            double cz = sphere.origin.z;
            double r = sphere.radius;
            Vector oc = origin-sphere.origin;
            double a = origin.length*origin.length;
            double b = 2*oc.dot(direction);
            double c = oc.length*oc.length - r*r;
            double discriminant = b*b - 4*a*c;
            return (discriminant>0);
        }
    }
}

