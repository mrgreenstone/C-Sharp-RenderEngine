using System.Drawing;

namespace RenderEngine {
    class Program {
        static void Main() {
            DateTime time = DateTime.Now;
            Sphere[] spheres = {new Sphere(new Vector(-2, 2, 0), 1, Color.FromArgb(255,255,0,0)), new Sphere(new Vector(-4, 10, 0), 1.5, Color.FromArgb(255,0,255,255)), new Sphere(new Vector(), 2, Color.FromArgb(255,0,255,0)), new Sphere(new Vector(3, 0, 0), 1, Color.FromArgb(255,0,0,255))};

            Camera camera = new Camera(new Vector(0, -20, 0), new Vector(1, 1, 1), new Vector(0, 0, 0), 500, 2048, 2048);

            camera.Render(spheres);
            Console.WriteLine(DateTime.Now-time);
        }
    }
}



//Nähster Punkt => Grade(Punkt zu Licht) bei Schnitten mit anderen Kugeln => kein Licht, bei keinen schnitten, Winkel zum Spiegelvektor vergleichen(klein => hell)