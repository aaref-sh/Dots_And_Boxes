using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly bool[,] lin = new bool[14, 10];
        private readonly int[,] crs = new int[6, 9];
        private bool player1 = true;
        private int p1, p2, c = 54;
        Dictionary<string, System.Windows.Controls.Label> m = new Dictionary <string, System.Windows.Controls.Label>();

        public MainWindow()
        {
            InitializeComponent();
            Fm();
            Line h=new Line();
            h.Name = "lin055";
            h.Stroke = Brushes.Green;
        }

        private void Fm()
        {
            m["00"] = l11;
            m["01"] = l12;
            m["02"] = l13;
            m["03"] = l14;
            m["04"] = l15;
            m["05"] = l16;
            m["06"] = l17;
            m["07"] = l18;
            m["08"] = l19;
            m["10"] = l21;
            m["11"] = l22;
            m["12"] = l23;
            m["13"] = l24;
            m["14"] = l25;
            m["15"] = l26;
            m["16"] = l27;
            m["17"] = l28;
            m["18"] = l29;


            m["20"] = l31;
            m["21"] = l32;
            m["22"] = l33;
            m["23"] = l34;
            m["24"] = l35;
            m["25"] = l36;
            m["26"] = l37;
            m["27"] = l38;
            m["28"] = l39;
            m["30"] = l41;
            m["31"] = l42;
            m["32"] = l43;
            m["33"] = l44;
            m["34"] = l45;
            m["35"] = l46;
            m["36"] = l47;
            m["37"] = l48;
            m["38"] = l49;

            m["40"] = l51;
            m["41"] = l52;
            m["42"] = l53;
            m["43"] = l54;
            m["44"] = l55;
            m["45"] = l56;
            m["46"] = l57;
            m["47"] = l58;
            m["48"] = l59;
            m["50"] = l61;
            m["51"] = l62;
            m["52"] = l63;
            m["53"] = l64;
            m["54"] = l65;
            m["55"] = l66;
            m["56"] = l67;
            m["57"] = l68;
            m["58"] = l69;
        }

        bool Odd(int x)
        {
            return x % 2 == 0;
        }


        void Ch(int x, int y)
        {
            string f = "" + x + y;
            if (crs[x, y] == 4)
            {
                if (player1)
                {
                    p2++;
                    m[f].Visibility = Visibility.Visible;
                    p2s.Content = p2.ToString();
                }
                else
                {
                    p1++;
                    m[f].Content = "1";
                    m[f].Background = new SolidColorBrush(Color.FromRgb(5,9,91));
                    m[f].Visibility = Visibility.Visible;
                    p1s.Content = p1.ToString();
                }
                c--;
            }
            if (c == 0)
            {
                if (p1 > p2) MessageBox.Show("Player 1 has won !");
                else if (p2 > p1) MessageBox.Show("Player 2 has won !");
                else MessageBox.Show("Tied fuck you !");
                this.Close();
            }
        }
        private void Superficie_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Line ln = (Line)sender;
            int col, row;
            row = Convert.ToInt32(ln.Name.Substring(3, 2)); row--;
            col = Convert.ToInt32(ln.Name.Substring(5, 1)); col--;
            if (col < 0) col = 9;
            if (!lin[row, col])
            {
                lin[row, col] = true;

                if (player1) ln.Stroke = Brushes.Blue;
                else ln.Stroke = Brushes.Red;
                player1 = !player1;

                if (Odd(row))
                {
                    if (row / 2 > 0 && row / 2 < 6)
                    {
                        crs[row / 2, col]++;
                        Ch(row / 2, col);
                        crs[row / 2 - 1, col]++;
                        Ch(row / 2 - 1, col);
                    }
                    else if (row / 2 == 0)
                    {
                        crs[row / 2, col]++;
                        Ch(row / 2, col);
                    }
                    else
                    {
                        crs[row / 2 - 1, col]++;
                        Ch(row / 2 - 1, col);
                    }
                }
                else
                {
                    if (col < 9 && col > 0)
                    {
                        crs[row / 2, col]++;
                        Ch(row / 2, col);
                        crs[row / 2, col - 1]++;
                        Ch(row / 2, col - 1);
                    }
                    else if (col == 0)
                    {
                        crs[row / 2, col]++;
                        Ch(row / 2, col);
                    }
                    else
                    {
                        crs[row / 2, col - 1]++;
                        Ch(row / 2, col - 1);
                    }
                }
            }
        }
        private void Superficie_MouseEnter(object sender, MouseEventArgs e)
        {
            Line l = (Line)sender;
            int row = Convert.ToInt32(l.Name.Substring(3, 2));
            int col = Convert.ToInt32(l.Name.Substring(5, 1));
            row--;
            col--;
            if (col < 0) col = 9;
            if (!lin[row, col]) l.Stroke = Brushes.Black;
        }

        private void Superficie_MouseLeave(object sender, MouseEventArgs e)
        {
            Line l = (Line)sender;
            int row = Convert.ToInt32(l.Name.Substring(3, 2));
            int col = Convert.ToInt32(l.Name.Substring(5, 1));
            row--;
            col--;
            if (col < 0) col = 9;
            if (!lin[row, col]) l.Stroke = Brushes.Gray;
        }
    }
}
