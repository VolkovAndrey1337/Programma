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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            Autorization main = new Autorization();
            main.Show();
            this.Close();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            int schet_prav = 0;
            string fam = Familiya.Text;
            string imya = Imya.Text;
            string ochest = Ochestvo.Text;
            string data = Data.Text;
            string parol = Parol.Text;
            string tel = Tel.Text;
            string mail = Mail.Text;

            int count = 0;
            string bukva = "";

            if (fam != "")
            {
                bukva = Convert.ToString(fam[0]);
                if (bukva == bukva.ToUpper())
                {
                    count++;
                    for (int i = 1; i < fam.Length; i++)
                    {
                        bukva = fam[i] + "";
                        if (bukva != bukva.ToUpper())
                        {
                            count++;
                        }
                    }
                }
                if (count == fam.Length)
                {
                    count = 0;
                    bukva = "";
                    schet_prav++;
                }
                else
                {
                    MessageBox.Show("Некорректно введена Фамилия!");
                }
            }
            else
            {
                MessageBox.Show("Некорректно введена Фамилия!");
            }


            if (imya != "")
            {
                bukva = Convert.ToString(imya[0]);
                if (bukva == bukva.ToUpper())
                {
                    count++;
                    for (int i = 1; i < imya.Length; i++)
                    {
                        bukva = imya[i] + "";
                        if (bukva != bukva.ToUpper())
                        {
                            count++;
                        }
                    }
                }
                if (count == imya.Length)
                {
                    count = 0;
                    bukva = "";
                    schet_prav++;
                }
                else
                {
                    MessageBox.Show("Некорректно введено Имя!");
                }
            }
            else
            {
                MessageBox.Show("Некорректно введено Имя!");
            }


            if (ochest.Length != 0)
            {
                bukva = Convert.ToString(ochest[0]);
                if (bukva == bukva.ToUpper())
                {
                    count++;
                    for (int i = 1; i < ochest.Length; i++)
                    {
                        bukva = ochest[i] + "";
                        if (bukva != bukva.ToUpper())
                        {
                            count++;
                        }
                    }
                }
                if (count == ochest.Length)
                {
                    count = 0;
                    bukva = "";
                    schet_prav++;
                }
                else
                {
                    MessageBox.Show("Некорректно введено Очество!");
                }
            }
            else
            {
                MessageBox.Show("Некорректно введено Очество!");
            }


            if (data != "")
            {
                int oshib = 0;
                string[] chisla = data.Split('.');

                for (int g = 0; g < chisla.Length; g++)
                {
                    for (int i = 0; i < chisla[g].Length; i++)
                    {
                        if (Convert.ToChar(chisla[g][i]) < 48 || 57 < Convert.ToChar(chisla[g][i]))
                        {
                            oshib++;
                        }
                    }
                }
                if (oshib == 0)
                {
                    if (Convert.ToInt32(chisla[0]) < 1 || Convert.ToInt32(chisla[0]) > 31)
                    {
                        MessageBox.Show("Некорректно введена дата рождения");
                    }
                    else if (Convert.ToInt32(chisla[1]) < 1 || Convert.ToInt32(chisla[1]) > 12)
                    {
                        MessageBox.Show("Некорректно введена дата рождения");
                    }
                    else if (Convert.ToInt32(chisla[2]) < 1 || Convert.ToInt32(chisla[2]) > 2021)
                    {
                        MessageBox.Show("Некорректно введена дата рождения");
                    }
                    else
                    {
                        schet_prav++;
                    }
                }
                else
                {
                    MessageBox.Show("Некорректно введена дата рождения");
                    oshib = 0;
                }
            }
            else
            {
                MessageBox.Show("Некорректно введена дата рождения");
            }


            int kol = 0;
            string cifri = "0123456789";
            if (parol.Length >= 8)
            {
                schet_prav++;
            }
            else
            {
                MessageBox.Show("Пароль должен содержать не менее 8 символов!");
            }


            if (tel != "")
            {
                if ("+".CompareTo(Convert.ToString(tel[0])) == 0)
                {
                    for (int i = 1; i < tel.Length; i++)
                    {
                        for (int j = 0; j < cifri.Length; j++)
                        {
                            if (tel[i] == cifri[j])
                            {
                                kol++;
                            }
                        }
                    }
                    if (kol == 11)
                    {
                        kol = 0;
                        schet_prav++;
                    }
                    else
                    {
                        MessageBox.Show("Некорректно введен номер телефона!");
                    }
                }
                else
                {
                    for (int i = 0; i < tel.Length; i++)
                    {
                        for (int j = 0; j < cifri.Length; j++)
                        {
                            if (tel[i] == cifri[j])
                            {
                                kol++;
                            }
                        }
                    }
                    if (kol == 11)
                    {
                        kol = 0;
                        schet_prav++;
                    }
                    else
                    {
                        MessageBox.Show("Некорректно введен номер телефона!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Некорректно введен номер телефона!");
            }

            int schet = 0;
            string prob = mail;
            for (int i = mail.Length; i < 100; i++)
            {
                prob += " ";
            }
            string table1 = "Polzovatel"; //Имя таблицы
            string ssql1 = $"SELECT  * FROM {table1} "; //Запрос 
            string connectionString1 = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
            SqlConnection conn1 = new SqlConnection(connectionString1); // Подключение к БД
            conn1.Open();// Открытие Соединения

            SqlCommand command1 = new SqlCommand(ssql1, conn1);// Объект вывода запросов
            SqlDataReader reader1 = command1.ExecuteReader(); // Выаолнение запроса вывод информации
            while (reader1.Read())
            {
                if (reader1[4] + "" == prob)
                {
                    schet++;
                }
            }
            if (schet != 0)
            {
                MessageBox.Show("Введенный E-mail уже привязан к личному кабинету!");
                schet = 0;
            }
            else if (mail != "")
            {
                string[] chast = mail.Split('@');
                string[] toch = chast[chast.Length - 1].Split('.');
                if (chast.Length != 2)
                {
                    MessageBox.Show("Некорректно введен e-mail!");
                }
                else if (chast[0].Length < 1 || chast[1].Length < 1)
                {
                    MessageBox.Show("Некорректно введен e-mail!");
                }
                else if (toch.Length != 2)
                {
                    MessageBox.Show("Некорректно введен e-mail!");
                }
                else if (toch[0].Length < 1 || toch[1].Length < 1)
                {
                    MessageBox.Show("Некорректно введен e-mail!");
                }
                else
                {
                    for (int g = 0; g < chast.Length; g++)
                    {
                        for (int i = 0; i < chast[g].Length; i++)
                        {
                            if (((Convert.ToChar(chast[g][i]) < 97 || 122 < Convert.ToChar(chast[g][i])) && (Convert.ToChar(chast[g][i]) < 48 || 57 < Convert.ToChar(chast[g][i]))) && chast[g][i] + "" != ".")
                            {
                                MessageBox.Show("Некорректно введен e-mail!");
                                break;
                            }
                            else if (i == 0 && chast[g][i] + "" == ".")
                            {
                                MessageBox.Show("Некорректно введен e-mail!");
                                break;
                            }
                            else if (i == chast[g].Length - 1 && chast[g][i] + "" == ".")
                            {
                                MessageBox.Show("Некорректно введен e-mail!");
                                break;
                            }
                            else
                            {
                                schet++;
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Некорректно введен e-mail!");
            }
            string fio = fam + " " + imya + " " + ochest;

            if (schet_prav == 6 && schet == mail.Length - 1)
            {
                string sql = string.Format("Insert Into Polzovatel (FIO,Data,Tel,Mail,Parol) Values(@fio,@data,@tel,@mail,@parol)");
                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Perevozki;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    // Добавить параметры
                    connection.Open();
                    cmd.Parameters.AddWithValue("@fio", fio);
                    cmd.Parameters.AddWithValue("@data", data);
                    cmd.Parameters.AddWithValue("@tel", tel);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@parol", parol);

                    cmd.ExecuteNonQuery();
                }
                Familiya.Clear();
                Imya.Clear();
                Ochestvo.Clear();
                Data.Clear();
                Parol.Clear();
                Mail.Clear();
                Tel.Clear();
                MessageBox.Show("Регистрация прошла успешно!");

                connection.Close();
            }
        }

    }
}
