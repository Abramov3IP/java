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
using System.Data.OleDb;

namespace city2
{

    public class city
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Region { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public object[] mass = new object[100];

    }

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();



        }

        object cd;

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Абрамов Павел 3ИП");
        }

        private void SelectedItem(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi");
        }


        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MyListView.Items.Add(new city { Name = "Moscow", Region = 1, Population = 12000000 });
            MyListView.Items.Add(new city { Name = "Kazan", Region = 20, Population = 1345345 });
            MyListView.Items.Add(new city { Name = "Anapa", Region = 31, Population = 2236256 });
            MyListView.Items.Add(new city { Name = "Kursk", Region = 57, Population = 5675764 });
            MyListView.Items.Add(new city { Name = "Kemerovo", Region = 103, Population = 9128344 });
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            MyListView.Items.Clear();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            cd = MyListView.SelectedItem;
            Clipboard.SetText(cd.ToString());
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
             MyListView.Items.Add(cd);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MyListView.Items.Remove(MyListView.SelectedItem);
        }

    }
    }
