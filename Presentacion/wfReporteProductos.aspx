<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfReporteProductos.aspx.cs" Inherits="Presentacion.wfReporteProductos" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="panel panel-default">
        <div class="panel-heading">Administración de Productos</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    <rsweb:ReportViewer ID="rvProductos" runat="server" Width="100%" ></rsweb:ReportViewer>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="row">
                    <asp:CustomValidator ID="cvMensaje" runat="server" ErrorMessage="CustomValidator" ForeColor="Red" Font-Size="Smaller"></asp:CustomValidator>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
