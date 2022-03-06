using System.Drawing;

namespace RenderEngine {
    class Camera : Object {
        double fov = 50;
        int resx = 512;
        int resy = 512;
        public Camera() : base() {}
        public Camera(Vector porigin, Vector psize, Vector protation, double pfov, int presx, int presy) : base(porigin, psize, protation) {
            fov = pfov;
            resx = presx;
            resy = presy;
        }
        public async void Render() {
            Bitmap bitmap = new Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            bitmap.SetPixel(10,5,Color.FromArgb(255,255,0,0));
            bitmap.Save(@"drawing.png");

            Object viewplane = new Object();

            for (int x = 0; x < resx; x++) {
                for (int y = 0; y < resy; y++) {
                    
                }
            }
            
        }
    }
}