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
    /// Логика взаимодействия для Glavnii.xaml
    /// </summary>
    public partial class Glavnii : Window
    {
        public Glavnii(string Id)
        {
            InitializeComponent();
            Polz.Content = Id;
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

        private void Vihod_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Izmenit_Click(object sender, RoutedEventArgs e)
        {
            Izmenenie main = new Izmenenie(Polz.Content+"");
            main.Show();
            this.Close();
        }

        private void Prosmotr_Click(object sender, RoutedEventArgs e)
        {
            Broni main = new Broni(Polz.Content + "");
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
                    Spisok.Text += reader[0] + ")\n" + reader[4] + "км. \n" + reader[5] + "мин. \n" + reader[6] + "руб. ";
                    chet++;
                }

            }
            if (chet == 0) MessageBox.Show("Маршрут не найден!");
        }   

        private void Bron_Click(object sender, RoutedEventArgs e)
        {
            if (Spisok.Text != "")
            {
                String[] bron = Spisok.Text.ToString().Split(')');
                int polz = Convert.ToInt32(Polz.Content);
                string sql = string.Format("Insert Into Broni (IdPolzovat,IdMarshrut) Values(@id1,@id2)");
                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    // Добавить параметры
                    connection.Open();
                    cmd.Parameters.AddWithValue("@id1", polz);
                    cmd.Parameters.AddWithValue("@id2", Convert.ToInt32(bron[0]));

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Забронировано!");

                connection.Close();
            }
            else MessageBox.Show("Маршрут не найден!");
        }
    }
}
