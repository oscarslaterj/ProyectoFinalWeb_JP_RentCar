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
            }
        }


        private void LlenaClase(Clientes cliente)
        {
            cliente.ClienteId = Utils.ToInt(ClienteIdTextBox.Text);
            cliente.Nombre = NombresTextBox.Text;
            cliente.Direccion = DireccionTextBox.Text;
            cliente.Cedula = CedulaTextBox.Text;
            cliente.Telefono = TelefonoTextBox.Text;
            cliente.Sexo = SexoDropDownList.Text;
            cliente.VehiculosRentados = 0;
        }

        private void Limpiar()
        {
            ClienteIdTextBox.Text = "0";
            FechaNacimientoTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombresTextBox.Text = "0";
            TelefonoTextBox.Text = "0";
            CedulaTextBox.Text = "0";
            DireccionTextBox.Text = "0";
            VehiculosRentadosTextBox.Text = "0";
        }

        public void LlenaCampos(Clientes cliente)
        {
            Limpiar();
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

            var deposito = repositorio.Buscar(Utils.ToInt(ClienteIdTextBox.Text));
            if (deposito != null)
            {
                LlenaCampos(deposito);
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
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            Clientes cliente = new Clientes();

            LlenaClase(cliente);

            if (ClienteIdTextBox.Text == "0")
            {
                paso = repositorio.Guardar(cliente);
                Utils.MostraMensaje(this, "Guardado", "Exito", "success");
                Limpiar();
            }
            else
            {
                RepositorioBase<Clientes> repository = new RepositorioBase<Clientes>();
                int id = Utils.ToInt(ClienteIdTextBox.Text);
                cliente = repository.Buscar(id);

                if (cliente != null)
                {
                    paso = repository.Modificar(cliente);
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
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
            int id = Utils.ToInt(ClienteIdTextBox.Text);

            var cliente = repositorio.Buscar(id);

            if (cliente != null)
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
