namespace RenderEngine {
    class Object {
        
        Vector _origin;
        Vector _size;
        Vector _rotation;
        public Object() {
            _origin = new Vector();
            _size = new Vector();
            _rotation = new Vector();
            }
        public Object(Vector porigin, Vector psize, Vector protation) {
            _origin = porigin;
            _size = psize;
            _rotation = protation;
        }
        public Vector origin{
            get => _origin; set => _origin = value;
        }
        public Vector size{
            get => _size; set => _size = value;
        }
        public Vector rotation{
            get => _rotation; set => _rotation = value;
        }
    }
}