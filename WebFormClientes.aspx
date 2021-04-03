<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormClientes.aspx.cs" Inherits="ViewsLayer.WebFormClientes" %>

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
                <h4>Lista de Clientes</h4>
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
                <asp:GridView ID="tbl" runat="server" CssClass="table table-hover table-responsive-sm " AutoGenerateSelectButton="True" Width="100%" EnablePersistedSelection="false" OnSelectedIndexChanged="tblClientes_SelectedIndexChanged">
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
    </div>
</asp:Content>

