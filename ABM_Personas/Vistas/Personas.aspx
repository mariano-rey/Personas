<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="ABM_Personas.Vistas.Personas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Personas</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 150px;
        }
        .auto-style3 {
            font-size: large;
            color: #000066;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Personas<br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">DNI</td>
                    <td>
                        <asp:TextBox ID="txtDNI" runat="server" Width="145px" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Nombres</td>
                    <td>
                        <asp:TextBox ID="txtNombres" runat="server" Width="321px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Apellidos</td>
                    <td>
                        <asp:TextBox ID="txtApellidos" runat="server" Width="321px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Nacionalidad</td>
                    <td>
                        <asp:TextBox ID="txtNacionalidad" runat="server" Width="292px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Fecha de Nacimiento</td>
                    <td>
                        <asp:Calendar ID="calendarioNacimiento" runat="server" BackColor="White" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" Width="330px" BorderStyle="Solid" CellSpacing="1" NextPrevFormat="ShortMonth">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                            <DayStyle BackColor="#CCCCCC" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="#333399" Font-Bold="True" BorderStyle="Solid" Font-Size="12pt" ForeColor="White" Height="12pt" />
                            <TodayDayStyle BackColor="#999999" ForeColor="White" />
                        </asp:Calendar>
                    </td>
                </tr>
            </table>
            <strong>
            <asp:Label ID="mensaje" runat="server" CssClass="auto-style3"></asp:Label>
            </strong>
            <br />
            <br />
            <asp:Button ID="consultar" runat="server" Text="Consultar" OnClick="consultar_Click" />
            &nbsp;<asp:Button ID="agregarPersona" runat="server" Text="Agregar" OnClick="agregarPersona_Click" />
            &nbsp;<asp:Button ID="borrarPersona" runat="server" Text="Borrar" OnClick="borrarPersona_Click" />
            &nbsp;<asp:Button ID="modificarPersona" runat="server" Text="Modificar" OnClick="modificarPersona_Click" />
            &nbsp;<asp:Button ID="limpiarPersonas" runat="server" OnClick="limpiarPersonas_Click" Text="Limpiar" />
            <br /><br />
            <asp:Label ID="mensajeNacionalidad" runat="server"></asp:Label>
            <br /><br />
        </div>
        <asp:GridView ID="GV_Personas" runat="server" AutoGenerateColumns="False" DataKeyNames="DNI" DataSourceID="SqlDataSource1" EmptyDataText="No hay registros de datos para mostrar." OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="DNI" HeaderText="DNI" InsertVisible="False" ReadOnly="True" SortExpression="DNI">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres" />
                <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                <asp:BoundField DataField="idNacionalidad" HeaderText="idNacionalidad" SortExpression="idNacionalidad" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" SortExpression="FechaNacimiento" />
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
        &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PersonasConnectionString1 %>" DeleteCommand="DELETE FROM [Personas] WHERE [DNI] = @DNI" InsertCommand="INSERT INTO [Personas] ([Nombres], [Apellidos], [FechaNacimiento], [idNacionalidad]) VALUES (@Nombres, @Apellidos, @FechaNacimiento, @idNacionalidad)" ProviderName="<%$ ConnectionStrings:PersonasConnectionString1.ProviderName %>" SelectCommand="SELECT [DNI], [Nombres], [Apellidos], [FechaNacimiento], [idNacionalidad] FROM [Personas]" UpdateCommand="UPDATE [Personas] SET [Nombres] = @Nombres, [Apellidos] = @Apellidos, [FechaNacimiento] = @FechaNacimiento, [idNacionalidad] = @idNacionalidad WHERE [DNI] = @DNI">
            <DeleteParameters>
                <asp:Parameter Name="DNI" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Nombres" Type="String" />
                <asp:Parameter Name="Apellidos" Type="String" />
                <asp:Parameter Name="FechaNacimiento" Type="DateTime" />
                <asp:Parameter Name="idNacionalidad" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Nombres" Type="String" />
                <asp:Parameter Name="Apellidos" Type="String" />
                <asp:Parameter Name="FechaNacimiento" Type="DateTime" />
                <asp:Parameter Name="idNacionalidad" Type="Int32" />
                <asp:Parameter Name="DNI" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
