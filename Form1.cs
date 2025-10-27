using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void databutton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=C:\\SQL\\Trips and Airports1.db";

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connected to SQLite database!");

                    string select = "SELECT * FROM Passanger";
                    using (var command = new SqliteCommand(select, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);
                        dataGridView1.DataSource = table;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Critical error: " + ex.Message);
            }

        }
    }
}