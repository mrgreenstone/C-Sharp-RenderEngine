using System.Drawing;

namespace RenderEngine {
    class Camera : Object {
        double fov = 50;
        int resx = 512;
        int resy = 384;
        public Camera() : base() {}
        public Camera(Vector porigin, Vector psize, Vector protation, double pfov, int presx, int presy) : base(porigin, psize, protation) {
            fov = pfov;
            resx = presx;
            resy = presy;
        }
        public void Render(Sphere[] spheres) {
            Bitmap bitmap = new Bitmap(resx, resy, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            

            Object viewplane = new Object(new Vector(Math.Round((origin.x+Math.Cos((rotation.z+0.25)*2*3.14159265358979323846264338327950)*(fov/100))*10000)/10000, Math.Round((origin.y+Math.Sin((rotation.z+0.25)*2*3.14159265358979323846264338327950)*(fov/100))*10000)/10000, origin.z), new Vector(), new Vector(0, 0, rotation.z));

            // Object viewplane = new Object(new Vector(origin., origin.z), new Vector(), new Vector(0, 0, rotation.z));


            double maxsize = (resx > resy) ? resx : resy;
            double pixelsize = 2/maxsize;

            double offsetx = (maxsize-resx)/2*pixelsize+pixelsize/2;
            double offsety = (maxsize-resy)/2*pixelsize+pixelsize/2;

            for (int x = 0; x < resx; x++) {
                if (x > 0) Console.Write(Math.Round(Convert.ToDouble(x)/Convert.ToDouble(resx-1)*10000)/100);
                else Console.Write(0.00);
                Console.WriteLine("%");
                for (int y = 0; y < resy; y++) {
                    
                    List<Point> points = new List<Point>();
                    Point closestpoint = new Point(new Vector(double.PositiveInfinity,double.PositiveInfinity,double.PositiveInfinity), Color.FromArgb(0,0,0,0));

                    for (int s = 0; s < spheres.Length; s++) {
                        Ray ray = new Ray(origin, new Vector(viewplane.origin.x - 1 + offsetx, viewplane.origin.y, viewplane.origin.z - 1 + offsety)-origin);
                        Vector[] collisions = ray.Collides(spheres[s]);

                        for (int c = 0; c < collisions.Length; c++) {
                            points.Add(new Point(collisions[c], spheres[s].color));
                        }
                    }
                    
                    points.ForEach(point => {
                        if ((point.origin-origin).length < (closestpoint.origin-origin).length) {
                            closestpoint = point;
                        }
                    });

                    bitmap.SetPixel(x, resy - y - 1, closestpoint.color);

                    offsety += pixelsize;
                }
                offsetx += pixelsize;
                offsety = (maxsize-resy)/2*pixelsize+pixelsize/2;
            }
            bitmap.Save(@"drawing.png");
        }
    }
}