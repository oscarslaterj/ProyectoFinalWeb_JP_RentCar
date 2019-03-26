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
    public partial class rVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void LlenaCombo()
        {
            
        }

        private void LlenaClase(Vehiculos vehiculos)
        {
            vehiculos.VehiculoId = Utils.ToInt(VehiculoIDTextBox.Text);
            vehiculos.Modelo = ModeloTextBox.Text;
            vehiculos.Marca = MarcaTextBox.Text;
            vehiculos.Placa = PlacaTextBox.Text;
            vehiculos.Tipo= TipoDropDownList.Text;
            vehiculos.Color = ColorDropDownList.Text;
            vehiculos.PrecioRenta = Utils.ToInt(PrecioTextBox.Text);
            vehiculos.Anio = Utils.ToInt(AñoTextBox.Text);
        }

        private void Limpiar()
        {
            VehiculoIDTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            MarcaTextBox.Text = "0";
            ModeloTextBox.Text = "0";
            PlacaTextBox.Text = "0";
            TipoDropDownList.Text = "0";
            ColorDropDownList.Text = "0";
            AñoTextBox.Text = "0";
            PrecioTextBox.Text = "0";
        }

        public void LlenaCampos(Vehiculos vehiculos)
        {
            Limpiar();
            FechaTextBox.Text = vehiculos.FechaRegistro.ToString("yyyy-MM-dd");
            MarcaTextBox.Text = vehiculos.Marca;
            ModeloTextBox.Text = vehiculos.Modelo;
            PlacaTextBox.Text = vehiculos.Placa;
            ColorDropDownList.Text = vehiculos.Color;
            TipoDropDownList.Text = vehiculos.Tipo;
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();

            var producto = repositorio.Buscar(Utils.ToInt(VehiculoIDTextBox.Text));
            if (producto != null)
            {
                LlenaCampos(producto);
                Utils.MostraMensaje(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Limpiar();
                Utils.MostraMensaje(this, "No Hay Resultado", "Error", "error");
            }
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            Vehiculos vehiculo= new Vehiculos();

            LlenaClase(vehiculo);

            if (VehiculoIDTextBox.Text == "0")
            {
                paso = repositorio.Guardar(vehiculo);
                Utils.MostraMensaje(this, "Guardado", "Exito", "success");
                Limpiar();
            }
            else
            {
                RepositorioBase<Vehiculos> repository = new RepositorioBase<Vehiculos>();
                int id = Utils.ToInt(VehiculoIDTextBox.Text);
                vehiculo = repository.Buscar(id);

                if (vehiculo != null)
                {
                    paso = repository.Modificar(vehiculo);
                    Utils.MostraMensaje(this, "Modificado", "Exito", "success");
                }
                else
                    Utils.MostraMensaje(this, "Id no existe", "Error", "error");
            }

            if (paso)
            {
                Limpiar();
            }
            else
                Utils.MostraMensaje(this, "No se pudo guardar", "Error", "error");
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            int id = Utils.ToInt(VehiculoIDTextBox.Text);

            var producto = repositorio.Buscar(id);

            if (producto != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.MostraMensaje(this, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.MostraMensaje(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.MostraMensaje(this, "No existe", "Error", "error");
        }
    }
}