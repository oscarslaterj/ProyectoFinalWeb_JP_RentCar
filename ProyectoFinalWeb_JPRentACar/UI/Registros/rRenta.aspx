<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rRenta.aspx.cs" Inherits="ProyectoFinalWeb_JPRentACar.UI.Registros.rRenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Registro de Alquiler</h3>
    <div class="container">


        <!--Card body-->
        <div class="card-body">
            <!--Id-->
            <div class="form-row">
                <div class="col-lg-3">
                    <asp:Label ID="Label1" CssClass="col-form-label" Text="UserIdText" runat="server">Renta ID</asp:Label>
                    <div class="input-group">
                        <asp:TextBox ID="RentaIDTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>

                        <div class="input-group-append">
                            <asp:LinkButton ID="BuscarLinkButton" CssClass="btn btn-secondary" runat="server" OnClick="BuscarLinkButton_Click" CausesValidation="false">
                                <span class="fas fa-search"></span>
                                Buscar
                            </asp:LinkButton>

                        </div>
                    </div>
                </div>

                <div class="form-group col-md-3">
                    <asp:Label Text="Fecha Registro" runat="server" />
                    <asp:TextBox ID="FechaRegistroTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>

            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label Text="Cliente" runat="server" />
                    <asp:DropDownList ID="ClienteDropDownList" AppendDataBoundItems="true" runat="server" readonly="true" class="form-control input-sm">
                        <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Agregar" runat="server" ErrorMessage="Cliente: Seleccione" ControlToValidate="ClienteDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label Text="Vehiculo" runat="server" />
                    <asp:DropDownList AutoPostBack="true" ID="VehiculoDropDownList" AppendDataBoundItems="true" OnSelectedIndexChanged="VehiculoDropDownList_SelectedIndexChanged" runat="server" readonly="true" class="form-control input-sm">
                        <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Agregar" runat="server" ErrorMessage="Vehiculo: Seleccione" ControlToValidate="VehiculoDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>

                </div>
            </div>



            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Fecha de Renta" runat="server" />
                    <asp:TextBox ID="FechaRentaTextBox" class="form-control input-group" TextMode="Date" runat="server" />

                </div>

                <div class="form-group col-md-3">
                    <asp:Label Text="Fecha de Devuelta" runat="server" />
                    <asp:TextBox ID="FechaDevueltaTextBox" class="form-control input-group" TextMode="Date" runat="server" />

                </div>

            </div>

            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Placa" runat="server" />
                    <asp:TextBox type="text" ReadOnly="true" class="form-control" ID="PlacaTextBox" placeholder="Ingresar Placa" runat="server"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese alguna Placa!" ControlToValidate="PlacaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>

                <div class="form-group col-md-3">
                    <asp:Label Text="Marca" runat="server" />
                    <asp:TextBox type="text" ReadOnly="true" class="form-control" ID="MarcaTextBox" placeholder="Ingresar Marca" runat="server"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="MarcaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>
            </div>


            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Modelo" runat="server" />
                    <asp:TextBox type="text" ReadOnly="true" class="form-control" ID="ModeloTextBox" placeholder="Ingresar Modelo" runat="server"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="NombreRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="ModeloTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>
                <div class="form-group col-md-6">
                    <asp:Label Text="Descripción" runat="server" />
                    <asp:TextBox type="text" ReadOnly="true" class="form-control" ID="DescripcionTextBox" placeholder="Ingresar Descripción" runat="server"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese alguna descripción!" ControlToValidate="DescripcionTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>

            </div>

            <div class="form-row">
                <div class="form-group col-md-4">
                    <asp:Button ID="AgregarButton" ValidationGroup="Agregar" CssClass="btn btn-primary" OnClick="AgregarButton_Click" runat="server" Text="Agregar" />
                    <%--<asp:Button ID="EliminarButton" CssClass="btn btn-danger" OnClick="EliminarButton_Click" runat="server" Text="Eliminar" />--%>
                </div>
            </div>
            <!--Grid-->
            <div class="row justify-content-center mt-3">
                <div class="col-lg-11">
                    <asp:GridView ID="DetalleGridView" runat="server" AllowPaging="true" PageSize="7"
                        CssClass="table table-striped table-hover table-responsive-lg"
                        AutoGenerateColumns="False"
                        DataKeyNames="DetalleId"
                        OnRowDeleting="DetalleGridView_RowDeleting">
                        <Columns>
                            <%--<asp:BoundField DataField="DetalleId" HeaderText="Id" />--%>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="RentaId" HeaderText="Renta #" />
                            <asp:BoundField DataField="VehiculoId" HeaderText="Vehiculo #" />
                            <asp:BoundField DataField="Marca" HeaderText="Marca" />
                            <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                            <asp:BoundField DataField="Anio" HeaderText="Ano" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                            <asp:CommandField ButtonType="Link" ShowDeleteButton="true" />
                        </Columns>
                    </asp:GridView>
                    <%--<asp:CustomValidator ID="CVDetalle" ValidationGroup="Guardar" OnServerValidate="CVDetalle_ServerValidate" Display="Dynamic" ForeColor="Red" Font-Bold="true" ErrorMessage="Grid Vacio" ControlToValidate="DetalleGridView" runat="server" />--%>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Monto Total" runat="server" />
                    <asp:TextBox ID="MontoTextBox" CssClass="form-control" ReadOnly="true" runat="server" />
                </div>
            </div>


            <div class="card-footer">
                <!--Butones-->
                <div class="form-group row justify-content-center">
                    <!--Nuevo-->
                    <div class="col-lg-1 mr-1">
                        <asp:LinkButton ID="NuevoLinkButton" CssClass="btn btn-primary" runat="server" OnClick="NuevoLinkButton_Click">
                        <span class="fas fa-plus"></span>
                        Nuevo
                        </asp:LinkButton>
                    </div>
                    <div class="col-lg-1 mr-1">
                        <asp:LinkButton ID="RentarLinkButton" CssClass="btn btn-primary" OnClick="RentarLinkButton_Click" runat="server" ValidationGroup="Agregar">
                                <span class="fas fa-search"></span>
                               Rentar
                        </asp:LinkButton>

                    </div>
                    <!--Eliminar-->
                    <div class="col-lg-1 mr-3">
                        <asp:LinkButton ID="EliminarLinkButton" CssClass="btn btn-danger" runat="server" OnClick="EliminarButton_Click">
                        <span class="fas fa-trash-alt"></span>
                        Eliminar
                        </asp:LinkButton>
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
