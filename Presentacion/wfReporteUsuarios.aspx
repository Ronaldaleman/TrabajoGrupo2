<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfReporteUsuarios.aspx.cs" Inherits="Presentacion.wfReporteUsuarios" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Reporte de Usuarios</div>
        <div class="panel-body">
             <div class="col-md-12">
                    <div class="form-group"> 
            <rsweb:ReportViewer ID="rptUsuario" runat="server"  ProcessingMode="Local" Width="100%"></rsweb:ReportViewer>
                        </div>
                 </div>
             <div class="col-md-12">
                    <div class="form-group"> 
                        <asp:CustomValidator ID="cvError" runat="server" ErrorMessage="CustomValidator" ForeColor="red"></asp:CustomValidator>
                        </div>

        </div>
    </div>
</asp:Content>
