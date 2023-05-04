using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Логика взаимодействия для AddNewFile.xaml
    /// </summary>
    public partial class AddNewFile : Window
    {
        private readonly NpgsqlConnection _connection;

        public AddNewFile(NpgsqlConnection npgsqlConnection)
        {
            _connection = npgsqlConnection;
            InitializeComponent();
            var list = GetDeviceList();
            ObservableCollection<DeviceDictionary> deviceDictionaries = new();
            //list.ForEach(deviceName => deviceDictionaries.Add(new DeviceDictionary() { IKey = String.Empty, IValue = deviceName }));
            Combo_Device.ItemsSource = deviceDictionaries;
        }
        private void AddNewFileButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            NpgsqlCommand command = new NpgsqlCommand("add_new_file", _connection);
            
            try
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@new_file_name", NewFileName.Text);
                command.Parameters.AddWithValue("@new_file_name", NewFileName.Text);
                command.Parameters.AddWithValue("@new_creation_date", dateTime);
                command.Parameters.AddWithValue("@new_file_size", Convert.ToInt32(NewFileSize.Text));
                command.ExecuteNonQuery();
                MessageBox.Show("Файл добавлен!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
        private List<int> GetDeviceList()
        {
            _connection.Open();
            var list = new List<int>();
            string query = string.Format("select combox_device()");
            var command = _connection.CreateCommand();
            command.CommandText = query;
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetInt32(0));
            }
            _connection.Close();
            return list;
            
        }
    }
    public class DeviceDictionary
    {
        private string _ikey;
        public string IKey
        {
            get
            {
                return _ikey;
            }
            set
            {
                _ikey = value;
            }
        }
        private string _ivalue;
        public string IValue
        {
            get
            {
                return _ivalue;
            }
            set
            {
                _ivalue = value;
            }
        }

    }
}
