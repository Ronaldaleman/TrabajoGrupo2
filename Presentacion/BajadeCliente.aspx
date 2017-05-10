<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfFormularioBase.aspx.cs" Inherits="Presentacion.wfFormularioBase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Baja de Clientes</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend></legend>
                <div class="row">
                 <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Id del Cliente</label>
                       <asp:TextBox ID="Id_txt" runat="server" class="form-control" placeholder="Id del Cliente"></asp:TextBox>
                    </div>
                </div>
                </div>
                <div class="row">
                 <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Nombres</label>
                        <asp:TextBox ID="txtNombres" runat="server" class="form-control" placeholder="Nombres"></asp:TextBox>
                    </div>
                </div>
                </div>
            </fieldset>
            <br />
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="txtEntrar" runat="server" Text="Confirmar" class="btn btn-danger" />
                    <asp:Button ID="Button1" runat="server" Text="Limpiar" class="btn btn-info" />
                    <asp:Button ID="Button2" runat="server" Text="Cancelar" class="btn btn-default" />
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker();
        });
    </script>
</asp:Content>
