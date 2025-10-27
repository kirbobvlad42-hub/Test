using System;
using Microsoft.Data.Sqlite;
using System.Windows.Forms;

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
            MessageBox.Show("Connected");

        }

                
    }
}