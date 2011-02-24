using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GSL_Caster_Bar
{
    /// <summary>
    /// Interaction logic for AboutDialog.xaml
    /// </summary>
    public partial class AboutDialog : Window
    {
        public static int count = 0;
        //MediaPlayer mp;
        public AboutDialog()
        {
            this.Left = SystemParameters.PrimaryScreenWidth / 3;
            this.Top = SystemParameters.PrimaryScreenHeight / 3;
            InitializeComponent();

            //mp = new MediaPlayer();
            //Uri banelingsound = new Uri("pack://application:,,,/GSL Caster Bar;component/artosis.wav");
            //mp.Open(banelingsound);
        }

        private void OKbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //mp.Play();
            //banelingsound.Play();
            count++;
            if (count >= 5)
            {
                chills.Visibility = Visibility.Visible;
                count = 0;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            count = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void banelingsound_MediaOpened(object sender, RoutedEventArgs e)
        {
            //banelingsound.Stop();
            //banelingsound.Position = TimeSpan.Zero;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            
        }


    }
}
