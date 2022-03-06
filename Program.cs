namespace RenderEngine {
    class Program {
        static void Main() {
            Camera camera = new Camera(new Vector(0, -5, 0), new Vector(1, 1, 1), new Vector(0.25, 0, 0), 50, 16, 16);
        }
    }
}