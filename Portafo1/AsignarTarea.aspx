<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AsignarTarea.aspx.cs" Inherits="Portafo1.AsignarTarea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Asignar tarea</h1>
<p>
    <asp:Label ID="Label1" runat="server" Text="Descripción"></asp:Label>
&nbsp;&nbsp;
    <asp:TextBox ID="TextBoxDescr" runat="server" OnTextChanged="TextBoxDescr_TextChanged"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Seleccionar fecha de inicio"></asp:Label>
    </p>
    <p>
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="107px" Width="209px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Seleccionar fecha final"></asp:Label>
    </p>
    <p>
        <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="90px" Width="227px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Seleccionar rut de funcionario a cargo"></asp:Label>
    &nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="ObjectDataSource4" DataTextField="nombre" DataValueField="nombre">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="listarRutsAso" TypeName="Portafo1.Negocio.NombreProcesoBLL">
            <SelectParameters>
                <asp:SessionParameter Name="rut" SessionField="rut" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <p>
        <asp:Label ID="Label5" runat="server" Text="Seleccionar tarea"></asp:Label>
    &nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList8" runat="server" DataSourceID="ObjectDataSource2" DataTextField="idTarea" DataValueField="idTarea">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="listarIdTareas" TypeName="Portafo1.Negocio.IdTareasBLL">
            <SelectParameters>
                <asp:SessionParameter Name="rut" SessionField="rut" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <p>
        <asp:Label ID="lblcalendarios" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Label ID="labeldatoono" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblexito" runat="server" ForeColor="#33CC33"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Asignar" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
    </p>
<p>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</p>
    <p>
    &nbsp;&nbsp;
        <asp:GridView ID="GridView7" runat="server">
        </asp:GridView>
</p>
        
</asp:Content>
