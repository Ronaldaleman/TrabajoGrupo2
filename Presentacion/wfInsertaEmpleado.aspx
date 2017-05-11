<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfInsertaEmpleado.aspx.cs" Inherits="Presentacion.wfInsertaEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Registro de Empleado</div>
        <div class="panel-body">
            <fieldset class="form-group">
                 <legend>Datos Generales</legend>
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label class="control-label">Nombres y Apellidos</label>
                            <asp:TextBox ID="txtNombres" runat="server" class="form-control" placeholder="Nombres" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombres" runat="server" ControlToValidate="txtNombres" ErrorMessage="Digite Nombres y Apellidos" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label class="control-label">Número de Cédula</label>
                            <asp:TextBox ID="txtNumeroCedula" runat="server" class="form-control" placeholder="000-000000-0000X" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCedula" runat="server" ErrorMessage="Digite Cédula" ControlToValidate="txtNumeroCedula" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label class="control-label">Dirección</label>
                            <asp:TextBox ID="txtDireccion" runat="server" class="form-control" placeholder="Drieccion" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ErrorMessage="Digite Dirección" ControlToValidate="txtDireccion" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </fieldset>
             <br />

            <div class="row">
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:ValidationSummary ID="vsDatos" runat="server" Font-Size="Smaller" ForeColor="#FF3300" />
                        <asp:CustomValidator ID="cvDatos" runat="server" ControlToValidate="txtDireccion" Text="*" ForeColor="Red"></asp:CustomValidator>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnGuardar_Click"/>
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-info" CausesValidation ="false"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btnCancelar_Click" CausesValidation="false" />
                    <asp:Button ID="btnReporte" runat="server" Text="Reporte" class="btn btn-primary" CausesValidation="false" OnClick="btnReporte_Click" />
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
