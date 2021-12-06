<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="TareasHistoricas.aspx.cs" Inherits="Portafo1.TareasHistoricas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Tareas historicas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="padre" style="margin-bottom: 40px">
        <h2 class="display-3">Tareas terminadas y listas para su revisión</h2>
    </div>
    <asp:Calendar ID="Calendar1" runat="server" Style="display: none"></asp:Calendar>

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

                <asp:CommandField ButtonType="Button" ShowDeleteButton="true" DeleteText="Revisar" />


            </Columns>
        </asp:GridView>

    </div>


    <div class="padre">
        <h2 class="display-3" style="margin-bottom: 40px">Lista de tareas rechazadas</h2>
        <p class="display-3" style="margin-bottom: 5px">&nbsp;</p>
    </div>

    <asp:Panel ID="Panel2" runat="server">
        <div class="padre">

        </div>

        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title">Reasignación de tarea</h3>
                </div>
                <div class="modal-body">
            <asp:Label ID="Label1" runat="server" Text="Id de la tarea a reasignar:   "></asp:Label>

            <asp:Label ID="Label88" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label302" runat="server" Text="Seleccione el rut del funcionario:   "></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource4" DataTextField="nombre" DataValueField="nombre"></asp:DropDownList>
            <br />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button3" runat="server" Text="Reasignar" OnClick="Button3_Click" BackColor="#CCFF66" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Cancelar" BackColor="#FF0066" OnClick="Button2_Click" />
            <br />
                </div>
            </div>
        </div>
        
    </asp:Panel>
    <div class="padre">

    <asp:Label ID="Label2" runat="server" Text="Tarea reasignada correctamente" BackColor="#CCFF99"></asp:Label>
    </div>
    <br />
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="listarRutsAso" TypeName="Portafo1.Negocio.NombreProcesoBLL">
            <SelectParameters>
                <asp:SessionParameter Name="rut" SessionField="rut" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>

    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="idEjecu" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GridView3_PageIndexChanging" OnRowDeleting="GridView3_RowDeleting" OnSelectedIndexChanged="GridView3_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="idEjecu">
                <ItemTemplate>
                    <asp:Label ID="Label21" runat="server" Text='<%# Bind("idEjecu") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Acotaciones de la tarea">
                <ItemTemplate>
                    <asp:Label ID="Label22" runat="server" Text='<%# Bind("descripcionEje") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de entrega">
                <ItemTemplate>
                    <asp:Label ID="Label23" runat="server" Text='<%# Bind("FechaEjec") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre de tarea">
                <ItemTemplate>
                    <asp:Label ID="Label24" runat="server" Text='<%# Bind("nombreTarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripción de la tarea">
                <ItemTemplate>
                    <asp:Label ID="Label25" runat="server" Text='<%# Bind("descripcionTarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Observación de la tarea">
                <ItemTemplate>
                    <asp:Label ID="Label26" runat="server" Text='<%# Bind("observacionTarea") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rut del responsable">
                <ItemTemplate>
                    <asp:Label ID="Label27" runat="server" Text='<%# Bind("personal_rut") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ButtonType="Button" ShowDeleteButton="true" DeleteText="Reasignar tarea" />


        </Columns>
    </asp:GridView>
    <script>        
        function preventAction(e) {
            e.preventDefault();
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Button ID="Button1" runat="server" Text="Señor boton" style="visibility:hidden"/>

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
                    <asp:Button ID="Button5" runat="server" Text="Enviar" class="btn btn-primary" OnClick="Button5_Click" />
                </div>
            </div>
        </div>

        [_*
    </asp:Panel>



</asp:Content>
