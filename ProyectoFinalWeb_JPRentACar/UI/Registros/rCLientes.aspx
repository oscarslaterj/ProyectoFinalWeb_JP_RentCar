<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCLientes.aspx.cs" Inherits="ProyectoFinalWeb_JPRentACar.UI.Registros.rCLientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card container">
        <h3>Registro de Clientes</h3>
        <!--Card body-->
        <div class="card-body">
            <!--Id-->
            <div class="form-row">

                <div class="col-lg-3">
                    <asp:Label Text="ClienteId" runat="server" />
                    <div class="input-group">
                        <asp:TextBox ID="ClienteIdTextBox" CssClass="form-control" TextMode="Number" placeholder="0" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Buscar" runat="server" ErrorMessage="*" ControlToValidate="ClienteIdTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

                        <div class="input-group-append">
                            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary" runat="server" ValidationGroup="Buscar" OnClick="BuscarLinkButton_Click">
                                <span class="fas fa-search"></span>
                                Buscar
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>

                <div class="form-group col-md-4">
                    <asp:Label Text="Fecha Registro" runat="server" />
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Guardar" runat="server" ErrorMessage="*" ControlToValidate="FechaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ErrorMessage="Fecha: Digite fecha valida" ValidationGroup="Guardar" Type="Date" MaximumValue="9999/12/28" MinimumValue="1000/12/28" Display="Dynamic" ForeColor="Red" ControlToValidate="FechaTextBox" runat="server" />

                </div>

            </div>


            <div class="form-row">
                <div class="form-group col-md-7">
                    <asp:Label Text="Nombres" runat="server" />
                    <asp:TextBox type="text" AutoCompleteType="Disabled" class="form-control" ID="NombresTextBox" placeholder="Ingresar Nombres" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NombreRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ValidationGroup="Guardar" ControlToValidate="NombresTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="NombreRegularExpressionValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ValidationGroup="Guardar" ControlToValidate="NombresTextBox" ValidationExpression="^[a-z & A-Z]*$"></asp:RegularExpressionValidator>

                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Sexo" runat="server" />
                    <asp:DropDownList ID="SexoDropDownList" runat="server" Class="form-control input-sm">
                        <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                        <asp:ListItem Text="Masculino"></asp:ListItem>
                        <asp:ListItem Text="Femenino"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Sexo: Seleccione" ValidationGroup="Guardar" ControlToValidate="SexoDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

                </div>

                <div class="form-group col-md-4">
                    <asp:Label Text="Cedula" runat="server" />
                    <asp:TextBox type="text" AutoCompleteType="Disabled" class="form-control" ID="CedulaTextBox" MaxLength="11" placeholder="Ingresar Cedula" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Cedula: Digite Cedula" ValidationGroup="Guardar" ControlToValidate="CedulaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CVCedulaMenor" OnServerValidate="CVCedulaMenor_ServerValidate" ErrorMessage="Cedula: Incorrecto" ControlToValidate="CedulaTextBox" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" Font-Bold="true" ValidationGroup="Guardar" runat="server" />
                    <asp:RegularExpressionValidator ID="IdRegularExpressionValidator" runat="server" ControlToValidate="CedulaTextBox" ForeColor="Red" Display="Dynamic" ErrorMessage="Cedula: Solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>

                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Fecha Nacimiento" runat="server" />
                    <asp:TextBox ID="FechaNacimientoTextBox" class="form-control input-group" TextMode="Date" runat="server" />

                </div>
                <div class="form-group col-md-4">
                    <asp:Label Text="Teléfono" runat="server" />
                    <asp:TextBox type="text" AutoCompleteType="Disabled" class="form-control" ID="TelefonoTextBox" TextMode="Phone" MaxLength="10" placeholder="Ingresar Telefono" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="ValidaTelefono" runat="server" ErrorMessage='Campo "Telefono" solo acepta numeros' ControlToValidate="TelefonoTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Solo acepta numeros" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="ValidaVacioTelefono" runat="server" ErrorMessage="El campo &quot;Telefono&quot; esta vacio" ControlToValidate="TelefonoTextBox" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CVTelefonoMenor" OnServerValidate="CVTelefonoMenor_ServerValidate" ErrorMessage="Telefono: Incorrecto" ControlToValidate="TelefonoTextBox" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" Font-Bold="true" ValidationGroup="Guardar" runat="server" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TelefonoTextBox" ForeColor="Red" Display="Dynamic" ErrorMessage="Cedula: Solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar"></asp:RegularExpressionValidator>

                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-2">
                    <asp:Label Text="Vehiculo Rentados" runat="server" />
                    <asp:TextBox ID="VehiculosRentadosTextBox" ReadOnly="true" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-5">
                    <asp:Label Text="Direccion" AutoCompleteType="Disabled" runat="server" />
                    <asp:TextBox type="text" class="form-control" ID="DireccionTextBox" placeholder="Ingresar Direccion" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Direccion: Rellene Correctamente" Font-Bold="true" ControlToValidate="DireccionTextBox" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
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
                    <asp:LinkButton ID="GuardarLinkButton" CssClass="btn btn-success" runat="server" ValidationGroup="Guardar" OnClick="GuardarLinkButton_Click">
                        <span class="fas fa-save"></span>
                        Guardar
                </asp:LinkButton>
                </div>

                <!--Eliminar-->
                <div class="col-lg-1 mr-3">
                    <asp:LinkButton ID="EliminarLinkButton" CssClass="btn btn-danger" runat="server" ValidationGroup="Buscar" OnClick="EliminarLinkButton_Click">
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
