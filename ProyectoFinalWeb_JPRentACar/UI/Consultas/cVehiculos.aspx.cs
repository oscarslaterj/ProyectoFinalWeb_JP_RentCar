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
    public partial class cVehiculos : System.Web.UI.Page
    
    {
        Expression<Func<Vehiculos, bool>> filtro = p => true;
        RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
        public static List<Vehiculos> listVehiculos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            }
            
        }

    
        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UI/Reportes/VehiculosReportViewer.aspx");
        }

        protected void FiltroDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*CriterioTextBox.Text = "";

            if (FiltroDropDownList.SelectedIndex == 0)
            {
                CriterioTextBox.ReadOnly = true;

            }
            else
            {
                CriterioTextBox.ReadOnly = false;
            }*/
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            DateTime desde = DateTime.Parse(DesdeTextBox.Text);
            DateTime hasta = DateTime.Parse(HastaTextBox.Text);

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

                case 1://VehiculoId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.VehiculoId == id && (p.FechaRegistro >= desde && p.FechaRegistro <= hasta);
                    break;

                case 2://Marca
                    filtro = p => p.Marca.Contains(CriterioTextBox.Text) && (p.FechaRegistro >= desde && p.FechaRegistro <= hasta);
                    break;
                case 3://Modelo
                    filtro = p => p.Modelo.Contains(CriterioTextBox.Text) && (p.FechaRegistro >= desde && p.FechaRegistro <= hasta);
                    break;
            }

            listVehiculos = repositorio.GetList(filtro);
            VehiculosGridView.DataSource = listVehiculos;
            VehiculosGridView.DataBind();
        }
    }
}