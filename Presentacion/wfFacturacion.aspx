<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfFacturacion.aspx.cs" Inherits="Presentacion.wfFacturacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="panel panel-default">
        <div class="panel-heading">Facturación</div>
        <div class="panel-body">
            <fieldset class="form-group">
                <legend>Facturación de Productos</legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-3 col-md-3 col-lg-2">
                        <div class="form-group">
                            <label class="control-label">Fecha</label>
                            <asp:TextBox ID="txtFecha" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">
                         <label class="control-label" for="txtCliente">Cliente</label>                        
                    </div>
                    <div class="col-xs-12 col-sm-2 col-md-1 col-lg-1 ">                         
                        <asp:TextBox ID="txtCliente" runat="server" class="form-control" placeholder="000"> </asp:TextBox> 
                    </div>
                     <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1 "> 
                        <asp:Button id="btnBuscarCliente" runat="server" Text="..." CausesValidation="False" OnClick="btnBuscarCliente_Click"></asp:Button>
                    </div>
                    <div class="col-xs-12 col-sm-1 col-md-1 col-lg-1">
                        <label class="control-label">Nombre</label>
                    </div>
                    <div class="col-xs-12 col-sm-5 col-md-4 col-lg-3 "> 
                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" ReadOnly="true"></asp:TextBox> 
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-3"> 
                        <asp:RequiredFieldValidator ID="rfvCliente" runat="server" ErrorMessage="Debe digitar el código del cliente." ControlToValidate="txtCliente" CssClass="alert-danger"></asp:RequiredFieldValidator>                  
                    </div>
                    <div class="col-xs-12 col-sm-4 col-md-3 col-lg-3">
                        <asp:RangeValidator ID="rvCliente" runat="server" ErrorMessage="Debe digitar el formato correcto." ControlToValidate="txtCliente" CssClass="alert-danger" MinimumValue="1" MaximumValue="999" Type="Integer"></asp:RangeValidator>
                    </div>                    
                </div>

                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-4 col-lg-4">
                        <div class="form-group">
                            <label class="control-label" for="ddlProducto">Producto</label>
                             <asp:DropDownList ID="ddlProducto" runat="server" class="form-control" AppendDataBoundItems="true" ></asp:DropDownList>    
                        </div>
                    </div>
                    <br />
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <asp:RequiredFieldValidator ID="rfvProducto" runat="server" InitialValue="0" ErrorMessage="Debe seleccionar el producto." ControlToValidate="ddlProducto" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-12 col-sm-2 col-md-1 col-lg-1">
                        <div class="form-group">
                            <label class="control-label">Cantidad</label>
                            <asp:TextBox ID="txtCantidad" runat="server" class="form-control" placeholder="0"></asp:TextBox>                            
                        </div>
                    </div>
                    <br />
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ErrorMessage="Debe digitar la cantidad del producto." ControlToValidate="txtCantidad" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    </div>    
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6"> 
                        <asp:RangeValidator ID="rvCantidad" runat="server" ErrorMessage="Debe digitar el formato correcto." ControlToValidate="txtCantidad" CssClass="alert-danger" MinimumValue="1" MaximumValue="999" Type="Integer"></asp:RangeValidator>
                    </div>                       
                </div>

                <div class="row">
                    <div class="text-center">
                        <div class="form-group">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="btn btn-info" OnClick="btnAgregar_Click"/>
                        </div>
                    </div>
                </div>

            </fieldset>

            <div class="row">
                <div class="col-lg-12">
                    <asp:GridView ID="gvFactura" runat="server"
                        AutoGenerateColumns="false"
                        CssClass="table table-bordered bs-table"
                        DataKeyNames="UsuarioProceso"
                        Width="100%"
                        PageSize="5"
                        AllowPaging="true"
                        OnPageIndexChanging="gvFactura_PageIndexChanging" 
                        OnRowDataBound="gvFactura_RowDataBound">
                        <%--Estilos--%>
                        <HeaderStyle BackColor="#001b36" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#ffffcc" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No hay registros!  
                        </EmptyDataTemplate>

                        <%--Paginador...--%>
                        <PagerTemplate>
                            <div class="col-xs-12 col-lg-7">
                                <asp:Label ID="Label1" runat="server" Text="Mostrar filas:" />
                                
                                <asp:DropDownList ID="RegsPag" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RegsPag_SelectedIndexChanged"
                                      Width="40px">
                                    <asp:ListItem Value="5" />
                                    <asp:ListItem Value="10" />
                                    <asp:ListItem Value="15" />
                                </asp:DropDownList>

                                <asp:Label ID="Label2" runat="server" Text="Ir a"></asp:Label>
                                
                                <asp:TextBox ID="IraPag" runat="server" AutoPostBack="true" OnTextChanged="IraPag"
                                    Width="30px" />

                                <asp:Label ID="Label3" runat="server" Text="de" />

                                <asp:Label ID="lblTotalNumberOfPages" runat="server" />
                            </div>
                            <div class="col-xs-12 col-lg-5 text-right">
                                <asp:Button ID="ImageButtonFirst" runat="server" CommandName="Page" ToolTip="Prim. Pag"
                                    CommandArgument="First" CssClass="btn btn-default" CausesValidation="False" Text="<<" />
                                <asp:Button ID="ImageButtonPrev" runat="server" CommandName="Page" ToolTip="Pág. anterior"
                                    CommandArgument="Prev" CssClass="btn btn-default" CausesValidation="False" Text="<" />
                                <asp:Button ID="ImageButtonNext" runat="server" CommandName="Page" ToolTip="Sig. página"
                                    CommandArgument="Next" CssClass="btn btn-default" CausesValidation="False" Text=">" />
                                <asp:Button ID="ImageButtonLast" runat="server" CommandName="Page" ToolTip="Últ. Pag"
                                    CommandArgument="Last" CssClass="btn btn-default" CausesValidation="False" Text=">>" />

                            </div>
                        </PagerTemplate>
                        <Columns>
                            <%--campos no editables...--%>
                            <asp:BoundField DataField="Producto" HeaderText="Producto" InsertVisible="False" ReadOnly="True" SortExpression="Producto" ControlStyle-Width="20%" />
                            <%--ControlStyle-Width="70px"--%>
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" InsertVisible="False" ReadOnly="True" SortExpression="Cantidad" ControlStyle-Width="20%" />
                            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" ReadOnly="True" SortExpression="Precio Unitario" ControlStyle-Width="10%" />
                            <asp:BoundField DataField="Importe" HeaderText="Importe" ReadOnly="True" SortExpression="Importe" ControlStyle-Width="10%" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-sm-4 col-md-4 col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Subtotal</label>
                        <asp:TextBox ID="txtSubTotal" runat="server" class="form-control" placeholder="0" ReadOnly="true"></asp:TextBox>                       
                    </div>
                </div>

                 <div class="col-xs-12 col-sm-4 col-md-4 col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Impuesto</label>
                        <asp:TextBox ID="txtImpuesto" runat="server" class="form-control" placeholder="0" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                 <div class="col-xs-12 col-sm-4 col-md-4 col-lg-3">
                    <div class="form-group">
                        <label class="control-label">Total</label>
                        <asp:TextBox ID="txtTotal" runat="server" class="form-control" placeholder="0" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>                
            </div>
                
            <div class="container">
                <div class="row">
                    <div class="text-center">                    
                        <asp:Button ID="btnFacturar" runat="server" Text="Facturar" class="btn btn-success" OnClick="btnFacturar_Click" />  
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-danger" OnClick="btnCancelar_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 col-md-12 col-sm-12 col-lg-12">
                    <asp:CustomValidator ID="cvDatos" runat="server"></asp:CustomValidator>
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
