<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCliente.aspx.cs" Inherits="Presentacion.Modificar_Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Modificar Clientes</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Datos Generales</legend>

                <div class="col-lg-2">
                    <div class="form-group">
                        <label class="control-label">Id del Cliente</label>
                        <asp:TextBox ID="txt_Id" runat="server" class="form-control" placeholder="Id" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Nombres</label>
                        <asp:TextBox ID="txtNombres" runat="server" class="form-control" placeholder="Nombres" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Número de Cédula</label>
                        <asp:TextBox ID="txtNumeroCedula" runat="server" class="form-control" placeholder="000-000000-0000X" ></asp:TextBox>
                    </div>
                </div>

            </fieldset>
            <fieldset class="form-group">
                <legend>Dirección</legend>
                <div class="col-lg-6">
                    <div class="form-group">
                        <label class="control-label">Dirección</label>
                        <asp:TextBox ID="txtDireccion" runat="server" class="form-control" placeholder="Direccion" ></asp:TextBox>
                    </div>
                </div>
            </fieldset>
            <fieldset class="form-group">
            </fieldset>
            <br />
            <asp:Label ID="lblMessage" runat="server" Text="" AssociatedControlID="txtNumeroCedula" Width="111px"></asp:Label>
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="btn_Actualizar" runat="server" Text="Actuaizar" class="btn btn_Actualzar" BackColor="Lime" BorderColor="Lime" OnClick="btn_Actualizar_Click" />
                    <asp:Button ID="btn_Recuperar" runat="server" Text="Recuperar" class="btn btn-default" BackColor="#FFFF66" OnClick="btn_Recuperar_Click"  />
                    <asp:Button ID="btn_Limpiar" runat="server" Text="Limpiar" class="btn btn-info" OnClick="btn_Limpiar_Click"  />
                    <asp:Button ID="btn_Cancelar" runat="server" Text="Cancelar" class="btn btn-default" />
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
