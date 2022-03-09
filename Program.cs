using System.Drawing;

namespace RenderEngine {
    class Program {
        static void Main() {
            DateTime time = DateTime.Now;
            Sphere[] spheres = {new Sphere(new Vector(-1.5, 0, -0.866), 1.5, 0.5, Color.FromArgb(255,255,0,0)),
                                new Sphere(new Vector(0, 0, 1.722), 1.5, 0.5, Color.FromArgb(255,0,255,0)),
                                new Sphere(new Vector(1.5, 0, -0.866), 1.5, 0.5, Color.FromArgb(255,0,0,255))};

            Camera camera = new Camera(new Vector(0, -20, 0), new Vector(1, 1, 1), new Vector(0, 0, 0), 500, 2048, 2048);

            camera.Render(spheres, 24);

            Console.WriteLine(DateTime.Now-time);
        }
    }
}