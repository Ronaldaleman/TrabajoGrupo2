<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfLogin.aspx.cs" Inherits="Presentacion.wfLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-4 col-md-offset-4">
        <div class="panel panel-default">
            <div class="panel-heading">Inicio de Sesión</div>
            <div class="panel-body">
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label">Usuario</label>
                        <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtLogin" Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtLogin" runat="server" class="form-control" placeholder="Usuario"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label">Contraseña</label>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtPassword" Font-Size="X-Small" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Contaseña" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Button ID="txtEntrar" runat="server" Text="ENTRAR" class="btn btn-info" Width="100%" Font-Bold="True" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
