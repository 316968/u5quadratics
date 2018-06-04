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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U5Quadratic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   int a;
        int b;
        int c;    
        public MainWindow()
        {
            
            InitializeComponent();
           
            Line line = new Line();
            line.StrokeThickness = 1;
            line.Stroke = Brushes.Black;
            line.X1 = 325;
            line.X2 = 325;
            line.Y1 = 50;
            line.Y2 = 450;
            canvas.Children.Add(line);

            Line line2 = new Line();
            line2.StrokeThickness = 1;
            line2.Stroke = Brushes.Black;
            line2.X1 = 125;
            line2.X2 = 525;
            line2.Y1 = 250;
            line2.Y2 = 250;
            canvas.Children.Add(line2);

            for (int i = 0; i < 41; i++)
            {
                Rectangle tick1 = new Rectangle();
                tick1.Height = 10;
                tick1.Width = 1;
                tick1.Fill = Brushes.Black;
                Canvas.SetLeft(tick1, 125 + i * 10);
                Canvas.SetTop(tick1, 245);
                canvas.Children.Add(tick1);

                Rectangle tick2 = new Rectangle();
                tick2.Height = 1;
                tick2.Width = 10;
                tick2.Fill = Brushes.Black;
                Canvas.SetLeft(tick2, 320);
                Canvas.SetTop(tick2, 50 + i * 10);
                canvas.Children.Add(tick2);

            }
        }
        public virtual void RemoveRange(int index, int count)
        {

        }
        public void btnCompute_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.RemoveRange(89, 6002);
            a = Convert.ToInt32(txtA.Text);
            b = Convert.ToInt32(txtB.Text);
            c = Convert.ToInt32(txtC.Text);

            if (Convert.ToDouble((b * b) - (4 * a * c)) < 0)
            {
                MessageBox.Show("No zeros");
            }
            else if (Convert.ToDouble((b*b) - (4 * a * c))== 0)
            {
                double out1 = ((-b + Math.Sqrt((b * b) - 4 * a * c)) / (2 * a));
                lblOutput.Content = (Math.Round(out1, 3)).ToString();
                rDot(out1);
            }
            else
            {
                double root1 = ((-b + Math.Sqrt((b * b) - 4 * a * c)) / (2 * a));
                double root2 = ((-b - Math.Sqrt((b * b) - 4 * a * c)) / (2 * a));
                /*if (root1 == root2)
                {
                    lbl.Content = root1;
                }*/
                lblOutput.Content = (Math.Round(root1, 3)).ToString() + (Math.Round(root2, 3));
                rDot(root1);
                rDot(root2);
                
            }
            for(int i = -3000; i < 3000; i++)
            {
                generateDot(i);
            }
        }
        public void generateDot(int p)
        {
            Ellipse ellipsex = new Ellipse();
            ellipsex.Width = 2;
            ellipsex.Height = 2;
            ellipsex.Fill = Brushes.Black;
            Canvas.SetLeft(ellipsex, (p * 0.005) * 10 + 325);
            Canvas.SetTop(ellipsex, (250 - (((p * 0.005 * p * 0.005) * a + p * 0.005 * b + c) * 10)));
            canvas.Children.Add(ellipsex);

        }
        public void rDot(double y)
        {
            Ellipse ellipseY = new Ellipse();
            ellipseY.Width = 6;
            ellipseY.Height = 6;
            Canvas.SetLeft(ellipseY, 323 + y + 10);
            Canvas.SetTop(ellipseY, 247);
            ellipseY.Fill = Brushes.Red;
            canvas.Children.Add(ellipseY);
        }
    }
}
