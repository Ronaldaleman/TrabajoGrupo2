<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfFormularioBase.aspx.cs" Inherits="Presentacion.wfFormularioBase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Registro de Usuarios</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Datos Generales</legend>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Primer Nombre</label>
                        <asp:TextBox ID="txtPrimerNombre" runat="server" class="form-control" placeholder="Primer Nombre" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Segundo Nombre</label>
                        <asp:TextBox ID="txtSegundoNombre" runat="server" class="form-control" placeholder="Segundo Nombre"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Primer Apellido</label>
                        <asp:TextBox ID="TextBox6" runat="server" class="form-control" placeholder="Primer Apellido" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Segundo Apellido</label>
                        <asp:TextBox ID="TextBox7" runat="server" class="form-control" placeholder="Segundo Apellido"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">¿Usuario es extranjero?</label>
                        <asp:DropDownList ID="ddlExtranjero" runat="server" class="form-control" >
                            <asp:ListItem Value="0">--Seleccione--</asp:ListItem>
                            <asp:ListItem Value="1">Si</asp:ListItem>
                            <asp:ListItem Value="2">NO</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Número de Cédula</label>
                        <asp:TextBox ID="txtNumeroCedula" runat="server" class="form-control" placeholder="000-000000-0000X" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Número de INSS</label>
                        <asp:TextBox ID="txtINSS" runat="server" class="form-control" placeholder="0000000000" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <label class="control-label">Fecha Nac</label>
                    <div class="input-group date" id="datetimepicker1">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                        <input type="text" runat="server" class="form-control">
                    </div>
                </div>

            </fieldset>
            <fieldset class="form-group">
                <legend>Datos Laborales UCA</legend>
                <div class="col-lg-6">
                    <div class="form-group">
                        <label class="control-label">Cargo</label>
                        <asp:TextBox ID="txtCargo" runat="server" class="form-control" placeholder="Cargo" ></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <label class="control-label">Centro de Costo</label>
                        <asp:TextBox ID="txtCentroCosto" runat="server" class="form-control" placeholder="Centro de Costo" ></asp:TextBox>
                    </div>
                </div>
            </fieldset>
            <fieldset class="form-group">
                <legend>Datos de Acceso</legend>
                <div class="col-lg-6">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                        <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="" disabled></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                        <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="" Text="webuca" disabled></asp:TextBox>
                    </div>
                </div>
            </fieldset>
            <br />
            <div class="col-lg-4">
                <div class="form-group">
                    <asp:Button ID="txtEntrar" runat="server" Text="Guardar" class="btn btn-danger" />
                    <asp:Button ID="Button1" runat="server" Text="Limpiar" class="btn btn-info" />
                    <asp:Button ID="Button2" runat="server" Text="Cancelar" class="btn btn-default"/>
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
