<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="FileSalida.aspx.cs" Inherits="ALO.WebSite.Formularios.Interfaz.FileSalida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- =================================================================================================================== -->
    <!-- ESTILOS                                                                                                             -->
    <!-- =================================================================================================================== -->
    <style type="text/css">
        #MODAL_ELIMINA_PROCESO_FILE {
            z-index: 1080 !important;
        }
    </style>
    <!-- =================================================================================================================== -->
    <!-- FIN ESTILOS                                                                                                         -->
    <!-- =================================================================================================================== -->

    <!-- =================================================================================================================== -->
    <!-- SCRIPT                                                                                                              -->
    <!-- =================================================================================================================== -->
    <script type="text/javascript">




        //=====================================================================================
        // FUNCION DE INICIO                                                                
        //=====================================================================================
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



        //=====================================================================================
        // MENSAJE LOG POR PANTALLA                                                         
        //=====================================================================================
        function ModalInterfaz() {

            //===========================================================
            // MOSTRAR INFORMACION MODAL                                    
            //===========================================================
            $("#ModalInterfaz").modal("show");

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
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item active">ASOCIAR PROCESO A INTERFAZ</li>
                    </ol>
                </div>
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
                        <asp:Label ID="LBL_INTERFAZ" runat="server" Text="INTERFAZ"></asp:Label>
                    </div>

                    <div class="col-sm-3">
                        <asp:DropDownList ID="DDL_INTERFAZ" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_INTERFAZ_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 25px;"></div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-1">
                        <asp:LinkButton ID="BNT_NUEVO_PROCESO_FILE" OnClick="BNT_NUEVO_PROCESO_FILE_Click" runat="server" CssClass="btn btn-primary" ToolTip="NUEVO PROCESO FILE">
                            <i class="glyphicon glyphicon-plus" >
                        </i></asp:LinkButton>
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

                            <asp:GridView ID="GRD_PROCESO_FILE" runat="server" AutoGenerateColumns="False"
                                CellPadding="4"
                                CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                ShowHeaderWhenEmpty="true"
                                OnPreRender="GRD_PROCESO_FILE_PreRender"
                                OnRowCommand="GRD_PROCESO_FILE_RowCommand">
                                <Columns>

                                    <asp:BoundField DataField="CODIGO_INTERFAZ" HeaderText="CODIGO INTERFAZ" ReadOnly="true" />
                                    <asp:BoundField DataField="DESCRIPCION_PROCESO_FILE" HeaderText="DESCRIPCION FILE" ReadOnly="true" />
                                    <asp:BoundField DataField="CODIGO_PROCESO_FILE" HeaderText="CODIGO FILE" ReadOnly="true" />
                                    <asp:BoundField DataField="PRIORIDAD" HeaderText="PRIORIDAD" ReadOnly="true" />
                                    <asp:BoundField DataField="SP" HeaderText="PROCEDIMIENTO ALMACENADO" ReadOnly="true" />

                                    <asp:TemplateField HeaderText="ACCIONES">

                                        <ItemTemplate>

                                            <asp:LinkButton ID="LINK_editar"
                                                runat="server"
                                                Visible="true"
                                                CssClass='btn btn-primary'
                                                CommandName="EditarProcesoFile"
                                                CommandArgument='<%# Eval("ID_PROCESO_FILE")%>'
                                                ToolTip='EDITAR PROCESO FILE'>
                                                <i class='glyphicon glyphicon-pencil'></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LINK_eliminar"
                                                runat="server"
                                                Visible="true"
                                                CssClass='btn btn-danger'
                                                CommandName="EliminarProcesoFile"
                                                CommandArgument='<%# Eval("ID_PROCESO_FILE")%>'
                                                ToolTip='ELIMINAR PROCESO FILE'>
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
                <div class="row" style="margin-top: 20px;"></div>

                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
            </div>
            <%--==============================================================================================================--%>
            <%-- FIN CONTAINER                                                                                                --%>
            <%--==============================================================================================================--%>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>


    <%--==============================================================================================================--%>
    <%-- INICIAL MODAL                                                                                                --%>
    <%--==============================================================================================================--%>
    <div class="modal fade" id="MODAL_GRID_PROCESO_FILE" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_PROCESO_FILE" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-tasks" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_PROCESO_FILE" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">


                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_PROCESO_FILE" class="alert alert-warning" style="display: none;"></div>
                            <div style="height: 10px"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>

                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:TextBox ID="TXT_ID_PROCESO_FILE" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

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
                                        <asp:Label ID="Label1" runat="server" Text="CODIGO" CssClass="control-label"></asp:Label>
                                        <asp:TextBox runat="server" ID="TXT_CODIGO" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label6" runat="server" Text="PRIORIDAD" CssClass="control-label"></asp:Label>
                                        <asp:TextBox runat="server" ID="TXT_PRIORIDAD" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>



                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label3" runat="server" Text="PROCEDIMIENTO ALMACENADO" CssClass="control-label"></asp:Label>
                                        <asp:DropDownList ID="DDL_SP" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_SP_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-4" style="margin-top: 10px;">
                                        <asp:Label ID="LBL_ACTUALIZAR_PARAMETROS" runat="server" Text="ACTUALIZAR PARAMETROS PROCEDIMIENTO ALMACENADO"></asp:Label>
                                    </div>
                                    <div class="col-md-4" style="margin-top: 10px;">

                                        <asp:CheckBox ID="CHK_ACTUALIZAR_PARAMETROS" runat="server" Checked="false" />

                                    </div>
                                </div>

                            </div>

                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GRD_PARAMETROS_SP" runat="server" AutoGenerateColumns="False"
                                            CellPadding="4"
                                            CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                            ShowHeaderWhenEmpty="true"
                                            OnPreRender="GRD_PARAMETROS_SP_PreRender">
                                            <Columns>

                                                <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" ReadOnly="true" />
                                                <asp:BoundField DataField="ORDEN" HeaderText="ORDEN" ReadOnly="true" />
                                                <asp:BoundField DataField="TIPO_DATO" HeaderText="TIPO DE DATO" ReadOnly="true" />
                                                <asp:BoundField DataField="LARGO" HeaderText="LARGO" ReadOnly="true" />
                                                <asp:BoundField DataField="TIPO_PARAMETRO" HeaderText="TIPO" ReadOnly="true" />

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div style="height: 10px"></div>
                            <div id="MSG_INFO_PROCESO_FILE" class="alert alert-info" style="display: none;"></div>


                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                <asp:Button ID="BTN_PROCESO_FILE" runat="server"
                                    Text=""
                                    OnClick="BTN_PROCESO_FILE_Click"
                                    CssClass="btn btn-primary"
                                    data-backdrop="static" />
                            </div>
                        </div>
                        <!-- FIN Modal content-->


                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_PROCESO_FILE" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--==============================================================================================================--%>
    <%-- FIN MODAL                                                                                                    --%>
    <%--==============================================================================================================--%>

    <%--=======================================================================================================================--%>
    <%-- INICIO MODAL ELIMINA PROCESO_FILE                                                                                     --%>
    <%--=======================================================================================================================--%>
    <div class="modal fade" id="MODAL_ELIMINA_PROCESO_FILE" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_ELIMINA_PROCESO_FILE" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">


                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-trash" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_ELIMINA_PROCESO_FILE" runat="server" Text="ELIMINAR PROCESO ASOCIADO A INTERFAZ"></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">


                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_ELIMINA_PROCESO_FILE" class="alert alert-warning" style="display: none;"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <form>


                                <%--=========================================================================================--%>
                                <%--=========================================================================================--%>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Label ID="LBL_TITULO_MENSAJE_ELIMINA_PROCESO_FILE" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </div>

                                <%--=========================================================================================--%>
                                <%--=========================================================================================--%>
                                <div class="row" style="margin-top: 5px;">

                                    <div class="col-sm-12">
                                        <asp:TextBox ID="TXT_ID_ELIMINA_PROCESO_FILE" runat="server" Visible="false"></asp:TextBox>
                                    </div>

                                </div>

                            </form>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_INFO_ELIMINA_PROCESO_FILE" class="alert alert-info" style="display: none;"></div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BTN_ELIMINA_PROCESO_FILE" runat="server"
                                Text="ELIMINAR"
                                OnClick="BTN_ELIMINA_PROCESO_FILE_Click"
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
    <%--  FIN MODAL ELIMINA PROCESO_FILE                                                                                       --%>
    <%--=======================================================================================================================--%>
</asp:Content>
