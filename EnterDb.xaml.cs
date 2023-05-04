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
    /// Логика взаимодействия для EnterDb.xaml
    /// </summary>
    public partial class EnterDb : Window
    {
        private readonly NpgsqlConnection _connection;
        NpgsqlDataAdapter adapter;
        public EnterDb (NpgsqlConnection npgsqlConnection)
        {
            _connection = npgsqlConnection;
            InitializeComponent();
        }
        private void EnterDB()
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var comboBoxItem = combobox.SelectedValue as ComboBoxItem;

            try
            {
                switch (comboBoxItem.Content)
                {
                    case "Device":
                        SetDeviceGrid();
                        break;
                    case "Files":
                        SetFilesGrid();
                        break;
                    case "Users":
                        SetUsersGrid();
                        break;
                    case "AuditLog":
                        SetAuditLogGrid();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                
            }
            finally
            {
                _connection.Close();
            }
        }

        private void SetDeviceGrid()
        {
            List<Device> devicelist = new List<Device>();
            _connection.Open();
            string sql = "SELECT * from enterdevicedb()";
            NpgsqlCommand command = new NpgsqlCommand(sql, _connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Device item = new Device()
                {
                    ID = Convert.ToInt32(reader["id_device"]),
                    DeviceName = Convert.ToString(reader["device_name"]),
                    Interface = Convert.ToString(reader["interface_device"]),
                    MemorySize = Convert.ToInt32(reader["memory_size"])
                };
                devicelist.Add(item);
            }
            dataGrid1.ItemsSource = devicelist;
            dataGrid1.Columns[0].Visibility = Visibility.Hidden;
        }
        private void SetFilesGrid()
        {
            List<Files> fileslist = new List<Files>();
            _connection.Open();
            string sql = "SELECT * FROM enterfilesdb()";
            NpgsqlCommand command = new NpgsqlCommand(sql, _connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Files item = new Files()
                {
                    ID = Convert.ToInt32(reader["id_file"]),
                    DeviceId = Convert.ToInt32(reader["device_id"]),
                    FileName = Convert.ToString(reader["file_name"]),
                    CreationDate = Convert.ToDateTime(reader["creation_date"]),
                    FileSize = Convert.ToInt32(reader["file_size"]),
                    UserId = Convert.ToInt32(reader["user_id"]),
                };
                fileslist.Add(item);
            }

            dataGrid1.ItemsSource = fileslist;
            dataGrid1.Columns[0].Visibility = Visibility.Hidden;
        }
        private void SetUsersGrid()
        {
            List<Users> userslist = new List<Users>();
            _connection.Open();
            string sql = "SELECT * FROM enterusersedb()";
            NpgsqlCommand command = new NpgsqlCommand(sql, _connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Users item = new Users()
                {
                    ID = Convert.ToInt32(reader["id_users"]),
                    FirstName = Convert.ToString(reader["first_name"]),
                    LastName = Convert.ToString(reader["last_name"]),
                    MiddleName = Convert.ToString(reader["middle_name"]),
                    RegistrationDate = Convert.ToDateTime(reader["registration_date"]),
                    LastActivity = Convert.ToDateTime(reader["last_activity"]),
                    LoginUser = Convert.ToString(reader["login_user"]),
                    PasswordUser = Convert.ToString(reader["password_user"])
                };
                userslist.Add(item);
            }

            dataGrid1.ItemsSource = userslist;
            dataGrid1.Columns[0].Visibility = Visibility.Hidden;
        }
        private void SetAuditLogGrid()
        {
            List<AuditLog> auditLogList = new List<AuditLog>();
            _connection.Open();
            string sql = "SELECT * FROM enterauditlogdb()";
            NpgsqlCommand command = new NpgsqlCommand(sql, _connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                AuditLog item = new AuditLog()
                {
                    ID = Convert.ToInt32(reader["id_audit"]),
                    FileId = Convert.ToInt32(reader["file_id"]),
                    UserId = Convert.ToInt32(reader["user_id"]),
                    Operation = Convert.ToString(reader["operation_"]),
                    ChangeDate = Convert.ToDateTime(reader["change_date"]),
                };
                auditLogList.Add(item);
            }

            dataGrid1.ItemsSource = auditLogList;
            dataGrid1.Columns[0].Visibility = Visibility.Hidden;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
