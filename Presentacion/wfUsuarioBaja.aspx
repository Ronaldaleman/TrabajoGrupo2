<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfUsuarioBaja.aspx.cs" Inherits="Presentacion.wfUsuarioBaja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Baja de Usuarios</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Datos Generales</legend>
                <div class="col-lg-1">
                    <div class="form-group">
                        <label class="control-label">Código Usuario</label>
                       <asp:RequiredFieldValidator ID="rqvCodigo" runat="server" ErrorMessage="Datos requeridos"  ForeColor="Red" ControlToValidate="txtCodigo" Text="*" ValidationGroup="validar" ></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtCodigo" runat="server" class="form-control" placeholder="Código de Usuario" Width="152px"  ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label class="control-label">Nombre del Usuario</label>
                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre de Usuario"  ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                 <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Login</label>
                        <asp:TextBox ID="txtLogin" runat="server" class="form-control" placeholder="Login" ReadOnly="true" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                         <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                </fieldset>
           
                
            <br />
            <asp:CustomValidator ID="cvDatos" runat="server"  ErrorMessage="Datos requeridos"></asp:CustomValidator>
            <asp:ValidationSummary ID="vsDatos" runat="server" DisplayMode="List" ForeColor="Red" Font-Size="Small"/>
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btnRecuperar" runat="server" Text="Recuperar" class="btn btn-info" OnClick="btnRecuperar_Click"    />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-info" OnClick="btnLimpiar_Click" />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnGuardar_Click" ValidationGroup="validar" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btnCancelar_Click" />
                   
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
