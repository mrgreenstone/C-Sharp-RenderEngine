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

        private Point NewTrace(Sphere[] spheres, Object viewplane, double offsetx, double offsety, Point closestpoint) {
            List<Point> specular_points = new List<Point>();
            Point specular_closestpoint = new Point(new Vector(double.PositiveInfinity,double.PositiveInfinity,double.PositiveInfinity), new Sphere(), Color.FromArgb(0,0,0,0));
            Point control = specular_closestpoint;
            Point test = specular_closestpoint;


            for (int s = 0; s < spheres.Length; s++) {
                Vector centervec = (new Vector(viewplane.origin.x - 1 + offsetx, viewplane.origin.y, viewplane.origin.z - 1 + offsety)-origin).reflectOn(closestpoint.origin-closestpoint.sphere.origin);



                Ray ray = new Ray(closestpoint.origin, centervec);
                Vector[] collisions = ray.Collides(spheres[s]);

                

                for (int c = 0; c < collisions.Length; c++) {

                    if ((closestpoint.sphere.specular > 0 || closestpoint.sphere.specular < 1) && spheres[s] != closestpoint.sphere) {
                        specular_points.Add(new Point(collisions[c], spheres[s], Color.FromArgb(255,
                                                                                            Convert.ToInt16((Convert.ToDouble(closestpoint.color.R)+1)*(1-closestpoint.sphere.specular)+      (((Convert.ToDouble(spheres[s].color.R)+1)*closestpoint.sphere.specular)-1)),
                                                                                            Convert.ToInt16((Convert.ToDouble(closestpoint.color.G)+1)*(1-closestpoint.sphere.specular)+      (((Convert.ToDouble(spheres[s].color.G)+1)*closestpoint.sphere.specular)-1)),
                                                                                            Convert.ToInt16((Convert.ToDouble(closestpoint.color.B)+1)*(1-closestpoint.sphere.specular)+      (((Convert.ToDouble(spheres[s].color.B)+1)*closestpoint.sphere.specular)-1)))));
                    }

                    
                }

                

            }
            


            specular_points.ForEach(point => {
                if ((point.origin-closestpoint.origin).length < (specular_closestpoint.origin-closestpoint.origin).length && point.sphere != closestpoint.sphere) {
                    specular_closestpoint = point;
                }
            });

            if (specular_points.Count == 0 || specular_points[0].sphere == control.sphere) specular_closestpoint = closestpoint;

            return specular_closestpoint;

        }
        public void Render(Sphere[] spheres, int raytracedepth) {
            Bitmap bitmap = new Bitmap(resx, resy, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            

            Object viewplane = new Object(new Vector(Math.Round((origin.x+Math.Cos((rotation.z+0.25)*2*3.14159265358979323846264338327950)*(fov/100))*10000)/10000, Math.Round((origin.y+Math.Sin((rotation.z+0.25)*2*3.14159265358979323846264338327950)*(fov/100))*10000)/10000, origin.z), new Vector(), new Vector(0, 0, rotation.z));

            // Object viewplane = new Object(new Vector(origin., origin.z), new Vector(), new Vector(0, 0, rotation.z));


            double maxsize = (resx > resy) ? resx : resy;
            double pixelsize = 2/maxsize;

            double offsetx = (maxsize-resx)/2*pixelsize+pixelsize/2;
            double offsety = (maxsize-resy)/2*pixelsize+pixelsize/2;

            double percent = 0;

            for (int x = 0; x < resx; x++) {
                if (x > 0 && percent != Math.Ceiling(100.0/resx*x)) {
                    percent = Math.Ceiling(100.0/resx*x);
                    Console.Write(percent);
                    if (percent == 69) Console.WriteLine("% nice");
                    else Console.WriteLine("%");
                }

                for (int y = 0; y < resy; y++) {
                    
                    List<Point> points = new List<Point>();
                    Point closestpoint = new Point(new Vector(double.PositiveInfinity,double.PositiveInfinity,double.PositiveInfinity), new Sphere(), Color.FromArgb(0,0,0,0));

                    for (int s = 0; s < spheres.Length; s++) {
                        Ray ray = new Ray(origin, new Vector(viewplane.origin.x - 1 + offsetx, viewplane.origin.y, viewplane.origin.z - 1 + offsety)-origin);
                        Vector[] collisions = ray.Collides(spheres[s]);

                        for (int c = 0; c < collisions.Length; c++) {
                            points.Add(new Point(collisions[c], spheres[s], spheres[s].color));
                        }
                    }

                    
                    points.ForEach(point => {
                        if ((point.origin-origin).length < (closestpoint.origin-origin).length) {
                            closestpoint = point;
                        }
                    });

                    

                    // reflections

                    for (int r = 0; r < raytracedepth; r++) {
                        closestpoint = NewTrace(spheres, viewplane, offsetx, offsety, closestpoint);
                    }

                    

                    // reflections

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