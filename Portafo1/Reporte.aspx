<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="Portafo1.Reporte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
    <h3>Reporte por funcionario</h3>
    <br />
    Seleccione el rut del funcionario
            <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="ObjectDataSource4" DataTextField="nombre" DataValueField="nombre">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="listarRutsAso" TypeName="Portafo1.Negocio.NombreProcesoBLL">
            <SelectParameters>
                <asp:SessionParameter Name="rut" SessionField="rut" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    <br />
    ingrese el año: 
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    Ingrese el mes: 
    <asp:DropDownList ID="DropDownList8" runat="server">
        <asp:ListItem>01</asp:ListItem>
        <asp:ListItem>02</asp:ListItem>
        <asp:ListItem>03</asp:ListItem>
        <asp:ListItem>04</asp:ListItem>
        <asp:ListItem>05</asp:ListItem>
        <asp:ListItem>06</asp:ListItem>
        <asp:ListItem>07</asp:ListItem>
        <asp:ListItem>08</asp:ListItem>
        <asp:ListItem>09</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
                <asp:Button ID="Button1" runat="server" Text="Generar reporte por funcionario" OnClick="Button1_Click1" class="btn btn-primary"/>

    <br />
        </div>
    </form>
</body>
</html>
