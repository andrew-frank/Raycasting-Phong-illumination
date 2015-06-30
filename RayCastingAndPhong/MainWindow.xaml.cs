using RayCastingAndPhong.RayCasting;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///    
    public partial class MainWindow : Window
    {
        byte[] pixels;
        
        public MainWindow()
        {
            InitializeComponent();
            DrawPixel(0, 0, Colors.Red, 50);
            //Sphere sampleSphere = new Sphere();
            //sampleSphere.Radius = 10;
            //sampleSphere.SpehereColor = Colors.Red;
            //sampleSphere.R = 255;
            //sampleSphere.G = 0;
            //sampleSphere.B = 0;
            //sampleSphere.Center = new SinglePoint();
            //sampleSphere.Center.x =5170;
            //sampleSphere.Center.y= 60;
            //sampleSphere.Center.z = 8;

            //SinglePoint pointOfTheViewer = new SinglePoint();
            //pointOfTheViewer.x = 100;
            //pointOfTheViewer.y = 80;
            //pointOfTheViewer.z = 1;

            //int canvasWidth = 500;
            //int canvasHeight = 300;
            //int[,] intersections = new int[canvasWidth, canvasHeight];
            //SphereInterscetionCheck(sampleSphere, pointOfTheViewer, canvasWidth, canvasHeight);
        }
        private void DrawPixel(int x, int y, Color color, int size)
        {
            Ellipse el = new Ellipse();
            el.Width = size;
            el.Height = size;
            el.Fill = new SolidColorBrush(color);
            Canvas.SetLeft(el, x);
            Canvas.SetTop(el, y);
            cOurCanvas.Children.Add(el);
        }

        /*   A sphere is given by its center (cx, cy, cz), its radius R, and its color (SR, SG, SB).
         *   line segment (ray) is given by its endpoints: P0 = (x0, y0, z0) and P1 = (x1, y1, z1).
         *   To find visible spheres, set P0 = viewer’s coordinates, VP = (VPx, VPy, VPz) and let P1 run through
         *   all the points (x1, y1, 0) where (x1, y1) is a pixel in the display area. 
         * 
         */
     //   private void SphereInterscetionCheck(Sphere sphere, SinglePoint viewerPoint, int width, int height)
     //   {           
     //       double dx, dy, dz, a, b, c, delta;
     //       SinglePoint lightPoint = new SinglePoint();
     //       lightPoint.x = 10;
     //       lightPoint.y = 15;
     //       lightPoint.z = 5;

     //       int [,] resultOfIntersection = new int[width, height];
     //       for (int i = 0; i < width; i++) {
     //           for (int j = 0; j < height; j++) {
     //               dx = i - viewerPoint.x;
     //               dy = j - viewerPoint.y;
     //               dz = 0 - viewerPoint.z;

     //               a = dx * dx + dy * dy + dz * dz;
     //               b = 2 * dx * (viewerPoint.z - sphere.Center.x) + 2 * dy * (viewerPoint.y - sphere.Center.y) + 2 * dz * (viewerPoint.z - sphere.Center.z);
     //               c = sphere.Center.x * sphere.Center.x + sphere.Center.y * sphere.Center.y + sphere.Center.z * sphere.Center.z + viewerPoint.x * viewerPoint.x + viewerPoint.y * viewerPoint.y + viewerPoint.z * viewerPoint.z -2 * (sphere.Center.x * viewerPoint.x + sphere.Center.y * viewerPoint.y + sphere.Center.z * viewerPoint.z) - sphere.Radius * sphere.Radius;
              
     //               delta = b * b - 4 * a * c;
     //               if (delta < 0) //Findinghadowws
     //                   DrawPixel(i, j, Colors.Blue);//FindShadows(new SinglePoint { x = i, y = j, z = 0 }, lightPoint, width, height)
     //               else if (delta == 0)
     //                   DrawPixel(i, j, (DiffuseShading(sphere, viewerPoint, lightPoint, dx, dy, dz, a, b, c, width, height)));//resultOfIntersection[i, j] = 1;
     //               else
     //                   DrawPixel(i, j, (DiffuseShading(sphere, viewerPoint, lightPoint, dx, dy, dz, a, b, c, width, height)));//resultOfIntersection[i, j] = 2;
     //           }
     //       }           
     //}
     //   private Color DiffuseShading(Sphere sphere, SinglePoint viewerPoint, SinglePoint lightPoint, double dx, double dy, double dz, double a, double b, double c, int width, int height)
     //   {
     //       double x, y, z, t;
     //       Vector3D normalVector = new Vector3D();
     //       Vector3D lightVector = new Vector3D(); 
     //       t = (-b -Math.Sqrt(b*b - 4*a*c))/(2*a);

     //       x = viewerPoint.x + t * dx;
     //       y = viewerPoint.y + t * dy;
     //       z = viewerPoint.z + t * dz;

     //       //Unit normal vector
     //       normalVector.X = ((x - sphere.Center.x) / sphere.Radius);
     //       normalVector.Y = (y - sphere.Center.y) / sphere.Radius;
     //       normalVector.Z = (z - sphere.Center.z) / sphere.Radius;

     //       //Vector from normal to the Light
     //       lightVector.X = lightPoint.x - x;
     //       lightVector.Y = lightPoint.y - y;
     //       lightVector.Z = lightPoint.z - z;

     //       //constants
     //       double kd = 0.8;
     //       double ka = 0.2;

     //       double fctr = Vector3D.DotProduct(normalVector, lightVector);
     //       Color resultColor = new Color();
     //       resultColor.R = (byte)(ka*sphere.R + kd*fctr*sphere.R);
     //       resultColor.G = (byte)(ka * sphere.G + kd*fctr*sphere.G);
     //       resultColor.B = (byte)(ka*sphere.B + kd*fctr*sphere.B);
     //       resultColor.A = 1;

     //       return resultColor;               
     //    }     
        
    }
}
