using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
namespace HomeWork3
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            var users = new List<User>();
            
            users.Add(new User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            string Selection = sender.ToString();
            CollectionView view;

            if (uxFirstNameColumn.Header.ToString() == Selection.ToString())
            {
                view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
            else if (uxPasswordColumn.Header.ToString() == Selection.ToString())
            {
                view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
            }
        }
    }
}