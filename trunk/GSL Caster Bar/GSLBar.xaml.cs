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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GSL_Caster_Bar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        //public static MainWindow mw;
        BrushConverter conv = new BrushConverter();
        //Point Drag1;
        public MainWindow()
        {
            //MessageBox.Show("This program is very alpha at this stage.\nI am not responsible for any tournament mishaps,\nragequitting players, or unnannounced announcements of announcements.\n\n(this message will be removed in the next version.)", "WARNING!!!!!!!!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            //FilterCommand.InputGestures.Add(new KeyGesture(Key.F, ModifierKeys.Control));
            InitializeComponent();
            this.Top = 0.0;
        }
        private void overlay_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            //Drag1 = e.GetPosition(this);
        }


        private void overlay_MouseMove(object sender, MouseEventArgs e)
        {
            /*if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (this.Top < 0.1)
                {
                    this.Top = 0.00;
                    this.Left += (e.GetPosition(this).X - Drag1.X);
                }
                else //Pretty much spaghetti code
                {
                    this.Top += (e.GetPosition(this).Y - Drag1.Y);
                    this.Left += (e.GetPosition(this).X - Drag1.X);
                }
            }*/
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenOptions_Click(object sender, RoutedEventArgs e)
        {
            //Window optWnd = new Options();
            //optWnd.Show();
            MessageBox.Show("Not yet implemented ;)", "Use context menu bro");
        }

        private void ChangePlayer1_Click(object sender, RoutedEventArgs e)
        {
            if (changep1.Visibility == Visibility.Collapsed)
            {
                changep1.Visibility = Visibility.Visible;
                changep1.Focus();
            }
            else changep1.Visibility = Visibility.Collapsed;
        }

        private void ChangePlayer2_Click(object sender, RoutedEventArgs e)
        {
            if (changep2.Visibility == Visibility.Collapsed)
            {
                changep2.Visibility = Visibility.Visible;
                changep2.Focus();
            }
            else changep2.Visibility = Visibility.Collapsed;
        }

        private void changep1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Player1.Text = changep1.Text;
        }

        private void changep2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Player2.Text = changep2.Text;
        }

        private void changep1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                changep1.Visibility = Visibility.Collapsed;
        }

        private void changep2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                changep2.Visibility = Visibility.Collapsed;
        }

        private void ChangePos1_Click(object sender, RoutedEventArgs e)
        {
            if (changel1.Visibility == Visibility.Collapsed)
            {
                changel1.Visibility = Visibility.Visible;
                changel1.Focus();
            }
            else changel1.Visibility = Visibility.Collapsed;
        }

        private void ChangePos2_Click(object sender, RoutedEventArgs e)
        {
            if (changel2.Visibility == Visibility.Collapsed)
            {
                changel2.Visibility = Visibility.Visible;
                changel2.Focus();
            }
            changel2.Visibility = Visibility.Visible;
        }

        private void ChangeCol1_Click(object sender, RoutedEventArgs e)
        {
            //ColorSelect cs = new ColorSelect();
            //cs.Show();

            //colorpicker.Visibility = Visibility.Visible;
        }

        private void ChangeCol2_Click(object sender, RoutedEventArgs e)
        {
            //ColorSelect cs = new ColorSelect();
            //cs.Show();

            //colorpicker.Visibility = Visibility.Visible;
        }

        private void changel1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Position1.Content = changel1.Text;
        }

        private void changel2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Position2.Content = changel2.Text;
        }

        private void changel1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                changel1.Visibility = Visibility.Collapsed;
        }

        private void changel2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                changel2.Visibility = Visibility.Collapsed;
        }

        private void P1Red_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.Red;
        }

        private void P1Blue_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = (Brush)conv.ConvertFrom("#FF0077E1");
        }

        private void P1Teal_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.Cyan;
        }

        private void P1Purple_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.Purple;
        }

        private void P1Green_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.Green;
        }

        private void P1Yellow_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.Yellow;
        }

        private void P1Orange_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.Orange;
        }

        private void P1LtPink_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.LightPink;
        }

        private void P2Red_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = Brushes.Red;
        }

        private void P2Blue_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = (Brush)conv.ConvertFrom("#FF0077E1");
        }

        private void P2Teal_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = Brushes.Teal;
        }

        private void P2Purple_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = Brushes.Purple;
        }

        private void P2Green_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = Brushes.Green;
        }

        private void P2Yellow_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = Brushes.Yellow;
        }

        private void P2Orange_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = Brushes.Orange;
        }

        private void P2LtPink_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = Brushes.LightPink;
        }

        private void ShowVersus_Click(object sender, RoutedEventArgs e)
        {
            if (blockVS.Visibility == Visibility.Collapsed)
            {
                blockVS.Visibility = Visibility.Visible;
            }
            else
            {
                blockVS.Visibility = Visibility.Collapsed;
            }
            
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog ad = new AboutDialog();
            ad.Show();
        }

        private void AlwaysOnTop_Click(object sender, RoutedEventArgs e)
        {
            if (this.Topmost == true) this.Topmost = false;
            else this.Topmost = true;
        }

        private void ShowScore_Click(object sender, RoutedEventArgs e)
        {
            if (scorebar.Visibility == Visibility.Visible) scorebar.Visibility = Visibility.Collapsed;
            else scorebar.Visibility = Visibility.Visible;
        }

        private void changescorep1_Click(object sender, RoutedEventArgs e)
        {
            if (setscorep1.Visibility == Visibility.Collapsed)
            {
                setscorep1.Visibility = Visibility.Visible;
                setscorep1.Focus();
            }
            else setscorep1.Visibility = Visibility.Collapsed;
        }

        private void changescorep2_Click(object sender, RoutedEventArgs e)
        {
            if (setscorep2.Visibility == Visibility.Collapsed)
            {
                setscorep2.Visibility = Visibility.Visible;
                setscorep2.Focus();
            }
            else setscorep2.Visibility = Visibility.Visible;
        }

        private void changeset_Click(object sender, RoutedEventArgs e)
        {
            if (changeset.Visibility == Visibility.Collapsed)
            {
                changeset.Visibility = Visibility.Visible;
                changeset.Focus();
            }
            else changeset.Visibility = Visibility.Visible;
        }

        private void changeset_TextChanged(object sender, TextChangedEventArgs e)
        {
            settext.Text = changeset.Text;
        }

        private void changeset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                changeset.Visibility = Visibility.Collapsed;
        }

        private void setscorep1_TextChanged(object sender, TextChangedEventArgs e)
        {
            scorep1.Text = setscorep1.Text;
        }

        private void setscorep1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                setscorep1.Visibility = Visibility.Collapsed;
        }

        private void setscorep2_TextChanged(object sender, TextChangedEventArgs e)
        {
            scorep2.Text = setscorep2.Text;
        }

        private void setscorep2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                setscorep2.Visibility = Visibility.Collapsed;
        }

    }
}
