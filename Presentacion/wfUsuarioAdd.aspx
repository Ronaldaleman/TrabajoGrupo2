<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfUsuarioAdd.aspx.cs" Inherits="Presentacion.wfUsuarioAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Registro de Usuarios</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Datos Generales</legend>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label class="control-label">Nombres y Apellidos</label>
                        <asp:RequiredFieldValidator ID="rqvNombre" runat="server"  ForeColor="Red" ControlToValidate="txtNombres"  ErrorMessage="Datos requeridos" ValidationGroup="validar" Text="*" ></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNombres" runat="server" class="form-control" placeholder="Nombres y Apellidos"  ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label class="control-label">Número de Cédula</label>
                        <asp:RequiredFieldValidator ID="rqvCedula" runat="server" ForeColor="Red" ControlToValidate="txtCedula"  ErrorMessage="Datos requeridos"  ValidationGroup="validar" Text="*"  ></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtCedula" runat="server" class="form-control" placeholder="Número de Cédula"></asp:TextBox>
                    </div>
                </div>
                 <div class="col-lg-4">
                    <div class="form-group">
                        <label class="control-label">Login</label>
                        <asp:RequiredFieldValidator ID="rqvLogin" runat="server" ErrorMessage="Datos requeridos"  ForeColor="Red" ControlToValidate="txtLogin"  ValidationGroup="validar" Text="*" ></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtLogin" runat="server" class="form-control" placeholder="Login" ></asp:TextBox>
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
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnGuardar_Click" ValidationGroup="validar" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-info" OnClick="btnLimpiar_Click" />
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
