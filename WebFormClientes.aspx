<%@ Page Title="MantenimientoClientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormClientes.aspx.cs" Inherits="ViewsLayer.WebFormClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="panel-body">
            <div class="row">
                <div class="col-12 text-left">
                    <div class="col-form-label  pl-3 text-capitalize">
                    </div>
                </div>
            </div>

            <%-- Button trigger modal --%>
            <div class="col-12 " style="left: 0px; top: 0px">
                <div class="col-form-label">
                    <h4>Mantenimiento de Clientes</h4>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-md-6">
                    <div class="col-12 d-flex flex-column mt-4">
                        <div class="d-flex">
                            <%-- Filtrar clientes --%>
                            <asp:Label for="TextCedula" runat="server" Text="Buscar: " CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TextCedula" runat="server" placeholder="Cedula" OnTextChanged="btnBuscar_Click" AutoPostBack="true" CssClass="form-control ml-4"></asp:TextBox>
                            <asp:Button ID="btnMostrar" runat="server" Text="Mostar Todo" CssClass="form-control ml-4 btn-light" OnClick="btnMostraTodo_Click" />
                        </div>
                    </div>
                </div>
                <div class="form-group col-md-6">
                    <div class="col-12 d-flex flex-column mt-3">
                        <%--   Boton Nuevo Registro --%>
                        <asp:Button ID="btnCrear" runat="server" Text="Nuevo Registro" CssClass="btn btn-success ml-auto" OnClick="btnCrear_Click" />
                    </div>
                </div>
            </div>
            <div class="col-12 justify-content-center align-items-center p-4">
                <div class=" " style="width: 100%; height: 200px; overflow: scroll">
                    <%-- Tabla de Datos --%>
                    <asp:GridView ID="tbl" runat="server" CssClass="table table-hover table-responsive-sm " AutoGenerateSelectButton="True" Width="100%" EnablePersistedSelection="false" OnSelectedIndexChanged="tblClientes_SelectedIndexChanged">
                        <EditRowStyle CssClass="bg-warning" ForeColor="White" />
                        <EmptyDataRowStyle BorderStyle="Dotted" />
                        <SelectedRowStyle CssClass="bg-success" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <div class="row mt-2 w-100">
        <div class="col-12 mt-2 w-100">
            <div id="AlertFooter" class="alert alert-dark" role="alert" runat="server" visible="false">
                <div class="form-check-label  h-100 w-100 ">
                    <asp:Label ID="textFijo" runat="server" Text="Estado:" CssClass="text-light"></asp:Label>
                    <asp:Label ID="informacion" runat="server" Text="Informacion de las cosas que van a pasar" CssClass="text-light"></asp:Label>
                </div>
            </div>
        </div>

        <%-- Modal  --%>

        <div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <%-- Titulo del modal--%>
                        <h5 class="modal-title" id="staticBackdropLabel">Registro Clientes</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <%--Campos Segun la Tabla--%>
                            <div class="row">
                                <div class="col-12">
                                    <asp:Label ID="lblTitleModal" runat="server" Text="" CssClass="h3"></asp:Label>
                                    <%--campos--%>
                                </div>

                                <%--  CEDULA--%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lbltxtCedula" runat="server" Text="Cedula" CssClass="form-label" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtCedula" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>
                                <%--  NOMBRE--%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtNombre" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>
                                <%-- APELLIDO_1 --%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblApellido_1" runat="server" Text="Apellido 1" CssClass="form-label" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtApellido_1" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>
                                <%-- APELLIDO_2 --%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lbltxtApellido_2" runat="server" Text="Apellido 2" CssClass="form-label" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtApellido_2" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>

                                <%-- ALERTA ERROR --%>
                                <div class="col-12 d-flex flex-column justify-content-center align-items-center  mt-3">
                                    <div id="alertModal" class="alert alert-danger alert-dismissible" role="alert" runat="server" visible="false">
                                        <small>
                                            <asp:Label ID="lbLAlertModal" runat="server" Text="Error" ToolTip="Error"></asp:Label>
                                        </small>
                                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                </div>
                                <%-- ALERTA ERROR --%>

                                <div class="col-12 d-flex mt-3 justify-content-center ">
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="form-control btn-primary mr-3" OnClick="btnGuardar_Click" />
                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="form-control btn-danger mr-3" OnClick="btnEliminar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-info" data-dismiss="modal">Cerrar</button>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

