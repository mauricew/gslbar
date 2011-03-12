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
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        bool P1NameChanged;
        bool P2NameChanged;
        bool P1PosChanged;
        bool P2PosChanged;
        bool P1ColorChanged;
        bool P2ColorChanged;
        bool P1RaceChanged;
        bool P2RaceChanged;
        bool P1ScoreChanged;
        bool P2ScoreChanged;
        bool SetTextChanged;

        bool MovableChecked;
        bool OnTopChecked;
        bool UseRaceIconsChecked;
        bool ShowScoreBarChecked;
        bool ShowVSChecked;

        Brush colorselect1;
        Brush colorselect2;
        BrushConverter conv = new BrushConverter();        

        public Options()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            if (P1NameChanged)
            {
                MainWindow.PlayerOne = P1Name.Text;
                MainWindow.SetPlayer1Ext();
            }
            if (P2NameChanged)
            {
                MainWindow.PlayerTwo = P2Name.Text;
                MainWindow.SetPlayer2Ext();
            }
            if (P1PosChanged)
            {
                MainWindow.PositionOne = P1Position.Text;
                MainWindow.SetPos1Ext();
            }
            if (P2PosChanged)
            {
                MainWindow.PositionTwo = P2Position.Text;
                MainWindow.SetPos2Ext();
            }
            if (P1ColorChanged)
            {
                MainWindow.Pos1Access.Foreground = colorselect1;
            }
            if (P2ColorChanged)
            {
                MainWindow.Pos2Access.Foreground = colorselect2;
            }
            if (P1ScoreChanged)
            {
                MainWindow.ScoreP1 = int.Parse(P1Score.Text);
                MainWindow.SetScorePlayer1(MainWindow.ScoreP1);
            }
            if (P2ScoreChanged)
            {
                MainWindow.ScoreP2 = int.Parse(P2Score.Text);
                MainWindow.SetScorePlayer2(MainWindow.ScoreP2);
            }
            if (P1RaceChanged)
            {
                char race1 = ((System.Windows.Controls.ContentControl)(P1Race.SelectedValue)).Content.ToString()[0];
                MainWindow.AssignRaceIcon(1, race1);
            }
            if (P2RaceChanged)
            {
                char race2 = ((System.Windows.Controls.ContentControl)(P2Race.SelectedValue)).Content.ToString()[0];
                MainWindow.AssignRaceIcon(2, race2);
            }
            if (SetTextChanged)
            {
                MainWindow.SetTextAccess.Text = TheSetText.Text;
            }
            if (MovableChecked)
            {
                MainWindow.IsMovable = true;
            }
            else if (!MovableChecked)
            {
                MainWindow.IsMovable = false;
            }
            if (OnTopChecked)
            {
                MainWindow.MWAccess.Topmost = true;
                MainWindow.OnTop = true;
            }
            else if (!OnTopChecked)
            {
                MainWindow.MWAccess.Topmost = false;
                MainWindow.OnTop = false;
            }
            if (ShowScoreBarChecked)
            {
                MainWindow.MWAccess.scorebar.Visibility = Visibility.Visible;
                MainWindow.ScoreBarEnabled = true;
            }
            else if (!ShowScoreBarChecked)
            {
                MainWindow.MWAccess.scorebar.Visibility = Visibility.Collapsed;
                MainWindow.ScoreBarEnabled = false;
            }
            if (ShowVSChecked)
            {
                MainWindow.MWAccess.blockVS.Visibility = Visibility.Collapsed;
                MainWindow.VSTextEnabled = true;
            }
            else if (!ShowVSChecked)
            {
                MainWindow.MWAccess.blockVS.Visibility = Visibility.Visible;
                MainWindow.VSTextEnabled = false;
            }
            if (UseRaceIconsChecked)
            {
                if (MainWindow.RaceIconsEnabled == false) MainWindow.MWAccess.RaceIconState();
            }
            else if (!UseRaceIconsChecked)
            {
                if (MainWindow.RaceIconsEnabled == true) MainWindow.MWAccess.RaceIconState();
            }

            if (P1Color.SelectedIndex == P2Color.SelectedIndex)
            {
                MessageBox.Show("Hey now, you have the same color selected for both players!");
                return;
            }

            MainWindow.MWAccess.ContextMenuSetup();
            this.Close();
        }

        private void P1Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            P1NameChanged = true;
        }

        private void P2Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            P2NameChanged = true;
        }

        private void P1Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            P1ColorChanged = true;
            MainWindow.Color1 = P1Color.SelectedIndex;
            colorselect1 = (Brush)conv.ConvertFromString(((System.Windows.Controls.ContentControl)(P1Color.SelectedValue)).Content.ToString());
            if (((System.Windows.Controls.ContentControl)(P1Color.SelectedValue)).Content.ToString() == "Red")
            {
                colorselect1 = MainWindow.SCRed;
            }
            else if (((System.Windows.Controls.ContentControl)(P1Color.SelectedValue)).Content.ToString() == "Blue")
            {
                colorselect1 = MainWindow.SCBlue;
            }
            else if (((System.Windows.Controls.ContentControl)(P1Color.SelectedValue)).Content.ToString() == "Teal")
            {
                colorselect1 = Brushes.Cyan;
            }
        }

        private void P2Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            P2ColorChanged = true;
            MainWindow.Color2 = P2Color.SelectedIndex;
            colorselect2 = (Brush)conv.ConvertFromString(((System.Windows.Controls.ContentControl)(P2Color.SelectedValue)).Content.ToString());
            if (((System.Windows.Controls.ContentControl)(P2Color.SelectedValue)).Content.ToString() == "Red")
            {
                colorselect2 = MainWindow.SCRed;
            }
            else if (((System.Windows.Controls.ContentControl)(P2Color.SelectedValue)).Content.ToString() == "Blue")
            {
                colorselect2 = MainWindow.SCBlue;
            }
            else if (((System.Windows.Controls.ContentControl)(P2Color.SelectedValue)).Content.ToString() == "Teal")
            {
                colorselect2 = Brushes.Cyan;
            }
        }

        private void P1Position_TextChanged(object sender, TextChangedEventArgs e)
        {
            P1PosChanged = true;
        }

        private void P2Position_TextChanged(object sender, TextChangedEventArgs e)
        {
            P2PosChanged = true;
        }

        private void P1Name_Loaded(object sender, RoutedEventArgs e)
        {
            P1Name.Text = MainWindow.PlayerOne;
        }

        private void P2Name_Loaded(object sender, RoutedEventArgs e)
        {
            P2Name.Text = MainWindow.PlayerTwo;
        }

        private void P1Position_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.RaceIconsEnabled)
            {
                P1Position.IsEnabled = false;
            }
            else P1Position.Text = MainWindow.Pos1Access.Text; ;
        }

        private void P2Position_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.RaceIconsEnabled)
            {
                P2Position.IsEnabled = false;
            }
            else P2Position.Text = MainWindow.Pos2Access.Text;
        }

        private void P1Score_TextChanged(object sender, TextChangedEventArgs e)
        {
            P1ScoreChanged = true;
        }

        private void P2Score_TextChanged(object sender, TextChangedEventArgs e)
        {
            P2ScoreChanged = true;
        }

        private void aboutdialogBtn_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog about = new AboutDialog();
            about.Show();
        }

        private void P1Race_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            P1RaceChanged = true;
            MainWindow.Race1 = P1Race.SelectedIndex;
        }

        private void P2Race_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            P2RaceChanged = true;
            MainWindow.Race2 = P2Race.SelectedIndex;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.MWAccess.Topmost) check_ontop.IsChecked = true;
            if (MainWindow.ScoreBarEnabled) check_scorebar.IsChecked = true;
            if (MainWindow.IsMovable) check_move.IsChecked = true;
            if (MainWindow.RaceIconsEnabled) check_raceicons.IsChecked = true;
            if (MainWindow.VSTextEnabled) check_showvs.IsChecked = true;
        }

        private void check_ontop_Checked(object sender, RoutedEventArgs e)
        {
            OnTopChecked = true;
        }

        private void check_move_Checked(object sender, RoutedEventArgs e)
        {
            MovableChecked = true;
        }

        private void check_raceicons_Checked(object sender, RoutedEventArgs e)
        {
            UseRaceIconsChecked = true;
        }
        
        private void check_scorebar_Checked(object sender, RoutedEventArgs e)
        {
            ShowScoreBarChecked = true;
        }

        private void check_showvs_Checked(object sender, RoutedEventArgs e)
        {
            ShowVSChecked = true;
        }

        private void check_ontop_Unchecked(object sender, RoutedEventArgs e)
        {
            OnTopChecked = false;
        }

        private void check_move_Unchecked(object sender, RoutedEventArgs e)
        {
            MovableChecked = false;
        }

        private void check_raceicons_Unchecked(object sender, RoutedEventArgs e)
        {
            UseRaceIconsChecked = false;
        }

        private void check_scorebar_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowScoreBarChecked = false;
        }

        private void check_showvs_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowVSChecked = false;
        }

        private void TheSetText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetTextChanged = true;
        }

        private void TheSetText_Loaded(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.ScoreBarEnabled) TheSetText.IsEnabled = false;
            TheSetText.Text = MainWindow.SetTextAccess.Text;
        }

        private void P1Score_Loaded(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.ScoreBarEnabled) P1Score.IsEnabled = false;
            P1Score.Text = MainWindow.ScoreP1.ToString();
        }

        private void P2Score_Loaded(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.ScoreBarEnabled) P2Score.IsEnabled = false;
            P2Score.Text = MainWindow.ScoreP2.ToString();
        }

        private void P1Race_Loaded(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.RaceIconsEnabled) P1Race.IsEnabled = false;
            P1Race.SelectedIndex = MainWindow.Race1;
        }

        private void P2Race_Loaded(object sender, RoutedEventArgs e)
        {
            if (!MainWindow.RaceIconsEnabled) P2Race.IsEnabled = false;
            P2Race.SelectedIndex = MainWindow.Race2;
        }

        private void P1Color_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.RaceIconsEnabled) P1Color.IsEnabled = false;
            P1Color.SelectedIndex = MainWindow.Color1;
        }

        private void P2Color_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.RaceIconsEnabled) P2Color.IsEnabled = false;
            P2Color.SelectedIndex = MainWindow.Color2;
        }

    }
}
