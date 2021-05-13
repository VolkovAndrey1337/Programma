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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Perevozki
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string table = "Mesta"; //Имя таблицы
            string ssql = $"SELECT  * FROM {table} "; //Запрос 
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader.Read())
            {
                Otkuda.Items.Add(reader[0] + ") " + reader[1]);
                Kuda.Items.Add(reader[0] + ") " + reader[1]);
            }
            reader.Close();
            conn.Close();

        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            Autorization main = new Autorization();
            main.Show();
            this.Close();
        }

        private void Bron_Click(object sender, RoutedEventArgs e)
        {
            Autorization main = new Autorization();
            main.Show();
            this.Close();
        }

        private void Naiti_Click(object sender, RoutedEventArgs e)
        {
            string data = Data.SelectedDate + "";
            String[] otkuda = Otkuda.SelectedItem.ToString().Split(')');
            String[] kuda = Kuda.SelectedItem.ToString().Split(')');
            string prob = "";
            for (int j = 0; j < 10; j++)
            {
                prob += data[j];
            }

            int chet = 0;

            string table = "Marshrut"; //Имя таблицы
            string ssql = $"SELECT  * FROM {table} "; //Запрос 
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader.Read())
            {
                if (reader[1] + "" == otkuda[0] && reader[2] + "" == kuda[0] && reader[3] + "" == prob)
                {
                    Spisok.Text += reader[4] + "км. \n" + reader[5] + "мин. \n" + reader[6] + "руб. ";
                    chet++;
                }
            }
            if (chet == 0) MessageBox.Show("Маршрут не найден!");

        }
    }
}
