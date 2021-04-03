<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormCardes_Movimiento.aspx.cs" Inherits="ViewsLayer.WebFormCardes_Movimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
                <h4>Lista de Cardes Movimiento</h4>
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
                <asp:GridView ID="tbl" runat="server" CssClass="table table-hover table-responsive-sm " AutoGenerateSelectButton="True" Width="100%" EnablePersistedSelection="false" OnSelectedIndexChanged="tblCardes_Movimiento_SelectedIndexChanged">
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
                        <h5 class="modal-title" id="staticBackdropLabel">Registro Cardes Movimiento</h5>
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

                                <%--  EMPRESA--%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblempresa" runat="server" Text="Empresa" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:DropDownList ID="txtEMPRESA" runat="server" ReadOnly="true" CssClass="form-control ml-4"></asp:DropDownList>
                                    </div>
                                </div>
                                <%--  SUCURSAL--%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblsucursal" runat="server" Text="Sucursal" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:DropDownList ID="txtSUCURSAL" runat="server" ReadOnly="true" CssClass="form-control ml-4"></asp:DropDownList>
                                    </div>
                                </div>
                                <%--  USUARIO --%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblusuario" runat="server" Text="Usuario" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtUSUARIO" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>
                                <%--  MOVIMIENTO --%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblmovimiento" runat="server" Text="Movimiento" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtMOVIMIENTO" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>
                                <%-- INVENTARIO --%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblinventario" runat="server" Text="Inventario" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtINVENTARIO" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>
                                <%-- TIPO --%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lbltipo" runat="server" Text="Tipo" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtTIPO" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>
                                <%-- CANTIDAD EXISTENTE --%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblcantidad_existente" runat="server" Text="Cantidad existente" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtCANTIDAD_EXISTENTE" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>
                                 <%-- CANTIDAD --%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lblcantidad" runat="server" Text="Cantidad" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtCANTIDAD" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
                                    </div>
                                </div>
                                <%-- FECHA HORA --%>
                                <div class="col-12 d-flex flex-column mt-3">
                                    <div class="d-flex">
                                        <asp:Label ID="lbFlfecha_hora" runat="server" Text="Fecha Hora" CssClass="" ToolTip="" Width="100px"></asp:Label>
                                        <asp:TextBox ID="txtFECHA_HORA" runat="server" ReadOnly="false" CssClass="form-control ml-4"></asp:TextBox>
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


