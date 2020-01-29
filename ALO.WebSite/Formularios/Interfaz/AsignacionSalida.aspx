<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AsignacionSalida.aspx.cs" Inherits="ALO.WebSite.Formularios.Interfaz.AsignacionSalida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- =================================================================================================================== -->
    <!-- ESTILOS                                                                                                             -->
    <!-- =================================================================================================================== -->
    <style type="text/css">
        #MODAL_SALIDAS_X_INTERFAZ {
            height: auto;
            width: 100%;
            overflow: auto;
        }

        /* scroll para panel de interfaz*/
        .scroll-panel {
            height: 240px;
            overflow: auto;
        }

            /* estilo del scroll*/
            .scroll-panel::-webkit-scrollbar {
                width: 8px;
                background: #ffffff;
            }

            .scroll-panel::-webkit-scrollbar-thumb {
                background-color: #337ab7;
                -webkit-border-radius: 1ex;
            }
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
                    "searching": false,
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
                            <li class="breadcrumb-item active">ASIGNAR COLUMNAS DE INTERFAS A ARCHIVO</li>
                        </ol>
                    </div>
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 10px;">

                    <div class="col-sm-12">
                        <asp:Panel runat="server" ID="PNL_MENSAJE" Visible="false">
                            <div id="MSG_ALERTA" class="alert alert-warning" runat="server">
                            </div>
                        </asp:Panel>
                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-offset-2 col-sm-1" style="margin-top: 10px;">
                        <asp:Label ID="Label4" runat="server" Text="CLUSTER"></asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="DDL_SELECT_CLUSTER" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_CLUSTER_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>

                    <div class="col-sm-1" style="margin-top: 10px;">
                        <asp:Label ID="Label1" runat="server" Text="INTERFAZ"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="DDL_INTERFAZ" CssClass="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_INTERFAZ_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>

                    <div class="col-sm-1">
                        <asp:LinkButton ID="LinK_BNT_BUSCAR" runat="server" CssClass="btn btn-primary" ToolTip="CONSULTAR" OnClick="BNT_BUSCAR_Click">
                            <i class="glyphicon glyphicon-search">
                        </i></asp:LinkButton>
                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 20px;"></div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">
                    <div class="col-sm-2">
                        <asp:LinkButton ID="LinK_BNT_NUEVA_ASIGNACION" OnClick="BNT_NUEVA_ASIGNACION_Click" runat="server" CssClass="btn btn-primary" ToolTip="NUEVA ASIGNACIÓN">
                            <i class="glyphicon glyphicon-plus" aria-hidden="true">
                        </i></asp:LinkButton>
                    </div>
                </div>

                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 20px;"></div>

                <div class="row">
                    <asp:Repeater ID="RPT_SALIDA" runat="server" OnItemDataBound="rpt_ItemDataBound" OnItemCommand="RPT_SALIDA_ItemCommand">
                        <ItemTemplate>
                            <div class="col-sm-6 col-md-4">
                                <div class="panel panel-primary">
                                    <div class="row">
                                        <div class="panel-heading">
                                            <div class="col-md-8 col-xs-8 col-sm-8 text-left">
                                                <h5>SALIDA:
                                                <%# Eval("DESCRIPCION_PROCESO_FILE") %></h5>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="panel-body">
                                        <div class="row scroll-panel">
                                            <table class="table table-striped">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="GRDData" runat="server" AutoGenerateColumns="False"
                                                            CellPadding="4"
                                                            CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                                            ShowHeaderWhenEmpty="True">
                                                            <Columns>

                                                                <asp:BoundField DataField="CAMPO_DET_PROCESO_FILE" HeaderText="CAMPO" ReadOnly="true" />
                                                                <asp:BoundField DataField="CAMPO_DET_INTERFAZ" HeaderText="CAMPO INTERFAZ" ReadOnly="true" />
                                                                <asp:BoundField DataField="DESCRIPCION_DATO" HeaderText="TIPO DE DATO" ReadOnly="true" />

                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="row" style="margin-bottom: 20px;"></div>
                <div class="row">
                    <asp:Repeater ID="RPT_PAGINADO" runat="server" OnItemCommand="rptPaginado_ItemCommand">
                        <ItemTemplate>
                            <asp:LinkButton ID="BTN_PAGINADO"
                                Style="padding: 8px; margin: 2px; margin-top: 15px; background: #337ab7; border: solid 1px #666;"
                                CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                                runat="server" ForeColor="White" Font-Bold="True">
                                                    <%# Container.DataItem %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 25px;">
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
            </div>
            <%--==============================================================================================================--%>
            <%-- FIN CONTAINER                                                                                                --%>
            <%--==============================================================================================================--%>
        </ContentTemplate>
    </asp:UpdatePanel>


    <%--==============================================================================================================--%>
    <%-- INICIO MODAL SALIDAS_X_INTERFAZ                                                                              --%>
    <%--==============================================================================================================--%>
    <div class="modal fade" id="MODAL_SALIDAS_X_INTERFAZ" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_SALIDAS_X_INTERFAZ" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-tasks" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_SALIDAS_X_INTERFAZ" runat="server" Text="ASIGNACIÓN DE SALIDAS"></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_SALIDAS_X_INTERFAZ" class="alert alert-warning" style="display: none;"></div>
                            <div style="height: 10px"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>


                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row">
                                <asp:TextBox ID="TXT_ID_INTERFAZ" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="TXT_ID_DETALLE_PROCESO_FILE" runat="server" Visible="false"></asp:TextBox>
                            </div>

                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row" style="margin-top: 10px;"></div>
                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row">

                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label5" runat="server" Text="PROCESO FILE" CssClass="control-label"></asp:Label>
                                        <asp:DropDownList ID="DDL_PROCESO_FILE" CssClass="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_PROCESO_FILE_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GRD_DETALLE_PROCESO_FILE" runat="server" AutoGenerateColumns="False"
                                            CellPadding="4"
                                            CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                            ShowHeaderWhenEmpty="true"
                                            OnPreRender="GRD_DETALLE_PROCESO_FILE_PreRender"
                                            OnRowCommand="GRD_DETALLE_PROCESO_FILE_RowCommand">
                                            <Columns>

                                                <asp:BoundField DataField="CAMPO_DET_PROCESO_FILE" HeaderText="CAMPO" ReadOnly="true" />
                                                <asp:BoundField DataField="CAMPO_DET_INTERFAZ" HeaderText="CAMPO INTERFAZ" ReadOnly="true" />
                                                <asp:BoundField DataField="DESCRIPCION_DATO" HeaderText="TIPO DE DATO" ReadOnly="true" />                                                

                                                <asp:TemplateField HeaderText="ACCIONES" ShowHeader="false">

                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="BTN_DELETE_SALIDA_X_INTERFAZ" runat="server" CommandName="EliminarSalida" CommandArgument='<%# Eval("ID_DETALLE_FILE_SALIDA") %>' ToolTip="ELIMINAR ASIGNACIÓN"
                                                            CssClass="btn-xs btn-danger"><i><span class="glyphicon glyphicon-trash"></span></i></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                            </div>
                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row" runat="server" id="DIV_CAMPOS">
                                <div class="col-md-3" style="margin-top: 10px">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="LBL_DETALLE_FILE" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <asp:ListBox ID="DDL_CAMPOS_INTERFAZ" runat="server" CssClass="selectpicker" data-live-search="true" data-width="100%" Width="100%"></asp:ListBox>
                                    </div>
                                </div>
                            </div>

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div style="height: 10px"></div>
                            <div id="MSG_INFO_SALIDAS_X_INTERFAZ" class="alert alert-info" style="display: none;"></div>


                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BTN_SALIDAS_X_INTERFAZ" runat="server"
                                Text="CREAR"
                                OnClick="BTN_SALIDAS_X_INTERFAZ_Click"
                                CssClass="btn btn-primary"
                                data-backdrop="static" />
                        </div>
                    </div>
                    <!-- FIN Modal content-->


                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_SALIDAS_X_INTERFAZ" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--==============================================================================================================--%>
    <%-- FIN MODAL CREAR SALIDAS_X_INTERFAZ                                                                           --%>
    <%--==============================================================================================================--%>

    <%--=======================================================================================================================--%>
    <%-- INICIO MODAL ELIMINA SALIDA_X_INTERFAZ                                                                                --%>
    <%--=======================================================================================================================--%>
    <div class="modal fade" id="MODAL_ELIMINA_SALIDA_X_INTERFAZ" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_ELIMINA_SALIDA_X_INTERFAZ" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-trash" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_ELIMINA_SALIDA_X_INTERFAZ" runat="server" Text="ELIMINACIÓN DE SALIDA POR INTERFAZ"></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">


                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_ELIMINA_SALIDA_X_INTERFAZ" class="alert alert-warning" style="display: none;"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <form>


                                <%--=========================================================================================--%>
                                <%--=========================================================================================--%>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Label ID="LBL_TITULO_MENSAJE_ELIMINA_SALIDA_X_INTERFAZ" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </div>

                                <%--=========================================================================================--%>
                                <%--=========================================================================================--%>
                                <div class="row" style="margin-top: 5px;">

                                    <div class="col-sm-12">
                                        <asp:TextBox ID="TXT_ID_DETALLE_FILE_SALIDA" runat="server" Visible="false"></asp:TextBox>
                                    </div>

                                </div>

                            </form>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_INFO_ELIMINA_SALIDA_X_INTERFAZ" class="alert alert-info" style="display: none;"></div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BTN_ELIMINA_SALIDA_X_INTERFAZ" runat="server"
                                Text="ELIMINAR"
                                OnClick="BTN_ELIMINA_SALIDA_X_INTERFAZ_Click"
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
    <%--  FIN MODAL ELIMINA SALIDA_X_INTERFAZ                                                                                  --%>
    <%--=======================================================================================================================--%>
</asp:Content>

