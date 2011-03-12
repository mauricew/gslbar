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
        public static string PlayerOne = "Player 1";
        public static string PlayerTwo = "Player 2";
        public static string PositionOne = "P1";
        public static string PositionTwo = "T2";
        public static int ScoreP1 = 0;
        public static int ScoreP2 = 0;
        public static int Color1;
        public static int Color2;
        public static int Race1;
        public static int Race2;
        public static string SetText;

        public static MainWindow MWAccess;
        public static TextBlock Player1Access;
        public static TextBlock Player2Access;
        public static TextBlock Pos1Access;
        public static TextBlock Pos2Access;
        public static TextBlock SetTextAccess;
        public static Image Race1Access;
        public static Image Race2Access;
        public static TextBlock Score1Access;
        public static TextBlock Score2Access;

        public static bool OnTop = true;
        public static bool IsMovable = true;
        public static bool RaceIconsEnabled = false;
        public static bool ScoreBarEnabled = true;
        public static bool VSTextEnabled = true;
        public static bool isThisABetaVersion = false;
        public static bool MainWndHidden = true;

        Options optWnd;
        BrushConverter conv = new BrushConverter();
        public static Brush SCRed;
        public static Brush SCBlue;

        public MainWindow()
        {
            InitializeComponent();
            InitStaticMethods();
            ContextMenuSetup();
            this.Top = 1.0;
            SCRed = (Brush)conv.ConvertFrom("#FFDD0000");
            SCBlue = (Brush)conv.ConvertFrom("#FF0077E1");
            FadeAnim().Begin();
            MainWndHidden = false;
        }

        public void ContextMenuSetup()
        {
            if (OnTop) UseRaceIcon.IsChecked = true;
            if (IsMovable) Movable.IsChecked = true;
            if (RaceIconsEnabled) UseRaceIcon.IsChecked = true;
            else if (!RaceIconsEnabled) UseRaceIcon.IsChecked = false;
            if(ScoreBarEnabled) ShowScore.IsChecked = true;
            if (VSTextEnabled) ShowVersus.IsChecked = true;
        }

        private void InitStaticMethods()
        {
            MWAccess = this;
            Player1Access = Player1;
            Player2Access = Player2;
            Pos1Access = Position1;
            Pos2Access = Position2;
            SetTextAccess = settext;
            Race1Access = racep1;
            Race2Access = racep2;
            Score1Access = scorep1;
            Score2Access = scorep2;
            Color1 = 0;
            Color2 = 1;
            Race1 = 0;
            Race2 = 1;
        }

        public static void SetScorePlayer1(int P1)
        {
            Score1Access.Text = P1.ToString();
        }

        public static void SetScorePlayer2(int P2)
        {
            Score2Access.Text = P2.ToString();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenOptions_Click(object sender, RoutedEventArgs e)
        {
            ShowOptions();
        }

        private void ShowOptions()
        {
            optWnd = new Options();
            optWnd.Show();
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
            PlayerOne = changep1.Text;
        }

        private void changep2_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlayerTwo = changep2.Text;
        }

        private void changep1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                changep1.Visibility = Visibility.Collapsed;
                Player1.Text = PlayerOne;
            }
        }

        private void changep2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                changep2.Visibility = Visibility.Collapsed;
                Player2.Text = PlayerTwo;
            }
        }

        public static void SetPlayer1Ext()
        {
            Player1Access.Text = PlayerOne;
        }

        public static void SetPlayer2Ext()
        {
            Player2Access.Text = PlayerTwo;
        }

        public static void SetPos1Ext()
        {
            Pos1Access.Text = PositionOne;
        }

        public static void SetPos2Ext()
        {
            Pos2Access.Text = PositionTwo;
        }

        public static void SetColor1Ext()
        {
            
        }

        public static void SetColor2Ext()
        {

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
            PositionOne = changel1.Text;
        }

        private void changel2_TextChanged(object sender, TextChangedEventArgs e)
        {
            PositionTwo = changel2.Text;
        }

        private void changel1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                changel1.Visibility = Visibility.Collapsed;
                Position1.Text = PositionOne;
            }
        }

        private void changel2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                changel2.Visibility = Visibility.Collapsed;
                Position2.Text = PositionTwo;
            }
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
            Position2.Foreground = SCRed;
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
            if (IsMovable)
            {
                DragMove();
                if (Top < 1)
                {
                    Top = 1;
                }
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog ad = new AboutDialog();
            ad.Show();
        }

        private void AlwaysOnTop_Click(object sender, RoutedEventArgs e)
        {
            ChangeOnTop();
        }

        public void ChangeOnTop()
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
            if (scorebar.Visibility == Visibility.Visible)
            {
                scorebar.Visibility = Visibility.Collapsed;
                ScoreBarEnabled = false;
            }
            else
            {
                scorebar.Visibility = Visibility.Visible;
                ScoreBarEnabled = true;
            }
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

            else if (e.Key == Key.F8)
            {
                RaceIconState();
            }

            else if (e.Key == Key.F9)
            {
                ShowVersusArea();
            }

            else if (e.Key == Key.F11)
            {
                ShowScoreArea();
            }

            else if (e.Key == Key.F12)
            {
                ShowOptions();
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

            else if (e.Key == Key.F5 && MainWndHidden)
            {
                FadeAnim().Begin();
                MainWndHidden = false;
            }
            else if (e.Key == Key.F6 && !MainWndHidden)
            {
                FadeAnim().Begin();
                MainWndHidden = true;
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
                Player1.Margin = new Thickness(Player1.Margin.Left, Player1.Margin.Top - 1.75, Player1.Margin.Right, Player1.Margin.Bottom);
                Player2.FontSize += 2;
                Player2.Margin = new Thickness(Player2.Margin.Left, Player2.Margin.Top - 1.75, Player2.Margin.Right, Player2.Margin.Bottom);
            }
        }

        private void DecreasePlayerNameFont()
        {
            if (Player1.FontSize >= 16)
            {
                Player1.FontSize -= 2;
                Player1.Margin = new Thickness(Player1.Margin.Left, Player1.Margin.Top + 1.75, Player1.Margin.Right, Player1.Margin.Bottom);
                Player2.FontSize -= 2;
                Player2.Margin = new Thickness(Player2.Margin.Left, Player2.Margin.Top + 1.75, Player2.Margin.Right, Player2.Margin.Bottom);
            }
        }

        private void UseRaceIcon_Click(object sender, RoutedEventArgs e)
        {
            RaceIconState();
        }

        public void RaceIconState()
        {
            if (Position1.Visibility == Visibility.Visible)
            {
                Position1.Visibility = Visibility.Collapsed;
                Position2.Visibility = Visibility.Collapsed;
                racep1.Visibility = Visibility.Visible;
                racep2.Visibility = Visibility.Visible;
                RaceIcon.IsEnabled = true;
                PlayerPos.IsEnabled = false;
                RaceIconsEnabled = true;
            }
            else
            {
                Position1.Visibility = Visibility.Visible;
                Position2.Visibility = Visibility.Visible;
                racep1.Visibility = Visibility.Collapsed;
                racep2.Visibility = Visibility.Collapsed;
                RaceIcon.IsEnabled = false;
                PlayerPos.IsEnabled = true;
                RaceIconsEnabled = false;
            }
        }

        private void ChangeRace1P_Click(object sender, RoutedEventArgs e)
        {
            AssignRaceIcon(1, 'P');
            Race1 = 0;
        }

        private void ChangeRace1T_Click(object sender, RoutedEventArgs e)
        {
            AssignRaceIcon(1, 'T');
            Race1 = 1;
        }

        private void ChangeRace1Z_Click(object sender, RoutedEventArgs e)
        {
            AssignRaceIcon(1, 'Z');
            Race1 = 2;
        }

        private void ChangeRace2P_Click(object sender, RoutedEventArgs e)
        {
            AssignRaceIcon(2, 'P');
            Race2 = 0;
        }

        private void ChangeRace2T_Click(object sender, RoutedEventArgs e)
        {
            AssignRaceIcon(2, 'T');
            Race2 = 1;
        }

        private void ChangeRace2Z_Click(object sender, RoutedEventArgs e)
        {
            AssignRaceIcon(2, 'Z');
            Race2 = 2;
        }

        public static void AssignRaceIcon(int playernum, char race)
        {
            Image raceimg;
            BitmapImage raceimage = new BitmapImage();
            if (playernum == 1)
            {
                raceimg = Race1Access;
            }
            else
            {
                raceimg = Race2Access;
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

        private void MainWnd_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Movable_Click(object sender, RoutedEventArgs e)
        {
            if (IsMovable) IsMovable = false;
            else IsMovable = true;
        }

        private Storyboard FadeAnim()
        {
            Storyboard fadeboard = new Storyboard();
            DoubleAnimation thefade = new DoubleAnimation();
            TimeSpan fadedurr = new TimeSpan(0, 0, 0, 0, 300);
            if(MainWndHidden)
            {
                thefade.From = 0.0;
                thefade.To = 1.0;
            }
            else
            {
                thefade.From = 1.0;
                thefade.To = 0.0;
            }
            thefade.Duration = new Duration(fadedurr);

            Storyboard.SetTarget(thefade, this);
            Storyboard.SetTargetProperty(thefade, new PropertyPath(Control.OpacityProperty));

            fadeboard.Children.Add(thefade);

            return fadeboard;
        }

        private void MainWnd_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!MainWndHidden) FadeAnim().Begin();
        }
    }

}
