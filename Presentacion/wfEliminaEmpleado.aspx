<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfEliminaEmpleado.aspx.cs" Inherits="Presentacion.wfEliminaEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="panel panel-default">
        <div class="panel-heading">Baja de Empleado</div>
        <div class="panel-body">
            <fieldset class="form-group">
                 <legend>Datos Generales</legend>
                <div class ="row">
                    <div class="col-lg-2">
                        <div class="form-group">
                            <label class="control-label">Id Empleado</label>
                            <asp:TextBox ID="txtIdEmpleado" runat="server" class="form-control" placeholder="idEmpleado" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvIdEmpleado" runat="server" ControlToValidate="txtIdEmpleado" ErrorMessage="Digite ID de Empleado" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br/>
                    <div class="col-lg-1">
                        <div class="form-group">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-success" OnClick="btnBuscar_Click"/>
                        </div>
                    </div>     
                </div>   
                <div class ="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label class="control-label">Nombres</label>
                            <asp:TextBox ID="txtNombres" runat="server" class="form-control" placeholder="Nombres" ></asp:TextBox>
                        </div>
                    </div>
                </div>
            </fieldset>
             <br />
            <div class="row">
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:CustomValidator ID="cvDatos" runat="server" ForeColor="Red">*</asp:CustomValidator>
                        <asp:ValidationSummary ID="vsDatos" runat="server" Font-Size="Smaller" ForeColor="#FF3300" />
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-info" CausesValidation="false"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-default" CausesValidation="false" OnClick="btnCancelar_Click" />
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
