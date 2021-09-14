﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="TareasHistoricas.aspx.cs" Inherits="Portafo1.TareasHistoricas" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Tareas historicas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="padre">
        <h2>Tareas terminadas y listas para su revisión</h2>
    </div>
<asp:Calendar ID="Calendar1" runat="server" style="display:none"></asp:Calendar>

    <div class="padre">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="idEjecu" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="rowDeletingEvent8">
        <Columns>
            <asp:TemplateField HeaderText="idEjecu">
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("idEjecu") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acotaciones de la tarea">
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("descripcionEje") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de entrega">
                <ItemTemplate>
                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("FechaEjec") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre de tarea">
                <ItemTemplate>
                    <asp:Label ID="Label14" runat="server" Text='<%# Bind("nombreTarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripción de la tarea">
                <ItemTemplate>
                    <asp:Label ID="Label15" runat="server" Text='<%# Bind("descripcionTarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Observación de la tarea">
                <ItemTemplate>
                    <asp:Label ID="Label16" runat="server" Text='<%# Bind("observacionTarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rut del responsable">
                <ItemTemplate>
                    <asp:Label ID="Label17" runat="server" Text='<%# Bind("personal_rut") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ButtonType="Button" ShowDeleteButton="true" DeleteText="Revisar"/>


        </Columns>
    </asp:GridView>

    </div>



<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:Button ID="Button1" runat="server" Text="Button" style="display:none"/>
    <cc1:ModalPopupExtender ID="Button1_ModalPopupExtender" runat="server" Enabled="True" TargetControlID="Button1" PopupControlID="Panel1" BackgroundCssClass="fondo" CancelControlID="equis5">
    </cc1:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server">
    <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h3 class="modal-title">Revisión</h3>
                    <button id="equis5" type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
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

    <div class="padre">
        <h2>Lista de tareas revisadas</h2>
    </div>
    <asp:GridView ID="GridView2" runat="server"></asp:GridView>

</asp:Panel>
</asp:Content>
