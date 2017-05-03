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
                        <asp:TextBox ID="txtNombres" runat="server" class="form-control" placeholder="Nombres y Apellidos" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label class="control-label">Número de Cédula</label>
                        <asp:TextBox ID="txtCedula" runat="server" class="form-control" placeholder="Número de Cédula"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label class="control-label">Correo Electrónico</label>
                        <asp:TextBox ID="txtCorreo" runat="server" class="form-control" placeholder="Correo"></asp:TextBox>
                    </div>
                </div>
                </fieldset>
            <fieldset class="form-group">
                <legend>Datos de Acceso</legend>
                <div class="col-lg-6">
                    <div class="form-group">
                        <label class="control-label">Usuario</label>
                        <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Usuario" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <label class="control-label">Clave</label>
                        <asp:TextBox ID="txtClave" runat="server" class="form-control" placeholder="Clave"></asp:TextBox>
                    </div>
                </div>
             </fieldset>   
                
            <br />
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-danger"  />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-info" OnClick="btnLimpiar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" />
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
