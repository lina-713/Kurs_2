using Microsoft.EntityFrameworkCore;
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
using Npgsql;

namespace Kurs_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NpgsqlConnection _connection;
        public MainWindow(NpgsqlConnection npgsqlConnection )
        {
            InitializeComponent();
            _connection = npgsqlConnection;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewDevices addNewDevices = new AddNewDevices(_connection);
            addNewDevices.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddNewFile addNewFile = new AddNewFile(_connection);
            addNewFile.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EnterDb enterDb = new EnterDb(_connection);
            enterDb.Show();
        }
    }
}
