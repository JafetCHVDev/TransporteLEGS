using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;



namespace TransporteEscolarApp
{

    public partial class Form1 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoBarras.Text.Trim();
            if (codigo == "") return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Estudiantes WHERE CodigoBarras = @codigo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@codigo", codigo);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int estudianteId = (int)reader["EstudianteID"];
                    string nombre = reader["Nombre"].ToString();
                    bool esBecado = (bool)reader["EsBecado"];
                    lblNombre.Text = nombre;
                    lblBecado.Text = esBecado ? "Sí" : "No";
                    reader.Close();

                    // Verificar si ya usó el transporte hoy
                    string verificar = @"SELECT COUNT(*) FROM UsoTransporte 
                                 WHERE EstudianteID = @id AND 
                                 CAST(FechaHora AS DATE) = CAST(GETDATE() AS DATE)";
                    SqlCommand checkCmd = new SqlCommand(verificar, conn);
                    checkCmd.Parameters.AddWithValue("@id", estudianteId);
                    int yaUso = (int)checkCmd.ExecuteScalar();

                    if (yaUso > 0)
                    {
                        MessageBox.Show("Este estudiante ya usó el transporte hoy.");
                    }
                    else
                    {
                        string insert = @"INSERT INTO UsoTransporte (EstudianteID, FechaHora, UtilizoTransporte) 
                                  VALUES (@id, @fecha, 1)";
                        SqlCommand insertCmd = new SqlCommand(insert, conn);
                        insertCmd.Parameters.AddWithValue("@id", estudianteId);
                        insertCmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                        insertCmd.ExecuteNonQuery();
                        MessageBox.Show("Registro exitoso.");
                    }
                }
                else
                {
                    MessageBox.Show("Estudiante no encontrado.");
                }
            }

            txtCodigoBarras.Clear();
            txtCodigoBarras.Focus();
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFechaFiltro.Value.Date;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
        SELECT 
            E.Nombre AS Estudiante,
            E.Cedula AS Cedula,
            E.Seccion AS Grado,
            CASE WHEN E.EsBecado = 1 THEN 'Sí' ELSE 'No' END AS Becado,
            FORMAT(U.FechaHora, 'yyyy-MM-dd HH:mm:ss') AS Hora
        FROM UsoTransporte U
        INNER JOIN Estudiantes E ON U.EstudianteID = E.EstudianteID
        WHERE CAST(U.FechaHora AS DATE) = @fecha
        ORDER BY U.FechaHora";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fecha", fechaSeleccionada);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvResumen.DataSource = dt;

                // Mostrar cantidad total de estudiantes
                lblTotal.Text = $"Total: {dt.Rows.Count} estudiantes";
            }
        }

        private void dtpFechaFiltro_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
