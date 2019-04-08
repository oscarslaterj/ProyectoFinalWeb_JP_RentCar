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
                    <asp:label id="Label1" cssclass="col-form-label" text="UserIdText" runat="server">Renta ID</asp:label>
                    <div class="input-group">
                        <asp:textbox id="RentaIDTextBox"  cssclass="form-control" textmode="Number" runat="server"></asp:textbox>
                    
                        <div class="input-group-append">
                            <asp:linkbutton id="BuscarLinkButton" cssclass="btn btn-secondary" runat="server" onclick="BuscarLinkButton_Click" CausesValidation="false">
                                <span class="fas fa-search"></span>
                                Buscar
                        </asp:linkbutton>

                        </div>
                    </div>
                </div>

                <div class="form-group col-md-3">
                    <asp:label text="Fecha Registro" runat="server" />
                    <asp:textbox id="FechaRegistroTextBox" class="form-control input-group" textmode="Date" runat="server" />
                </div>

            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:label text="Cliente" runat="server" />
                    <asp:dropdownlist id="ClienteDropDownList" appenddatabounditems="true" runat="server" readonly="true" class="form-control input-sm">
                        <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                    </asp:dropdownlist>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Agregar" runat="server" ErrorMessage="Cliente: Seleccione" ControlToValidate="ClienteDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:label text="Vehiculo" runat="server" />
                    <asp:dropdownlist  AutoPostBack="true" id="VehiculoDropDownList" appenddatabounditems="true" onselectedindexchanged="VehiculoDropDownList_SelectedIndexChanged" runat="server" readonly="true" class="form-control input-sm">
                        <asp:ListItem Selected="True" Value="">Seleccione Uno</asp:ListItem>
                    </asp:dropdownlist>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Agregar" runat="server" ErrorMessage="Vehiculo: Seleccione" ControlToValidate="VehiculoDropDownList" Display="Dynamic" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                </div>
            </div>
            


            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:label text="Fecha de Renta" runat="server" />
                    <asp:textbox id="FechaRentaTextBox" class="form-control input-group" textmode="Date" runat="server" />

                </div>

                <div class="form-group col-md-3">
                    <asp:label text="Fecha de Devuelta" runat="server" />
                    <asp:textbox id="FechaDevueltaTextBox" class="form-control input-group" textmode="Date" runat="server" />

                </div>

            </div>

            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:label text="Placa" runat="server" />
                    <asp:textbox type="text" readonly="true" class="form-control" id="PlacaTextBox" placeholder="Ingresar Placa" runat="server"></asp:textbox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese alguna Placa!" ControlToValidate="PlacaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>

                <div class="form-group col-md-3">
                    <asp:label text="Marca" runat="server" />
                    <asp:textbox type="text" readonly="true" class="form-control" id="MarcaTextBox" placeholder="Ingresar Marca" runat="server"></asp:textbox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="MarcaTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>
            </div>


            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:label text="Modelo" runat="server" />
                    <asp:textbox type="text" readonly="true" class="form-control" id="ModeloTextBox" placeholder="Ingresar Modelo" runat="server"></asp:textbox>
                    <%--<asp:RequiredFieldValidator ID="NombreRequiredFieldValidator" runat="server" ErrorMessage="Ingrese algun nombre!" ControlToValidate="ModeloTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>
                <div class="form-group col-md-6">
                    <asp:label text="Descripción" runat="server" />
                    <asp:textbox type="text" readonly="true" class="form-control" id="DescripcionTextBox" placeholder="Ingresar Descripción" runat="server"></asp:textbox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese alguna descripción!" ControlToValidate="DescripcionTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>

            </div>

            <div class="form-row">
                <div class="form-group col-md-4">
                    <asp:button id="AgregarButton" ValidationGroup="Agregar" cssclass="btn btn-primary" onclick="AgregarButton_Click" runat="server" text="Agregar" />
                    <%--<asp:Button ID="EliminarButton" CssClass="btn btn-danger" OnClick="EliminarButton_Click" runat="server" Text="Eliminar" />--%>
                </div>
            </div>
            <!--Grid-->
            <div class="row justify-content-center mt-3">
                <div class="col-lg-11">
                    <asp:gridview id="DetalleGridView" runat="server" allowpaging="true" pagesize="7"
                        cssclass="table table-striped table-hover table-responsive-lg"
                        autogeneratecolumns="False" 
                        datakeynames="DetalleId"
                        onrowdeleting="DetalleGridView_RowDeleting" >
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
                    </asp:gridview>
                    <%--<asp:CustomValidator ID="CVDetalle" ValidationGroup="Guardar" OnServerValidate="CVDetalle_ServerValidate" Display="Dynamic" ForeColor="Red" Font-Bold="true" ErrorMessage="Grid Vacio" ControlToValidate="DetalleGridView" runat="server" />--%>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-3">
                    <asp:Label Text="Monto Total"  runat="server" />
                    <asp:TextBox ID="MontoTextBox" CssClass="form-control" ReadOnly="true" runat="server" />
                </div>
            </div>


            <div class="card-footer">
                <!--Butones-->
                <div class="form-group row justify-content-center">
                    <!--Nuevo-->
                    <div class="col-lg-1 mr-1">
                        <asp:linkbutton id="NuevoLinkButton" cssclass="btn btn-primary" runat="server" onclick="NuevoLinkButton_Click">
                        <span class="fas fa-plus"></span>
                        Nuevo
                </asp:linkbutton>
                    </div>
                    <div class="col-lg-1 mr-1">
                        <asp:linkbutton id="RentarLinkButton" cssclass="btn btn-primary" onclick="RentarLinkButton_Click" runat="server" ValidationGroup="Agregar">
                                <span class="fas fa-search"></span>
                               Rentar
                        </asp:linkbutton>

                    </div>
                    <!--Eliminar-->
                    <div class="col-lg-1 mr-3">
                        <asp:linkbutton id="EliminarLinkButton" cssclass="btn btn-danger" runat="server" onclick="EliminarButton_Click">
                        <span class="fas fa-trash-alt"></span>
                        Eliminar
                </asp:linkbutton>
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
