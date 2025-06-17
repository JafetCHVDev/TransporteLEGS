using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace TransporteEscolarApp
{
    public partial class FormEstudiantes : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        public FormEstudiantes()
        {
            InitializeComponent();
            CargarEstudiantes();

            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

        }

        private void CargarEstudiantes()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Estudiantes";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEstudiantes.DataSource = dt;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtCedula.Text == "" || txtSeccion.Text == "" || txtCodigoBarras.Text == "")
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string insert = @"INSERT INTO Estudiantes (Nombre, Cedula, Seccion, CodigoBarras, EsBecado)
                                  VALUES (@nombre, @cedula, @seccion, @codigo, @becado)";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                cmd.Parameters.AddWithValue("@seccion", txtSeccion.Text.Trim());
                cmd.Parameters.AddWithValue("@codigo", txtCodigoBarras.Text.Trim());
                cmd.Parameters.AddWithValue("@becado", chkEsBecado.Checked);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Estudiante agregado exitosamente.");
            CargarEstudiantes();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un estudiante para editar.");
                return;
            }

            int id = Convert.ToInt32(dgvEstudiantes.CurrentRow.Cells["EstudianteID"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string update = @"UPDATE Estudiantes 
                                  SET Nombre = @nombre, Cedula = @cedula, Seccion = @seccion, 
                                      CodigoBarras = @codigo, EsBecado = @becado 
                                  WHERE EstudianteID = @id";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@cedula", txtCedula.Text.Trim());
                cmd.Parameters.AddWithValue("@seccion", txtSeccion.Text.Trim());
                cmd.Parameters.AddWithValue("@codigo", txtCodigoBarras.Text.Trim());
                cmd.Parameters.AddWithValue("@becado", chkEsBecado.Checked);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Estudiante actualizado.");
            CargarEstudiantes();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un estudiante para eliminar.");
                return;
            }

            int id = Convert.ToInt32(dgvEstudiantes.CurrentRow.Cells["EstudianteID"].Value);

            var confirm = MessageBox.Show("¿Está seguro de eliminar este estudiante?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string delete = "DELETE FROM Estudiantes WHERE EstudianteID = @id";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Estudiante eliminado.");
            CargarEstudiantes();
            LimpiarCampos();
        }

        private void dgvEstudiantes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEstudiantes.CurrentRow == null) return;

            txtNombre.Text = dgvEstudiantes.CurrentRow.Cells["Nombre"].Value.ToString();
            txtCedula.Text = dgvEstudiantes.CurrentRow.Cells["Cedula"].Value.ToString();
            txtSeccion.Text = dgvEstudiantes.CurrentRow.Cells["Seccion"].Value.ToString();
            txtCodigoBarras.Text = dgvEstudiantes.CurrentRow.Cells["CodigoBarras"].Value.ToString();
            chkEsBecado.Checked = (bool)dgvEstudiantes.CurrentRow.Cells["EsBecado"].Value;

            // Activar botones Editar y Eliminar, desactivar Agregar
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnAgregar.Enabled = false;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCedula.Clear();
            txtSeccion.Clear();
            txtCodigoBarras.Clear();
            chkEsBecado.Checked = false;

            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvEstudiantes.ClearSelection();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
