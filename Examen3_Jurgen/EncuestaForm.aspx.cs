using System;
using System.Data.SqlClient;

namespace Examen3_Jurgen
{
    public partial class EncuestaForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que no hayan espacios en blanco
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) || string.IsNullOrWhiteSpace(txtCorreoElectronico.Text))
                {
                    lblMensaje.Text = "Todos los campos son obligatorios";
                    return;
                }

                // Validar correo electrónico con expresión regular básica
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtCorreoElectronico.Text, @"^[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"))
                {
                    lblMensaje.Text = "Correo electrónico inválido";
                    return;
                }

                // Validar fecha de nacimiento
                DateTime fechaNacimiento;
                if (!DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento))
                {
                    lblMensaje.Text = "Formato de fecha de nacimiento incorrecto";
                    return;
                }

                // Validar edad entre 18 y 50
                int edad = DateTime.Now.Year - fechaNacimiento.Year;
                if (!(edad >= 18 && edad <= 50))
                {
                    lblMensaje.Text = "La edad debe estar entre 18 y 50 años";
                    return;
                }

                // Agregar encuesta utilizando procedimiento almacenado
                using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=BD_Jurgen;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("spAgregarEncuesta", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                        cmd.Parameters.AddWithValue("@CorreoElectronico", txtCorreoElectronico.Text);
                        cmd.Parameters.AddWithValue("@PartidoPoliticoCodigo", int.Parse(ddlPartidoPolitico.SelectedValue));

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                lblMensaje.Text = "Encuesta agregada exitosamente";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar la encuesta: " + ex.Message;
            }

             int CalcularEdad(DateTime fechaNacimiento)
            {
                DateTime fechaActual = DateTime.Now;
                int edad = fechaActual.Year - fechaNacimiento.Year;

                if (fechaNacimiento.AddYears(edad) > fechaActual)
                {
                    edad--;
                }

                return edad;
            }
        }
    }
}