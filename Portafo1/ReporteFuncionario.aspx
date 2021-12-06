<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteFuncionario.aspx.cs" Inherits="Portafo1.ReporteFuncionario"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
</head>
<body>
    <form id="form1" runat="server">
                            <div>
            <asp:Chart ID="Chart1" runat="server">
                <Series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

        </div>
        <asp:Panel ID="descargarPDF" runat="server">
            <h1>hola</h1>
            <img src="imgs/logo.jpg" />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  DataKeyNames="idEjecu" CssClass="table table-striped table-bordered table-hover">
        <Columns>
            <asp:TemplateField HeaderText="idEjecu">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("idEjecu") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Acotación del encargado">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("descripcionEje") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de inicio">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("fechainicio") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de termino">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("fechaTermino") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rut del asignador de tarea">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("adjudicador") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tipo de tarea">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("tipotarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre de la tarea">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("nombreTarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripción de la tarea">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("descripcionTarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Observaciones">
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("observacionTarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        </asp:Panel>

         <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

    </form>
</body>
</html>
