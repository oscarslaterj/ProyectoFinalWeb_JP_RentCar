<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rVehiculos.aspx.cs" Inherits="ProyectoFinalWeb_JPRentACar.UI.Registros.rVehiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Registro de Vehiculos</h3>
    <!--Card body-->
    <div class="card-body">
        <!--Id-->
        <div class="form-row">
            <asp:Label ID="Label1" CssClass="col-form-label" Text="UserIdText" runat="server">Vehiculo ID</asp:Label>
            <div class="col-lg-3">
                <div class="input-group">
                    <asp:TextBox ID="VehiculoIDTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
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
        <label for="TipoDropDownList" class="col-md-3 control-label input-sm">Tipo</label>
        <div class="col-md-8">
            <asp:DropDownList ID="TipoDropDownList" runat="server" Class="form-control input-sm">
                <asp:ListItem Selected="True">Seleccione Uno</asp:ListItem>
                <asp:ListItem Text="Sedan"></asp:ListItem>
                <asp:ListItem Text="Deportivo"></asp:ListItem>
                <asp:ListItem Text="Familiar"></asp:ListItem>
                <asp:ListItem Text="Coupe"></asp:ListItem>
                <asp:ListItem Text="TodoTerreno"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    
    <div class="form-group">
        <label class="col-lg-8 control-label">Placa</label>
        <div class="col-lg-8">
            <asp:TextBox type="text" class="form-control" ID="PlacaTextBox" placeholder="Ingresar Placa" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese alguna Placa!" ControlToValidate="PlacaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-8 control-label">Marca</label>
        <div class="col-lg-8">
            <asp:TextBox type="text" class="form-control" ID="MarcaTextBox" placeholder="Ingresar Marca" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="MarcaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-8 control-label">Modelo</label>
        <div class="col-lg-8">
            <asp:TextBox type="text" class="form-control" ID="ModeloTextBox" placeholder="Ingresar Modelo" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="NombreRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="ModeloTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="form-group">
        <label for="TipoDropDownList" class="col-md-3 control-label input-sm">Color</label>
        <div class="col-md-8">
            <asp:DropDownList ID="ColorDropDownList" runat="server" Class="form-control input-sm">
                <asp:ListItem Selected="True">Seleccione Uno</asp:ListItem>
                <asp:ListItem Text="Azul"></asp:ListItem>
                <asp:ListItem Text="Rojo"></asp:ListItem>
                <asp:ListItem Text="Amarillo"></asp:ListItem>
                <asp:ListItem Text="Blanco"></asp:ListItem>
                <asp:ListItem Text="Verde"></asp:ListItem>
                <asp:ListItem Text="Negro"></asp:ListItem>
                <asp:ListItem Text="Dorado"></asp:ListItem>
                <asp:ListItem Text="PlateadO"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="form-group row">
        <asp:Label ID="Label2" CssClass="col-lg-1" Text="AñoLabel" runat="server">Año</asp:Label>
        <div class="col-lg-2">
            <div class="input-group">
                <asp:TextBox ID="AñoTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-8 control-label">Descripción</label>
        <div class="col-lg-8">
            <asp:TextBox type="text" class="form-control" ID="DescripcionTextBox" placeholder="Ingresar Descripción" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese alguna descripción!" ControlToValidate="DescripcionTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Precio"></asp:Label>
                <asp:TextBox class="form-control" ID="PrecioTextBox" placeholder="0" type="number" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-8 control-label">Fecha de Registro</label>
        <div class="col-lg-8 ">
            <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
    </div>
    <div class="card-footer">
        <!--Butones-->
        <div class="form-group row justify-content-center">
            <!--Nuevo-->
            <div class="col-lg-1 mr-1">
                <asp:LinkButton ID="NuevoLinkButton" CssClass="btn btn-primary" runat="server" CausesValidation="False">
                        <span class="fas fa-plus"></span>
                        Nuevo
                </asp:LinkButton>
            </div>

            <!--Guardar-->
            <div class="col-lg-1 mr-3">
                <asp:LinkButton ID="GuardarLinkButton" CssClass="btn btn-success" runat="server">
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
