<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormEmpleados.aspx.cs" Inherits="ViewsLayer.WebFormEmpleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <meta charset="utf-8" />
    <div class="row ">
        <div class="col-12 text-left">
            <div class="col-form-label  pl-3 text-capitalize">
                <%--  Cambiar el nombre del objeto--%>
                <label runat="server">Administrar</label>
                <asp:Label ID="lblbebe" runat="server" Text="Relacion"></asp:Label>
                <asp:Label ID="lblRelacion" runat="server" Text="Relacion"></asp:Label>
                <%--Nombre de la pagina--%>
            </div>
        </div>
    </div>
    <!-- Button trigger modal -->
    <div class="row mb-3 ">
        <div class="col-12 " style="left: 0px; top: 0px">
            <div class="col-form-label">
                <h4>Lista de Empleados</h4>
                <%-- Listar objetos--%>
            </div>
        </div>
        <%-- Cambiar el nombre del boton--%>
        <div class="col-12 " style="left: 0px; top: 0px">
            <div class="col-form-label">

                <asp:Button ID="btnCrear" runat="server" Text="Insertar Nuevo Registro" CssClass="btn btn-primary" OnClick="btnCrear_Click" /><%--   Nombre del botom--%>
            </div>
        </div>
        <div class="col-12 justify-content-center align-items-center p-4">
            <div class=" " style="width: 100%; height: 200px; overflow: scroll">
                <%-- cambiar nombre de la tabla--%>
                <asp:GridView ID="tbl" runat="server" CssClass="table table-hover table-responsive-sm " AutoGenerateSelectButton="True" Width="100%" EnablePersistedSelection="false" OnSelectedIndexChanged="tblEmpleados_SelectedIndexChanged">
                    <EditRowStyle CssClass="bg-warning" ForeColor="White" />
                    <EmptyDataRowStyle BorderStyle="Dotted" />
                    <SelectedRowStyle CssClass="bg-success" />
                </asp:GridView>
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

        <!-- Modal -->
        <div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <%--CAMBIAR NOMBRE MODAL--%>
                        <h5 class="modal-title" id="staticBackdropLabel">Registro Empleados</h5>
                        <%-- Titulo del modal--%>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <%--Campos segun la tabla--%>
                            <div class="row">
                                <div class="col-12">
                                    <asp:Label ID="lblTitleModal" runat="server" Text="" CssClass="h3"></asp:Label>
                                    <%--campos--%>
                                </div>

                                <%--  ID EMPRESA--%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblempresa" runat="server" Text="Empresa" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:DropDownList ID="txtEmpresa" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:DropDownList>
                                    </div>
                                </div>
                                <%--  ID SUCURSAL--%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblsucursal" runat="server" Text="Sucursal" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:DropDownList ID="txtSucursal" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:DropDownList>
                                    </div>
                                </div>
                                <%--  CEDULA --%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblcedula" runat="server" Text="Cedula" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtCedula" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>
                                <%--  NOMBRE--%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblnombre" runat="server" Text="Nombre" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtNombre" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>
                                <%-- APELLIDOS --%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblapellidos" runat="server" Text="Apellidos" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtApellidos" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>
                                <%-- EMAIL --%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblemail" runat="server" Text="Email" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtEmail" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>
                                <%-- TELEFONO --%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lbltelefono" runat="server" Text="Telefono" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtTelefono" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
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
                                <div class="col-12 d-flex mt-3 justify-content-center ">
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="form-control btn-primary mr-3" OnClick="btnGuardar_Click" />
                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="form-control btn-primary mr-3" OnClick="btnEliminar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

