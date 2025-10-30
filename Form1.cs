using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
                    using (var command = new SqliteCommand(@"SELECT Name,Surname,de.Location AS Airport,ar.Location AS Flight FROM Passanger JOIN Trip ON Trip.PassangerID = Passanger.ID  JOIN Airport de ON de.ID = Trip.DepartueAirportID JOIN Airport ar ON ar.ID = Trip.ArrivalAirportID WHERE Name=@DO", connection))
                    {
                        command.Parameters.AddWithValue("@DO", textBox1.Text);
                        using (var reader = command.ExecuteReader())
                        {

                            DataTable Passanger = new DataTable();
                            Passanger.Load(reader);
                            dataGridView1.DataSource = Passanger;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Critical error: " + ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            string query = $@"
                SELECT  Passanger.Name,
                Passanger.Surname,
                de.Location AS Airport,
                ar.Location AS Flight
                FROM Passanger
                JOIN Trip ON Trip.PassangerID = Passanger.ID
                JOIN Airport de ON de.ID = Trip.DepartueAirportID
                JOIN Airport ar ON ar.ID = Trip.ArrivalAirportID";
        
            this.BeginInvoke(/*(Action)*/(() =>
            {
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.Visible = checkedListBox1.CheckedItems.Contains(column.HeaderText);
                }
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=C:\\SQL\\Trips and Airports1.db";

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(@"INSERT INTO Trip (DepartueAirportID,ArrivalAirportID,PlaneID,PassangerID) VALUES (@Eirport,@Flightt,@PLANeId,@PASSangerId)", connection))
                    {
                        command.Parameters.AddWithValue("@Eirport", textBox4.Text);
                        command.Parameters.AddWithValue("@Flightt", textBox5.Text);
                        command.Parameters.AddWithValue("@PLANeId", textBox6.Text);
                        command.Parameters.AddWithValue("@PASSangerId", textBox7.Text);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Done");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Critical error: " + ex.Message);
            }          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=C:\\SQL\\Trips and Airports1.db";

            try 
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(@"INSERT INTO Passanger (Name,Surname) VALUES (@NAM, @SURNAM)", connection))
                    {
                        command.Parameters.AddWithValue("@NAM", textBox2.Text);
                        command.Parameters.AddWithValue("@SURNAM", textBox3.Text);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Done");
                }

            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Critical error: " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}