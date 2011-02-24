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
        public Brush positioncolor = Brushes.Green;
        BrushConverter conv = new BrushConverter();

        public ColorSelect()
        {
            InitializeComponent();
        }

        private void rectangle1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle1.Fill;
            this.Close();
        }

        private void rectangle2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle2.Fill;
            this.Close();
        }

        private void rectangle3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle3.Fill;
            this.Close();
        }

        private void rectangle4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle4.Fill;
            this.Close();
        }

        private void rectangle5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle5.Fill;
            this.Close();
        }

        private void rectangle6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle6.Fill;
            this.Close();
        }

        private void rectangle7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle7.Fill;
            this.Close();
        }

        private void rectangle8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            positioncolor = rectangle8.Fill;
            this.Close();
        }

        public Brush GetPosColor()
        {
            return positioncolor;            
        }

    }
}
