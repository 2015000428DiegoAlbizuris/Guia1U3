using System;
//Insertar librerias de conexion
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guia1_ConexionSQL
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAB-C-PC-23\SQLEXPRESS; Initial Catalog=Producto; Integrated Security=true");
        public Form1()
        {
            InitializeComponent();
            ObtenerRegistros();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=LAB-C-PC-23\SQLEXPRESS; Initial Catalog=Producto; Integrated Security=true");
            conexion.Open();
            MessageBox.Show("Conexion Exitosa");
            conexion.Close();
            MessageBox.Show("Se cerro la conexion");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")

                    MessageBox.Show("Llene los campos necesarios");
                else
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("insert into postres (nombre, precio, stock) values('" + textBox1.Text + "','" + textBox2.Text
                        + "', '" + textBox3.Text + "')", conn);
                    sda.SelectCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Datos almacenados correctamente");
                    ObtenerRegistros();
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error de sql Verificar " + ex.ToString());

            }
        }

        //Metodo
        private void ObtenerRegistros()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from postres", conn);
            DataSet ds = new DataSet();
            da.Fill(ds,"nombre");
            dataGridView1.DataSource = ds.Tables["nombre"].DefaultView;

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
    }
