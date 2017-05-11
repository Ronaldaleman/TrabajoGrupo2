<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfEditaEmpleado.aspx.cs" Inherits="Presentacion.wfEditaEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="panel panel-default">
        <div class="panel-heading">Modificación de Empleado</div>
        <div class="panel-body">
            <fieldset class="form-group">
                 <legend>Datos Generales</legend>
                <div class="row">
                    <div class="col-lg-2">
                        <div class="form-group">
                            <label class="control-label">Id Empleado</label>
                            <asp:TextBox ID="txtIdEmpleado" runat="server" class="form-control" placeholder="idEmpleado"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvIdEmpleado" runat="server" ControlToValidate="txtIdEmpleado" ErrorMessage="Digite Id de Empleado" ForeColor="Red" ValidationGroup="vgEdita">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br/>
                    <div class="col-lg-1">
                        <div class="form-group">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-success" OnClick="btnBuscar_Click"/>
                        </div>
                    </div>                      
                </div>
                <div class="row">
                    <div class="col-lg-5">
                        <div class="form-group">
                            <label class="control-label">Nombres y Apellidos</label>
                            <asp:TextBox ID="txtNombres" runat="server" class="form-control" placeholder="Nombres" MaxLength="80" ></asp:TextBox> 
                            <asp:RequiredFieldValidator ID="rfvNombres" runat="server" ControlToValidate="txtNombres"  ErrorMessage="Digite Nombres y Apellidos" ForeColor="Red" ValidationGroup="vgEdita">*</asp:RequiredFieldValidator>                             
                        </div>
                    </div>
                    <br/>
                    <asp:RegularExpressionValidator ID="revNombres" runat="server"
                    ErrorMessage="SOLO SE PERMITEN LETRAS EN NOMBRES Y APELLIDOS" ForeColor="Red" Font-Size="Smaller"
                    ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtNombres"></asp:RegularExpressionValidator>
                </div>
                <div class="row">
                    <div class="col-lg-2">
                        <div class="form-group">
                            <label class="control-label">Número de Cédula</label>
                            <asp:TextBox ID="txtNumeroCedula" runat="server" class="form-control" placeholder="000-000000-0000X" MaxLength="16" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCedula" runat="server" ControlToValidate="txtNumeroCedula" ErrorMessage="Digite la Cédula" ForeColor="Red" ValidationGroup="vgEdita">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label class="control-label">Dirección</label>
                            <asp:TextBox ID="txtDireccion" runat="server" class="form-control" placeholder="Drieccion" MaxLength="80" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Digite Dirección" ForeColor="Red" ValidationGroup="vgEdita">*</asp:RequiredFieldValidator>
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
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnGuardar_Click" ValidationGroup="vgEdita"/>
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
