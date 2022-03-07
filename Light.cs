namespace RenderEngine {
    class Light {
        Vector _origin;
        double _brightness;
        public Light() {
            _origin = new Vector();
            _brightness = 1;
        }
        public Light(Vector porigin, double pbrightness) {
            _origin = porigin;
            _brightness = pbrightness;
        }
    }
}