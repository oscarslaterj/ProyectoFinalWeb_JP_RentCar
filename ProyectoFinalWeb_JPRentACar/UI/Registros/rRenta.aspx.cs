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
        public static Rentas renta = new Rentas();
        private RepositorioBase<Clientes> repositorioCliente = new RepositorioBase<Clientes>();
        private RepositorioBase<Vehiculos> repositorioVehiculos = new RepositorioBase<Vehiculos>();
        private RentaRepositorio repositorioRenta = new RentaRepositorio();
        public static List<RentasDetalles> detalles = new List<RentasDetalles>();
        private RepositorioBase<RentasDetalles> repositorioDetalle = new RepositorioBase<RentasDetalles>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
               
                FechaRegistroTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FechaDevueltaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FechaRentaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaDropDown();
                ViewState.Add("Detale", detalles);
                ViewState.Add("Renta", renta);

            }
        }

        protected void BindGrid()
        {
            DetalleGridView.DataSource = ((Rentas)ViewState["Renta"]).Detalle;
            DetalleGridView.DataBind();

        }

        private Rentas GetRenta()
        {

            //renta = (Rentas)ViewState["Renta"];
            renta.RentaId = Utils.ToInt(RentaIDTextBox.Text);
            renta.FechaDevuelta = Utils.ToDateTime(FechaDevueltaTextBox.Text);
            renta.FechaRegistro = Utils.ToDateTime(FechaRegistroTextBox.Text);
            renta.ClienteId = Utils.ToInt(ClienteDropDownList.SelectedValue);
            renta.Detalle = detalles;
            renta.Monto = Utils.ToDecimal(MontoTextBox.Text);
            return renta;
         ;
        }

        protected void RentarLinkButton_Click(object sender, EventArgs e)
        {
            //RepositorioBase<Rentas> repositorio = new RepositorioBase<Rentas>();
            RentaRepositorio repositorio = new RentaRepositorio();
            Rentas renta = repositorio.Buscar(Utils.ToInt(RentaIDTextBox.Text));

            if (IsValid)
            {


                if (renta == null)
                {
                    if (repositorio.Guardar(GetRenta()))
                    {
                        Response.Redirect("/UI/Reportes/ReciboRentaReportViewer.aspx");
                        //Response.Write("<script> window.open('" + "/UI/Reportes/ReciboRentaReportViewer.aspx" + "','_blank'); </script>");
                        //Poner();
                        Limpiar();
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
                        Poner();
                        Limpiar();
                        Utils.MostraMensaje(this, "Modificado", "Exito", "success");

                    }

                    else
                        Utils.MostraMensaje(this, "No Modificado", "Error", "error");
                }
            }
        }

        private void Poner()
        {
            int cantidad = DetalleGridView.Rows.Count;
            int id = Utils.ToInt(ClienteDropDownList.SelectedValue);
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes cliente = new Clientes();
            cliente = repositorio.Buscar(id);

            cliente.VehiculosRentados += cantidad;
            repositorio.Modificar(cliente);
        }

        private void Quitar()
        {
            int cantidad = DetalleGridView.Rows.Count;
            int id = Utils.ToInt(ClienteDropDownList.SelectedValue);
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes cliente = new Clientes();
            cliente = repositorio.Buscar(id);

            cliente.VehiculosRentados -= cantidad;
            repositorio.Modificar(cliente);
        }

        private void LlenaDropDown()
        {
            //RepositorioBase<Vehiculos> repositorioVehiculos = new RepositorioBase<Vehiculos>();
            VehiculoDropDownList.DataSource = repositorioVehiculos.GetList(x => true);
            VehiculoDropDownList.DataValueField = "VehiculoId";
            VehiculoDropDownList.DataTextField = "Marca";
            VehiculoDropDownList.AppendDataBoundItems = true;
            VehiculoDropDownList.DataBind();


            // RepositorioBase<Clientes> repositorioClientes = new RepositorioBase<Clientes>();
            ClienteDropDownList.DataSource = repositorioCliente.GetList(x => true);
            ClienteDropDownList.DataValueField = "ClienteId";
            ClienteDropDownList.DataTextField = "Nombre";
            ClienteDropDownList.AppendDataBoundItems = true;
            ClienteDropDownList.DataBind();
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {

            Vehiculos vehiculos = repositorioVehiculos.Buscar(Utils.ToInt(VehiculoDropDownList.SelectedValue));
            decimal monto = 0;

            var rentaAnt = repositorioRenta.Buscar(Utils.ToInt(RentaIDTextBox.Text));
            if (IsValid)
            {
                detalles.Add(new RentasDetalles(Utils.ToInt(RentaIDTextBox.Text), vehiculos.VehiculoId, vehiculos.Anio, vehiculos.Marca, vehiculos.Modelo, vehiculos.PrecioRenta));

                ViewState["Detalle"] = detalles;
                DetalleGridView.DataSource = detalles;
                DetalleGridView.DataBind();
                detalles.ForEach(x => monto += x.Precio);
                MontoTextBox.Text = monto.ToString();
               

                /*if (rentaAnt == null)
                {
                    Utils.MostraMensaje(this, "Agregado", "Exito!!", "info");
                    //renta = (Rentas)ViewState["Renta"];
                    renta.AgregarDetalle(Utils.ToInt(RentaIDTextBox.Text), vehiculos.VehiculoId, vehiculos.Anio, vehiculos.Marca, vehiculos.Modelo, vehiculos.PrecioRenta);
                    ViewState["Renta"] = renta;
                }
                else
                {
                    Utils.MostraMensaje(this, "Agregado", "Exito!!", "info");
                    rentaAnt.AgregarDetalle(Utils.ToInt(RentaIDTextBox.Text), vehiculos.VehiculoId,  vehiculos.Anio, vehiculos.Marca, vehiculos.Modelo, vehiculos.PrecioRenta);
                    ViewState["Renta"] = rentaAnt;
                }*/

                //this.BindGrid();
            }

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

            //RepositorioBase<Rentas> repositorio = new RepositorioBase<Rentas>();

            List<RentasDetalles> lista = (List<RentasDetalles>)ViewState["Detalle"];
            Rentas renta = repositorioRenta.Buscar(Utils.ToInt(RentaIDTextBox.Text));
            if (IsValid)
            {


                if (renta != null)
                {
                    if (repositorioRenta.Eliminar(renta.RentaId))
                    {
                        ViewState["Detalle"] = lista;
                        DetalleGridView.DataSource = ViewState["Detalle"];
                        DetalleGridView.DataBind();
                        Quitar();
                        Limpiar();
                        Utils.MostraMensaje(this, "Eliminado", "Exito", "success");

                    }
                    else
                        Utils.MostraMensaje(this, "No se pudo eliminar", "Error", "error");
                }
                else
                    Utils.MostraMensaje(this, "No existe", "Error", "error");
            }

        }

        private void LlenaCampoVehiculo()
        {
            //RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            Vehiculos vehiculos = repositorioVehiculos.Buscar(Utilitarios.Utils.ToInt(VehiculoDropDownList.SelectedValue));

            PlacaTextBox.Text = vehiculos.Placa;
            ModeloTextBox.Text = vehiculos.Modelo;
            MarcaTextBox.Text = vehiculos.Marca;
            DescripcionTextBox.Text = vehiculos.Descripcion;


        }

        protected void VehiculoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (VehiculoDropDownList.SelectedIndex != 0)
                LlenaCampoVehiculo();
            else
            {
                PlacaTextBox.Text = "";
                ModeloTextBox.Text = "";
                MarcaTextBox.Text = "";
                DescripcionTextBox.Text = "";
            }
        }

        private void Limpiar()
        {
            //renta = new Rentas();
            //detalles = new List<RentasDetalles>();
            //repositorioCliente = new RepositorioBase<Clientes>();
            //repositorioDetalle = new RepositorioBase<RentasDetalles>();
            //repositorioRenta = new RentaRepositorio();
            //repositorioVehiculos = new RepositorioBase<Vehiculos>();
            RentaIDTextBox.Text = "";
            FechaDevueltaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            FechaRegistroTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            FechaRentaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ClienteDropDownList.SelectedIndex = 0;
            VehiculoDropDownList.SelectedIndex = 0;
            PlacaTextBox.Text = "";
            ModeloTextBox.Text = "";
            MarcaTextBox.Text = "";
            DescripcionTextBox.Text = "";
            DetalleGridView.DataSource = null;
            DetalleGridView.DataBind();
            MontoTextBox.Text = "";
            ViewState["Renta"] = null;
        }

        private void LlenarCampos(Rentas renta)
        {
            RentaIDTextBox.Text = renta.RentaId.ToString();
            FechaDevueltaTextBox.Text = renta.FechaDevuelta.ToString("yyyy-MM-dd");
            FechaRentaTextBox.Text = renta.FechaRegistro.ToString("yyyy-MM-dd");
            ClienteDropDownList.Text = renta.ClienteId.ToString();
            MontoTextBox.Text = renta.Monto.ToString();
            foreach (var item in renta.Detalle)
            {

                VehiculoDropDownList.SelectedValue = item.VehiculoId.ToString();

            }

            DetalleGridView.DataSource = renta.Detalle;
            DetalleGridView.DataBind();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            renta = repositorioRenta.Buscar(Utils.ToInt(RentaIDTextBox.Text));
            if (IsValid)
            {
                if (renta != null)
                {
                    Utils.MostraMensaje(this, "Hay Resultado", "Exito!!", "info");
                    LlenarCampos(renta);

                }
                else
                {
                    Limpiar();
                    Utils.MostraMensaje(this, "No Hay Resultado", "Fallo!!", "warning");
                }

            }
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void DetalleGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DetalleGridView.EditIndex = e.NewEditIndex;
            this.BindGrid();

        }

        protected void DetalleGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DetalleGridView.EditIndex = -1;
            this.BindGrid();
        }

        protected void DetalleGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(DetalleGridView.DataKeys[e.RowIndex].Values[0]);

            if (id == 0)
            {
                return;
                //detalles.RemoveRange(id, id);
                //this.BindGrid();
                //DetalleGridView.DataSource = detalles;               
                //DetalleGridView.DataBind();
            }
            else
            {
                RentasDetalles d = repositorioDetalle.Buscar(id);
                repositorioDetalle.Eliminar(d.DetalleId);
            }

            DetalleGridView.EditIndex = -1;
            ViewState["Renta"] = detalles;
            DetalleGridView.DataSource = detalles;
            DetalleGridView.DataBind();
        }

        protected void DetalleGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            /*GridViewRow row = DetalleGridView.Rows[e.RowIndex];
            int id_Detalle = Convert.ToInt32(DetalleGridView.DataKeys[e.RowIndex].Values[0]);
            string nombre = (row.FindControl("NombreTextBox") as TextBox).Text;

            Grupos_Usuarios grupos = repositorio.Buscar(c => c.Id_Grupo_Usuario == id_Grupo);
            grupos.Nombre = nombre;

            repositorio.Modificar(grupos);
            GrupoUsuarioGridView.EditIndex = -1;
            BingGrid();*/
        }

        protected void CVDetalle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = DetalleGridView.DataSource == null ? false : true;
        }
    }
}