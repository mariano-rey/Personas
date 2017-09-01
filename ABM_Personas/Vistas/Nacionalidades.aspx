<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nacionalidades.aspx.cs" Inherits="ABM_Personas.Vistas.Nacionalidades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Nacionalidades</title>
    <style type="text/css">
        .auto-style3 {
            width: 187px;
            height: 36px;
        }

        .auto-style4 {
            height: 42px;
        }
        .auto-style5 {
            width: 12%;
        }
        .auto-style7 {
            width: 170px;
        }
        .auto-style8 {
            width: 18px;
        }

        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Nacionalidades<br />
            <br />
            <table class="auto-style5">
                <tr>
                    <td class="auto-style8">idNacionalidad</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtID" runat="server" Width="113px" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4">Nacionalidad</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtNacionalidad" runat="server" Width="292px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="mensajeNacionalidad" runat="server" Text=""></asp:Label>
            <br /><br />
            <asp:Button ID="consultar" runat="server" Text="Consultar" OnClick="consultar_Click" />
            &nbsp;<asp:Button ID="agregarNacionalidad" runat="server" Text="Agregar" OnClick="agregarNacionalidad_Click" />
            &nbsp;<asp:Button ID="borrarNacionalidad" runat="server" Text="Borrar" OnClick="borrarNacionalidad_Click" />
            &nbsp;<asp:Button ID="modificarNacionalidad" runat="server" Text="Modificar" OnClick="modificarNacionalidad_Click" />
            &nbsp;<asp:Button ID="limpiarNacionalidades" runat="server" OnClick="limpiarPersonas_Click" Text="Limpiar" />
            <br />
            <br />
        </div>
        <asp:GridView ID="GV_Nacionalidades" runat="server" AutoGenerateColumns="False" DataKeyNames="idNacionalidad" DataSourceID="SqlDataSource1" EmptyDataText="No hay registros de datos para mostrar." AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="idNacionalidad" HeaderText="idNacionalidad" ReadOnly="True" SortExpression="idNacionalidad" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PersonasConnectionString1 %>" DeleteCommand="DELETE FROM [Nacionalidades] WHERE [idNacionalidad] = @idNacionalidad" InsertCommand="INSERT INTO [Nacionalidades] ([Descripcion]) VALUES (@Descripcion)" ProviderName="<%$ ConnectionStrings:PersonasConnectionString1.ProviderName %>" SelectCommand="SELECT [idNacionalidad], [Descripcion] FROM [Nacionalidades]" UpdateCommand="UPDATE [Nacionalidades] SET [Descripcion] = @Descripcion WHERE [idNacionalidad] = @idNacionalidad">
            <DeleteParameters>
                <asp:Parameter Name="idNacionalidad" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Descripcion" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Descripcion" Type="String" />
                <asp:Parameter Name="idNacionalidad" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
