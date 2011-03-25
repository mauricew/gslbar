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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ColorSelect : Window
    {
        public Brush positioncolor;
        BrushConverter conv = new BrushConverter();
        public int PlayerNum;
        public int colorselected;

        public ColorSelect(int Pos)
        {
            InitializeComponent();
            PlayerNum = Pos;
            GetCurrentColor();
            Title += " For Player " + PlayerNum.ToString();
        }

        private void GetCurrentColor()
        {
            if (PlayerNum == 1)
            {
                positioncolor = MainWindow.Pos1Access.Foreground;
            }
            else
            {
                positioncolor = MainWindow.Pos2Access.Foreground;
                MainWindow.Color2 = colorselected;
            }
            rect_curr.Fill = positioncolor;
        }

        private void SetCurrentColor()
        {
            if (PlayerNum == 1)
            {
                MainWindow.Color1 = colorselected - 1;
            }
            else MainWindow.Color2 = colorselected - 1;
        }

        private void rectangle1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = MainWindow.SCRed;
            colorselected = 1;
            this.Close();
        }

        private void rectangle2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = MainWindow.SCBlue;
            colorselected = 2;
            this.Close();
        }

        private void rectangle3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle3.Fill;
            colorselected = 3;
            this.Close();
        }

        private void rectangle4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle4.Fill;
            colorselected = 4;
            this.Close();
        }

        private void rectangle5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle5.Fill;
            colorselected = 5;
            this.Close();
        }

        private void rectangle6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle6.Fill;
            colorselected = 6;
            this.Close();
        }

        private void rectangle7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle7.Fill;
            colorselected = 7;
            this.Close();
        }

        private void rectangle8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle8.Fill;
            colorselected = 8;
            this.Close();
        }

        public Brush GetPosColor()
        {
            return positioncolor;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(PlayerNum == 1)
            {
                MainWindow.Pos1Access.Foreground = positioncolor;
                SetCurrentColor();
            }
            else
            {
                MainWindow.Pos2Access.Foreground = positioncolor;
                SetCurrentColor();
            }
        }
    }
}
