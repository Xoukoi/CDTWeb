<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="TareasPorFuncionario.aspx.cs" Inherits="Portafo1.TareasPorFuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="idEjecu" CssClass="table table-striped table-bordered table-hover" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("fechaInicio") %>'></asp:Label>
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







    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
      google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawVisualization);

      function drawVisualization() {
        // Some raw data (not necessarily accurate)
        var data = google.visualization.arrayToDataTable([
          ['Month', 'En desarrollo', 'Rechazada', 'Entregadas a tiempo', 'Atrasadas'],
            ['Tipo de tarea',  <%=obtener()%>,      <%=obtener2()%>,         <%=obtener3()%>,             <%=obtener4()%>]
        ]);

        var options = {
          title : 'Reporte de tareas',
          vAxis: {title: 'Cantidad'},
          hAxis: {title: 'Tareas'},
          seriesType: 'bars',
          series: {5: {type: 'line'}}
        };

        var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));
        chart.draw(data, options);
      }
    </script>
    <div id="chart_div" style="width: 900px; height: 500px;"></div>
    <br />
    <asp:Panel ID="descargarPDF" runat="server">
        <div class="padre">
        <h2>Información del empleado</h2>
            <h3>Fecha y hora actual: <%=dia()%> / <%=hora()%></h3>
            <br />
    </div>
    <h5>Mes del reporte: <%=mes()%>-<%=ano()%></h5>
    <h5>Nombre : <%=nombre()%></h5>
    <h5>Apellido : <%=apellido()%></h5>
    <h5>Correo : <%=correo()%></h5>
    <h5>Cantidad de tareas en desarrollo : <%=obtener()%></h5>
    <h5>Cantidad de tareas rechazadas : <%=obtener2()%></h5>
    <h5>Cantidad de tareas entregadas dentro del plazo : <%=obtener3()%></h5>
    <h5>Cantidad de tareas entregadas fuera del plazo : <%=obtener4()%></h5>

    <br />
    <br />
    </asp:Panel>
        
    <asp:Button ID="Button1" runat="server" Text="Descargar informe PDF" class="btn btn-primary" OnClick="Button1_Click"/>
     <br />
    </asp:Content>
