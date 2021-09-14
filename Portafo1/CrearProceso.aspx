<%@ Page Title="" Language="C#" MasterPageFile="~/HomeDiseñador.Master" AutoEventWireup="true" CodeBehind="CrearProceso.aspx.cs" Inherits="Portafo1.CrearProceso" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <br />
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Button ID="Button1" runat="server" Text="Agregar Flujo de trabajo" class="btn btn-info btn-lg btn-block"/>
    <cc1:ModalPopupExtender ID="Button1_ModalPopupExtender" runat="server" Enabled="True" TargetControlID="Button1" PopupControlID="Panel1" BackgroundCssClass="fondo" CancelControlID="equis">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server">
                    <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h2 class="modal-title">Agregar nuevo flujo de trabajo</h2>
                    <button id="equis" type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                    <br />

    <asp:Label runat="server" Text="Descripción"></asp:Label>
    <asp:TextBox runat="server" ID="txtdesc" ></asp:TextBox>
    <br />
    <br />
    <asp:Label runat="server" Text="Nombre Proceso"></asp:Label>
    <asp:TextBox runat="server" ID="txtnom" placeholder="llene este campo" ></asp:TextBox>
    <br />
    <br />
    <asp:Label runat="server" Text="Fecha inicio"></asp:Label>
    <asp:Calendar runat="server" ID="fechaI" OnSelectionChanged="fechaI_SelectionChanged"></asp:Calendar>
    <br />
    <br />
    <asp:Label runat="server" Text="Fecha término"></asp:Label>
    <asp:Calendar runat="server" ID="fechaT" OnSelectionChanged="fechaT_SelectionChanged"></asp:Calendar>
    <br />
    <br />

     <p>
        <asp:Label ID="lblcalendarios" runat="server" ForeColor="Red"></asp:Label>
    </p>

    <p>
        <asp:Label ID="lblcalendarios1" runat="server" ForeColor="Red"></asp:Label>
    </p>


    <asp:Label runat="server" Text="Unidad Interna" ID="Label5"></asp:Label>
    <asp:TextBox runat="server" ID="txtU"></asp:TextBox>
                  </div>
                  <div class="modal-footer">
                      <asp:Button runat="server" Text="Crear" OnClick="GuardarProce" class="btn btn-primary"/>
                  </div>
                </div>
              </div>
    </asp:Panel>



    <br />
    <br />
    <br />

    <asp:Button ID="Button2" runat="server" Text="Agregar tareas a Flujo" class="btn btn-success btn-lg btn-block" OnClick="Button2_Click"/>

    <cc1:ModalPopupExtender ID="Button2_ModalPopupExtender" runat="server" Enabled="True" TargetControlID="Button2" PopupControlID="Panel2" BackgroundCssClass="fondo" CancelControlID="equis4">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="Panel2" runat="server">
                            <div class="modal-dialog" role="document">
                <div class="modal-content">
                  <div class="modal-header">
                    <h2 class="modal-title">Agregar nueva tarea</h2>
                      <p class="modal-title">
                          
                      </p>
                    <button id="equis4" type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div class="modal-body">
                      <br />

    Nombre de la tarea&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
    <br />
    <br />
    Descripción&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox14" runat="server" class="form-control"></asp:TextBox>
    <br />
    <br />
    Observación&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtObse" runat="server" class="form-control"></asp:TextBox>
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

                      
                  </div>
                </div>
              </div>
    </asp:Panel>

        <br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="IDPROCESO" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="rowCancelEditEvent" OnRowDeleting="rowDeletingEvent" OnRowEditing="rowEditingEvent" OnRowUpdating="rowUpdatingEvent" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="IDPROCESO">
                <ItemTemplate>
                    <asp:Label ID="Label41" runat="server" Text='<%# Bind("IDPROCESO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripción">
                <ItemTemplate>
                    <asp:Label ID="Label42" runat="server" Text='<%# Bind("DESCRIPCION") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxDescrippp" runat="server" Text='<%# Bind("DESCRIPCION") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre">
                <ItemTemplate>
                    <asp:Label ID="Label43" runat="server" Text='<%# Bind("NOMBREPROCESO") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxNombreee" runat="server" Text='<%# Bind("NOMBREPROCESO") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de inicio">
                <ItemTemplate>
                    <asp:Label ID="Label44" runat="server" Text='<%# Bind("FECHAINIT") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de termino">
                <ItemTemplate>
                    <asp:Label ID="Label45" runat="server" Text='<%# Bind("FECHATER") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unidad a la que pertenece">
                <ItemTemplate>
                    <asp:Label ID="Label46" runat="server" Text='<%# Bind("UNIDADINT") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" />

        </Columns>
    </asp:GridView>
    <br />
    
    <%--<asp:Button runat="server" Text="Modificar" OnClick="ModificarProce" />--%>
    <br />
    <br />
    
</asp:Content>
