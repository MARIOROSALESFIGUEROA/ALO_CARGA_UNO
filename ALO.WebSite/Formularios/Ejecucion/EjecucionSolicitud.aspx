<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="EjecucionSolicitud.aspx.cs" Inherits="ALO.WebSite.Formularios.Ejecucion.EjecucionSolicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- =================================================================================================================== -->
    <!-- ESTILOS                                                                                                             -->
    <!-- =================================================================================================================== -->
    <style type="text/css">
        #MODAL_GRID_OBJETO_X_INTERFAZ {
            z-index: 1080 !important;
        }

        #MODAL_ELIMINA_OBJETO_X_INTERFAZ {
            z-index: 1080 !important;
        }

        .checkbox {
            padding-left: 20px;
        }

            .checkbox label {
                display: inline-block;
                vertical-align: middle;
                position: relative;
                padding-left: 5px;
            }

                .checkbox label::before {
                    content: "";
                    display: inline-block;
                    position: absolute;
                    width: 17px;
                    height: 17px;
                    left: 0;
                    margin-left: -20px;
                    border: 1px solid #cccccc;
                    border-radius: 3px;
                    background-color: #fff;
                    -webkit-transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
                    -o-transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
                    transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
                }

                .checkbox label::after {
                    display: inline-block;
                    position: absolute;
                    width: 16px;
                    height: 16px;
                    left: 0;
                    top: 0;
                    margin-left: -20px;
                    padding-left: 3px;
                    padding-top: 1px;
                    font-size: 11px;
                    color: #555555;
                }

            .checkbox input[type="checkbox"] {
                opacity: 0;
                z-index: 1;
            }

                .checkbox input[type="checkbox"]:checked + label::after {
                    font-family: "FontAwesome";
                    content: "\f00c";
                }

        .checkbox-primary input[type="checkbox"]:checked + label::before {
            background-color: #337ab7;
            border-color: #337ab7;
        }

        .checkbox-primary input[type="checkbox"]:checked + label::after {
            color: #fff;
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
                    "pageLength": 5,
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
                            <li class="breadcrumb-item active">EJECUCION DE SOLICITUD CARGA 2</li>
                        </ol>
                    </div>
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-12"></div>

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
                        <asp:LinkButton ID="LinK_BNT_BUSCAR" runat="server" CssClass="btn btn-primary" ToolTip="CONSULTAR" OnClick="BNT_BUSCAR_Click">
                            <i class="glyphicon glyphicon-search">
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
                            <asp:Label ID="Label2" runat="server" Text="PROCESOS"></asp:Label></h4>
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
                                                ToolTip="PROCESO EN EJECUCION">
                                                <i class="glyphicon glyphicon-search"></i>                                
                                            </asp:LinkButton>

                                        </ItemTemplate>

                                    </asp:TemplateField>


                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="GRUPO DE CARGA" ReadOnly="true" />

                                    <asp:BoundField DataField="ESTADO_GRUPO" HeaderText="ESTADO" ReadOnly="true" />
                                    <asp:BoundField DataField="MENSAJE" HeaderText="DETALLE" ReadOnly="true" />

                                    <asp:TemplateField HeaderText="ACCIONES">

                                        <ItemTemplate>

                                            <asp:LinkButton ID="Link_OK"
                                                runat="server"
                                                Enabled="false"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 3) ? true : false %>'
                                                CssClass='btn btn-success'
                                                ToolTip='PROCESO FINALIZADO'>
                                                <i class='glyphicon glyphicon-ok'></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="Link_Error"
                                                runat="server"
                                                Enabled="false"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 4) ? true : false %>'
                                                CssClass='btn btn-danger'
                                                ToolTip='ERROR EN PROCESO'>
                                                <i class='glyphicon glyphicon-remove'></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LinkButton1"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 2) ? true : false %>'
                                                CssClass="btn btn-success"
                                                CommandName="CrearSolicitud"
                                                CommandArgument='<%# Eval("ID_GRUPO_CARGA")%>'
                                                ToolTip="MANDAR A EJECUCION">
                                                <i class="glyphicon glyphicon-play"></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LinkButton2"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") >= 3) ? true : false %>'
                                                CssClass="btn btn-danger"
                                                CommandName="EliminarSolicitud"
                                                CommandArgument='<%# Eval("ID_GRUPO_CARGA")%>'
                                                ToolTip="REINICIAR">
                                                <i class="glyphicon glyphicon-erase"></i>                                
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
                            <asp:Label ID="Label3" runat="server" Text="INTERFACES A PROCESAR"></asp:Label></h4>
                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 20px;">
                    <div class="col-sm-12">
                        <div class="table-responsive">

                            <asp:GridView ID="GRDDataDetalleGrupo" runat="server" AutoGenerateColumns="False"
                                CellPadding="4"
                                CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                ShowHeaderWhenEmpty="true"
                                OnRowCommand="GRDDataDetalleGrupo_RowCommand">

                                <Columns>

                                    <asp:BoundField DataField="CODIGO_INTERFAZ" HeaderText="CODIGO INTERFAZ" ReadOnly="true" />
                                    <asp:BoundField DataField="FILENAME" HeaderText="ARCHIVO" ReadOnly="true" />
                                    <%--<asp:BoundField DataField="TABLA" HeaderText="TABLA" ReadOnly="true" />--%>
                                    <asp:BoundField DataField="NRO_SOLICITUD" HeaderText="NÚMERO SOLICITUD" ReadOnly="true" />
                                    <asp:BoundField DataField="NRO_SOLICITUD" HeaderText="LINK" ReadOnly="true" />
                                    <asp:BoundField DataField="NRO_SOLICITUD" HeaderText="LOG" ReadOnly="true" />


                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="ESTADO" ReadOnly="true" />
                                    <asp:BoundField DataField="MENSAJE" HeaderText="DETALLE" ReadOnly="true" />

                                    <asp:TemplateField HeaderText="ACCIONES" HeaderStyle-Width="10%">

                                        <ItemTemplate>

                                            <asp:LinkButton ID="Link_OK"
                                                runat="server"
                                                Enabled="false"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 3) ? true : false %>'
                                                CssClass='btn btn-success'
                                                ToolTip='PROCESO FINALIZADO'>
                                                <i class='glyphicon glyphicon-ok'></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="Link_Error"
                                                runat="server"
                                                Enabled="false"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 4) ? true : false %>'
                                                CssClass='btn btn-danger'
                                                ToolTip='ERROR EN PROCESO'>
                                                <i class='glyphicon glyphicon-remove'></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LinkButton1"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 2) ? true : false %>'
                                                CssClass="btn btn-success"
                                                CommandName="CrearSolicitud"
                                                CommandArgument='<%# Eval("ID_DETALLE_GRUPO_CARGA")%>'
                                                ToolTip="MANDAR A EJECUCION">
                                                <i class="glyphicon glyphicon-play"></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LinkButton2"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 3) ? true : false %>'
                                                CssClass="btn btn-danger"
                                                CommandName="EliminarSolicitud"
                                                CommandArgument='<%# Eval("ID_DETALLE_GRUPO_CARGA")%>'
                                                ToolTip="REINICIAR">
                                                <i class="glyphicon glyphicon-erase"></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LinkButton3"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 4) ? true : false %>'
                                                CssClass="btn btn-danger"
                                                CommandName="EliminarSolicitud"
                                                CommandArgument='<%# Eval("ID_DETALLE_GRUPO_CARGA")%>'
                                                ToolTip="REINICIAR">
                                                <i class="glyphicon glyphicon-erase"></i>                                
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

                <%--<div class="row">
                    <div class="col-sm-12">
                        <div class="table-responsive">

                            <asp:GridView ID="GRD_ASIGNACION_OBJETO" runat="server" AutoGenerateColumns="False"
                                CellPadding="4"
                                CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                ShowHeaderWhenEmpty="true"
                                OnPreRender="GRD_ASIGNACION_OBJETO_PreRender"
                                OnRowCommand="GRD_ASIGNACION_OBJETO_RowCommand">
                                <Columns>

                                    <asp:BoundField DataField="CODIGO_OBJETO" HeaderText="CODIGO DE OBJETO" ReadOnly="true" />
                                    <asp:BoundField DataField="DESCRIPCION_OBJETO" HeaderText="DESCRIPCION DEL OBJETO" ReadOnly="true" />
                                    <asp:BoundField DataField="VALOR" HeaderText="VALOR" ReadOnly="true" />

                                    <asp:TemplateField HeaderText="ACCIONES">

                                        <ItemTemplate>

                                            <asp:LinkButton ID="LINK_edit"
                                                runat="server"
                                                Visible="true"
                                                CssClass='btn btn-primary'
                                                CommandName="EditarObjeto"
                                                CommandArgument='<%# Eval("ID_OBJETO_X_INTERFAZ")%>'
                                                ToolTip='EDITAR ASIGNACION DE OBJETO'>
                                                <i class='glyphicon glyphicon-pencil'></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LINK_delete"
                                                runat="server"
                                                Visible="true"
                                                CssClass='btn btn-danger'
                                                CommandName="EliminarObjeto"
                                                CommandArgument='<%# Eval("ID_OBJETO_X_INTERFAZ")%>'
                                                ToolTip='ELIMINAR ASIGNACION DE OBJETO'>
                                                <i class='glyphicon glyphicon-trash'></i>                                
                                            </asp:LinkButton>

                                        </ItemTemplate>

                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>--%>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-12">

                        <hr />

                    </div>
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
    <%-- INICIAL MODAL                                                                                                --%>
    <%--==============================================================================================================--%>
    <div class="modal fade" id="MODAL_GRID_OBJETO_X_INTERFAZ" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_OBJETO_X_INTERFAZ" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-tasks" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_OBJETO_X_INTERFAZ" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">


                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_OBJETO_X_INTERFAZ" class="alert alert-warning" style="display: none;"></div>
                            <div style="height: 10px"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>

                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:TextBox ID="TXT_ID_OBJETO" runat="server" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="TXT_ID_INTERFAZ" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row">

                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label5" runat="server" Text="OBJETOS" CssClass="control-label"></asp:Label>
                                        <asp:DropDownList ID="DDL_OBJETOS" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="VALOR" CssClass="control-label"></asp:Label>
                                        <asp:TextBox runat="server" ID="TXT_VALOR" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div style="height: 10px"></div>
                            <div id="MSG_INFO_OBJETO_X_INTERFAZ" class="alert alert-info" style="display: none;"></div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" id="BTN_CERRAR" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BTN_OBJETO_X_INTERFAZ" runat="server"
                                Text=""
                                OnClick="BTN_OBJETO_X_INTERFAZ_Click"
                                CssClass="btn btn-primary"
                                data-backdrop="static" />
                        </div>
                    </div>
                    <!-- FIN Modal content-->


                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_OBJETO_X_INTERFAZ" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--==============================================================================================================--%>
    <%-- FIN MODAL                                                                                                    --%>
    <%--==============================================================================================================--%>

    <%--=======================================================================================================================--%>
    <%-- INICIO MODAL ELIMINA OBJETO_X_INTERFAZ                                                                                --%>
    <%--=======================================================================================================================--%>
    <div class="modal fade" id="MODAL_ELIMINA_OBJETO_X_INTERFAZ" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_ELIMINA_OBJETO_X_INTERFAZ" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">


                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-trash" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_ELIMINA_OBJETO_X_INTERFAZ" runat="server" Text="ELIMINAR OBJETO ASIGNADO"></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">


                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_ELIMINA_OBJETO_X_INTERFAZ" class="alert alert-warning" style="display: none;"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <form>


                                <%--=========================================================================================--%>
                                <%--=========================================================================================--%>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Label ID="LBL_TITULO_MENSAJE_ELIMINA_OBJETO_X_INTERFAZ" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </div>

                                <%--=========================================================================================--%>
                                <%--=========================================================================================--%>
                                <div class="row" style="margin-top: 5px;">

                                    <div class="col-sm-12">
                                        <asp:TextBox ID="TXT_ID_ELIMINA_OBJETO_X_INTERFAZ" runat="server" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="TXT_ELIMINA_ID_INTERFAZ" runat="server" Visible="false"></asp:TextBox>
                                    </div>

                                </div>

                            </form>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_INFO_ELIMINA_OBJETO_X_INTERFAZ" class="alert alert-info" style="display: none;"></div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BTN_ELIMINA_OBJETO_X_INTERFAZ" runat="server"
                                Text="ELIMINAR"
                                OnClick="BTN_ELIMINA_OBJETO_X_INTERFAZ_Click"
                                CssClass="btn btn-danger"
                                data-backdrop="static" />
                        </div>
                    </div>
                    <!-- FIN Modal content -->
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%--=======================================================================================================================--%>
    <%--  FIN MODAL ELIMINA USUARIO                                                                                            --%>
    <%--=======================================================================================================================--%>

    <%--==============================================================================================================--%>
    <%-- INICIO MODAL OBJETOS                                                                                         --%>
    <%--==============================================================================================================--%>
    <div class="modal fade" id="MODAL_OBJETOS" role="dialog" tabindex="-1">
        <asp:UpdatePanel ID="UPDATE_PANEL_OBJETOS" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-tasks" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_OBJETOS" runat="server" Text="ENVIAR ESTOS OBJETOS JUNTO A LA EJECUCION ?"></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_OBJETOS" class="alert alert-warning" style="display: none;"></div>
                            <div style="height: 10px"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>

                            <asp:TextBox runat="server" Visible="false" ID="TXT_ID_GRUPO_CARGA"></asp:TextBox>
                            <asp:TextBox runat="server" Visible="false" ID="TXT_ID_DETALLE_GRUPO_CARGA"></asp:TextBox>

                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row" style="margin-top: 10px;"></div>
                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-responsive">

                                        <asp:GridView ID="GRD_ASIGNACION_OBJETO" runat="server" AutoGenerateColumns="False"
                                            CellPadding="4"
                                            CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                            ShowHeaderWhenEmpty="true"
                                            OnPreRender="GRD_ASIGNACION_OBJETO_PreRender"
                                            OnRowCommand="GRD_ASIGNACION_OBJETO_RowCommand">
                                            <Columns>

                                                <asp:BoundField DataField="CODIGO_INTERFAZ" HeaderText="CODIGO DE INTERFAZ" ReadOnly="true" />
                                                <asp:BoundField DataField="CODIGO_OBJETO" HeaderText="CODIGO DE OBJETO" ReadOnly="true" />
                                                <asp:BoundField DataField="DESCRIPCION_OBJETO" HeaderText="DESCRIPCION DEL OBJETO" ReadOnly="true" />
                                                <asp:BoundField DataField="VALOR" HeaderText="VALOR" ReadOnly="true" />

                                                <asp:TemplateField HeaderText="ACCIONES" HeaderStyle-Width="20%">

                                                    <ItemTemplate>

                                                        <asp:LinkButton ID="LINK_edit"
                                                            runat="server"
                                                            Visible="true"
                                                            CssClass='btn btn-primary'
                                                            CommandName="EditarObjeto"
                                                            CommandArgument='<%# Eval("ID_OBJETO_X_INTERFAZ")%>'
                                                            ToolTip='EDITAR ASIGNACION DE OBJETO'>
                                                <i class='glyphicon glyphicon-pencil'></i>                                
                                                        </asp:LinkButton>

                                                        <asp:LinkButton ID="LINK_delete"
                                                            runat="server"
                                                            Visible="true"
                                                            CssClass='btn btn-danger'
                                                            CommandName="EliminarObjeto"
                                                            CommandArgument='<%# Eval("ID_OBJETO_X_INTERFAZ")%>'
                                                            ToolTip='ELIMINAR ASIGNACION DE OBJETO'>
                                                <i class='glyphicon glyphicon-trash'></i>                                
                                                        </asp:LinkButton>

                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>

                                    </div>
                                </div>
                            </div>
                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div style="height: 10px"></div>
                            <div id="MSG_INFO_OBJETOS" class="alert alert-info" style="display: none;"></div>


                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BTN_OBJETOS" runat="server"
                                Text="EJECUTAR"
                                OnClick="BTN_OBJETOS_Click"
                                CssClass="btn btn-primary"
                                data-backdrop="static" />
                        </div>
                    </div>
                    <!-- FIN Modal content -->


                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_OBJETOS" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--==============================================================================================================--%>
    <%-- FIN MODAL EJECUCION_EXCEL                                                                                    --%>
    <%--==============================================================================================================--%>
</asp:Content>
