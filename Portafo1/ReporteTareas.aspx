<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ReporteTareas.aspx.cs" Inherits="Portafo1.ReporteTareas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
            <br />
        <div class="padre">
                    <h1>Reporte de rendimiento por empleado</h1>
    </div>
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
            <asp:DropDownList ID="DropDownList9" runat="server">
                <asp:ListItem>2021</asp:ListItem>
            </asp:DropDownList>
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
            <br />
             <div class="padre">
                    <h1>Listado de personal a su cargo</h1>
    </div>
    <br />

             <div style="width:100%">
                    <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" AllowPaging="false" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="RUT" CssClass="table table-striped table-bordered table-hover">
                <Columns>
            <asp:TemplateField HeaderText="RUT ">
                <ItemTemplate>
                    <asp:Label ID="Label31" runat="server" Text='<% # Bind("RUT") %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre ">
                <ItemTemplate>
                    <asp:Label ID="Label32" runat="server" Text='<% # Bind("NOMBRE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido paterno ">
                <ItemTemplate>
                    <asp:Label ID="Label33" runat="server" Text='<% # Bind("APEPATE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Correo ">
                <ItemTemplate>
                    <asp:Label ID="Label34" runat="server" Text='<% # Bind("CORREO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cargo ">
                <ItemTemplate>
                    <asp:Label ID="Label35" runat="server" Text='<% # Bind("CARGO") %>' style="width:400px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

        </asp:GridView>
    </div>
        </div>
</asp:Content>
