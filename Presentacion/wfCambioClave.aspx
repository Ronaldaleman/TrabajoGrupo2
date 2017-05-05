<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfCambioClave.aspx.cs" Inherits="Presentacion.wfCambioClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="col-md-4 col-md-offset-4">
        <div class="panel panel-default">
            <div class="panel-heading">Cambio de Contraseña</div>
            <div class="panel-body">
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label">Nueva Contraseña</label>
                        <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtNuevoPassword" Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNuevoPassword" runat="server" class="form-control" placeholder="Nueva Contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label">Confirmar Contraseña</label>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtPasswordConf" Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPasswordConf" runat="server" class="form-control" placeholder="Confirme Contaseña" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="red"></asp:Label>
                        <asp:CustomValidator ID="cvError" runat="server" ErrorMessage="" ForeColor="red"></asp:CustomValidator>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Button ID="txtEntrar" runat="server" Text="Guardar" class="btn btn-info" Width="100%" Font-Bold="True" OnClick="txtEntrar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
