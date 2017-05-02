<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfFormularioGrid.aspx.cs" Inherits="Presentacion.wfFormularioGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">Administración de Usuarios</div>
        <div class="panel-body">
            <div class="col-lg-12">

            </div>
            <div class="col-lg-12">
                <asp:GridView ID="gvUsuarios" runat="server"
                    AutoGenerateColumns="false"
                    CssClass="table table-bordered bs-table"
                    DataKeyNames="C_Usuario"
                    Width="100%"
                    PageSize="5"
                    AllowPaging="true"
                    OnPageIndexChanging="gvUsuarios_PageIndexChanging"
                    OnRowDataBound="gvUsuarios_RowDataBound" OnRowCommand="gvUsuarios_RowCommand">
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
                                <asp:LinkButton ID="lkbEliminar" Text="ELIMINAR" CommandName="ELIMINAR" CommandArgument='<%# Eval("C_Usuario") %>'
                                    OnClientClick='if(!confirm("¿ESTA SEGURO QUE DESEA ELIMINAR EL REGISTRO?"))return false'
                                    runat="server" CssClass="btn btn-danger btn-sm" ToolTip="ELIMINAR"><span class="glyphicon glyphicon glyphicon-trash"></span></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lkbEditar" Text="EDITAR" CommandName="EDITAR" CommandArgument='<%# Eval("C_Usuario") %>'
                                    runat="server" CssClass="btn btn-info btn-sm" ToolTip="EDITAR"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--campos no editables...--%>
                        <asp:BoundField DataField="S_Nomb_Usuario" HeaderText="Nombres" InsertVisible="False" ReadOnly="True" SortExpression="Nombres" ControlStyle-Width="20%" />
                        <%--ControlStyle-Width="70px"--%>
                        <asp:BoundField DataField="S_Apell_Usuario" HeaderText="Apellidos" InsertVisible="False" ReadOnly="True" SortExpression="Apellidos" ControlStyle-Width="20%" />
                        <asp:BoundField DataField="S_Cedula" HeaderText="Número Cédula" ReadOnly="True" SortExpression="Cédula" ControlStyle-Width="10%" />
                        <asp:BoundField DataField="S_Inss" HeaderText="Número INSS" ReadOnly="True" SortExpression="INSS" ControlStyle-Width="10%" />
                        <asp:BoundField DataField="S_Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" ControlStyle-Width="10%" />
                        <asp:BoundField DataField="B_Extranjero" HeaderText="Extranjero" ReadOnly="True" SortExpression="Extranjero" ControlStyle-Width="5%" />
                        <asp:BoundField DataField="cargo" HeaderText="Cargo" ReadOnly="True" SortExpression="Cargo" ControlStyle-Width="10%" />
                        <asp:BoundField DataField="c_ctr" HeaderText="Centro de Costo" ReadOnly="True" SortExpression="Centro Costo" ControlStyle-Width="10%" />
                        <asp:BoundField DataField="C_caja" HeaderText="Caja Asignada" ReadOnly="True" SortExpression="Caja" ControlStyle-Width="5%" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
