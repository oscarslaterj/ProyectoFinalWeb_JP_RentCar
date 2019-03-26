<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="ProyectoFinalWeb_JPRentACar.UI.Registros.rUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3>Registro de Usuarios</h3>
           <!--Card body-->
        <div class="card-body">
            <!--Id-->
            <div class="form-row">
                <asp:Label ID="Label1" CssClass="col-form-label" Text="UserIdText" runat="server">Usuario ID</asp:Label>
                <div class="col-lg-3">
                    <div class="input-group">
                        <asp:TextBox ID="usuarioidTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary" runat="server" CausesValidation="False">
                                <span class="fas fa-search"></span>
                                Buscar
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
                
            </div>
         </div>


        <div class="form-group">
            <label class="col-lg-8 control-label">Fecha de Registro</label>
            <div class="col-lg-8 ">
                <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
            </div>
        </div>


        <div class="form-group">
            <label for="TipoDropDownList" class="col-md-3 control-label input-sm">Tipo Usuario:</label>
            <div class="col-md-8">
                <asp:DropDownList ID="TipoDropDownList" runat="server" Class="form-control input-sm">
                    <asp:ListItem Selected="True">Seleccione Uno</asp:ListItem>
                    <asp:ListItem Text="Administrador"></asp:ListItem>
                    <asp:ListItem Text="Empleado"></asp:ListItem>
                </asp:DropDownList>

            </div>
        </div>

        <div class="form-group">
            <label class="col-lg-8 control-label">Nombres</label>
            <div class="col-lg-8">
                <asp:TextBox type="text" class="form-control" ID="NombresTextBox" placeholder="Ingresar Nombres" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NombreRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="NombresTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="NombreRegularExpressionValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="NombresTextBox" ValidationExpression="^[a-z & A-Z]*$"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="form-group">
            <label class="col-lg-8 control-label" for="nomUser">Usuario</label>
            <div class="col-lg-8">
                <asp:TextBox type="text" class="form-control" ID="nomUserTextBox" placeholder="Ingresar Usuario" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="UserRequiredFieldValidator1" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="nomUserTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="UserRegularExpressionValidator1" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="nomUserTextBox" ValidationExpression="^[a-z & A-Z]*$"></asp:RegularExpressionValidator>
            </div>


            <div class="form-group">
                <label class="col-lg-8 control-label">Contraseña</label>
                <div class="col-lg-8">
                    <asp:TextBox type="text" class="form-control" ID="contraseñaTextBox" placeholder="Ingresar Contraseña" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ContraValidar" runat="server" ErrorMessage="El campo &quot;Contraseña&quot; esta vacio" ControlToValidate="ContraseñaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Contraseña obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                </div>
            </div>



            <div class="form-group">
                <label class="col-lg-8 control-label">Confirmar Contraseña</label>
                <div class="col-lg-8">
                    <asp:TextBox type="text" class="form-control" ID="ConfirmarContraseñaTextBox" placeholder="Confirmar Contraseña" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="ConfirmarContraseña" runat="server" ErrorMessage="Las Contraseñas no son iguales" ControlToValidate="ConfirmarContraseñaTextBox" ControlToCompare="ContraseñaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Las Contraseñas no son iguales" ValidationGroup="Guardar">*</asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="ValidaConfirmarContraseña" runat="server" ErrorMessage="El campo &quot;Nombres&quot; estas vacio" ControlToValidate="ConfirmarContraseñaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Confirmar Contraseña obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="panel-footer">
                <div class="text-center">
                    <div class="form-group" style="display: inline-block">
                        <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" class="btn btn-primary btn-sm" OnClick="BtnNuevo_Click" />
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-success btn-sm" OnClick="BtnGuardar_Click" />
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" class="btn btn-danger btn-sm" OnClick="BtnEliminar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
