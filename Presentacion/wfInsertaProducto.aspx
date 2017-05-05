<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfInsertaProducto.aspx.cs" Inherits="Presentacion.wfInsertaProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">Registro de Producto</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Datos Generales</legend>
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label for="txtDescripcion" class="control-label">Descripción:
                                <%--<small style="color:red;font-weight:lighter;font-size:smaller"> campo requerido</small>--%>
                                <asp:RequiredFieldValidator ID="rvfDescripcion" runat="server" ErrorMessage="CAMPO ES REQUERIDO" 
                                ForeColor="Red" Font-Size="Smaller" Font-Bold="false" ControlToValidate="txtDescripcion"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" placeholder="Descripción" ></asp:TextBox>                            
                        </div>
                    </div>
                    <br/><br/>                   
                    <%--<asp:RequiredFieldValidator ID="rvfDescripcion" runat="server" Text="*"
                    ErrorMessage="CAMPO ES REQUERIDO" ForeColor="Red" Font-Size="Smaller" ControlToValidate="txtDescripcion"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="revDescripcion" runat="server" 
                    ErrorMessage="SOLO SE PERMITEN LETRAS EN DESCRIPCION" ForeColor="Red" Font-Size="Smaller"
                    ValidationExpression="^[A-Za-z ]+$" ControlToValidate="txtDescripcion"></asp:RegularExpressionValidator>
                    
                </div>
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label for="txtExistencia" class="control-label">Existencia:
                                <%--<small style="color:red;font-weight:lighter;font-size:smaller"> campo requerido</small>--%>
                                <asp:RequiredFieldValidator ID="rfvExistencia" runat="server" ErrorMessage="CAMPO ES REQUERIDO" 
                                ForeColor="Red" Font-Size="Smaller" Font-Bold="false" ControlToValidate="txtExistencia"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtExistencia" runat="server" class="form-control" placeholder="Existencia"></asp:TextBox>
                        </div>
                    </div>
                    <br/><br/>
                    <%--<asp:RequiredFieldValidator ID="rfvExistencia" runat="server" Text="*"
                    ErrorMessage="CAMPO ES REQUERIDO" ForeColor="Red" Font-Size="Smaller" ControlToValidate="txtExistencia"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="revExistencia" runat="server" 
                    ErrorMessage="SOLO SE PERMITEN NUMEROS ENTEROS EN EXISTENCIA" ForeColor="Red" Font-Size="Smaller"
                    ValidationExpression="^[0-9]+$" ControlToValidate="txtExistencia"></asp:RegularExpressionValidator>
                </div>
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label for="txtPrecioUnitario" class="control-label">Precio Unitario:
                                <%--<small style="color:red;font-weight:lighter;font-size:smaller"> campo requerido</small>--%>
                                <asp:RequiredFieldValidator ID="rfvPrecioUnitario" runat="server" ErrorMessage="CAMPO ES REQUERIDO" 
                                ForeColor="Red" Font-Size="Smaller" Font-Bold="false" ControlToValidate="txtPrecioUnitario"></asp:RequiredFieldValidator>
                            </label>
                            <asp:TextBox ID="txtPrecioUnitario" runat="server" class="form-control" placeholder="Precio Unitario. Formato: 0.000" ></asp:TextBox>
                        </div>
                    </div>
                    <br/><br/>
                    <%--<asp:RequiredFieldValidator ID="rfvPrecioUnitario" runat="server" Text="*"
                    ErrorMessage="CAMPO ES REQUERIDO" ForeColor="Red" Font-Size="Smaller" ControlToValidate="txtPrecioUnitario"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="revPrecioUnitario" runat="server" 
                    ErrorMessage="SOLO SE PERMITEN NUMEROS EN PRECIO UNITARIO" ForeColor="Red" Font-Size="Smaller"
                    ValidationExpression="^\d*\.?\d*" ControlToValidate="txtPrecioUnitario"></asp:RegularExpressionValidator>
                    <%--ValidationExpression="^[0-9]([.][0-9])?$" ControlToValidate="txtPrecioUnitario"></asp:RegularExpressionValidator>--%>
                </div>
            </fieldset>
            <br />
            <div class="row">
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-danger" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <asp:CustomValidator ID="cvMensaje" runat="server" ForeColor="Red" Font-Size="Smaller"></asp:CustomValidator>
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
