<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfEditaProducto.aspx.cs" Inherits="Presentacion.wfEditaProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Administración de Productos</div>
        <div class="panel-body">
            <div class="col-lg-12">

            </div>
            <div class="col-lg-12">
                <asp:GridView ID="gvProductos" runat="server"
                    AutoGenerateColumns="false"
                    CssClass="table table-bordered bs-table"
                    DataKeyNames="Id"
                    Width="100%"
                    PageSize="5"
                    AllowPaging="true"
                    OnPageIndexChanging="gvProductos_PageIndexChanging"
                    OnRowDataBound="gvProductos_RowDataBound" OnRowCommand="gvProductos_RowCommand">
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

                            <asp:DropDownList ID="RegsPag" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="RegsPag_SelectedIndexChanged" Width="40px">
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
                        <%--botones de acción sobre los registros...--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbEliminar" Text="ELIMINAR" CommandName="ELIMINAR" CommandArgument='<%# Eval("Id") %>'
                                    OnClientClick='if(!confirm("¿ESTA SEGURO QUE DESEA ELIMINAR EL REGISTRO?"))return false'
                                    runat="server" CssClass="btn btn-danger btn-sm" ToolTip="ELIMINAR"><span class="glyphicon glyphicon glyphicon-trash"></span></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbEditar" Text="EDITAR" CommandName="EDITAR" CommandArgument='<%# Eval("Id") %>'
                                    runat="server" CssClass="btn btn-info btn-sm" ToolTip="EDITAR"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--campos no editables...--%>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" InsertVisible="False" ReadOnly="True" SortExpression="Descripcion" ControlStyle-Width="20%" />
                        <%--ControlStyle-Width="70px"--%>
                        <asp:BoundField DataField="Existencia" HeaderText="Existencia" InsertVisible="False" ReadOnly="True" SortExpression="Existencia" ControlStyle-Width="20%" />
                        <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" ReadOnly="True" SortExpression="Precio Unitario" ControlStyle-Width="10%" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" ReadOnly="True" SortExpression="Estado" ControlStyle-Width="10%" />
                        <asp:BoundField DataField="FechaProceso" HeaderText="FechaProceso" ReadOnly="True" SortExpression="FechaProceso" ControlStyle-Width="10%" />
                    </Columns>
                </asp:GridView>
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

</asp:Content>
