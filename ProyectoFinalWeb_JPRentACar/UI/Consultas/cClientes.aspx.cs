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
    public partial class cClientes : System.Web.UI.Page
    {
        Expression<Func<Clientes, bool>> filtro = p => true;
        RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
        public static List<Clientes> listClientes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                listClientes = repositorio.GetList(filtro);

            }
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            if (hasta.Date < desde.Date)
            {
                Utils.MostraMensaje(this, "No Sera Posible Hacer Una Consulta Si El Rango Hasta Es Menor Que El Desde!!", "Fechas Invalidas!!", "warning");
                return;
            }

            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = p => true && p.FechaRegistro >= desde && p.FechaRegistro <= hasta;
                    break;

                case 1://ClienteId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.ClienteId == id && p.FechaRegistro >= desde && p.FechaRegistro <= hasta;
                    break;

                case 2://Nombres
                    filtro = p => p.Nombre.Contains(CriterioTextBox.Text) && p.FechaRegistro >= desde && p.FechaRegistro <= hasta;
                    break;
            }

            listClientes = repositorio.GetList(filtro);
            ClientesGridView.DataSource = listClientes;
            ClientesGridView.DataBind();           

        }
        public static List<Clientes> RetornarClientes()
        {
            return listClientes;
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ClientesReportViewer.aspx");
        }

        protected void FiltroDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CriterioTextBox.Text = "";

            if (FiltroDropDownList.SelectedIndex == 0)
            {
                CriterioTextBox.ReadOnly = true;

            }
            else
            {
                CriterioTextBox.ReadOnly = false;
            }
        }
    }
}