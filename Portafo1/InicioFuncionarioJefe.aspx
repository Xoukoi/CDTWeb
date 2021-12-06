<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="InicioFuncionarioJefe.aspx.cs" Inherits="Portafo1.TareasAsociadas" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtId" runat="server" Visible="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button5" runat="server" Text="Limpiar" OnClick="Button5_Click" Visible="False" />
    <br />
    <asp:Label ID="lbliderr" runat="server" ForeColor="#FF3300"></asp:Label>
<br />
&nbsp;

    <asp:Button ID="Buttonasignar" runat="server" Text="Asignar tarea a funcionario" class="btn btn-info btn-lg btn-block" OnClick="Buttonasignar_Click"/>
    <cc1:ModalPopupExtender ID="Buttonasignar_ModalPopupExtender" runat="server" Enabled="True" TargetControlID="Buttonasignar" PopupControlID="Panel3" BackgroundCssClass="fondo" CancelControlID="equis6">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="Panel3" runat="server">
                    <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h3 class="modal-title">Asignar Tarea a un funcionario</h3>
                    <button id="equis6" type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                    <p>
    <asp:Label ID="Label1" runat="server" Text="Descripción"></asp:Label>
&nbsp;&nbsp;
    <asp:TextBox ID="texdescip" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Seleccionar fecha de inicio"></asp:Label>
    </p>
    <p>
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" >
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
        <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged">
        </asp:Calendar>
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
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="listarIdTareas" TypeName="Portafo1.Negocio.IdTareasBLL">
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

                  <asp:Label ID="Label36" runat="server" BackColor="Red" BorderColor="Black"></asp:Label>

                  </div>
                  <div class="modal-footer">
                      <asp:Button ID="Button2" runat="server" Text="Asignar Tarea" OnClick="Button2_Click2" class="btn btn-primary"/>
                      <asp:Button ID="Button3" runat="server" Text="Cancelar" OnClick="Button3_Click1" CssClass="btn btn-danger"/>
                  </div>
                </div>
              </div>
    </asp:Panel>
    <asp:Button ID="Button1" runat="server" Text="Buscar para modificar o eliminar" OnClick="Button1_Click" Visible="False" />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:Button ID="Button9" runat="server" class="btn btn-primary btn-lg btn-block" Text="Agregar nueva tarea" OnClick="Button9_Click" />
    <cc1:ModalPopupExtender ID="Button9_ModalPopupExtender" runat="server" Enabled="True" TargetControlID="Button9" PopupControlID="Panel2" BackgroundCssClass="fondo" CancelControlID="equis2">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="Panel2" runat="server">
                    <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h2 class="modal-title">Agregar nueva tarea</h2>
                      <p class="modal-title">
                          
                      </p>
                    <button id="equis2" type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                      <br />

    Nombre de la tarea&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtNombre" runat="server" OnTextChanged="txtNombre_TextChanged" class="form-control"></asp:TextBox>
    <br />
    <br />
    Descripción&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtDesc" runat="server" class="form-control"></asp:TextBox>
    <br />
    <br />
    Observación&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtObse" runat="server" class="form-control"></asp:TextBox>
    <br />
    <br />
     Id de tarea padre&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownListTareaPadr" runat="server" DataSourceID="ObjectDataSource2" DataTextField="idTarea" DataValueField="idTarea" OnSelectedIndexChanged="DropDownListTareaPadr_SelectedIndexChanged" CssClass="form-control">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="listarIdTareas" TypeName="Portafo1.Negocio.IdTareasBLL">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="Session[&quot;rut&quot;].ToString()" Name="rut" SessionField="rut" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:CheckBox ID="CheckBox1" runat="server" Text="Tarea sin Tarea Padre" CssClass="form-control"/>
    <br />
    <br />
    Flujo&nbsp;&nbsp; &nbsp;<asp:DropDownList ID="DropDownListproce" runat="server" DataSourceID="ObjectDataSource1" DataTextField="nombre" DataValueField="nombre" CssClass="form-control">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="listarNombresProceso" TypeName="Portafo1.Negocio.NombreProcesoBLL" ></asp:ObjectDataSource>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<br />
    <br />
                  <asp:Label ID="Labelconfirtar" runat="server" ForeColor="#009933" Visible="False"></asp:Label>    
                      <br />
                      <asp:Label ID="Labelerrotar" runat="server" ForeColor="#FF3300" Visible="False"></asp:Label>
                  </div>
                  <div class="modal-footer">
                      <asp:Button ID="Button4" runat="server" Text="Agregar" OnClick="Button4_Click" CssClass="btn btn-primary"/>

                      <asp:Button ID="Button11" runat="server" Text="Cancelar" class="btn btn-danger"/>
                  </div>
                </div>
              </div>
    </asp:Panel>
    <br />
<br />
    <div class="padre">
        <h2>Tareas Disponibles</h2>
    </div>

    <br />

    <div style="width:100%">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCancelingEdit="roeCancelEditEvent" OnRowDeleting="rowDeletingEvent" OnRowEditing="rowEditingEvent" OnRowUpdating="rowUpdatingEvent" DataKeyNames="IDTAREA" CssClass="table table-striped table-bordered table-hover" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:TemplateField HeaderText="ID DE TAREA">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<% # Bind("IDTAREA") %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TIPO">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<% # Bind("TIPOTAREA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="NOMBRE">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<% # Bind("NOMBRETA") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxnombre" runat="server" Text='<% # Bind("NOMBRETA") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DESCRIPCIÓN">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<% # Bind("DESCRIPCION") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxDescripcion" runat="server" Text='<% # Bind("DESCRIPCION") %>' style="width:400px"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Observación">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<% # Bind("Observacion") %>' style="width:400px"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxObser" runat="server" Text='<% # Bind("Observacion") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rut del creador">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<% # Bind("adjudicador") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id de tarea madre">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<% # Bind("TAREA_IDTAREA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Proceso al que pertenece">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<% # Bind("nombreProce") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:CommandField ButtonType="Button" ShowEditButton="true"/>
            <asp:CommandField ButtonType="Button" ShowDeleteButton="true"/>
            
            
                     
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
    </div>


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <br />

    <asp:Button ID="Button6" runat="server" Text="cargar" style="display:none"/>

    <cc1:ModalPopupExtender ID="Button6_ModalPopupExtender" runat="server" Enabled="True" TargetControlID="Button6" PopupControlID="Panel1" BackgroundCssClass="fondo" CancelControlID="equis">
    </cc1:ModalPopupExtender>
    <div class="padre">
        <h2>Funcionarios disponibles</h2>
    </div>
    
    <br />
    <div style="width:100%">
                    <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="RUT" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GridView7_PageIndexChanging">
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


    <asp:Panel ID="Panel1" runat="server">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title">Eliminar</h5>
                    <button id="equis" type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                    <p>¿Seguro de eliminar?</p>
                  </div>
                  <div class="modal-footer">
                      <asp:Button ID="Button7" runat="server" Text="Si" class="btn btn-danger" OnClick="Button7_Click1"/>
                      <asp:Button ID="Button8" runat="server" Text="No" CssClass="btn btn-primary"/>
                  </div>
                </div>
              </div>
    </asp:Panel>
<br />
&nbsp; 
    </asp:Content>
