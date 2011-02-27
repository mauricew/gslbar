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
        public static string PlayerOne;
        Options optWnd;
        BrushConverter conv = new BrushConverter();
        Brush SCBlue;
        //Point Drag1;
        public MainWindow()
        {
            //FilterCommand.InputGestures.Add(new KeyGesture(Key.F, ModifierKeys.Control));
            InitializeComponent();
            SCBlue = (Brush)conv.ConvertFrom("#FF0077E1");
            this.Top = 1.0;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenOptions_Click(object sender, RoutedEventArgs e)
        {
            optWnd = new Options();
            optWnd.player1edit.Text = Player1.Text;
            optWnd.Show();
            //MessageBox.Show("Not yet implemented ;)", "Use context menu bro");
        }

        private void ChangePlayer1_Click(object sender, RoutedEventArgs e)
        {
            ChangePlayerOne();
        }

        private void ChangePlayerOne()
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
            ChangePlayerTwo();
        }

        private void ChangePlayerTwo()
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
            ChangePositionOne();
        }

        public void ChangePositionOne()
        {
            if (Position1.Visibility == Visibility.Visible)
            {
                if (changel1.Visibility == Visibility.Collapsed)
                {
                    changel1.Visibility = Visibility.Visible;
                    changel1.Focus();
                }
                else changel1.Visibility = Visibility.Collapsed;
            }
        }

        private void ChangePos2_Click(object sender, RoutedEventArgs e)
        {
            ChangePositionTwo();
        }

        public void ChangePositionTwo()
        {
            if (Position2.Visibility == Visibility.Visible)
            {
                if (changel2.Visibility == Visibility.Collapsed)
                {
                    changel2.Visibility = Visibility.Visible;
                    changel2.Focus();
                }
                else changel2.Visibility = Visibility.Collapsed;
            }
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
            Position1.Foreground = SCBlue;
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
            Position2.Foreground = SCBlue;
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
            ShowVersusArea();            
        }

        private void ShowVersusArea()
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
            ShowScoreArea();
        }

        private void ShowScoreArea()
        {
            if (scorebar.Visibility == Visibility.Visible) scorebar.Visibility = Visibility.Collapsed;
            else scorebar.Visibility = Visibility.Visible;
        }

        private void changescorep1_Click(object sender, RoutedEventArgs e)
        {
            ChangeScoreOne();
        }

        private void ChangeScoreOne()
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
            ChangeScoreTwo();
        }

        private void ChangeScoreTwo()
        {
            if (setscorep2.Visibility == Visibility.Collapsed)
            {
                setscorep2.Visibility = Visibility.Visible;
                setscorep2.Focus();
            }
            else setscorep2.Visibility = Visibility.Collapsed;

        }

        private void changeset_Click(object sender, RoutedEventArgs e)
        {
            Change_Set();
        }

        private void Change_Set()
        {
            if (scorebar.Visibility == Visibility.Visible)
            {
                if (changeset.Visibility == Visibility.Collapsed)
                {
                    changeset.Visibility = Visibility.Visible;
                    changeset.Focus();
                }
                else changeset.Visibility = Visibility.Collapsed;
            }
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

        private void ShowMapOverlay_Click(object sender, RoutedEventArgs e)
        {
            MapName mn = new MapName();
            mn.Show();
        }

        private void MainWnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1 && Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                ChangePositionOne();
            }

            else if (e.Key == Key.F2 && Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                ChangePositionTwo();
            }

            else if (e.Key == Key.F1 && Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
            {
                ChangeScoreOne();
            }

            else if (e.Key == Key.F2 && Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
            {
                ChangeScoreTwo();
            }

            else if (e.Key == Key.F2)
            {
                ChangePlayerTwo();
            }

            else if (e.Key == Key.F1)
            {
                ChangePlayerOne();
            }

            else if (e.Key == Key.F10)
            {
                RaceIconState();
            }

            else if (e.Key == Key.F11)
            {
                ShowVersusArea();
            }

            else if (e.Key == Key.F12)
            {
                ShowScoreArea();
            }

            else if (e.Key == Key.F3 && Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
            {
                Change_Set();
            }

            else if (e.Key == Key.OemMinus && Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                DecreasePlayerNameFont();
            }

            else if (e.Key == Key.OemPlus && Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                IncreasePlayerNameFont();
            }
        }

        private void IncreasePNFont_Click(object sender, RoutedEventArgs e)
        {
            IncreasePlayerNameFont();
        }

        private void DecreasePNFont_Click(object sender, RoutedEventArgs e)
        {
            DecreasePlayerNameFont();
        }

        private void IncreasePlayerNameFont()
        {
            if (Player1.FontSize <= 44)
            {
                Player1.FontSize += 2;
                Player1.Margin = new Thickness(Player1.Margin.Left, Player1.Margin.Top - 1.5, Player1.Margin.Right, Player1.Margin.Bottom);
                Player2.FontSize += 2;
                Player2.Margin = new Thickness(Player2.Margin.Left, Player2.Margin.Top - 1.5, Player2.Margin.Right, Player2.Margin.Bottom);
            }
        }

        private void DecreasePlayerNameFont()
        {
            if (Player1.FontSize >= 16)
            {
                Player1.FontSize -= 2;
                Player1.Margin = new Thickness(Player1.Margin.Left, Player1.Margin.Top + 1.5, Player1.Margin.Right, Player1.Margin.Bottom);
                Player2.FontSize -= 2;
                Player2.Margin = new Thickness(Player2.Margin.Left, Player2.Margin.Top + 1.5, Player2.Margin.Right, Player2.Margin.Bottom);
            }
        }

        private void UseRaceIcon_Click(object sender, RoutedEventArgs e)
        {
            RaceIconState();
        }

        private void RaceIconState()
        {
            if (Position1.Visibility == Visibility.Visible)
            {
                Position1.Visibility = Visibility.Collapsed;
                Position2.Visibility = Visibility.Collapsed;
                racep1.Visibility = Visibility.Visible;
                racep2.Visibility = Visibility.Visible;
                RaceIcon.IsEnabled = true;
                PlayerPos.IsEnabled = false;
            }
            else
            {
                Position1.Visibility = Visibility.Visible;
                Position2.Visibility = Visibility.Visible;
                racep1.Visibility = Visibility.Collapsed;
                racep2.Visibility = Visibility.Collapsed;
                RaceIcon.IsEnabled = false;
                PlayerPos.IsEnabled = true;
            }
        }

        private void ChangeRace1P_Click(object sender, RoutedEventArgs e)
        {
            AssignRaceIcon(1, 'P');
        }

        private void ChangeRace1T_Click(object sender, RoutedEventArgs e)
        {
            AssignRaceIcon(1, 'T');
        }

        private void ChangeRace1Z_Click(object sender, RoutedEventArgs e)
        {
            AssignRaceIcon(1, 'Z');
        }

        private void ChangeRace2P_Click(object sender, RoutedEventArgs e)
        {
            AssignRaceIcon(2, 'P');
        }

        private void ChangeRace2T_Click(object sender, RoutedEventArgs e)
        {
            AssignRaceIcon(2, 'T');
        }

        private void ChangeRace2Z_Click(object sender, RoutedEventArgs e)
        {
            AssignRaceIcon(2, 'Z');
        }

        private void AssignRaceIcon(int playernum, char race)
        {
            Image raceimg;
            BitmapImage raceimage = new BitmapImage();
            if (playernum == 1)
            {
                raceimg = racep1;
            }
            else
            {
                raceimg = racep2;
            }
            raceimage.BeginInit();
            if (race == 'P')
            {
                raceimage.UriSource = new Uri("pack://application:,,,/GSL Caster Bar;component/Res/protossicon.png");
            }
            else if (race == 'T')
            {
                raceimage.UriSource = new Uri("pack://application:,,,/GSL Caster Bar;component/Res/terranicon.png");
            }
            else
            {
                raceimage.UriSource = new Uri("pack://application:,,,/GSL Caster Bar;component/Res/zergicon.png");
            }
            raceimage.EndInit();
            raceimg.Source = raceimage;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            Player1.Text = PlayerOne;
        }

        public static void QuickSetP1(String P1Name)
        {
            //Player1.Text = P1Name;
        }
    }

}
