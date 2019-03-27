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
    public partial class rCLientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FechaNacimientoTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }


        private Clientes LlenaClase()
        {
            Clientes cliente = new Clientes();

            cliente.ClienteId = Utils.ToInt(ClienteIdTextBox.Text);
            cliente.FechaRegistro = Convert.ToDateTime(FechaTextBox.Text);
            cliente.FechaNacimiento = Convert.ToDateTime(FechaNacimientoTextBox.Text);
            cliente.Nombre = NombresTextBox.Text;
            cliente.Direccion = DireccionTextBox.Text;
            cliente.Cedula = CedulaTextBox.Text;
            cliente.Telefono = TelefonoTextBox.Text;
            cliente.Sexo = SexoDropDownList.Text;
            cliente.VehiculosRentados = 0;
            return cliente;
        }

        private void Limpiar()
        {
            ClienteIdTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            FechaNacimientoTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombresTextBox.Text = "";
            TelefonoTextBox.Text = "";
            CedulaTextBox.Text = "";
            DireccionTextBox.Text = "";
            VehiculosRentadosTextBox.Text = "";
        }

        public void LlenaCampos(Clientes cliente)
        {
            Limpiar();
            FechaTextBox.Text = cliente.FechaRegistro.ToString("yyy-MM-dd");
            FechaNacimientoTextBox.Text = cliente.FechaNacimiento.ToString("yyyy-MM-dd");
            NombresTextBox.Text = cliente.Nombre;
            TelefonoTextBox.Text = cliente.Telefono;
            CedulaTextBox.Text = cliente.Cedula;
            DireccionTextBox.Text = cliente.Direccion;
            VehiculosRentadosTextBox.Text = cliente.VehiculosRentados.ToString();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();

            var cliente = repositorio.Buscar(Utils.ToInt(ClienteIdTextBox.Text));
            if (cliente != null)
            {
                LlenaCampos(cliente);
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
           
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes cliente = repositorio.Buscar(Utils.ToInt(ClienteIdTextBox.Text));

            
            if (cliente == null)
            {
                if (repositorio.Guardar(LlenaClase()))
                {
                    Utils.MostraMensaje(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    Utils.MostraMensaje(this, "No Guardado", "Exito", "success");
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
                    Utils.MostraMensaje(this, "No Modificado", "Error", "error");
            }
        }

        protected void EliminarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            

            Clientes cliente = repositorio.Buscar(Utils.ToInt(ClienteIdTextBox.Text));

            if (cliente != null)
            {
                if (repositorio.Eliminar(cliente.ClienteId))
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
