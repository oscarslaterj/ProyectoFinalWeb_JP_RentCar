<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cUsuarios.aspx.cs" Inherits="ProyectoFinalWeb_JPRentACar.UI.Consultas.cUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Consulta de Usuarios</h3>
    <div class="form-row justify-content-center">

        <%--Filtro--%>
        <div class="form-group col-md-2">
            <asp:Label Text="Filtro" class="text-primary" runat="server" />
            <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                <asp:ListItem>Todo</asp:ListItem>
                <asp:ListItem>Usuario ID</asp:ListItem>
                <asp:ListItem>Nombre de usuario</asp:ListItem>
                <asp:ListItem>Tipo</asp:ListItem>
                <asp:ListItem>Nombres</asp:ListItem>
              
            </asp:DropDownList>
        </div>

        <%--Criterio--%>
        <div class="form-group col-md-3">
            <asp:Label ID="Label1" runat="server" Text="Buscar">Buscar:</asp:Label>
            <asp:TextBox ID="CriterioTextBox" class="form-control input-group" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1 p-0">
            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="BuscarLinkButton_Click">
                <span class="fas fa-search"></span>
                 Buscar
            </asp:LinkButton>
        </div>
    </div>

    <div class="form-row justify-content-center">
        <%--Desde--%>
        <div class="form-group col-md-2">
            <asp:Label Text="Desde" runat="server" />
            <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />

        </div>

        <%--Hasta--%>
        <div class="form-group col-md-2">
            <asp:Label Text="Hasta" runat="server" />
            <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />

        </div>

    </div>


    <div class="form-row justify-content-center">
        <asp:GridView ID="UsuarioGridView" runat="server" class="table table-condensed table-bordered table-responsive"
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="SkyBlue" />
            <Columns>
                <asp:BoundField DataField="UsuarioId" HeaderText="Usuario Id" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombres" />
                <asp:BoundField DataField="NombreUser" HeaderText="Nombre de usuario" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />

            </Columns>
        </asp:GridView>
    </div>

     <div class="form-row justify-content-center">
        <asp:Button ID="ImprimirButton" CssClass="btn btn-outline-info mt-4" runat="server" Text="Imprimir" OnClick="ImprimirButton_Click" />

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
