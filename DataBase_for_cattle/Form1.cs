using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase_for_cattle
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDBDataSet.Students". При необходимости она может быть перемещена или удалена.
            //this.studentsTableAdapter.Fill(this.testDBDataSet.Students);
            LoadData();
            
        }
        private void LoadData()
        {
            string connectString = @"Data Source=MAINKRAVSIKWORK\SQLEXPRESS;
                            Initial Catalog=TestDB;
                            Integrated Security=True";
            /*Здесь указал имя БД(хотя для создания БД его указывать не нужно)
              для того, чтобы проверить, может данная БД уже создана
            Создаем экземпляр класса  SqlConnection по имени conn
            и передаем конструктору этого класса, строку подключения
             */
            SqlConnection myConnection = new SqlConnection(connectString);
            try
            {
                //пробуем подключится
                myConnection.Open();
            }
            catch (SqlException se)
            {
                label1.Text = "Ошибка подключения:{0}" + se.Message;
                return;
            }


            

            string query = "SELECT * FROM Table_1 ORDER BY ID";

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[3]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
            }

            reader.Close();

            myConnection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
           
        }
    }
}
