using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Perevozki
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Registraciya_Click(object sender, RoutedEventArgs e)
        {
            Registration main = new Registration();
            main.Show();
            this.Close();
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string parol = Parol.Text;
            for (int i = login.Length; i < 100; i++) 
            {
                login += " ";
            }
            for (int i = parol.Length; i < 50; i++)
            {
                parol += " ";
            }
            int chet = 0;

            string table = "Polzovatel"; //Имя таблицы
            string ssql = $"SELECT  * FROM {table} "; //Запрос 
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader.Read())
            {
                if (reader[4] + "" == login && reader[5] + "" == parol)
                {
                    Glavnii main = new Glavnii(reader[0]+"");
                    main.Show();
                    this.Close();
                    chet++;
                }
            }
            if (chet==0) MessageBox.Show("Неверный логин или пароль!");
        }
    }
}
