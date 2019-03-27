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
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                int id = Utilitarios.Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
                    var usuario = repositorio.Buscar(id);

                    if (usuario == null)
                    {
                        Utils.MostraMensaje(this, "No Hay Resultado", "Error", "error");
                    }
                    else
                    {
                        LlenaCampos(usuario);
                    }
                }

            }
        }

        private Usuarios LlenaClase()
        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = Utils.ToInt(usuarioidTextBox.Text);
            usuario.NombreUser = nomUserTextBox.Text;
            usuario.Nombre = NombresTextBox.Text;
            usuario.Clave = contraseñaTextBox.Text;
            usuario.Tipo = TipoDropDownList.Text;
            return usuario;
        }

        private void LlenaCampos(Usuarios usuario)
        {
            usuarioidTextBox.Text = usuario.UsuarioId.ToString();
            nomUserTextBox.Text = usuario.NombreUser;
            NombresTextBox.Text = usuario.Nombre;
            contraseñaTextBox.Text = usuario.Clave;
            TipoDropDownList.Text = usuario.Tipo;

        }

        private void Limpiar()
        {
            usuarioidTextBox.Text = "";
            nomUserTextBox.Text = "";
            NombresTextBox.Text = "";
            TipoDropDownList.SelectedIndex = 0;
            contraseñaTextBox.Text = "";
            ConfirmarContraseñaTextBox.Text = "";
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = repositorio.Buscar(Utils.ToInt(usuarioidTextBox.Text));
           

         

            if (usuarios == null)
            {
                if (repositorio.Guardar(LlenaClase()))
                {
                    Utils.MostraMensaje(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    Utils.MostraMensaje(this, "Guardado", "Exito", "success");
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

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();

            Usuarios usuaario = repositorio.Buscar(Utils.ToInt(usuarioidTextBox.Text));

            if (usuaario != null)
            {
                if (repositorio.Eliminar(usuaario.UsuarioId))
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

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositoriobase = new RepositorioBase<Usuarios>();
            Usuarios users = repositoriobase.Buscar(Utils.ToInt(usuarioidTextBox.Text));
            if (users != null)
            {
                FechaTextBox.Text = users.Fecha.ToString("yyyy-MM-dd");
                NombresTextBox.Text = users.Nombre;
                nomUserTextBox.Text = users.NombreUser;
                Utils.MostraMensaje(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Utils.MostraMensaje(this, "No Hay Resultado", "Error", "error");
            }
        }
    }
}