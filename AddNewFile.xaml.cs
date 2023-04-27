using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<DeviceDictionary> deviceDictionary;

        private Files files = new Files();
        private Device device = new Device();

        public AddNewFile(NpgsqlConnection npgsqlConnection)
        {
            _connection = npgsqlConnection;
            InitializeComponent();
            var columnValues = new ObservableCollection<string> { "iPhone 6S Plus", "Nexus 6P", "Galaxy S7 Edge" };
            Combo_Device.ItemsSource = columnValues;
        }

        private void AddNewFileButton_Click(object sender, RoutedEventArgs e)
        {
            _connection.Open();
            string sql = "SELECT devicename FROM Files.Device";
            Combo_Device_SelectionChanged(sql, "devicename", Combo_Device);
        }

        private void Combo_Device_SelectionChanged(string stringQuery, string column, ComboBox myBox)
        {
            _connection.Open();
            List<string> columnValues = GetColumnValues(stringQuery, column);
            myBox.ItemsSource = columnValues.ToList();
            //string sql = "SELECT devicename FROM Files.Device";
           // loadElementToComboBox(sql, "devicename", Combo_Device);
           // NpgsqlCommand command = new NpgsqlCommand(sql, _connection);
           // command.ExecuteNonQuery();
           // command.Dispose();
            //NpgsqlCommand command = new NpgsqlCommand("combobox_device", _connection);
            // command.CommandType = System.Data.CommandType.StoredProcedure;

        }
        public List<string> GetColumnValues(string query, string columnName)
        {
            List<string> columnValues = new List<string>();
            _connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    object columnValueObject = reader.GetValue(reader.GetOrdinal(columnName));
                    string columnValue = columnValueObject != DBNull.Value ? columnValueObject.ToString() : "";
                    columnValues.Add(columnValue);
                }
            }
            return columnValues;
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
