using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace HomeWork4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmitButton.IsEnabled = false;
        }

        private void uxZipcodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var USZipcode1 = @"^\d{5}$";
            var USZipcode2 = @"^\d{5}-\d{4}$";
            var CanadaZipcode = @"^[A-Z]\d[A-Z]\d[A-Z]\d$";
            string zipcode = uxZipcodeTextBox.Text;

            if ((!Regex.Match(zipcode, USZipcode1).Success) && (!Regex.Match(zipcode, USZipcode2).Success) && (!Regex.Match(zipcode, CanadaZipcode).Success))
                uxSubmitButton.IsEnabled = false;
            else
                uxSubmitButton.IsEnabled = true;
        }
    }
}
