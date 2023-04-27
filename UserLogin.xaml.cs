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
    /// Логика взаимодействия для UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }
        private void UserLogging_Click(object sender, RoutedEventArgs e)
        {
            string str = Log(AddLogin.Text, AddPassword.Text);
            if (str == null)
            {
                MessageBox.Show("Пользователя с таким логином/паролем не сущетсвует!");
                return;
            }
            NpgsqlConnection connection = new NpgsqlConnection(str);
            MainWindow mainWindow = new MainWindow(connection);
            mainWindow.Show();
            Close();
        }
        public static string Log(string login, string password )
        {
            string script;
            switch (login, password)
            {
                case ("guest_user", "guest"):
                        script = "Host=localhost;Port=5432;Database=Alina;Username=guest_user;Password=guest";
                    break;

                case ("worker_user", "worker"):
                        script = "Host=localhost;Port=5432;Database=Alina;Username=worker_user;Password=worker";
                    break;

                case ("postgres", "1"):
                        script = "Host=localhost;Port=5432;Database=Alina;Username=postgres;Password=1";
                    break;
                default:
                        script = null;
                    break;
            }

            return script;
        }
    }
}
