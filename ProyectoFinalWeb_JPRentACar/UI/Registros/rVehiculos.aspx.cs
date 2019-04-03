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

        private Vehiculos LlenaClase()
        {
            Vehiculos vehiculos = new Vehiculos();
            vehiculos.VehiculoId = Utils.ToInt(VehiculoIDTextBox.Text);
            vehiculos.Descripcion = DescripcionTextBox.Text;
            vehiculos.Modelo = ModeloTextBox.Text;
            vehiculos.Marca = MarcaTextBox.Text;
            vehiculos.Placa = PlacaTextBox.Text;
            vehiculos.Tipo = TipoDropDownList.Text;
            vehiculos.Color = ColorDropDownList.Text;
            vehiculos.PrecioRenta = Utils.ToInt(PrecioTextBox.Text);
            vehiculos.Anio = Utils.ToInt(AñoTextBox.Text);
            return vehiculos;
        }

        private void Limpiar()
        {
            VehiculoIDTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            MarcaTextBox.Text = "";
            ModeloTextBox.Text = "";
            PlacaTextBox.Text = "";
            TipoDropDownList.SelectedIndex = 0;
            ColorDropDownList.SelectedIndex = 0;
            AñoTextBox.Text = "";
            PrecioTextBox.Text = "";
            DescripcionTextBox.Text = "";

        }

        public void LlenaCampos(Vehiculos vehiculos)
        {
            Limpiar();
            FechaTextBox.Text = vehiculos.FechaRegistro.ToString("yyyy-MM-dd");
            DescripcionTextBox.Text = vehiculos.Descripcion;
            AñoTextBox.Text = vehiculos.Anio.ToString();
            MarcaTextBox.Text = vehiculos.Marca;
            ModeloTextBox.Text = vehiculos.Modelo;
            PlacaTextBox.Text = vehiculos.Placa;
            ColorDropDownList.Text = vehiculos.Color;
            TipoDropDownList.Text = vehiculos.Tipo;
            PrecioTextBox.Text = vehiculos.PrecioRenta.ToString();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();

            var producto = repositorio.Buscar(Utils.ToInt(VehiculoIDTextBox.Text));
            if (IsValid)
            {


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
        }

        protected void NuevoLinkButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            Vehiculos vehiculo = repositorio.Buscar(Utils.ToInt(VehiculoIDTextBox.Text));
            vehiculo = LlenaClase();
            var vehiculoExistentes = repositorio.GetList(x => true);

            if (IsValid)
            {

                if (vehiculo.VehiculoId == 0)
                {
                    if(!vehiculoExistentes.Exists(v=> v.Placa == vehiculo.Placa))
                    {
                        if (repositorio.Guardar(vehiculo))
                        {
                            Utils.MostraMensaje(this, "Guardado", "Exito", "success");
                            Limpiar();
                        }
                        else
                        {
                            Utils.MostraMensaje(this, "No Guardado", "Fallo", "error");
                        }

                    }
                    else
                    {
                        Utils.MostraMensaje(this, "# Placa Existente", "Fallo", "error");
                    }                   

                }
                else
                {
                    if (repositorio.Modificar(LlenaClase()))
                    {
                        Utils.MostraMensaje(this, "Modificado", "Exito", "success");
                        Limpiar();
                    }

                    else
                        Utils.MostraMensaje(this, "Id no existe", "Error", "error");
                }
            }
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Vehiculos> repositorio = new RepositorioBase<Vehiculos>();
            Vehiculos vehiculo = repositorio.Buscar(Utils.ToInt(VehiculoIDTextBox.Text));
            if (IsValid)
            {

                if (vehiculo != null)
                {
                    if (repositorio.Eliminar(vehiculo.VehiculoId))
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
}