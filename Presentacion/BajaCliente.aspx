<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BajaCliente.aspx.cs" Inherits="Presentacion.BajaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Baja de Clientes</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Id del Cliente</legend>
                <div class="row">
                 <div class="col-lg-2">
                    <div class="form-group">
                        <label class="control-label">Id del Cliente</label>
                       <asp:TextBox ID="txt_Id" runat="server" class="form-control" placeholder="Id del Cliente"></asp:TextBox>
                    </div>
                </div>
                </div>
                <div class="row">
                 <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Nombres</label>
                        <asp:TextBox ID="txt_Nombres" runat="server" class="form-control" placeholder="Nombres"></asp:TextBox>
                        </div>
                </div>
                </div>
            </fieldset>
            <br />
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btn_Confirmar" runat="server" Text="Confirmar" class="btn btn-danger" OnClick="btn_Confirmar_Click"  />
                    <asp:Button ID="btn_Recuperar" runat="server" Text="Recuperar" class="btn btn-default" BackColor="#FFFF66" OnClick="btn_Recuperar_Click" />
                    <asp:Button ID="btn_Limpiar" runat="server" Text="Limpiar" class="btn btn-info" OnClick="btnLimpiar" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btn_Cancelar" />
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <div class="form-group">
                    <asp:CustomValidator ID="cvDatos" runat="server" ForeColor="Red"></asp:CustomValidator>
                </div>
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
