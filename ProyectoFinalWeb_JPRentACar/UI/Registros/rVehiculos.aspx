<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rVehiculos.aspx.cs" Inherits="ProyectoFinalWeb_JPRentACar.UI.Registros.rVehiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card container">
        <h3>Registro de Vehiculos</h3>
        <!--Card body-->
        <div class="card-body">
            <!--Id-->
            <div class="form-row">

                <div class="col-lg-3">
                    <asp:Label Text="Vehiculo Id" runat="server" />
                    <div class="input-group">
                        <asp:TextBox ID="VehiculoIDTextBox" CssClass="form-control" placeholder="0" TextMode="Number" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Buscar" runat="server" ErrorMessage="*" ControlToValidate="VehiculoIDTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                        <div class="input-group-append">
                            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary" runat="server" ValidationGroup="Buscar" OnClick="BuscarLinkButton_Click">
                                <span class="fas fa-search"></span>
                                Buscar
                        </asp:LinkButton>
                        </div>
                    </div>
                </div>

                <div class="form-group col-md-3">
                    <asp:Label Text="Fecha Registro" runat="server" />
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>

            </div>

            <div class="form-row">
                <div class="form-group col-md-5">
                    <asp:Label Text="Tipo Vehiculo" runat="server" />
                    <asp:DropDownList ID="TipoDropDownList" runat="server" Class="form-control input-sm">
                        <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                        <asp:ListItem Text="Sedan"></asp:ListItem>
                        <asp:ListItem Text="Deportivo"></asp:ListItem>
                        <asp:ListItem Text="Familiar"></asp:ListItem>
                        <asp:ListItem Text="Coupe"></asp:ListItem>
                        <asp:ListItem Text="TodoTerreno"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Tipo Vehiculo: Seleccione" ValidationGroup="Guardar" ControlToValidate="TipoDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Placa" runat="server" />
                    <asp:TextBox type="text" AutoCompleteType="Disabled" class="form-control" ID="PlacaTextBox" placeholder="Ingresar Placa" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="Guardar" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese alguna Placa!" ControlToValidate="PlacaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>

            </div>
            <div class="form-row">
                <div class="form-group  col-md-3">
                    <asp:Label Text="Marca" runat="server" />
                    <asp:TextBox type="text" AutoCompleteType="Disabled" class="form-control" ID="MarcaTextBox" placeholder="Ingresar Marca" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="Guardar" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="MarcaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Modelo" runat="server" />

                    <asp:TextBox type="text" AutoCompleteType="Disabled" class="form-control" ID="ModeloTextBox" placeholder="Ingresar Modelo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="Guardar"  ID="NombreRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="ModeloTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Color" AutoCompleteType="Disabled" runat="server" />
                    <asp:DropDownList ID="ColorDropDownList" runat="server" Class="form-control input-sm">
                        <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                        <asp:ListItem Text="Azul"></asp:ListItem>
                        <asp:ListItem Text="Rojo"></asp:ListItem>
                        <asp:ListItem Text="Amarillo"></asp:ListItem>
                        <asp:ListItem Text="Blanco"></asp:ListItem>
                        <asp:ListItem Text="Verde"></asp:ListItem>
                        <asp:ListItem Text="Negro"></asp:ListItem>
                        <asp:ListItem Text="Dorado"></asp:ListItem>
                        <asp:ListItem Text="PlateadO"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ValidationGroup="Guardar"  ID="RequiredFieldValidator6" runat="server" ErrorMessage="Color: Seleccione" ControlToValidate="ColorDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Año" runat="server" />
                    <div class="input-group">
                        <asp:TextBox ID="AñoTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Guardar"  ID="RequiredFieldValidator7" runat="server" ErrorMessage="Ingrese año!" ControlToValidate="AñoTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="IdRegularExpressionValidator" runat="server" ControlToValidate="AñoTextBox" ForeColor="Red" Display="Dynamic" ErrorMessage="Año: Solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                    </div>
                </div>

            </div>

            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label Text="Descripción" AutoCompleteType="Disabled" runat="server" />
                    <asp:TextBox type="text" class="form-control" ID="DescripcionTextBox" placeholder="Ingresar Descripción" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese alguna descripción!" ControlToValidate="DescripcionTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>

                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label ID="Label4" runat="server" Text="Precio"></asp:Label>
                    <asp:TextBox class="form-control" ID="PrecioTextBox" placeholder="0" type="number" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="Guardar"  ID="RequiredFieldValidator8" runat="server" ErrorMessage="Ingrese precio!" ControlToValidate="PrecioTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PrecioTextBox" ForeColor="Red" Display="Dynamic" ErrorMessage="Precio: Solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                    
                </div>
            </div>

        </div>

        <div class="card-footer">
            <!--Butones-->
            <div class="form-group row justify-content-center">
                <!--Nuevo-->
                <div class="col-lg-1 mr-1">
                    <asp:LinkButton ID="NuevoLinkButton" CssClass="btn btn-primary" runat="server" CausesValidation="False" OnClick="NuevoLinkButton_Click">
                        <span class="fas fa-plus"></span>
                        Nuevo
                </asp:LinkButton>
                </div>

                <!--Guardar-->
                <div class="col-lg-1 mr-3">
                    <asp:LinkButton ID="GuardarLinkButton" ValidationGroup="Guardar" CssClass="btn btn-success" runat="server" OnClick="GuardarLinkButton_Click">
                        <span class="fas fa-save"></span>
                        Guardar
                </asp:LinkButton>
                </div>

                <!--Eliminar-->
                <div class="col-lg-1 mr-3">
                    <asp:LinkButton ID="EliminarLinkButton" CssClass="btn btn-danger" runat="server" CausesValidation="false" OnClick="EliminarLinkButton_Click">
                        <span class="fas fa-trash-alt"></span>
                        Eliminar
                </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
