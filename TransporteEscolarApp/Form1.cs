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
using System.Drawing.Printing;




namespace TransporteEscolarApp
{

    public partial class Form1 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        PrintDocument printDoc = new PrintDocument();
        int filaActual = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Courier New", 10);
            int startX = 50;
            int startY = 50;
            int offsetY = 20;

            // Encabezado
            string header = string.Format("{0,-40} {1,-15} {2,-6}", "Estudiante", "Cédula", "Grado");
            e.Graphics.DrawString(header, font, Brushes.Black, startX, startY);
            startY += offsetY;

            while (filaActual < dgvResumen.Rows.Count)
            {
                DataGridViewRow fila = dgvResumen.Rows[filaActual];

                string estudiante = (fila.Cells["Estudiante"].Value ?? "").ToString();
                string cedula = (fila.Cells["Cedula"].Value ?? "").ToString();
                string grado = (fila.Cells["Grado"].Value ?? "").ToString();

                string linea = string.Format("{0,-40} {1,-15} {2,-6}", estudiante, cedula, grado);
                e.Graphics.DrawString(linea, font, Brushes.Black, startX, startY);
                startY += offsetY;

                filaActual++;

                if (startY > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
            filaActual = 0;
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            filaActual = 0; // Reinicia por si se imprime de nuevo
            printDoc.PrintPage -= printDoc_PrintPage; // Evita doble suscripción
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;

            try
            {
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar vista previa: " + ex.Message);
            }
        }


    }
}
