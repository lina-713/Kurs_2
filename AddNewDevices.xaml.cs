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
using System.Windows.Shapes;
using Npgsql;
using NpgsqlTypes;

namespace Kurs_2
{
    /// <summary>
    /// Логика взаимодействия для AddNewDevices.xaml
    /// </summary>
    public partial class AddNewDevices : Window
    {
        private readonly NpgsqlConnection _connection;
        public AddNewDevices()
        {
            InitializeComponent();
        }
        
        public AddNewDevices(NpgsqlConnection npgsqlConnection)
        {
            _connection = npgsqlConnection;
        }
        private void DAddDevice_Click(object sender, RoutedEventArgs e)
        {
            _connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("add_new_device",_connection);
            try
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@new_device_name", DName.Text);
                command.Parameters.AddWithValue("@new_interface", DInterface.Text);
                command.Parameters.AddWithValue("@new_memory_size", Convert.ToInt32(DMemorySize.Text));
                command.ExecuteNonQuery();
                MessageBox.Show("Устройство добавлено!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                _connection.Close();
            }

            Close();
        }
    }
}
