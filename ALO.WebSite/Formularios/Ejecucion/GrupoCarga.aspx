<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="GrupoCarga.aspx.cs" Inherits="ALO.WebSite.Formularios.Ejecucion.GrupoCarga" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- =================================================================================================================== -->
    <!-- ESTILOS                                                                                                             -->
    <!-- =================================================================================================================== -->
    <style type="text/css">
       

    </style>
    <!-- =================================================================================================================== -->
    <!-- FIN ESTILOS                                                                                                         -->
    <!-- =================================================================================================================== -->

    <!-- =================================================================================================================== -->
    <!-- SCRIPT                                                                                                              -->
    <!-- =================================================================================================================== -->
    <script type="text/javascript">

        //======================================================================================
        // LOAD PAGINA                                                                        
        //======================================================================================
        function pageLoad() {

            $(document).ready(function () {

                $(".selectpicker").selectpicker();

                //==============================================================================
                // TABLAS CON BUSCARDOR
                //==============================================================================
                $(".tablaConBuscador").DataTable({
                    "destroy": true,
                    "stateSave": true,
                    "pageLength": 10,
                    "paging": true,
                    "lengthChange": false,
                    "searching": true,
                    "ordering": true,
                    "info": true,
                    "autoWidth": false,
                    "language": {
                        "sProcessing": "Procesando...",
                        "sLengthMenu": "Mostrar _MENU_ registros",
                        "sZeroRecords": "No se encontraron resultados",
                        "sEmptyTable": "Ningún dato disponible en esta tabla",
                        "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                        "sInfoEmpty": "No se encuentran registros",
                        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                        "sInfoPostFix": "",
                        "sSearch": "Buscar :  ",
                        "sUrl": "",
                        "sInfoThousands": ",",
                        "sLoadingRecords": "Cargando...",
                        "oPaginate": {
                            "sFirst": "  Primero",
                            "sLast": "Último  ",
                            "sNext": "  Siguiente",
                            "sPrevious": "Anterior  "
                        },
                        "oAria": {
                            "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                            "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                        }
                    }
                });

            });
        }


    </script>
    <!-- =================================================================================================================== -->
    <!-- FIN SCRIPT                                                                                                          -->
    <!-- =================================================================================================================== -->


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:UpdatePanel ID="UPDATE_PANEL_CONTENEDOR" runat="server">
        <Triggers>
        </Triggers>


        <ContentTemplate>

            <%--==============================================================================================================--%>
            <%-- CONTAINER                                                                                                    --%>
            <%--==============================================================================================================--%>
            <div class="container">

                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">
                    <div class="col-sm-12">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item active">CONFIGURACIÓN DE PROCESO DE CARGA</li>
                        </ol>
                    </div>
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-offset-4 col-sm-1" style="margin-top: 10px;">
                        <asp:Label ID="Label4" runat="server" Text="CLUSTER"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="DDL_SELECT_CLUSTER" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_CLUSTER_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>

                    <div class="col-sm-1">
                        <asp:LinkButton ID="LINK_BTN_BUSCAR"
                            runat="server"
                            OnClick="BNT_BUSCAR_Click"
                            CssClass="btn btn-primary"
                            ToolTip="BUSCAR">
                               <i class='glyphicon glyphicon-search'></i>
                        </asp:LinkButton>
                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 25px;"></div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-1">
                        <asp:LinkButton ID="BNT_NUEVO_GRUPO" OnClick="BNT_NUEVO_GRUPO_Click" runat="server" CssClass="btn btn-primary" ToolTip="NUEVO GRUPO DE CARGA">
                            <i class="glyphicon glyphicon-plus" >
                        </i></asp:LinkButton>
                    </div>
                </div>

                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-12">

                        <hr />

                    </div>
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-6" style="margin-top: 20px;">
                        <h4>
                            <asp:Label ID="Label2" runat="server" Text="CONFIGURACIÓN DE PROCESO"></asp:Label></h4>
                    </div>

                </div>

                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 20px;">
                    <div class="col-sm-12">
                        <div class="table-responsive">

                            <asp:GridView ID="GRDDataGrupo" runat="server" AutoGenerateColumns="False"
                                CellPadding="4"
                                CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                ShowHeaderWhenEmpty="true"
                                OnPreRender="GRDDataGrupo_PreRender"
                                OnRowCommand="GRDDataGrupo_RowCommand">
                                <Columns>

                                    <asp:TemplateField HeaderText="OPCIONES">

                                        <ItemTemplate>

                                            <asp:LinkButton ID="LINK_Buscar"
                                                runat="server"
                                                Visible="true"
                                                CssClass="btn btn-info"
                                                CommandName="BuscarDetalle"
                                                CommandArgument='<%# Eval("ID_GRUPO_CARGA")%>'
                                                ToolTip="VER INTERFAZ DE PROCESO">
                                                <i class="glyphicon glyphicon-search"></i>                                
                                            </asp:LinkButton>

                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="GRUPO DE CARGA" ReadOnly="true" />
                                    <asp:BoundField DataField="LLAVE_LISTA_EXPLOTADOR" HeaderText="LLAVE EXPLOTACIÓN" ReadOnly="true" />
                                    <asp:BoundField DataField="LLAVE_LISTA_NOTIFICACION" HeaderText="LLAVE NOTIFICACIÓN" ReadOnly="true" />
                                    <asp:BoundField DataField="LLAVE_LISTA_VERIFICACION" HeaderText="LLAVE VERIFICACIÓN" ReadOnly="true" />                                    

                                    <asp:TemplateField HeaderText="ACCIONES">

                                        <ItemTemplate>

                                            <asp:LinkButton ID="LINK_editar"
                                                runat="server"
                                                Visible="true"
                                                CssClass='btn btn-primary'
                                                CommandName="EditarGrupo"
                                                CommandArgument='<%# Eval("ID_GRUPO_CARGA")%>'
                                                ToolTip='EDITAR'>
                                                <i class='glyphicon glyphicon-pencil'></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LINK_cargar_archivo"
                                                runat="server"
                                                Visible="true"
                                                CssClass='btn btn-primary'
                                                CommandName="CargarArchivo"
                                                CommandArgument='<%# Eval("ID_GRUPO_CARGA")%>'
                                                ToolTip='CARGAR ARCHIVO'>
                                                <i class='glyphicon glyphicon-plus'></i>                                
                                            </asp:LinkButton>

                                        </ItemTemplate>

                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>

                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-12">

                        <hr />

                    </div>
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-6" style="margin-top: 20px;">
                        <h4>
                            <asp:Label ID="Label7" runat="server" Text="INTERFACES ASIGNADAS AL PROCESO"></asp:Label></h4>
                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 20px;">
                    <div class="col-sm-12">
                        <div class="table-responsive">

                            <asp:GridView ID="GRD_INTERFAZ" runat="server" AutoGenerateColumns="False"
                                CellPadding="4"
                                CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                ShowHeaderWhenEmpty="true"
                                OnRowCommand="GRD_INTERFAZ_RowCommand"
                                OnPreRender="GRD_INTERFAZ_PreRender">
                                <Columns>

                                    <asp:BoundField DataField="CODIGO_INTERFAZ" HeaderText="CODIGO INTERFAZ" ReadOnly="true" />
                                    <asp:BoundField DataField="FILENAME" HeaderText="ARCHIVO" ReadOnly="true" />

                                    <asp:TemplateField HeaderText="ESTADO ARCHIVO">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LINK_BTN_ARCHIVO"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_EJECUCION") == 0) ? true : false %>'
                                                CssClass="btn btn-danger"
                                                CommandArgument='<%# Eval("ID_INTERFAZ") +";" + Eval("ID_GRUPO_CARGA") %>'
                                                ToolTip="SIN ARCHIVO">
                                                <i class='glyphicon glyphicon-floppy-remove'></i>
                                            </asp:LinkButton>

                                            <asp:Label ID="Label9" runat="server" Text="SIN ARCHIVO" Visible='<%# ((int)Eval("ID_EJECUCION") == 0) ? true : false %>'></asp:Label>

                                            <asp:LinkButton ID="LINK_BTN_ARCHIVO2"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_EJECUCION") == 0) ? false : true %>'
                                                CssClass="btn btn-primary"
                                                CommandArgument='<%# Eval("ID_INTERFAZ") +";" + Eval("ID_GRUPO_CARGA") %>'
                                                ToolTip="ARCHIVO CARGADO">
                                                <i class='glyphicon glyphicon-floppy-saved'></i>
                                            </asp:LinkButton>
                                            <asp:Label ID="Label7" runat="server" Text="ARCHIVO CARGADO" Visible='<%# ((int)Eval("ID_EJECUCION") == 0) ? false : true %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="ACCIONES">

                                        <ItemTemplate>

                                            <asp:LinkButton ID="LINK_BTN_SUBIR_ARCHIVO"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_EJECUCION") == 0) ? true : false %>'
                                                CssClass="btn btn-primary"
                                                CommandName="subirArchivo"
                                                CommandArgument='<%# Eval("ID_INTERFAZ") +";" + Eval("ID_GRUPO_CARGA") +";" + Eval("ID_EJECUCION") %>'
                                                ToolTip="SUBIR ARCHIVO DE CARGA">
                                                <i class='glyphicon glyphicon-cloud-upload'></i>
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LinkButton1"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_EJECUCION") == 0) ? false : true %>'
                                                CssClass="btn btn-danger"
                                                CommandName="quitarArchivo"
                                                CommandArgument='<%# Eval("ID_INTERFAZ") +";" + Eval("ID_GRUPO_CARGA") +";" + Eval("ID_EJECUCION")%>'
                                                ToolTip="QUITAR ARCHIVO DE CARGA">
                                                <i class='glyphicon glyphicon-erase'></i>
                                            </asp:LinkButton>

                                        </ItemTemplate>

                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 25px;"></div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
            </div>
            <%--==============================================================================================================--%>
            <%-- FIN CONTAINER                                                                                                --%>
            <%--==============================================================================================================--%>
        </ContentTemplate>


    </asp:UpdatePanel>

    <%--==============================================================================================================--%>
    <%-- INICIO MODAL GRUPO_CARGA                                                                                     --%>
    <%--==============================================================================================================--%>
    <div class="modal fade" id="MODAL_GRUPO_CARGA" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_GRUPO_CARGA" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-tasks" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_GRUPO_CARGA" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_GRUPO_CARGA" class="alert alert-warning" style="display: none;"></div>
                            <div style="height: 10px"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>


                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row">
                                <asp:TextBox ID="TXT_ID_GRUPO_CARGA_MODAL" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="TXT_ID_CLUSTER_MODAL" runat="server" Visible="false"></asp:TextBox>
                            </div>

                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row" style="margin-top: 10px;"></div>
                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row">

                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label5" runat="server" Text="DESCRIPCION" CssClass="control-label"></asp:Label>
                                        <asp:TextBox runat="server" ID="TXT_DESCRIPCION" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="LLAVE LISTA EXPLOTACIÓN" CssClass="control-label"></asp:Label>
                                        <asp:TextBox runat="server" ID="TXT_LLAVE_EXPLOTACION" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label3" runat="server" Text="LLAVE LISTA NOTIFICACIÓN" CssClass="control-label"></asp:Label>
                                        <asp:TextBox runat="server" ID="TXT_LLAVE_NOTIFICACION" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label6" runat="server" Text="LLAVE LISTA VERIFICACIÓN" CssClass="control-label"></asp:Label>
                                        <asp:TextBox runat="server" ID="TXT_LLAVE_VERIFICACION" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>


                            </div>

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div style="height: 10px"></div>
                            <div id="MSG_INFO_GRUPO_CARGA" class="alert alert-info" style="display: none;"></div>


                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BTN_GRUPO_CARGA" runat="server"
                                Text=""
                                OnClick="BTN_GRUPO_CARGA_Click"
                                CssClass="btn btn-primary"
                                data-backdrop="static" />
                        </div>
                    </div>
                    <!-- FIN Modal content -->

                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_GRUPO_CARGA" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--==============================================================================================================--%>
    <%-- FIN MODAL CREAR GRUPO_CARGA                                                                                  --%>
    <%--==============================================================================================================--%>


    <%--==============================================================================================================--%>
    <%-- CARGAR ARCHIVO EN GRILLA                                                                                          --%>
    <%--==============================================================================================================--%>
    <div class="modal fade" id="MODAL_ARCHIVO" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_ARCHIVO" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">


                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-menu-hamburger"></i>
                                <asp:Label ID="LBL_TITULO_ARCHIVO" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_ARCHIVO" class="alert alert-warning" style="display: none;"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <form>
                                <%--*********************************************************************************************--%>
                                <%--*********************************************************************************************--%>
                                <div class="row">
                                    <asp:TextBox ID="TXT_ID_GRUPO_CARGA" runat="server" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="TXT_ID_CLUSTER" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <%--*********************************************************************************************--%>
                                <%--*********************************************************************************************--%>

                                <div class="row" style="height: 10px"></div>
                                <%--*********************************************************************************************--%>
                                <%--*********************************************************************************************--%>
                                <div class="row">

                                    <div class="col-sm-1" style="margin-top: 10px;">
                                        <asp:Label ID="Label10" runat="server" Text="INTERFAZ"></asp:Label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="DDL_INTERFAZ" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_INTERFAZ_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>

                                    <div class="col-md-2">
                                        <asp:LinkButton ID="LINK_SUBIR_ARCHIVO"
                                            runat="server"
                                            CssClass="btn btn-primary"
                                            ToolTip="SUBIR ARCHIVO DE CARGA"
                                            OnClick="BTN_CARGA_ARCHIVO_Click">
                                                <i class='glyphicon glyphicon-cloud-upload'></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <%--*********************************************************************************************--%>
                                <%--*********************************************************************************************--%>
                                <div class="row" style="height: 10px"></div>
                                <%--*********************************************************************************************--%>
                                <%--*********************************************************************************************--%>
                            </form>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_INFO_ARCHIVO" class="alert alert-info" style="display: none;"></div>


                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                    <!-- FIN Modal content-->


                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="LINK_SUBIR_ARCHIVO" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <%--==============================================================================================================--%>
    <%-- FIN CARGAR ARCHIVO EN GRILLA                                                                                      --%>
    <%--==============================================================================================================--%>
</asp:Content>

