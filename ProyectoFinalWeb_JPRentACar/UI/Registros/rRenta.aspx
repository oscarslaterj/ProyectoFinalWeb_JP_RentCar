<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rRenta.aspx.cs" Inherits="ProyectoFinalWeb_JPRentACar.UI.Registros.rRenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Registro de Alquiler</h3>
    <!--Card body-->
    <div class="card-body">
        <!--Id-->
        <div class="form-row">
            <asp:Label ID="Label1" CssClass="col-form-label" Text="UserIdText" runat="server">Renta ID</asp:Label>
            <div class="col-lg-3">
                <div class="input-group">
                    <asp:TextBox ID="RentaIDTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary" runat="server" CausesValidation="False">
                                <span class="fas fa-search"></span>
                                Buscar
                        </asp:LinkButton>
                          <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" CausesValidation="False">
                                <span class="fas fa-search"></span>
                               Rentar
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <label for="VehiculoDropDownList" class="col-md-3 control-label input-sm">Vehiculo</label>
            <div class="col-md-8">
                <asp:DropDownList ID="VehiculoDropDownList" runat="server" ReadOnly="true" Class="form-control input-sm">
                    <asp:ListItem Selected="True">Seleccione Uno</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="TipoDropDownList" class="col-md-3 control-label input-sm">Cliente</label>
                <div class="col-md-8">
                    <asp:DropDownList ID="ClienteDropDownList" runat="server" ReadOnly="true" Class="form-control input-sm">
                        <asp:ListItem Selected="True">Seleccione Uno</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-8 control-label">Fecha de Renta</label>
        <div class="col-lg-8 ">
            <asp:TextBox ID="FechaRentaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-8 control-label">Fecha de Devuelta</label>
        <div class="col-lg-8 ">
            <asp:TextBox ID="FechaDevueltaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
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
        <label class="col-lg-8 control-label">Descripción</label>
        <div class="col-lg-8">
            <asp:TextBox type="text" class="form-control" ID="DescripcionTextBox" placeholder="Ingresar Descripción" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese alguna descripción!" ControlToValidate="DescripcionTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-8 control-label">Fecha de Registro</label>
        <div class="col-lg-8 ">
            <asp:TextBox ID="FechaRegistroTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
    </div>

    <!--Grid-->
    <div class="row justify-content-center mt-3">
        <div class="col-lg-11">
            <asp:GridView ID="DetalleGridView"  runat="server" AllowPaging="true" PageSize="7" CssClass="table table-striped table-hover table-responsive-lg" AutoGenerateColumns="False" >

            </asp:GridView>
        </div>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Agregar" />
    <asp:Button ID="Button2" runat="server" Text="Eliminar" />

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
