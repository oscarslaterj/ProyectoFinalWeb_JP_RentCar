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
        RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
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
            int id = 0;
            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            if (hasta < desde)
            {
                Utils.MostraMensaje(this, "No Sera Posible Hacer Una Consulta Si El Rango Hasta Es Menor Que El Desde!!", "Fechas Invalidas!!", "warning");
                return;
            }

            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = p => true;
                    break;

                case 1://UsuarioId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.UsuarioId == id && (p.Fecha >= desde && p.Fecha <= hasta);
                    break;

                case 2://Usuario
                    filtro = p => p.NombreUser.Contains(CriterioTextBox.Text) && (p.Fecha >= desde && p.Fecha <= hasta);
                    break;
                case 3://Tipo
                    filtro = p => p.Tipo.Contains(CriterioTextBox.Text) && (p.Fecha >= desde && p.Fecha <= hasta);
                    break;
                case 4://Nombre
                    filtro = p => p.Nombre.Contains(CriterioTextBox.Text) && (p.Fecha >= desde && p.Fecha <= hasta);
                    break;
            }

            listUsuarios = repositorio.GetList(filtro);
            UsuarioGridView.DataSource = listUsuarios;
            UsuarioGridView.DataBind();
        }

      

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (listUsuarios.Count > 0)
            {
                Response.Redirect("/UI/Reportes/UsuarioReportViewer.aspx");
            }
            else
            {
                Utils.MostraMensaje(this, "No Hay Datos", "Fallo!!", "error");
            }
        }
    }
}