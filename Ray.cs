namespace RenderEngine {
    partial class Ray : Straight {
        public Ray() : base() {}
        public Ray(Vector porigin, Vector pdirection) : base(porigin, pdirection) {}

        public Vector[] Collides(Sphere sphere) {
            double xc = sphere.origin.x;
            double yc = sphere.origin.y;
            double zc = sphere.origin.z;
            double x0 = origin.x;
            double y0 = origin.y;
            double z0 = origin.z;
            double x1 = origin.x + direction.x;
            double y1 = origin.y + direction.y;
            double z1 = origin.z + direction.z;
            double a = (x0-xc) * (x0-xc) + (y0-yc) * (y0-yc) + (z0-zc) * (z0-zc) - r*r;
            double b = (x0-x1) * (x0-x1) + (y0-y1) * (y0-y1) + (z0-z1) * (z0-z1);
            double c = (x1-xc) * (x1-xc) + (y1-yc) * (y1-yc) + (z1-zc) * (z1-zc) - a - b - r * r;
            if ((c/b/2) * (c/b/2) - a/b < 0) {
                return new Vector[] {};
            } else if ((c/b/2) * (c/b/2) - a/b == 0) {
                double t = - c/b/2;
                return new Vector[] {at(t)};
            } else {
                double t0 = - c/b/2 - Math.Sqrt((c/b/2) * (c/b/2) - a/b);
                double t1 = - c/b/2 + Math.Sqrt((c/b/2) * (c/b/2) - a/b);
                return new Vector[] {at(t0), at(t1)};
            }
            
            
        }
    }
}

