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
    /// Interaction logic for NameL3.xaml
    /// </summary>
    public partial class PlayerNameL3 : Window
    {
        private bool isClosed;
        public String PlayerText;
        public PlayerNameL3(String s, Brush b)
        {
            this.Top = SystemParameters.PrimaryScreenHeight / 2.25;
            InitializeComponent();
            MainWindow.IntroSound.Open(new Uri(MainWindow.sound_pathname));
            MainWindow.IntroSound.Play();
            textBlock1.Text = s;
            textBlock1.Foreground = b;
            IntroAnimation().Begin();
        }

        private Storyboard IntroAnimation()
        {
            Storyboard sb_intro = new Storyboard();
            DoubleAnimation textanim = new DoubleAnimation();
            TimeSpan textduration = new TimeSpan(0, 0, 0, 0, 600);

            textanim.From = 0.0;
            textanim.To = 1.0;
            textanim.Duration = new Duration(textduration);

            Storyboard.SetTarget(textanim, textBlock1);
            Storyboard.SetTargetProperty(textanim, new PropertyPath(Control.OpacityProperty));

            sb_intro.Children.Add(textanim);

            DoubleAnimation windowanim = new DoubleAnimation();
            TimeSpan wndduration = new TimeSpan(0, 0, 0, 0, 250);

            windowanim.From = 1.0;
            windowanim.To = Width;
            windowanim.Duration = new Duration(wndduration);

            Storyboard.SetTarget(windowanim, this);
            Storyboard.SetTargetProperty(windowanim, new PropertyPath(Control.WidthProperty));

            sb_intro.Children.Add(windowanim);

            return sb_intro;
        }

        private Storyboard NameAnimationBackwards()
        {
            Storyboard nametext = new Storyboard();
            DoubleAnimation textanim = new DoubleAnimation();
            TimeSpan textduration = new TimeSpan(0, 0, 0, 0, 750);

            textanim.From = 0.5;
            textanim.To = 0.0;
            textanim.Duration = new Duration(textduration);

            Storyboard.SetTarget(textanim, textBlock1);
            Storyboard.SetTargetProperty(textanim, new PropertyPath(Control.OpacityProperty));

            nametext.Children.Add(textanim);
            return nametext;
        }

        private Storyboard WindowAnimationBackwards()
        {
            Storyboard windowsb = new Storyboard();
            DoubleAnimation windowanim = new DoubleAnimation();
            TimeSpan wndduration = new TimeSpan(0, 0, 0, 0, 300);
            windowanim.From = Width;
            windowanim.To = 1.0;
            windowanim.Duration = new Duration(wndduration);
            Storyboard.SetTarget(windowanim, this);
            Storyboard.SetTargetProperty(windowanim, new PropertyPath(Control.WidthProperty));
            windowsb.Completed += new EventHandler(windowsb_Completed);
            
            windowsb.Children.Add(windowanim);
            return windowsb;
        }

        void windowsb_Completed(object sender, EventArgs e)
        {
            isClosed = true;
            this.Close();
        }

        private void NameL3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void NameL3_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            while (!isClosed)
            {
                NameAnimationBackwards().Begin();
                WindowAnimationBackwards().Begin();
                e.Cancel = true;
                isClosed = true;
            }
        }
    }
}
