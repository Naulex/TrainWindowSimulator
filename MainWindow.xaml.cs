using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Drawing;
using System.IO;
using System.Media;

namespace ProjectNaumov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer sp = new SoundPlayer(String.Format(@"file:///{0}/Data/2.wav", Directory.GetCurrentDirectory())); //Плеер

        SoundPlayer sp1 = new SoundPlayer(String.Format(@"file:///{0}/Data/1.wav", Directory.GetCurrentDirectory()));

        public MainWindow()
        {

            sp1.Play();
            sp1.PlayLooping();
            DateTime date1 = new DateTime(0, 0);
            InitializeComponent();
            name.IsEnabled = false;
            Ticket.IsEnabled = false;
            vagonplace.IsEnabled = false;
            placevagon.IsEnabled = false;

            int vagon;
            int ticket;
            int mesto;

            Random rnd = new Random(); //Вагон, номер билета и место вычисляются случайно
            vagon = rnd.Next(1, 10);
            ticket = rnd.Next(1, 1000);
            mesto = rnd.Next(1, 40);
            Ticket.Text = Convert.ToString(ticket);
            vagonplace.Text = Convert.ToString(vagon);
            placevagon.Text = Convert.ToString(mesto);

            DoubleAnimation db = new DoubleAnimation(); //Вращение солнца
            db.From = 0;
            db.To = 360;
            db.Duration = new Duration(TimeSpan.FromSeconds(32));
            RotateTransform rt = new RotateTransform();
            db.RepeatBehavior = RepeatBehavior.Forever;
            sun.RenderTransform = rt;
            rt.BeginAnimation(RotateTransform.AngleProperty, db);


            DoubleAnimation dc = new DoubleAnimation(); //Вращение луны
            dc.From = -180;
            dc.To = 180;
            dc.Duration = new Duration(TimeSpan.FromSeconds(32));
            RotateTransform ra = new RotateTransform();
            dc.RepeatBehavior = RepeatBehavior.Forever;
            moon.RenderTransform = ra;
            ra.BeginAnimation(RotateTransform.AngleProperty, dc);
        }

        private void Button1_Click(object sender, RoutedEventArgs e) //Обработчик кнопки "войти"
        {
            string username;
            if (textBox1.Text == "")
            { MessageBox.Show("У пассажира может не быть подписи, но должно быть имя!", "Внимание!"); }
            else
            {
                username = textBox1.Text;
                name.Text = username;
                DoubleAnimation da = new DoubleAnimation(); //Доска уезжает
                da.From = 0;
                da.To = 180;
                da.Duration = new Duration(TimeSpan.FromSeconds(3));
                RotateTransform rt = new RotateTransform();
                doska.RenderTransform = rt;
                rt.BeginAnimation(RotateTransform.AngleProperty, da);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Lighton_Click(object sender, RoutedEventArgs e)
        {
            RadialGradientBrush radialGradient = new RadialGradientBrush(); //Включение света
            radialGradient.GradientOrigin = new Point(0.3, 0.3);
            radialGradient.RadiusX = 1;
            radialGradient.RadiusY = 1;
            radialGradient.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            radialGradient.GradientStops.Add(new GradientStop(Colors.Orange, 1.0));


            lamp1.Fill = radialGradient;
            lamp2.Fill = radialGradient;
            lamp1L.Visibility = Visibility.Visible;
            lamp2L.Visibility = Visibility.Visible;
        }

        private void Lightoff_Click_1(object sender, RoutedEventArgs e)
        {
            lamp1.Fill = Brushes.LightYellow; //Выключение света
            lamp2.Fill = Brushes.LightYellow;
            lamp1L.Visibility = Visibility.Hidden;
            lamp2L.Visibility = Visibility.Hidden;

        }


        private void Musstart_Click(object sender, RoutedEventArgs e)
        {
            sp.Stop(); //Включение музыки
            sp1.Play();
            sp1.PlayLooping();
        }

        private void Musstop_Click(object sender, RoutedEventArgs e)
        {
            sp1.Stop(); //Выключение музыки
            sp.Play();
            sp.PlayLooping();
        }

        private void Author_Click(object sender, RoutedEventArgs e)
        {
            Window1 taskWindow = new Window1();
            taskWindow.Show();
        }
    }
}
