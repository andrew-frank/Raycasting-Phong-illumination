using RayCastingAndPhong.RayCasting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RayCastingAndPhong
{

    public class PointToCheck
    {
        public double x;
        public double y;
        public double delta;

        public override string ToString()
        {
            return "[" + x + ", " + y + "| Delta: " + delta + "]";
        }
    }

    public partial class MainWindow : Window
    {

        private int canvasWidth = -1;
        private int canvasHeight = -1;

        private Sphere sampleSphere = new Sphere {
            Center = new SinglePoint { x = 50, y = 50, z = 4 },
            R = 255,
            G = 0,
            B = 0,
            Radius = 500,
            SpehereColor = Colors.Green
        };

        private SinglePoint camera = new SinglePoint {
            x = 0, y = 0, z = 0
        };

        private List<PointToCheck> grid = new List<PointToCheck>();

        private List<SinglePoint> pointsOfIntersection = new List<SinglePoint>();

        Vector3D normalVector = new Vector3D();
        Vector3D lightVector = new Vector3D();

        double dx, dy, dz, a, b, c, delta, t;

        SinglePoint lightPoint = new SinglePoint();

        //PHONG VARIABLES
        Vector3D vectorN = new Vector3D();
        Vector3D vectorL = new Vector3D();
        Vector3D vectorV = new Vector3D();
        Vector3D vectorR = new Vector3D();


        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Activated(object sender, EventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.canvasWidth = (int)this.gOurGrid.ActualWidth; //Canvas.ActualWidthProperty(this.cOurCanvas);// (int)this.cOurCanvas.Width;
            //this.canvasHeight = (int)this.gOurGrid.ActualHeight;
            this.canvasHeight = 400;
            this.canvasWidth = 400;

            this.Start();
        }

        private void Reset()
        {
            this.cOurCanvas.Children.Clear();
        }

        private void Start()
        {
            
            //DrawPixel(this.canvasWidth/2, this.canvasHeight/2, Colors.Red, 40);
            //DrawPixel(100, 100, Colors.Blue, 40);
            //DrawPixel(-100, -100, Colors.Blue, 40);
            if (this.canvasWidth <= 0 || this.canvasHeight <= 0)
                return;
            
            for (int i = -this.canvasWidth / 2; i < this.canvasWidth / 2; i++) {
                for (int j = -this.canvasHeight / 2; j < this.canvasHeight / 2; j++)
                    this.SphereInterscetionCheck(this.camera, new SinglePoint { x = i, y = j, z = 0 });
            }
            
            Debug.WriteLine("\n\n******------- Done ------******\n");
            //DrawPixel(0, 0, Colors.Orange, 4);

        }


        private void DrawPixel(double x, double y, Color color, int size)
        {
            Ellipse el = new Ellipse();
            el.Width = size;
            el.Height = size;
            el.Fill = new SolidColorBrush(color);
            Canvas.SetLeft(el, x - size / 2);
            Canvas.SetTop(el, y - size / 2);
            cOurCanvas.Children.Add(el);

            //SinglePoint p = new SinglePoint();
        }

        private void ShiftCoordinates(ref SinglePoint p)
        {
            p.x += this.canvasWidth / 2;
            p.y += this.canvasHeight / 2;
        }

        /*   A sphere is given by its center (cx, cy, cz), its radius R, and its color (SR, SG, SB).
         *   line segment (ray) is given by its endpoints: P0 = (x0, y0, z0) and P1 = (x1, y1, z1).
         *   To find visible spheres, set P0 = viewer’s coordinates, VP = (VPx, VPy, VPz) and let P1 run through
         *   all the points (x1, y1, 0) where (x1, y1) is a pixel in the display area. 
         * 
         */
        private void SphereInterscetionCheck(SinglePoint p0, SinglePoint p1)
        {
            lightPoint.x = 0;
            lightPoint.y = 50;
            lightPoint.z = 0;

            //p1.z = (double)Math.Sqrt(Math.Pow(p0.x - p1.x, 2) + Math.Pow(p0.y - p1.y, 2) + Math.Pow(p0.z - p1.z, 2));

            dx = p1.x - p0.x;
            dy = p1.y - p0.y;
            dz = p1.z - p0.z;

            a = dx * dx + dy * dy + dz * dz;
            b = 2 * dx * (p0.x - this.sampleSphere.Center.x) + 2 * dy * (p0.y - this.sampleSphere.Center.y) + 2 * dz * (p0.z - this.sampleSphere.Center.z);
            c = this.sampleSphere.Center.x * this.sampleSphere.Center.x + this.sampleSphere.Center.y * this.sampleSphere.Center.y
                + this.sampleSphere.Center.z * this.sampleSphere.Center.z + p0.x * p0.x + p0.y * p0.y + p0.z * p0.z
                - 2 * (this.sampleSphere.Center.x * p0.x + this.sampleSphere.Center.y * p0.y + this.sampleSphere.Center.z * p0.z)
                - this.sampleSphere.Radius * this.sampleSphere.Radius;

            delta = b * b - 4 * a * c;

            t = (-b - Math.Sqrt(delta)) / (2 * a);
            SinglePoint diffuseShadingPoint = new SinglePoint { x = p0.x + t * dx, y = p0.y + t * dy, z = p0.z + t * dz };
            pointsOfIntersection.Add(diffuseShadingPoint);


            if (delta < 0) {
                DrawPixel((p0.x + t * dx), (p0.y + t * dy), Colors.Black, 1);
            } else if (delta == 0) {
                //DrawPixel((int)p1.x, (int)p1.y, this.sampleSphere.SpehereColor, 1);
                //this.grid.Add(new PointToCheck { x = (int)p1.x, y = (int)p1.y });

                //DrawPixel((p0.x + t * dx), (p0.y + t * dy), Colors.Green, 1);
                //this.grid.Add(new PointToCheck { x = (p0.x + t * dx), y = (p0.y + t * dy), delta = delta });

                DrawPixel((p0.x + t * dx), (p0.y + t * dy), DiffuseShading(diffuseShadingPoint, lightPoint), 1);
                this.grid.Add(new PointToCheck { x = (p0.x + t * dx), y = (p0.y + t * dy), delta = delta });


            } else {
                //DrawPixel((int)p1.x, (int)p1.y, this.sampleSphere.SpehereColor, 1);
                //this.grid.Add(new PointToCheck { x = (int)p1.x, y = (int)p1.y });

                //DrawPixel((p0.x + t * dx), (p0.y + t * dy), Colors.Red, 1);
                //this.grid.Add(new PointToCheck { x = (p0.x + t * dx), y = (p0.y + t * dy), delta = delta });

                DrawPixel((p0.x + t * dx), (p0.y + t * dy), DiffuseShading(diffuseShadingPoint, lightPoint), 1);
                this.grid.Add(new PointToCheck { x = (p0.x + t * dx), y = (p0.y + t * dy), delta = delta });


            }          

        }
        private Color DiffuseShading(SinglePoint interscetionPoint, SinglePoint lightPoint)
        {                   
            //Unit normal vector
            normalVector.X = (interscetionPoint.x - this.sampleSphere.Center.x) / this.sampleSphere.Radius;
            normalVector.Y = (interscetionPoint.y - this.sampleSphere.Center.y) / this.sampleSphere.Radius;
            normalVector.Z = (interscetionPoint.z - this.sampleSphere.Center.z) / this.sampleSphere.Radius;

            //Vector from normal to the Light
            lightVector.X = (lightPoint.x - interscetionPoint.x);// / Math.Abs(lightPoint.x - interscetionPoint.x);
            lightVector.Y = (lightPoint.y - interscetionPoint.y);// / Math.Abs(lightPoint.y - interscetionPoint.y);
            lightVector.Z = (lightPoint.z - interscetionPoint.z);// / Math.Abs(lightPoint.z - interscetionPoint.z);
            lightVector.Normalize();
            //constants
            double kd = 0.8;
            double ka = 0.2;

            double fctr = Vector3D.DotProduct(normalVector, lightVector);
            Color resultColor = new Color();
            resultColor.R = (byte)(ka * this.sampleSphere.R + kd * fctr * this.sampleSphere.R);
            resultColor.G = (byte)(ka * this.sampleSphere.G + kd * fctr * this.sampleSphere.G);
            resultColor.B = (byte)(ka * this.sampleSphere.B + kd * fctr * this.sampleSphere.B);
            resultColor.A = 1;

            return resultColor;
        }
        private Color PhongIllumination(SinglePoint pointOfInterscetion, Vector3D normalVector)
        {           
            vectorN = normalVector;
            vectorL = lightVector;
            vectorR.X = (this.sampleSphere.Center.x - pointOfInterscetion.x);
            vectorR.Y = (this.sampleSphere.Center.y - pointOfInterscetion.y);
            vectorR.Z = (this.sampleSphere.Center.z - pointOfInterscetion.z);
            vectorV = -vectorR;
            


            return new Color();
        }

    }
}
