using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Не забываем про библиотеку
using MySql.Data.MySqlClient;

namespace WindowsFormsApp4
{
	public partial class Form1 : Form
	{
        //Лист, в который будем выгружать данные. Объявляем один - 
		//потом просто чистить будем, чтобы память не забивать
		List<string[]> data = new List<string[]>();
        //Коннектион
		MySqlConnection connect = new MySqlConnection("server=localhost;userid=root;password=1234;" +
			"database=test;port=3306;persistsecurityinfo=True;sslmode=None");
		public Form1()
		{
            //Перед тем, как что-то делать нужно руками - через интерфейс создать необходимые столбцы таблицы - это не сложно
			InitializeComponent();
			try
			{
                //Здесь и далее первая строка это обычная выгрузка, вторая из двух таблиц. Сделал таблицу-словарь ролей
                //И во-втором запросе выгружаю роли не из пользователей, а из соседней таблицы
                // MySqlCommand cmd = new MySqlCommand("select * from users;", connect);
                MySqlCommand cmd = new MySqlCommand("select users.Login, users.Password," +
					" role.Role from users inner join " +
					"role on users.Role=role.Role", connect);
                //Открываем коннектион
                connect.Open();
                //Класс, который как раз и выгружает, ему присваеваем переменную запроса - cmd, с командой "ВыполнитьПрочитать"
				MySqlDataReader read = cmd.ExecuteReader();
                //Теперь делаем цикл аля СИ П П Засовываем метод чтения в условие и по есть чтение делаем ...
				while(read.Read())
				{
                    //В лист добавляем новый элемент - массив строк из трех элементов - по количеству столбцов
					data.Add(new string[3]);
                    // Теперь как и в обычном массиве присваеиваем значения из бд листу
                    //"название листа"[количество элементов минус один][номер столбца] = "переменная чтения"
					//[номер столбца из бд].ПереводВстроку();
					data[data.Count - 1][0] = read[0].ToString();
					data[data.Count - 1][1] = read[1].ToString();
					data[data.Count - 1][2] = read[2].ToString();
				}
			}
            //Думаю catch и finally в комментах не нуждаются
			catch(Exception ex)
			{
				MessageBox.Show("Ошибка соединения с базой данных. \n\n\n\n\nПодробнее:\n" + ex.ToString());
			}
			finally
			{
				connect.Close();
			}

            //Теперь выбираем Массив строк нашей таблице на форме и вызываем метод их очитски
			dataGridView1.Rows.Clear();
            //Цикл для заполнения таблицы данными из листа
            //"Для каждого массива строк в листе"...
			foreach(string[] item in data)
			{
                //По одному добавляем в массив строк таблицы - тут строки, как строки таблицы - массив строк листа
				dataGridView1.Rows.Add(item);
			}
		}
        //"Буличка" для удаления
		private void buttonDelete_Click(object sender, EventArgs e)
		{
            // Проверяем заполнен ли текстовое поле с логином для удаления
			if (textBoxLoginDelete.Text != "" && textBoxLoginDelete.Text != "  ")
			{
				try
				{
                    //Пишем запрос по удалению строки и с БД с условием where по ключевому полу, 
                    //Можно и не по нему, но оно однозначно интерпретирует то, что ты хочешь удалить
					MySqlCommand cmd = new MySqlCommand("delete from users where Login='" + textBoxLoginDelete.Text + "';", connect);
					connect.Open();
                    //Тут мы ничего не читаем по этому просто пишем пременную запроса с методом "ИсполнитьБезОтвета"
					cmd.ExecuteNonQuery();
                    //Цикл для того, чтобы удалить 
					for (int i = 0; i < dataGridView1.RowCount; i++)
					{
                        //Строка[i]Ячека[Заранее известный номер ячейки логина].СвойстваЗначения.ПереводВстроку.Сравнение(содержимое текстового поля логина для удаления) 
						if (dataGridView1.Rows[i].Cells[0].Value.ToString().Equals(textBoxLoginDelete.Text))
						{
                            //Если условие воплнилось, то удаляем строку из таблицы под номером i
							dataGridView1.Rows.RemoveAt(i);
                            //Выходим из цикла, чтобы не тратить время
							break;
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ошибка соединения с базой данных. \n\n\n\n\nПодробнее:\n" + ex.ToString());
				}
				finally
				{
					connect.Close();
				}
			}
			else
			{
				MessageBox.Show("Введите Логин  учетной записи, которую хотите удалить.");
			}
		}

		private void buttonUpdate_Click(object sender, EventArgs e)
		{
            //Проверка заполненены ли все поля для изменения данных заполнены
			if (textBoxLoginUpdate.Text != "" && textBoxLoginUpdate.Text != "  " &&
				textBoxNewPasswordUpdate.Text != "" && textBoxNewPasswordUpdate.Text != " " &&
				textBoxNewRoleUpdate.Text != "" && textBoxNewRoleUpdate.Text != " ")
			{
				try
				{
                    //Запрос на изменение данных в  полях "где" логин равен значению логина в текстовом поле для обновления
					MySqlCommand cmd = new MySqlCommand("update users set Password = '" + textBoxNewPasswordUpdate.Text + "', Role = '" + textBoxNewRoleUpdate.Text + "' where (Login = '" + textBoxLoginUpdate.Text + "');", connect);
					connect.Open();
					cmd.ExecuteNonQuery();
                    //Цикл для изменения значений в нашей таблице на форме
					for (int i = 0; i < dataGridView1.RowCount; i++)
					{
						if (dataGridView1.Rows[i].Cells[0].Value.ToString().Equals(textBoxLoginUpdate.Text))
						{
                            //Изменение значение в полях в соответсвии их расположением
							dataGridView1.Rows[i].Cells[1].Value = textBoxNewPasswordUpdate.Text;
							dataGridView1.Rows[i].Cells[2].Value = textBoxNewRoleUpdate.Text;
							break;
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ошибка соединения с базой данных. \n\n\n\n\nПодробнее:\n" + ex.ToString());
				}
				finally
				{
					connect.Close();
				}
			}
			else
			{
				MessageBox.Show("Для изменения данных учетной записи заполните все необходимые поля.");
			}
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
            
			if (textBoxNewLoginAdd.Text != "" && textBoxNewLoginAdd.Text != "  " &&
				textBoxNewPasswordAdd.Text != "" && textBoxNewPasswordAdd.Text != " " &&
				textBoxNewRoleAdd.Text != "" && textBoxNewRoleAdd.Text != " ")
			{
				try
				{

					MySqlCommand cmd = new MySqlCommand("insert into users (Login, Password, Role) VALUES ('" + textBoxNewLoginAdd.Text + "', '" + textBoxNewPasswordAdd.Text + "', '" + textBoxNewRoleAdd.Text + "');", connect);
					connect.Open();
					cmd.ExecuteNonQuery();
                    //Добавление новой строки в таблицу
					dataGridView1.Rows.Add(textBoxNewLoginAdd.Text, textBoxNewPasswordAdd.Text, textBoxNewRoleAdd.Text);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ошибка соединения с базой данных. \n\n\n\n\nПодробнее:\n" + ex.ToString());
				}
				finally
				{
					connect.Close();
				}
			}
			else
			{
				MessageBox.Show("Для изменения данных учетной записи заполните все необходимые поля.");
			}
		}
        //Кнопка поиска
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text != "" && textBoxSearch.Text != " ")
            {
                //Очистка листа и таблицы
                data.Clear();
                dataGridView1.Rows.Clear();
                // MySqlCommand cmd = new MySqlCommand("select * from users;", connect);
                MySqlCommand cmd = new MySqlCommand("select users.Login, users.Password, role.Role from users inner join role on users.Role=role.Role", connect);
                try
                {
                    connect.Open();
                    MySqlDataReader Data = cmd.ExecuteReader();
                    while(Data.Read())
                    {
                        data.Add(new string[3]);
                        data[data.Count - 1][0] = Data[0].ToString();
                        data[data.Count - 1][1] = Data[1].ToString();
                        data[data.Count - 1][2] = Data[2].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка соединения с базой данных. \n\n\n\n\nПодробнее:\n" + ex.ToString());
                }
                finally
                {
                    connect.Close();
                }
                //Сама фишка поиска
                foreach(var item in data)
                {
                    //Условие содержит ли какое-либо из поле 
                    if (item[0].Contains(textBoxSearch.Text) || item[1].Contains(textBoxSearch.Text) || item[2].Contains(textBoxSearch.Text))
                    {
                        dataGridView1.Rows.Add(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не введен критерий для поиска!!!");
            }
        }
        //Кнопка отмены поиска
        private void buttonCancleSearch_Click(object sender, EventArgs e)
        {
            data.Clear();
            dataGridView1.Rows.Clear();
            try
            {
               // MySqlCommand cmd = new MySqlCommand("select * from users;", connect);
                MySqlCommand cmd = new MySqlCommand("select users.Login, users.Password, role.Role from users inner join role on users.Role=role.Role", connect);
                connect.Open();
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    data.Add(new string[3]);
                    data[data.Count - 1][0] = read[0].ToString();
                    data[data.Count - 1][1] = read[1].ToString();
                    data[data.Count - 1][2] = read[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка соединения с базой данных. \n\n\n\n\nПодробнее:\n" + ex.ToString());
            }
            finally
            {
                connect.Close();
            }
            dataGridView1.Rows.Clear();
            foreach (string[] item in data)
            {
                dataGridView1.Rows.Add(item);
            }
        }
    }
}
