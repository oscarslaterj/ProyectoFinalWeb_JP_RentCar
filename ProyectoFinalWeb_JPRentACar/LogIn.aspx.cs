using BLL;
using Entities;
using ProyectoFinalWeb_JPRentACar.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb_JPRentACar
{
    public partial class LogIn : System.Web.UI.Page
    {
        private Usuarios usuario = new Usuarios();
        private RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
        List<Usuarios> userList = new List<Usuarios>();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UsuarioTextBox.Focus();

            }
        }

        private void Limpiar()
        {
            UsuarioTextBox.Text = "";
            PassTextBox.Text = "";
            UsuarioTextBox.Focus();
        }

        protected void LoginLinkButton_Click(object sender, EventArgs e)
        {
            userList = repositorio.GetList(u => u.NombreUser.Equals(UsuarioTextBox.Text) && u.Clave.Equals(PassTextBox.Text));
            usuario = (userList != null && userList.Count > 0) ? userList[0] : null;

            if (usuario != null)
            {
                
                FormsAuthentication.RedirectFromLoginPage(usuario.NombreUser, true);
            }
            else
            {
                Utils.MostraMensaje(this, "Esta Cuenta No Existe", "Error", "error");
                Limpiar();
            }

        }
    }
}