namespace RenderEngine {
    class Vector {
        private double _x;
        private double _y;
        private double _z;
        public Vector() {
            _x = 0;
            _y = 0;
            _z = 0;
            }
        public Vector(double px, double py, double pz) {
            _x = px;
            _y = py;
            _z = pz;
        }
        public double x{
            get => _x; set => _x = value;
        }
        public double y{
            get => _y; set => _y = value;
        }
        public double z{
            get => _z; set => _z = value;
        }
        public double[] get() {
            return new double[] {_x, _y, _z};
        }
        private void setLength(double plength) {
            _x=_x*plength/length;
            _y=_y*plength/length;
            _z=_z*plength/length;
        }
        public double length{
            get => Math.Sqrt(_x*_x + _y*_y + _z*_z); set => setLength(value);
        }
        public double dot(Vector to) {
            return _x*to.x+_y*to.y+_z*to.z;
        }
        public double angle(Vetor to) {
            return Math.Acos(dot(to)/(_length*to.length))/Math.PI;
        }
        public static Vector operator +(Vector a, Vector b) {
            return new Vector(a.x+b.x, a.y+b.y, a.z+b.z);
        }
        public static Vector operator -(Vector a, Vector b) {
            return new Vector(a.x-b.x, a.y-b.y, a.z-b.z);
        }
        public static Vector operator *(Vector a, double b) {
            return new Vector(a.x*b, a.y*b, a.z*b);
        }
        public static Vector operator /(Vector a, double b) {
            return new Vector(a.x/b, a.y/b, a.z/b);
        }
    }
}
