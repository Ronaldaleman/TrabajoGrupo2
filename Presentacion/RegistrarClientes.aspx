<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarClientes.aspx.cs" Inherits="Presentacion.RegistrarClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Registro de Clientes</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Datos Generales</legend>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">&nbsp;Nombres</label>
                        <asp:TextBox ID="txtNombres" runat="server" class="form-control" placeholder="Nombres" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Número de Cédula</label>
                        <asp:TextBox ID="txtNumeroCedula" runat="server" class="form-control" placeholder="000-000000-0000X" Width="383px" ></asp:TextBox>
                    </div>
                </div>

            </fieldset>
            <fieldset class="form-group">
                <legend>Dirección</legend>
                <div class="col-lg-6">
                    <div class="form-group">
                        &nbsp;<asp:TextBox ID="txtDireccion" runat="server" class="form-control" placeholder="Dirección" ></asp:TextBox>
                    </div>
                </div>
            </fieldset>
            <fieldset class="form-group">
            </fieldset>
            <br />
            <asp:Label ID="lblMessage" runat="server" Text="" AssociatedControlID="txtNumeroCedula" Width="111px"></asp:Label>
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="txtEntrar" runat="server" Text="Guardar" class="btn btn-danger" OnClick="txtEntrar_Click" BackColor="Lime" BorderColor="Lime" />
                    <asp:Button ID="Btn_Limpiar" runat="server" Text="Limpiar" class="btn btn-info" OnClick="Btn_Limpiar_Click"  />
                    <asp:Button ID="Btn_Cancelar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="Btn_Cancelar_Click" />
                    <asp:CustomValidator ID="cvDatos" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
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
