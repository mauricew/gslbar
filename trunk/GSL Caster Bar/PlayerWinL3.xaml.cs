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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GSL_Caster_Bar
{
    /// <summary>
    /// Interaction logic for PlayerWinL3.xaml
    /// </summary>
    public partial class PlayerWinL3 : Window
    {
        bool AnimationPlayed;
        bool isClosed;
        public PlayerWinL3(String playername)
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = System.Windows.SystemParameters.PrimaryScreenHeight - this.Height - 24;
            //this.Top = 350;
            textBlock1.Text = playername;
            FadeIn().Begin();
            AnimationPlayed = false;
        }

        private Storyboard FadeIn()
        {
            Storyboard wndfade = new Storyboard();
            DoubleAnimation fade = new DoubleAnimation();
            TimeSpan length = new TimeSpan(0, 0, 0, 0, 400);

            fade.From = 0.0;
            fade.To = 1.0;
            fade.Duration = new Duration(length);

            Storyboard.SetTarget(fade, this);
            Storyboard.SetTargetProperty(fade, new PropertyPath(Control.OpacityProperty));

            wndfade.Children.Add(fade);

            return wndfade;
        }

        private Storyboard FadeOut()
        {
            Storyboard wndfade = new Storyboard();
            DoubleAnimation fade = new DoubleAnimation();
            TimeSpan length = new TimeSpan(0, 0, 0, 0, 400);

            fade.From = 1.0;
            fade.To = 0.0;
            fade.Duration = new Duration(length);

            Storyboard.SetTarget(fade, this);
            Storyboard.SetTargetProperty(fade, new PropertyPath(Control.OpacityProperty));
            wndfade.Completed += new EventHandler(wndfade_Completed);

            wndfade.Children.Add(fade);

            return wndfade;
        }

        void wndfade_Completed(object sender, EventArgs e)
        {
            isClosed = true;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            while (!isClosed)
            {
                FadeOut().Begin();
                e.Cancel = true;
                isClosed = true;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
