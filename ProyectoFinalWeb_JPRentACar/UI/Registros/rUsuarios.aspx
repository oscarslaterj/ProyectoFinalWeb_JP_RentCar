<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="ProyectoFinalWeb_JPRentACar.UI.Registros.rUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card container">
        <h3>Registro de Usuarios</h3>
        <!--Card body-->
        <div class="card-body">
            <!--Id-->
            <div class="form-row">

                <div class="col-lg-3">
                    <asp:Label Text="Usuario ID" runat="server" />
                    <div class="input-group">
                        <asp:TextBox ID="usuarioidTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="usuarioidTextBox" ValidationGroup="Buscar" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <div class="input-group-append">
                            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary" runat="server" ValidationGroup="Buscar" OnClick="BuscarLinkButton_Click" >
                                <span class="fas fa-search"></span>
                                Buscar
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>

                <div class="form-group col-md-3">
                    <asp:Label Text="Fecha Registro" runat="server" />
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                    <asp:RequiredFieldValidator ID="RFVFFecha" ValidationGroup="Guardar" ControlToValidate="FechaTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>


            </div>

            <div class="form-row">
                <div class="form-group col-md-4">
                    <asp:Label Text="Nombres" runat="server" />
                    <asp:TextBox type="text" class="form-control" ID="NombresTextBox" placeholder="Ingresar Nombres" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NombreRequiredFieldValidator" ValidationGroup="Guardar" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="NombresTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="NombreRegularExpressionValidator" ValidationGroup="Guardar" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="NombresTextBox" ValidationExpression="^[a-z & A-Z]*$"></asp:RegularExpressionValidator>

                </div>

                <div class="form-group col-md-4">
                    <asp:Label Text="Usuario" runat="server" />
                    <asp:TextBox type="text" class="form-control" ID="nomUserTextBox" placeholder="Ingresar Usuario" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserRequiredFieldValidator1" runat="server" ValidationGroup="Guardar" ErrorMessage="Ingrese algun nombre!" ControlToValidate="nomUserTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="UserRegularExpressionValidator1" ValidationGroup="Guardar" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="nomUserTextBox" ValidationExpression="^[a-z & A-Z]*$"></asp:RegularExpressionValidator>

                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-5">
                    <asp:Label Text="Tipo Usuario" runat="server" />
                    <asp:DropDownList ID="TipoDropDownList" runat="server" Class="form-control input-sm">
                        <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                        <asp:ListItem Text="Administrador"></asp:ListItem>
                        <asp:ListItem Text="Empleado"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="Guardar" ControlToValidate="TipoDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-4">
                    <asp:Label Text="Contraseña" runat="server" />
                    <asp:TextBox type="text" class="form-control" ID="contraseñaTextBox" TextMode="Password" placeholder="Ingresar Contraseña" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ContraValidar" runat="server" ValidationGroup="Guardar" ErrorMessage="El campo &quot;Contraseña&quot; esta vacio" ControlToValidate="ContraseñaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Contraseña obligatorio" >*</asp:RequiredFieldValidator>

                </div>



                <div class="form-group col-md-4">
                    <asp:Label Text="Confirmar Contraseña" runat="server" />
                    <asp:TextBox type="text" class="form-control" ID="ConfirmarContraseñaTextBox" TextMode="Password" placeholder="Confirmar Contraseña" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="ConfirmarContraseña" runat="server" ValidationGroup="Guardar" ErrorMessage="Las Contraseñas no son iguales" ControlToValidate="ConfirmarContraseñaTextBox" ControlToCompare="ContraseñaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Las Contraseñas no son iguales" >*</asp:CompareValidator>
                    <asp:RequiredFieldValidator ID="ValidaConfirmarContraseña" runat="server" ValidationGroup="Guardar" ErrorMessage="El campo &quot;Nombres&quot; estas vacio" ControlToValidate="ConfirmarContraseñaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Confirmar Contraseña obligatorio" >*</asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="card-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">
                    <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" class="btn btn-primary" OnClick="BtnNuevo_Click" />
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="Guardar" OnClick="BtnGuardar_Click" />
                    <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" class="btn btn-danger" ValidationGroup="Buscar" OnClick="BtnEliminar_Click" />
                </div>
            </div>
        </div>
    </div>
 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
