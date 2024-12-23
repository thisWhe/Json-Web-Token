﻿using Projec12_JwtToken.JWT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projec12_JwtToken
{
    public partial class FrmEmployee : Form
    { 
        public FrmEmployee()
        {
            InitializeComponent();
        }
        public string tokenGet;

        SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-RA4ABQ2\\SQLEXPRESS;initial catalog=Db12Project20;integrated security=true");
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            TokenValidator tokenValidator = new TokenValidator();

            richTextBox1.Text = tokenGet;
            
            var principal = tokenValidator.ValidateJwtToken(tokenGet);

            if(principal != null )
            {
                string username = principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
                MessageBox.Show("Hoş Geldiniz: " + username);

                sqlConnection.Open();
                SqlCommand command = new SqlCommand("Select * From TblEmployee", sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                dataGridView1.DataSource = datatable;
                sqlConnection.Close();
            }
            else
            {
                MessageBox.Show("Geçersiz Token:");
            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}