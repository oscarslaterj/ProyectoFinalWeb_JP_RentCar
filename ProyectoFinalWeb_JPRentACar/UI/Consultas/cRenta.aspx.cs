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
    public partial class cRenta : System.Web.UI.Page
    {
        Expression<Func<Rentas, bool>> filtro = p => true;
        RepositorioBase<Rentas> repositorio = new RepositorioBase<Rentas>();
        public static List<Rentas> listVehiculos { get; set; }
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
            Response.Redirect("/UI/Reportes/ReciboRentaReportViewer.aspx");
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

                case 1://RentaId
                    id = Utils.ToInt(CriterioTextBox.Text);
                    filtro = p => p.RentaId == id && (p.FechaRegistro >= desde && p.FechaRegistro <= hasta);
                    break;

                case 2://ClienteId
                    filtro = p => p.ClienteId == id && (p.FechaRegistro >= desde && p.FechaRegistro <= hasta);
                    break;       
            }

            listVehiculos = repositorio.GetList(filtro);
            RentaGridView.DataSource = listVehiculos;
            RentaGridView.DataBind();
        }
    }

    }
