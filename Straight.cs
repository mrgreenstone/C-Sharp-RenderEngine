namespace RenderEngine {
    partial class Straight {
        Vector _origin;
        Vector _direction;
        public Straight() {
            _origin = new Vector();
            _direction = new Vector();
        }
        public Straight(Vector porigin, Vector pdirection)  {
            _origin = porigin;
            _direction = pdirection;
        }
        public Vector origin{
            get => _origin; set => _origin = value;
        }
        public Vector direction{
            get => _direction; set => _direction = value;
        }
    }
}