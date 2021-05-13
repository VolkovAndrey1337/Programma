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
    /// Логика взаимодействия для Broni.xaml
    /// </summary>
    public partial class Broni : Window
    {
        public Broni(string Id)
        {
            InitializeComponent();
            Polz.Content = Id;

            int chet = 0;

            string table = "Broni"; //Имя таблицы
            string ssql = $"SELECT  * FROM {table} "; //Запрос 
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader.Read())
            {
                if (reader[1] + "" == Id) 
                {
                    string table1 = "Marshrut"; //Имя таблицы
                    string ssql1 = $"SELECT  * FROM {table1} "; //Запрос 
                    string connectionString1 = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
                    SqlConnection conn1 = new SqlConnection(connectionString1); // Подключение к БД
                    conn1.Open();// Открытие Соединения

                    SqlCommand command1 = new SqlCommand(ssql1, conn1);// Объект вывода запросов
                    SqlDataReader reader1 = command1.ExecuteReader(); // Выаолнение запроса вывод информации
                    while (reader1.Read())
                    {
                        if (reader1[0] + "" == reader[2] + "")
                        {
                            string table2 = "Mesta"; //Имя таблицы
                            string ssql2 = $"SELECT  * FROM {table2} "; //Запрос 
                            string connectionString2 = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
                            SqlConnection conn2 = new SqlConnection(connectionString2); // Подключение к БД
                            conn2.Open();// Открытие Соединения

                            SqlCommand command2 = new SqlCommand(ssql2, conn2);// Объект вывода запросов
                            SqlDataReader reader2 = command2.ExecuteReader(); // Выаолнение запроса вывод информации
                            while (reader2.Read())
                            {
                                if (reader1[2] + "" == reader2[0] + "") 
                                {
                                    Spisok.Text += reader[0] + ")\nМесто прибытия: " + reader2[1] + "\n" + reader1[3] + "\n" + reader1[4] + "км. \n" + reader1[5] + "мин. \n" + reader1[6] + "руб. \n\n";
                                    chet++;
                                }

                            }
                        }

                    }
                }
            }
            if (chet == 0) MessageBox.Show("Бронирований не найдено!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Glavnii main = new Glavnii(Polz.Content + "");
            main.Show();
            this.Close();
        }

        private void Obnova_Click(object sender, RoutedEventArgs e)
        {
            Spisok.Text = "";
            string Id = Convert.ToString(Polz.Content);
            int chet = 0;

            string table = "Broni"; //Имя таблицы
            string ssql = $"SELECT  * FROM {table} "; //Запрос 
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader.Read())
            {
                if (reader[1] + "" == Id)
                {
                    string table1 = "Marshrut"; //Имя таблицы
                    string ssql1 = $"SELECT  * FROM {table1} "; //Запрос 
                    string connectionString1 = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
                    SqlConnection conn1 = new SqlConnection(connectionString1); // Подключение к БД
                    conn1.Open();// Открытие Соединения

                    SqlCommand command1 = new SqlCommand(ssql1, conn1);// Объект вывода запросов
                    SqlDataReader reader1 = command1.ExecuteReader(); // Выаолнение запроса вывод информации
                    while (reader1.Read())
                    {
                        if (reader1[0] + "" == reader[2] + "")
                        {
                            string table2 = "Mesta"; //Имя таблицы
                            string ssql2 = $"SELECT  * FROM {table2} "; //Запрос 
                            string connectionString2 = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
                            SqlConnection conn2 = new SqlConnection(connectionString2); // Подключение к БД
                            conn2.Open();// Открытие Соединения

                            SqlCommand command2 = new SqlCommand(ssql2, conn2);// Объект вывода запросов
                            SqlDataReader reader2 = command2.ExecuteReader(); // Выаолнение запроса вывод информации
                            while (reader2.Read())
                            {
                                if (reader1[2] + "" == reader2[0] + "")
                                {
                                    Spisok.Text += reader[0] + ")\nМесто прибытия: " + reader2[1] + "\n" + reader1[3] + "\n" + reader1[4] + "км. \n" + reader1[5] + "мин. \n" + reader1[6] + "руб. \n\n";
                                    chet++;
                                }

                            }
                        }

                    }
                }
            }
            if (chet == 0) MessageBox.Show("Бронирований не найдено!");
        }

        private void Poisk_Click(object sender, RoutedEventArgs e)
        {
            Spisok.Text = "";
            string Id = Convert.ToString(Polz.Content);
            string data = Data.SelectedDate + "";
            string prob = "";
            for (int j = 0; j < 10; j++)
            {
                prob += data[j];
            }
            int chet = 0;

            string table = "Broni"; //Имя таблицы
            string ssql = $"SELECT  * FROM {table} "; //Запрос 
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader.Read())
            {
                if (reader[1] + "" == Id)
                {
                    string table1 = "Marshrut"; //Имя таблицы
                    string ssql1 = $"SELECT  * FROM {table1} "; //Запрос 
                    string connectionString1 = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
                    SqlConnection conn1 = new SqlConnection(connectionString1); // Подключение к БД
                    conn1.Open();// Открытие Соединения

                    SqlCommand command1 = new SqlCommand(ssql1, conn1);// Объект вывода запросов
                    SqlDataReader reader1 = command1.ExecuteReader(); // Выаолнение запроса вывод информации
                    while (reader1.Read())
                    {
                        if (reader1[0] + "" == reader[2] + "")
                        {
                            string table2 = "Mesta"; //Имя таблицы
                            string ssql2 = $"SELECT  * FROM {table2} "; //Запрос 
                            string connectionString2 = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
                            SqlConnection conn2 = new SqlConnection(connectionString2); // Подключение к БД
                            conn2.Open();// Открытие Соединения

                            SqlCommand command2 = new SqlCommand(ssql2, conn2);// Объект вывода запросов
                            SqlDataReader reader2 = command2.ExecuteReader(); // Выаолнение запроса вывод информации
                            while (reader2.Read())
                            {
                                if (reader1[2] + "" == reader2[0] + "")
                                {
                                    if (reader1[3] + "" == prob)
                                    {
                                        Spisok.Text += reader[0] + ")\nМесто прибытия: " + reader2[1] + "\n" + reader1[3] + "\n" + reader1[4] + "км. \n" + reader1[5] + "мин. \n" + reader1[6] + "руб. \n\n";
                                        chet++;
                                    }
                                }

                            }
                        }

                    }
                }
            }
            if (chet == 0) MessageBox.Show("Бронирований не найдено!");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string id = Id.Text;

            if (Spisok.Text.IndexOf(id+")") >= 0) 
            {
            string sql = string.Format("DELETE  FROM Broni  WHERE id = @id");
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                // Добавить параметры
                connection.Open();
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }

            Id.Clear();
            Spisok.Text = "";
            MessageBox.Show($"Данные удалены!");
            }
            else  MessageBox.Show("Нет доступного бронирования для удаления!");
        }
    }
}
