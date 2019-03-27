using BLL;
using Entities;
using ProyectoFinalWeb_JPRentACar.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb_JPRentACar.UI.Consultas
{
    public partial class cUsuarios : System.Web.UI.Page
    {
        Expression<Func<Usuarios, bool>> filtro = c => true;
        public static List<Usuarios> listUsuarios { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            int id = 0;
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = c => true;
                    break;

                case 1://UsuarioId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = c => c.UsuarioId == id && (c.Fecha >= Utils.ToDateTime(DesdeTextBox.Text) && c.Fecha <= Utils.ToDateTime(HastaTextBox.Text));
                    break;

                case 2://Fecha
                    filtro = (c => c.Fecha.Equals(CriterioTextBox.Text));
                    break;

                case 3://Nombre
                    filtro = c => c.Nombre.Contains(CriterioTextBox.Text) && (c.Fecha >= Utils.ToDateTime(DesdeTextBox.Text) && c.Fecha <= Utils.ToDateTime(HastaTextBox.Text));
                    break;

                case 4://Nombre de usuario
                    filtro = c => c.NombreUser.Contains(CriterioTextBox.Text) && (c.Fecha >= Utils.ToDateTime(DesdeTextBox.Text) && c.Fecha <= Utils.ToDateTime(HastaTextBox.Text));
                    break;

            }

            ConsultaGridView.DataSource = repositorio.GetList(filtro);
            ConsultaGridView.DataBind();
        }

        public static List<Usuarios> RetornarUsuarios()
        {
            return listUsuarios;
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (listUsuarios.Count > 0)
            {
                Response.Redirect("/Reportes/UsuariosReportViewer.aspx");
            }
            else
            {
                Utils.MostraMensaje(this, "No Hay Datos", "Fallo!!", "error");
            }
        }
    }
}