using System;
using System.Data.SqlClient;

namespace Examen3_Jurgen
{
    public partial class ReporteEncuestas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarReporte();
            }
        }

        protected void CargarReporte()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=BD_Jurgen;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("spObtenerReporteEncuestas", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        con.Open();
                        gvReporte.DataSource = cmd.ExecuteReader();
                        gvReporte.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error inesperado: " + ex.Message;
            }
        }
    }
}
