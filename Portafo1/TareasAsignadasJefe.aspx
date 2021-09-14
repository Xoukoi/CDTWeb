<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="TareasAsignadasJefe.aspx.cs" Inherits="Portafo1.TareasAsignadasJefe" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="padre">
        <h2>Nuevas tareas asignadas</h2>
    </div>
    <asp:Calendar ID="Calendar1" runat="server" style="display:none"></asp:Calendar>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="idEjecu" CssClass="table table-striped table-bordered table-hover" OnRowDeleting="rowDeletingEvent" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
            <asp:CommandField ButtonType="Button" ShowDeleteButton="true" DeleteText="Aceptar/rechazar"/>
        </Columns>
    </asp:GridView>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:Button ID="Button1" runat="server" Text="Button" style="display:none"/>
    <cc1:ModalPopupExtender ID="Button1_ModalPopupExtender" runat="server" Enabled="True" TargetControlID="Button1" PopupControlID="Panel1" BackgroundCssClass="fondo" CancelControlID="equis">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server">
        <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h3 class="modal-title">Seleccione una opción</h3>
                    <button id="equis" type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                    <p>Aceptar o rechazar tarea asignada</p>
                      
                  </div>
                  <div class="modal-footer">
                      <asp:Button ID="Button3" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="Button3_Click"/>
                      <asp:Button ID="Button4" runat="server" Text="Rechazar" class="btn btn-danger" OnClick="Button4_Click"/>

                      <br />
                      <asp:Label ID="Label11" runat="server" Text=""></asp:Label>

                      <br />

                      <br />

                      <asp:Label ID="Label10" runat="server" Text="Argumente el motivo del rechazo"></asp:Label>
                      &nbsp;<asp:TextBox ID="TextBoxrazonrechazo" runat="server" Height="22px" style="margin-top: 0px" Width="276px"></asp:TextBox>
                  </div>
                </div>
              </div>
    </asp:Panel>
    <div class="padre">
        <h2>-------------------------------------------------------------------------------------</h2>
        <h2>Tareas en ejecución</h2>
    </div>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="idEjecu" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDeleting="rowDeletingEvent2" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="idEjecu">
                <ItemTemplate>
                    <asp:Label ID="Label20" runat="server" Text='<%# Bind("idEjecu") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acotación del encargado">
                <ItemTemplate>
                    <asp:Label ID="Label21" runat="server" Text='<%# Bind("descripcionEje") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de inicio">
                <ItemTemplate>
                    <asp:Label ID="Label22" runat="server" Text='<%# Bind("fechaInicio") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de término">
                <ItemTemplate>
                    <asp:Label ID="Label23" runat="server" Text='<%# Bind("fechaTermino") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de aceptación">
                <ItemTemplate>
                    <asp:Label ID="Label24" runat="server" Text='<%# Bind("FechaEjec") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Proximidad a la fecha de término">
                <ItemTemplate>
                    <asp:Label ID="Label25" runat="server" Text='<%# Bind("semaforo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre tarea">
                <ItemTemplate>
                    <asp:Label ID="Label26" runat="server" Text='<%# Bind("nombreTarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripción de tarea">
                <ItemTemplate>
                    <asp:Label ID="Label27" runat="server" Text='<%# Bind("descripcionTarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Observaciones">
                <ItemTemplate>
                    <asp:Label ID="Label28" runat="server" Text='<%# Bind("observacionTarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ButtonType="Button" ShowDeleteButton="true" DeleteText="Informar sobre tarea" />

        </Columns>
    </asp:GridView>

    <asp:Button ID="Button2" runat="server" Text="Button" style="display:none"/>

    <cc1:ModalPopupExtender ID="Button2_ModalPopupExtender" runat="server"  Enabled="True" TargetControlID="Button2" PopupControlID="Panel2" BackgroundCssClass="fondo" CancelControlID="equis4">
    </cc1:ModalPopupExtender>

    <asp:Panel ID="Panel2" runat="server">
        <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h3 class="modal-title">Reportar</h3>
                    <button id="equis4" type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                      <asp:Label ID="Label300" runat="server" Text="Seleccione una opcion"></asp:Label>

                      &nbsp;
                      <asp:DropDownList ID="DropDownList1" runat="server">
                          <asp:ListItem>Terminada</asp:ListItem>
                          <asp:ListItem>Problema</asp:ListItem>
                      </asp:DropDownList>
                      <br />
                      <br />
                      <asp:Label ID="Label12" runat="server" Text="Comentario: "></asp:Label>
                      &nbsp;&nbsp;
                      <asp:TextBox ID="TextBoxcomentario" runat="server"></asp:TextBox>
                      <br />
                      <br />
                      <asp:Label ID="Label301" runat="server" ForeColor="#FF3300"></asp:Label>
                  </div>
                  <div class="modal-footer">
                      <asp:Button ID="Button5" runat="server" Text="Enviar" class="btn btn-primary" OnClick="Button5_Click"/>
                  </div>
                </div>
              </div>
    </asp:Panel>

</asp:Content>
