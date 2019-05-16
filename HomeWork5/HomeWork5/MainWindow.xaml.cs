using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeWork5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum User { X, O }
        User user = User.X;
        string[,] Condition;

        public MainWindow()
        {
            InitializeComponent();
            SetUserTurn();
            Condition = new string[3, 3];
        }

        private void SetUserTurn()
        {
            uxTurn.Text = string.Format("{0}'s Turn", user.ToString());
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            SetUserTurn();
            Condition = new string[3, 3];

            foreach (Button b in uxGrid.Children)
            {
                b.Content = null;
                b.IsEnabled = true;
            }
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content == null)
            {
                string[] SplitTag = ((Button)sender).Tag.ToString().Split(',');
                int xCordinate = Int32.Parse(SplitTag[0]);
                int yCordinate = Int32.Parse(SplitTag[1]);

                ((Button)sender).Content = user.ToString();

                Condition[xCordinate, yCordinate] = user.ToString();

                CheckWin();
            }
        }

        private void WinnerFound(string u)
        {
            foreach (Button b in uxGrid.Children)
            {
                b.IsEnabled = false;
            }

            uxTurn.Text = string.Format("{0} is the winner!", user.ToString());
        }

        private void CheckWin()
        {
            if (Condition[0,0] != null)
            {
                if (Condition[0, 0] == Condition[0, 1] && Condition[0, 0] == Condition[0, 2])
                {
                    WinnerFound(Condition[0, 0]);
                }
                else if (Condition[0, 0] == Condition[1, 0] && Condition[0, 0] == Condition[2, 0])
                {
                    WinnerFound(Condition[0, 0]);
                }
                else if (Condition[0, 0] == Condition[1, 1] && Condition[0, 0] == Condition[2, 2])
                {
                    WinnerFound(Condition[0, 0]);
                }
                else
                {
                    if (user == User.X)
                        user = User.O;
                    else
                        user = User.X;

                    SetUserTurn();
                }
            }
            else if(Condition[1,1] != null)
            {
                if (Condition[1, 0] == Condition[1, 1] && Condition[1, 1] == Condition[1, 2])
                {
                    WinnerFound(Condition[1, 0]);
                }
                else if (Condition[0, 1] == Condition[1, 1] && Condition[1, 1] == Condition[2, 1])
                {
                    WinnerFound(Condition[0, 1]);
                }
                else if (Condition[2, 0] == Condition[1, 1] && Condition[1, 1] == Condition[0, 2])
                {
                    WinnerFound(Condition[2, 0]);
                }
                else
                {
                    if (user == User.X)
                        user = User.O;
                    else
                        user = User.X;

                    SetUserTurn();
                }
            }
            else if(Condition[2,2] != null)
            {
                if (Condition[2, 0] == Condition[2, 2] && Condition[2, 1] == Condition[2, 2])
                {
                    WinnerFound(Condition[2, 0]);
                }
                else if (Condition[0, 2] == Condition[2, 2] && Condition[1, 2] == Condition[2, 2])
                {
                    WinnerFound(Condition[0, 2]);
                }
                else
                {
                    if (user == User.X)
                        user = User.O;
                    else
                        user = User.X;

                    SetUserTurn();
                }
            }         
            else
            {
                if (user == User.X)
                    user = User.O;
                else
                    user = User.X;

                SetUserTurn();
            }

        }
    }
}
