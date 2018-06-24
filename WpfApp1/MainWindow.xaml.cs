using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {

        public ImgChng imgChng;
        public double dar;


        public MainWindow()
        {



            InitializeComponent();
            imgChng = new ImgChng();
            dar = imgChng.Width;
            this.DataContext = this.imgChng;




        }
        #region image   functions
        public void Stretchy(object sender, RoutedEventArgs e)
        {
            rect.SelectedIndex = 0;

            imgChng.Width = 1.1 * imgChng.Width;
            
        }
        public void Narrow(object sender, RoutedEventArgs e)
        {

            imgChng.Width = imgChng.Width / 1.1;
            rect.SelectedIndex = 2;
        }
        public void Rotate(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation
                 (360, 0, new Duration(TimeSpan.FromSeconds(3)));
            RotateTransform rt = new RotateTransform();
            phot.RenderTransform = rt;
            //image1.RenderTransformOrigin = new Point(0.5, 0.5);
            rect.SelectedIndex = 1;

            da.RepeatBehavior =new RepeatBehavior(1);
            rt.BeginAnimation(RotateTransform.AngleProperty, da);

        }
        #endregion
        public void Diss(object sender, RoutedEventArgs e)
        { (sender as Window).Height = 1;
            //Console.Beep();

            return;
        }
        public void Ovr(object sender, RoutedEventArgs e)
        {
            System.Windows.Media.Color col = System.Windows.Media.Color.FromRgb(10, 155, 155);

            var cnt = (sender as Border);
            cnt.Background = new SolidColorBrush(col);
        }
        public void Lovr(object sender, RoutedEventArgs e)
        {

            var cnt = (sender as Border);
            cnt.Background = new SolidColorBrush(Colors.AliceBlue);
        }
        
        
        public   void Upload(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.DefaultExt = ".jpg"; // Required file extension 
                fileDialog.Filter = "Picture (.jpg)|*.jpg"; // Optional file extensions

            if (fileDialog.ShowDialog() == true)
            {
                
                //string l = image.ToString().Trim('{','}');
                    phot.Source = new BitmapImage(new Uri(fileDialog.FileName));

                }
            });
        }

        private void rect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }



    public class ImgChng :  INotifyPropertyChanged
        {
            private double mwidth;
        private double mheight;

        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };


            public ImgChng() 
            {
                mwidth = 100;
                mheight = 100;

            }

            public  double Width
            {
            get => mwidth;
            set  
                {
                    this.mwidth = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyRaised(nameof(Width));

                }
            }
        public double Height
        {
            get => mheight;
            set
            {
                this.mheight = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyRaised(nameof(Height));

            }
        }
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyRaised([CallerMemberName] string width="")
            {
                //PropertyChangedEventHandler handler = PropertyChanged;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(width));
                }
            }


        }
    }



