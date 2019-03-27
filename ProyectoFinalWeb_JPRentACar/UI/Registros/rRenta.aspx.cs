using BLL;
using Entities;
using ProyectoFinalWeb_JPRentACar.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb_JPRentACar.UI.Registros
{
    public partial class rRenta : System.Web.UI.Page
    {
        private List<RentasDetalle> detalles = new List<RentasDetalle>();
        private Renta renta = new Renta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaRegistroTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FechaDevueltaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FechaRentaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaDropDown();

                ViewState.Add("Detalle", detalles);
                ViewState.Add("Renta", renta);

            }
        }

        private Renta GetRenta()
        {
            return new Renta() {
                RentaId =  Utils.ToInt(RentaIDTextBox.Text),
                FechaDevuelta =Utils.ToDateTime(FechaDevueltaTextBox.Text),
                FechaRegistro = Utils.ToDateTime(FechaRegistroTextBox.Text),
                Detalle = detalles

            };
        }

        protected void RentarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Renta> repositorio = new RepositorioBase<Renta>();
            Renta renta = repositorio.Buscar(Utils.ToInt(RentaIDTextBox.Text));


            if (renta == null)
            {
                if (repositorio.Guardar(GetRenta()))
                {
                    Utils.MostraMensaje(this, "Guardado", "Exito", "success");
                  
                }
                else
                {
                    Utils.MostraMensaje(this, "No Guardado", "Exito", "success");
                }

            }
            else
            {
                if (repositorio.Modificar(GetRenta()))
                {
                    Utils.MostraMensaje(this, "Modificado", "Exito", "success");
                   
                }

                else
                    Utils.MostraMensaje(this, "No Modificado", "Error", "error");
            }
        }

        private void LlenaDropDown()
        {
            RepositorioBase<Vehiculos> repositorioVehiculos = new RepositorioBase<Vehiculos>();
            VehiculoDropDownList.DataSource = repositorioVehiculos.GetList(x => true);
            VehiculoDropDownList.DataValueField = "VehiculoId";
            VehiculoDropDownList.DataTextField = "Tipo";
            VehiculoDropDownList.AppendDataBoundItems = true;
            VehiculoDropDownList.DataBind();


            RepositorioBase<Clientes> repositorioClientes = new RepositorioBase<Clientes>();
            ClienteDropDownList.DataSource = repositorioClientes.GetList(x => true);
            ClienteDropDownList.DataValueField = "ClienteId";
            ClienteDropDownList.DataTextField = "Nombre";
            ClienteDropDownList.AppendDataBoundItems = true;
            ClienteDropDownList.DataBind();
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            Vehiculos vehiculos = repositorio.Buscar(Utilitarios.Utils.ToInt(VehiculoDropDownList.SelectedValue));

            detalles.Add(new RentasDetalle()
            {
                DetalleId = 0,
                RentaId = Utilitarios.Utils.ToInt(RentaIDTextBox.Text),
                ClienteId = Utilitarios.Utils.ToInt(ClienteDropDownList.SelectedValue),
                VehiculoId = Utilitarios.Utils.ToInt(VehiculoDropDownList.SelectedValue),
                Marca = vehiculos.Marca,
                Modelo = vehiculos.Modelo,
                Anio = vehiculos.Anio,
                Precio = vehiculos.PrecioRenta
            });

            ViewState["Detalle"] = detalles;
            DetalleGridView.DataSource = detalles;
            DetalleGridView.DataBind();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

            RepositorioBase<Renta> repositorio = new RepositorioBase<Renta>();


            Renta renta = repositorio.Buscar(Utils.ToInt(RentaIDTextBox.Text));

            if (renta != null)
            {
                if (repositorio.Eliminar(renta.RentaId))
                {
                    Utils.MostraMensaje(this, "Eliminado", "Exito", "success");
                   
                }
                else
                    Utils.MostraMensaje(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.MostraMensaje(this, "No existe", "Error", "error");
        }

        private void LlenaCampoVehiculo()
        {
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            Vehiculos vehiculos = repositorio.Buscar(Utilitarios.Utils.ToInt(VehiculoDropDownList.SelectedValue));

            PlacaTextBox.Text = vehiculos.Placa;
            ModeloTextBox.Text = vehiculos.Modelo;
            MarcaTextBox.Text = vehiculos.Marca;
            DescripcionTextBox.Text = vehiculos.Descripcion;


        }

        protected void VehiculoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenaCampoVehiculo();
        }
    }
}