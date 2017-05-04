<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfEliminaEmpleado.aspx.cs" Inherits="Presentacion.wfEliminaEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="panel panel-default">
        <div class="panel-heading">Baja de Empleado</div>
        <div class="panel-body">
            <fieldset class="form-group">
                 <legend>Datos Generales</legend>
                <div class ="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label class="control-label">Id Empleado</label>
                            <asp:TextBox ID="txtIdEmpleado" runat="server" class="form-control" placeholder="idEmpleado" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvIdEmpleado" runat="server" ControlToValidate="txtIdEmpleado" ErrorMessage="Digite ID de Empleado" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                        <asp:ValidationSummary ID="vsDatos" runat="server" Font-Size="Smaller" ForeColor="#FF3300" />
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="txtEntrar" runat="server" Text="Guardar" class="btn btn-success" />
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
