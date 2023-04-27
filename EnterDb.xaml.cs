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
        public EnterDb()
        {
            InitializeComponent();
        }
        public EnterDb (NpgsqlConnection npgsqlConnection)
        {
            _connection = npgsqlConnection;
        }
        private void EnterDB()
        {
            _connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("enterdevices", _connection);
            
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }
    }
}
