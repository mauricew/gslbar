using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Interop;
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
	
	#region "Local Variables"
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
        public static int SetNum;
        public static String CustomSetText;
        public static string SetText;
        public static string sound_filename = "none";
        public static string sound_pathname = "C:\\none";
        public static double sound_volume = 0.50;
    #endregion

    #region "Global Access Variables"
        public static MainWindow MWAccess;
        public static PlayerNameL3 pnl;
        public static ColorSelect poscolor;
        public static TextBlock Player1Access;
        public static TextBlock Player2Access;
        public static TextBlock Pos1Access;
        public static TextBlock Pos2Access;
        public static TextBlock SetTextAccess;
        public static Image Race1Access;
        public static Image Race2Access;
        public static TextBlock Score1Access;
        public static TextBlock Score2Access;
        IntPtr handle;
	#endregion
     /*
        private KeyGesture Key_EditP1;
        private KeyGesture Key_EditP2;
        private KeyGesture Key_EditPos1;
        private KeyGesture Key_EditPos2;
        private KeyGesture Key_EditScore1M;
        private KeyGesture Key_EditScore2M;
        private KeyGesture Key_EditSetM;
        private KeyGesture Key_Movable;
        private KeyGesture Key_OnTop;
        private KeyGesture Key_RaceIconToggle;
        private KeyGesture Key_ScoreBarToggle;
        private KeyGesture Key_VSToggle;
        */
		
	#region "Options"
		public static bool OnTop = true;
        public static bool IsMovable = false;
        public static bool RaceIconsEnabled = false;
        public static bool ScoreBarEnabled = true;
        public static bool VSTextEnabled = true;
        public static bool isThisABetaVersion = false;
        public static bool MainWndHidden = true;
        public static bool isClosed = false;
	#endregion
	
        Options optWnd;
        BrushConverter conv = new BrushConverter();
        public static Brush SCRed;
        public static Brush SCBlue;

        public static MediaPlayer IntroSound = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            InitStaticMethods();
            //InitHotkeys();
            ContextMenuSetup();
            this.Top = 1.0;
            this.Left = (SystemParameters.PrimaryScreenWidth / 2) - (Width / 2);
            SCRed = (Brush)conv.ConvertFrom("#FFDD0000");
            SCBlue = (Brush)conv.ConvertFrom("#FF0077E1");
            settext.Text = SetNum.ToString() + SetText;
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
            SetNum = 1;
            SetText = "SET";
            handle = new System.Windows.Interop.WindowInteropHelper(this).Handle;
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
            this.Close();
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
                changep1.Text = PlayerOne;
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
                changep2.Text = PlayerTwo;
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
                    changel1.Text = PositionOne;
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
                    changel2.Text = PositionTwo;
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
                if(poscolor != null) poscolor.Close();
            }
        }

        private void changel2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                changel2.Visibility = Visibility.Collapsed;
                Position2.Text = PositionTwo;
                if(poscolor != null) poscolor.Close();
            }
        }

        private void P1Red_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.Red;
            Color1 = 0;
        }

        private void P1Blue_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = SCBlue;
            Color1 = 1;
        }

        private void P1Teal_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.Cyan;
            Color1 = 2;
        }

        private void P1Purple_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.Purple;
            Color1 = 3;
        }

        private void P1Green_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.Green;
            Color1 = 4;
        }

        private void P1Yellow_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.Yellow;
            Color1 = 5;
        }

        private void P1Orange_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.Orange;
            Color1 = 6;
        }

        private void P1LtPink_Click(object sender, RoutedEventArgs e)
        {
            Position1.Foreground = Brushes.LightPink;
            Color1 = 7;
        }

        private void P2Red_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = SCRed;
            Color2 = 0;
        }

        private void P2Blue_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = SCBlue;
            Color2 = 1;
        }

        private void P2Teal_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = Brushes.Teal;
            Color2 = 2;
        }

        private void P2Purple_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = Brushes.Purple;
            Color2 = 3;
        }

        private void P2Green_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = Brushes.Green;
            Color2 = 4;
        }

        private void P2Yellow_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = Brushes.Yellow;
            Color2 = 5;
        }

        private void P2Orange_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = Brushes.Orange;
            Color2 = 6;
        }

        private void P2LtPink_Click(object sender, RoutedEventArgs e)
        {
            Position2.Foreground = Brushes.LightPink;
            Color2 = 7;
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
            CustomSetText = changeset.Text;
        }

        private void changeset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                changeset.Visibility = Visibility.Collapsed;
                settext.Text = CustomSetText;
            }
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
            if (e.Key == Key.System && e.SystemKey == Key.F10)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.F1 && Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
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
            else if (e.Key == Key.F5 && Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
            {
                ShowWinDialog(1);
            }
            else if (e.Key == Key.F6 && Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
            {
                ShowWinDialog(2);
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
            else if (e.Key == Key.F3 && Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                ShowWinDialog(1);
            }
            else if (e.Key == Key.F4 && Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
            {
                ShowWinDialog(2);
            }
            else if (e.Key == Key.F3)
            {
                if (!RaceIconsEnabled)
                {
                    StartWipeThingy(PlayerOne, Position1.Foreground);
                }
                else StartWipeThingy(PlayerOne, SCRed);
            }
            else if (e.Key == Key.F4)
            {
                if (!RaceIconsEnabled)
                {
                    StartWipeThingy(PlayerTwo, Position2.Foreground);
                }
                else StartWipeThingy(PlayerTwo, SCRed);
            }
        }


        public static void FocusThingy(IntPtr handle)
        {
            var extendedStyle = WindowServices.GetWindowLong(handle, WindowServices.GWL_EXSTYLE);
            WindowServices.SetWindowLong(handle, WindowServices.GWL_EXSTYLE, extendedStyle | WindowServices.WS_EX_TRANSPARENT);
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            handle = new WindowInteropHelper(this).Handle;
            //WindowServices.SetWindowExTransparent(handle);
        }

        public static void ShowWinDialog(int playernum)
        {
            if (playernum == 1)
            {
                PlayerWinL3 windlg = new PlayerWinL3(PlayerOne);
                windlg.Show();
            }
            else
            {
                PlayerWinL3 windlg = new PlayerWinL3(PlayerTwo);
                windlg.Show();
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

        public static Storyboard FadeAnim()
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

            Storyboard.SetTarget(thefade, MWAccess);
            Storyboard.SetTargetProperty(thefade, new PropertyPath(Control.OpacityProperty));

            fadeboard.Completed += new EventHandler(fadeboard_Completed);

            fadeboard.Children.Add(thefade);

            return fadeboard;
        }

        private void MainWnd_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FadeAnim().Begin();
            isClosed = true;
        }

        public static void StartWipeThingy(String pname, Brush color)
        {
            pnl = new PlayerNameL3(pname, color);
            System.Threading.Thread.Sleep(200);
            pnl.Show();
        }

        private void scorep2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                increaseScore(2);
            }
        }

        private void scorep1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                increaseScore(1);
            }
        }

        private void increaseScore(int p)
        {
            if (p == 1)
            {
                ScoreP1++;

                if (ScoreP1 > 9)
                {
                    ScoreP1 = 0;
                    ScoreP2 = 0;
                    SetNum = 0;
                    SetScorePlayer2(ScoreP2);
                }

                SetScorePlayer1(ScoreP1);

                SetNum++;

                settext.Text = SetNum.ToString() + SetText;
            }
            else
            {
                ScoreP2++;

                if (ScoreP2 > 9)
                {
                    ScoreP1 = 0;
                    ScoreP2 = 0;
                    SetNum = 0;
                    SetScorePlayer1(ScoreP1);
                }

                SetScorePlayer2(ScoreP2);

                SetNum++;

                settext.Text = SetNum.ToString() + SetText;
            }
        }

        private void Player1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) ChangePlayerOne();
        }

        private void Player2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) ChangePlayerTwo();
        }

        private void Position1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                ChangePositionOne();
                poscolor = new ColorSelect(1);

                poscolor.Top = e.GetPosition(this).Y + 50;
                poscolor.Left = e.GetPosition(this).X + 75;
                poscolor.Show();
                
            }
        }

        private void Position2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                ChangePositionTwo();
                poscolor = new ColorSelect(2);

                poscolor.Top = e.GetPosition(this).Y + 50;
                poscolor.Left = e.GetPosition(this).X + 75;
                poscolor.Show();
            }
        }

        private void settext_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) Change_Set();
        }

        public static void fadeboard_Completed(object sender, EventArgs e)
        {
            if(isClosed) Application.Current.Shutdown();
        }

    }

}
