<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCLientes.aspx.cs" Inherits="ProyectoFinalWeb_JPRentACar.UI.Registros.rCLientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card">
        <h3>Registro de Clientes</h3>
        <!--Card body-->
        <div class="card-body">
            <!--Id-->
            <div class="form-row">
                <asp:Label ID="Label1" CssClass="col-form-label" Text="Cliente ID" runat="server">Cliente ID</asp:Label>
                <div class="col-lg-3">
                    <div class="input-group">
                        <asp:TextBox ID="ClienteIdTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
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
            <label class="col-lg-8 control-label">Nombres</label>
            <div class="col-lg-8">
                <asp:TextBox type="text" class="form-control" ID="NombresTextBox" placeholder="Ingresar Nombres" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NombreRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="NombresTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="NombreRegularExpressionValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="NombresTextBox" ValidationExpression="^[a-z & A-Z]*$"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <label for="TipoDropDownList" class="col-md-3 control-label input-sm">Sexo</label>
                <div class="col-md-8">
                    <asp:DropDownList ID="TipoDropDownList" runat="server" Class="form-control input-sm">
                        <asp:ListItem Selected="True">Seleccione Uno</asp:ListItem>
                        <asp:ListItem Text="Masculino"></asp:ListItem>
                        <asp:ListItem Text="Femenino"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-8 control-label">Cedula</label>
            <div class="col-lg-8">
                <asp:TextBox type="text" class="form-control" ID="CedulaTextBox" placeholder="Ingresar Cedula" runat="server"></asp:TextBox>
            </div>

        </div>

        <div class="form-group">
            <label class="col-lg-8 control-label">Fecha de Nacimiento</label>
            <div class="col-lg-8">
                <asp:TextBox ID="FechaNacimientoTextBox" class="form-control input-group" TextMode="Date" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-8 control-label">Teléfono</label>
            <div class="col-lg-8">
                <asp:TextBox type="text" class="form-control" ID="TelefonoTextBox" placeholder="Ingresar Telefono" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="ValidaTelefono" runat="server" ErrorMessage='Campo "Telefono" solo acepta numeros' ControlToValidate="TelefonoTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Solo acepta numeros" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="ValidaVacioTelefono" runat="server" ErrorMessage="El campo &quot;Telefono&quot; esta vacio" ControlToValidate="TelefonoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Telefono es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-8 control-label">Fecha de Registro</label>
            <div class="col-lg-8 ">
                <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
            </div>
        </div>
         <div class="form-group row justify-content-center">
            <asp:Label ID="Label2" CssClass="col-form-label" Text="Cliente ID" runat="server">Vehiculos Rentados</asp:Label>
            <div class="col-lg-3">
                <div class="input-group">
                    <asp:TextBox ID="TextBox1" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>



    <div class="card-footer">
        <!--Butones-->
        <div class="form-group row justify-content-center">
            <!--Nuevo-->
            <div class="col-lg-1 mr-1">
                <asp:LinkButton ID="NuevoLinkButton" CssClass="btn btn-primary" runat="server"  CausesValidation="False">
                        <span class="fas fa-plus"></span>
                        Nuevo
                </asp:LinkButton>
            </div>

            <!--Guardar-->
            <div class="col-lg-1 mr-3">
                <asp:LinkButton ID="GuardarLinkButton" CssClass="btn btn-success"  runat="server">
                        <span class="fas fa-save"></span>
                        Guardar
                </asp:LinkButton>
            </div>

            <!--Eliminar-->
            <div class="col-lg-1 mr-3">
                <asp:LinkButton ID="EliminarLinkButton" CssClass="btn btn-danger" runat="server" CausesValidation="False">
                        <span class="fas fa-trash-alt"></span>
                        Eliminar
                </asp:LinkButton>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
