<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AsignacionPlanificacion.aspx.cs" Inherits="ALO.WebSite.Formularios.Ejecucion.AsignacionPlanificacion" %>

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

                $(".tablaConBuscador").DataTable({
                    "destroy": true,
                    "stateSave": true,
                    "pageLength": 5,
                    "paging": true,
                    "lengthChange": false,
                    "searching": true,
                    "ordering": true,
                    "info": true,
                    "autoWidth": false,
                    "iDisplayLength": 1,
                    "aaSorting": [[1, "asc"]],
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


            //==============================================================================
            // CALENDARIO JQUERY                                           
            //==============================================================================
            $("#<%=TXT_FECHA_INI.ClientID%>").datepicker({
                showOn: 'button',
                dateFormat: 'd-mm-yy',
                buttonImageOnly: true,
                buttonImage: '<%=UrlWeb("~/IMAGES/date.png")%>'
            });


            //==============================================================================
            // CALENDARIO JQUERY                                           
            //==============================================================================
            $("#<%=TXT_FECHA_FIN.ClientID%>").datepicker({
                showOn: 'button',
                dateFormat: 'd-mm-yy',
                buttonImageOnly: true,
                buttonImage: '<%=UrlWeb("~/IMAGES/date.png")%>'
            });
        }

    </script>
    <!-- =================================================================================================================== -->
    <!-- FIN SCRIPT                                                                                                          -->
    <!-- =================================================================================================================== -->


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UPDATE_PANEL_CONTENEDOR" runat="server">
        <ContentTemplate>


            <%--==============================================================================================================--%>
            <%-- CONTAINER                                                                                                    --%>
            <%--==============================================================================================================--%>
            <div class="container">

                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">
                    <div class="col-sm-12" style="margin-top: 20px;">

                        <ol class="breadcrumb">
                            <li class="breadcrumb-item active">ASIGNACIÓN DE CAMPOS PARA PLANIFICACIÓN </li>
                        </ol>

                    </div>
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 25px;"></div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-offset-2 col-sm-1" style="margin-top: 10px;">
                        <asp:Label ID="Label4" runat="server" Text="CLUSTER"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="DDL_SELECT_CLUSTER" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_CLUSTER_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>

                    <div class="col-sm-1" style="margin-top: 10px;">
                        <asp:Label ID="Label7" runat="server" Text="INTERFAZ"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="DDL_INTERFAZ" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_INTERFAZ_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 25px;"></div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GRD_EJECUCIONES" runat="server" AutoGenerateColumns="False"
                                CellPadding="4"
                                CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                ShowHeaderWhenEmpty="true"
                                OnPreRender="GRD_EJECUCIONES_PreRender"
                                OnRowCommand="GRD_EJECUCIONES_RowCommand">

                                <Columns>

                                    <asp:TemplateField HeaderText="OPCIONES">

                                        <ItemTemplate>

                                            <asp:LinkButton ID="LINK_buscar"
                                                runat="server"
                                                Visible="true"
                                                CssClass='btn btn-info'
                                                CommandName="Buscar"
                                                CommandArgument='<%# Eval("ID_INTERFAZ")%>'
                                                ToolTip='CARGAR ARCHIVO'>
                                                <i class='glyphicon glyphicon-search'></i>                                
                                            </asp:LinkButton>

                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:BoundField DataField="CODIGO_INTERFAZ" HeaderText="INTERFAZ" ReadOnly="true" />
                                    <asp:BoundField DataField="FILENAME" HeaderText="ARCHIVO" ReadOnly="true" />
                                    <asp:BoundField DataField="TABLA" HeaderText="TABLA" ReadOnly="true" />

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
                <div runat="server" id="DIV_PANEL">
                    <%--===========================================================================================================--%>
                    <%--===========================================================================================================--%>
                    <div class="row">

                        <div class="col-sm-offset-1 col-sm-2" style="margin-top: 10px;">
                            <asp:Label ID="Label6" runat="server" Text="PROCEDIMIENTO ALMACENADO"></asp:Label>
                        </div>

                        <div class="col-sm-3">
                            <asp:DropDownList ID="DDL_SP" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%"></asp:DropDownList>
                        </div>

                        <div class="col-md-1" runat="server" id="DIV_CREACION">
                            <asp:LinkButton ID="Link_Create_sp"
                                runat="server"
                                Visible="true"
                                CssClass='btn btn-primary'
                                ToolTip='ALMACENAR PROCEDIMIENTO'>                            
                             <i class='glyphicon glyphicon-play-circle'></i>                                
                            </asp:LinkButton>
                        </div>

                        <div class="col-md-1" runat="server" id="DIV_ASIGNACION">
                            <asp:LinkButton ID="LINK_Asignacion"
                                runat="server"
                                Visible="true"
                                CssClass='btn btn-primary'
                                ToolTip='ASIGNAR CAMPOS'
                                OnClick="LINK_Asignacion_Click">                            
                             <i class='glyphicon glyphicon-plus'></i>                                
                            </asp:LinkButton>
                        </div>


                    </div>
                    <%--===========================================================================================================--%>
                    <%--===========================================================================================================--%>
                    <div class="row" style="margin-top: 25px;"></div>
                    <%--===========================================================================================================--%>
                    <%--===========================================================================================================--%>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="table-responsive">
                                <asp:GridView ID="GRD_PARAMETROS_SP" runat="server" AutoGenerateColumns="False"
                                    CellPadding="4"
                                    CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                    ShowHeaderWhenEmpty="true"
                                    OnPreRender="GRD_PARAMETROS_SP_PreRender"
                                    OnRowCommand="GRD_PARAMETROS_SP_RowCommand">

                                    <Columns>

                                        <asp:BoundField DataField="TIPO_PARAMETRO" HeaderText="TIPO" ReadOnly="true" />
                                        <asp:BoundField DataField="ORDEN_SP_PARAMETRO" HeaderText="ORDEN PARAMETRO" ReadOnly="true" />                                        
                                        <asp:BoundField DataField="CAMPO_SP_PARAMETRO" HeaderText="PARAMETRO" ReadOnly="true" />
                                        <asp:TemplateField HeaderText="CAMPO INTERFAZ" SortExpression="CAMPO_INTERFAZ_DETALLE">
                                            <ItemTemplate><%# (int.Parse(Eval("ID_INTERFAZ_DETALLE").ToString()) == 0) ? "SIN ASIGNAR" : Eval("CAMPO_INTERFAZ_DETALLE").ToString() %></ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="ACCIONES">

                                            <ItemTemplate>

                                                <asp:LinkButton ID="LINK_eliminar"
                                                    runat="server"
                                                    Visible='<%# ((int)Eval("ID_INTERFAZ_DETALLE") != 0 ) ? true : false %>'
                                                    CssClass='btn btn-danger'
                                                    CommandName="EliminarAsignacion"
                                                    CommandArgument='<%# Eval("ID_SP_PARAMETRO")%>'
                                                    ToolTip='ELIMINAR ASIGNACION'>
                                                <i class='glyphicon glyphicon-trash'></i>                                
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
                    <div class="row" style="margin-top: 30px;"></div>
                    <%--===========================================================================================================--%>
                    <%--===========================================================================================================--%>
                    <div class="row">

                        <div class="col-sm-offset-1 col-sm-1" style="margin-top: 10px;">
                            <asp:Label ID="Label3" runat="server" Text="CARTERA"></asp:Label>
                        </div>

                        <div class="col-sm-3">
                            <asp:TextBox runat="server" ID="TXT_CARTERA" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="col-sm-1">
                            <asp:LinkButton ID="BNT_CARGAR_TABLA" runat="server" CssClass="btn btn-primary" ToolTip="CARGAR TABLAS" OnClick="BNT_CARGAR_TABLA_Click">
                            <i class="glyphicon glyphicon-search">
                        </i></asp:LinkButton>
                        </div>

                    </div>
                    <%--===========================================================================================================--%>
                    <%--===========================================================================================================--%>
                    <div class="row" style="margin-top: 25px;"></div>
                    <%--===========================================================================================================--%>
                    <%--===========================================================================================================--%>
                    <div class="row">

                        <div class="col-sm-offset-1 col-sm-1" style="margin-top: 5px;">
                            <asp:Label ID="Label2" runat="server" Text="TABLA ASIGNACIÓN"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="DDL_TABLA_ASIGNACION" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_TABLA_ASIGNACION_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>

                        <div runat="server" id="DIV_TABLA_ASIGNACION">
                            <div class="col-sm-1" style="margin-top: 5px;">
                                <asp:Label ID="Label8" runat="server" Text="TABLA ASIGNACIÓN"></asp:Label>
                            </div>

                            <div class="col-sm-3">
                                <asp:TextBox runat="server" ID="TXT_TABLA_ASIGNACION" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    <%--===========================================================================================================--%>
                    <%--===========================================================================================================--%>
                    <div class="row" style="margin-top: 25px;"></div>
                    <%--===========================================================================================================--%>
                    <%--===========================================================================================================--%>
                    <div class="row">
                        <div class="col-sm-offset-1 col-sm-1">
                            <asp:Label ID="Label5" runat="server" Text="INICIO CICLO CARGA" Style="margin-top: 10px;"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="TXT_FECHA_INI" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="col-sm-1">
                            <asp:Label ID="Label1" runat="server" Text="FIN CICLO CARGA" Style="margin-top: 10px;"></asp:Label>
                        </div>
                        <div class="col-sm-3">
                            <asp:TextBox ID="TXT_FECHA_FIN" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>


                    </div>
                    <%--===========================================================================================================--%>
                    <%--===========================================================================================================--%>
                    <div class="row" style="margin-top: 25px;"></div>
                    <%--===========================================================================================================--%>
                    <%--===========================================================================================================--%>
                    <div class="row">

                        <div class="col-md-offset-9 col-md-3" runat="server" id="DIV_ALMACENAR">
                            <asp:LinkButton ID="BNT_ALMACENAR_ASIGNACION" runat="server" CssClass="btn btn-primary btn-block btn-sm" ToolTip="ALMACENAR ASIGNACIÓN"> <i class="glyphicon glyphicon-floppy-disk" aria-hidden="true">
                                </i>&nbsp;ALMACENAR ASIGNACIÓN
                            </asp:LinkButton>
                        </div>


                    </div>
                    <%--===========================================================================================================--%>
                    <%--===========================================================================================================--%>
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
    <%-- INICIAL MODAL                                                                                                --%>
    <%--==============================================================================================================--%>
    <div class="modal fade" id="MODAL_ASIGNACION_CAMPOS" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_ASIGNACION_CAMPOS" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-tasks" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_ASIGNACION_CAMPOS" runat="server" Text="ASIGNACIÓN DE CAMPOS PARA PLANIFICACIÓN"></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_ASIGNACION_CAMPOS" class="alert alert-warning" style="display: none;"></div>
                            <div style="height: 10px"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>

                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:TextBox ID="TXT_ID_PARAMETRO_SP" runat="server" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="TXT_NAME_SP" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row">

                                <div class="col-sm-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GRD_PARAMETROS_SP_2" runat="server" AutoGenerateColumns="False"
                                            CellPadding="4"
                                            CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                            ShowHeaderWhenEmpty="true"
                                            OnPreRender="GRD_PARAMETROS_SP_2_PreRender"
                                            OnRowCommand="GRD_PARAMETROS_SP_2_RowCommand">

                                            <Columns>

                                                <asp:BoundField DataField="TIPO_PARAMETRO" HeaderText="TIPO" ReadOnly="true" />
                                                <asp:BoundField DataField="ORDEN_SP_PARAMETRO" HeaderText="ORDEN PARAMETRO" ReadOnly="true" />                                                
                                                <asp:BoundField DataField="CAMPO_SP_PARAMETRO" HeaderText="PARAMETRO" ReadOnly="true" />                                                
                                                <asp:TemplateField HeaderText="CAMPO INTERFAZ" SortExpression="CAMPO_INTERFAZ_DETALLE">
                                                    <ItemTemplate><%# (int.Parse(Eval("ID_INTERFAZ_DETALLE").ToString()) == 0) ? "SIN ASIGNAR" : Eval("CAMPO_INTERFAZ_DETALLE").ToString() %></ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="ACCIONES">

                                                    <ItemTemplate>

                                                        <asp:LinkButton ID="LINK_eliminar"
                                                            runat="server"
                                                            Visible='<%# ((int)Eval("ID_INTERFAZ_DETALLE") != 0 ) ? true : false %>'
                                                            CssClass='btn btn-danger'
                                                            CommandName="EliminarAsignacion"
                                                            CommandArgument='<%# Eval("ID_SP_PARAMETRO")%>'
                                                            ToolTip='ELIMINAR ASIGNACION'>
                                                <i class='glyphicon glyphicon-trash'></i>                                
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
                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row" runat="server" id="DIV_CAMPOS">
                                <div class="col-md-3" style="margin-top: 10px">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="LBL_DETALLE_CAMPO" Text="CAMPO"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <asp:DropDownList ID="DDL_INTERFAZ_DETALLE" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div style="height: 10px"></div>
                            <div id="MSG_INFO_ASIGNACION_CAMPOS" class="alert alert-info" style="display: none;"></div>


                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="BTN_ASIGNACION_CAMPOS" runat="server"
                                    Text="ASIGNAR"
                                    OnClick="BTN_ASIGNACION_CAMPOS_Click"
                                    CssClass="btn btn-primary"
                                    data-backdrop="static" />
                            </div>
                        </div>
                        <!-- FIN Modal content-->

                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_ASIGNACION_CAMPOS" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--==============================================================================================================--%>
    <%-- FIN MODAL                                                                                                    --%>
    <%--==============================================================================================================--%>

    <%--=======================================================================================================================--%>
    <%-- INICIO MODAL ELIMINA ASIGNACION                                                                                       --%>
    <%--=======================================================================================================================--%>
    <div class="modal fade" id="MODAL_ELIMINA_ASIGNACION" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_ELIMINA_ASIGNACION" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-trash" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_ELIMINA_ASIGNACION" runat="server" Text="ELIMINACIÓN DE ASIGNACIÓN DE PARAMETRO"></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">


                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_ELIMINA_ASIGNACION" class="alert alert-warning" style="display: none;"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <form>

                                <%--=========================================================================================--%>
                                <%--=========================================================================================--%>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Label ID="LBL_TITULO_MENSAJE_ELIMINA_ASIGNACION" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </div>

                                <%--=========================================================================================--%>
                                <%--=========================================================================================--%>
                                <div class="row" style="margin-top: 5px;">

                                    <div class="col-sm-12">
                                        <asp:TextBox ID="TXT_ID_SP_PARAMETRO_DELETE" runat="server" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="TXT_NAME_SP_DELETE" runat="server" Visible="false"></asp:TextBox>
                                    </div>

                                </div>

                            </form>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_INFO_ELIMINA_ASIGNACION" class="alert alert-info" style="display: none;"></div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BTN_ELIMINA_ASIGNACION" runat="server"
                                Text="ELIMINAR"
                                OnClick="BTN_ELIMINA_ASIGNACION_Click"
                                CssClass="btn btn-danger"
                                data-backdrop="static" />
                        </div>
                    </div>
                    <!-- FIN Modal content-->
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%--=======================================================================================================================--%>
    <%--  FIN MODAL ELIMINA ASIGNACION                                                                                         --%>
    <%--=======================================================================================================================--%>
</asp:Content>

