<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Ejecucion.aspx.cs" Inherits="ALO.WebSite.Formularios.Ejecucion.Ejecucion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- =================================================================================================================== -->
    <!-- ESTILOS                                                                                                             -->
    <!-- =================================================================================================================== -->
    <style type="text/css">
        .checkbox
        {
            padding-left: 20px;
        }

            .checkbox label
            {
                display: inline-block;
                vertical-align: middle;
                position: relative;
                padding-left: 5px;
            }

                .checkbox label::before
                {
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

                .checkbox label::after
                {
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

            .checkbox input[type="checkbox"]
            {
                opacity: 0;
                z-index: 1;
            }

                .checkbox input[type="checkbox"]:checked + label::after
                {
                    font-family: "FontAwesome";
                    content: "\f00c";
                }

        .checkbox-primary input[type="checkbox"]:checked + label::before
        {
            background-color: #337ab7;
            border-color: #337ab7;
        }

        .checkbox-primary input[type="checkbox"]:checked + label::after
        {
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
                            <li class="breadcrumb-item active">EJECUCION DE PROCESO</li>
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

                    <div class="col-sm-6" style="margin-top: 30px;">
                        <h4>
                            <asp:Label ID="Label1" runat="server" Text="PROCESOS"></asp:Label></h4>
                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">
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

                                            <asp:LinkButton ID="LINK_EjecutaProcesos"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 0 ) ? true : false %>'
                                                CssClass="btn btn-success"
                                                CommandName="Play"
                                                CommandArgument='<%# Eval("ID_GRUPO_CARGA") %>'
                                                ToolTip="ENVIAR A EJECUTAR">
                                                <i class="glyphicon glyphicon-play-circle"></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LINK_EnProceso"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 1) ? true : false %>'
                                                CssClass="btn btn-info"                                                
                                                ToolTip="EN EJECUCIÓN">
                                                <i class="glyphicon glyphicon-record"></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LINK_Reinicia"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") > 1) ? true : false %>'
                                                CssClass='btn btn-danger'
                                                CommandName="Reinicia"
                                                CommandArgument='<%#Eval("ID_GRUPO_CARGA")%>'
                                                ToolTip='LIMPIAR EJECUCIÓN'>

                                                <i class='glyphicon glyphicon-erase'></i>
                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="Link_OK"
                                                runat="server"
                                                Enabled="false"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 2) ? true : false %>'
                                                CssClass='btn btn-success'
                                                ToolTip='PROCESO CARGADO'>
                                                <i class='glyphicon glyphicon-ok'></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="Link_OK_FIN"
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

                    <div class="col-sm-6" style="margin-top: 30px;">
                        <h4>
                            <asp:Label ID="Label2" runat="server" Text="INTERFACES A PROCESAR"></asp:Label>

                        </h4>
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

                                    <asp:TemplateField HeaderText="OPCIONES">

                                        <ItemTemplate>
                                            <asp:LinkButton ID="LINK_BuscarEjecuciones"
                                                runat="server"
                                                Visible="true"
                                                CssClass="btn btn-info"
                                                CommandName="BuscarEjecuciones"
                                                CommandArgument='<%# Eval("ID_EJECUCION")%>'
                                                ToolTip="BUSCAR EJECUCIONES">
                                                <i class="glyphicon glyphicon-search"></i>                                
                                            </asp:LinkButton>


                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:BoundField DataField="CODIGO_INTERFAZ" HeaderText="CODIGO INTERFAZ" ReadOnly="true" />
                                    <asp:BoundField DataField="FILENAME" HeaderText="ARCHIVO" ReadOnly="true" />
                                    <asp:BoundField DataField="TABLA" HeaderText="TABLA" ReadOnly="true" />
                                                          
                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="ESTADO" ReadOnly="true" />
                                    <asp:BoundField DataField="MENSAJE" HeaderText="DETALLE" ReadOnly="true" />


                                    <asp:TemplateField HeaderText="ACCIONES">

                                        <ItemTemplate>

                                            <asp:LinkButton
                                                ID="BTN_PARALELISMO"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 1 ) ? false : true %>'
                                                CommandName="Paralelismo"
                                                CommandArgument='<%# Eval("ID_EJECUCION") %>'
                                                ToolTip="ASIGNAR PROCESO"
                                                CssClass="btn btn-primary">
                                                <i class="glyphicon glyphicon-th-list"></i>
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LINK_EjecutaProcesos"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 0 ) ? true : false %>'
                                                CssClass="btn btn-success"
                                                CommandName="Play"
                                                CommandArgument='<%# Eval("ID_DETALLE_GRUPO_CARGA") %>'
                                                ToolTip="ENVIAR A EJECUTAR">
                                                <i class="glyphicon glyphicon-play-circle"></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LINK_EnProceso"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 1) ? true : false %>'
                                                CssClass="btn btn-info"                                                
                                                ToolTip="EN EJECUCIÓN">
                                                <i class="glyphicon glyphicon-record"></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LINK_Reinicia"
                                                runat="server"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") > 1) ? true : false %>'
                                                CssClass='btn btn-danger'
                                                CommandName="Reinicia"
                                                CommandArgument='<%#Eval("ID_DETALLE_GRUPO_CARGA")%>'
                                                ToolTip='LIMPIAR EJECUCIÓN'>

                                                <i class='glyphicon glyphicon-erase'></i>
                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="Link_OK"
                                                runat="server"
                                                Enabled="false"
                                                Visible='<%# ((int)Eval("ID_ESTADO_CARGA") == 2) ? true : false %>'
                                                CssClass='btn btn-success'
                                                ToolTip='PROCESO CARGADO'>
                                                <i class='glyphicon glyphicon-ok'></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="Link_OK_FIN"
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

                    <div class="col-sm-6" style="margin-top: 20px;">
                        <h4>
                            <asp:Label ID="Label6" runat="server" Text="PARALELISMO"></asp:Label>

                        </h4>
                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 20px;">

                    <div class="col-sm-12">
                        <div class="table-responsive">

                            <asp:GridView ID="GRDData" runat="server" AutoGenerateColumns="False"
                                CellPadding="4"
                                CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                ShowHeaderWhenEmpty="true">

                                <Columns>
                                    <asp:BoundField DataField="FECHA_CREACION" HeaderText="FECHA CREACION" ReadOnly="true" />
                                    <asp:BoundField DataField="ROW_INICIO" HeaderText="INICIO" ReadOnly="true" />
                                    <asp:BoundField DataField="ROW_FIN" HeaderText="FIN" ReadOnly="true" />
                                    <asp:BoundField DataField="ROW_PROCESADO" HeaderText="REGISTROS PROCESADO" ReadOnly="true" />
                                    <asp:BoundField DataField="ESTADO_PROCESO" HeaderText="ESTADO PROCESO" ReadOnly="true" />

                                    <asp:BoundField DataField="MENSAJE" HeaderText="DETALLE" ReadOnly="true" />

                                    <asp:TemplateField HeaderText="ACCIONES">

                                        <ItemTemplate>

                                            <asp:LinkButton ID="LinkButton1"
                                                runat="server"
                                                Enabled="false"
                                                Visible='<%# ((int)Eval("ID_ESTADO_PROCESO") == 1) ? true : false %>'
                                                CssClass='btn btn-info'
                                                ToolTip='EN PROCESO'>

                                                <i class='glyphicon glyphicon-record'></i>
                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="Link_OK"
                                                runat="server"
                                                Enabled="false"
                                                Visible='<%# ((int)Eval("ID_ESTADO_PROCESO") == 2) ? true : false %>'
                                                CssClass='btn btn-success'
                                                ToolTip='PROCESO FINALIZADO'>

                                                <i class='glyphicon glyphicon-ok'></i>
                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="Link_Error"
                                                runat="server"
                                                Enabled="false"
                                                Visible='<%# ((int)Eval("ID_ESTADO_PROCESO") == 3) ? true : false %>'
                                                CssClass='btn btn-danger'
                                                ToolTip='ERROR EN PROCESO'>

                                                <i class='glyphicon glyphicon-remove'></i>
                                
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
    <div class="modal fade" id="MODAL_GRID_PROCESO" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_PROCESO" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-tasks" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_PROCESO" runat="server" Text="PARTICIONAR CARGA"></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">


                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_PROCESO" class="alert alert-warning" style="display: none;"></div>
                            <div style="height: 10px"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>

                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:TextBox ID="TXT_ID_EJECUCION_PAR" runat="server" Width="100%" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="TXT_ID_GRUPO_CARGA_PAR" runat="server" Visible="false"></asp:TextBox>
                                </div>
                            </div>

                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row" style="margin-top: 10px;">
                                <div class="col-sm-3" style="margin-top: 10px;">
                                    <asp:Label ID="Label3" runat="server" Text="NUMERO DE PROCESO"></asp:Label>
                                </div>
                                <div class="col-sm-1"></div>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="DDL_PROCESO" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_PROCESO_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row" style="margin-top: 10px;">
                                <div class="col-sm-3">
                                    <asp:Label ID="Label7" runat="server" Text="REGISTROS"></asp:Label>
                                </div>
                                <div class="col-sm-1"></div>
                                <div class="col-sm-8">
                                    <asp:Label ID="LBL_REGISTROS" runat="server" Text="0"></asp:Label>
                                </div>
                            </div>
                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row" style="margin-top: 10px;">
                                <div class="col-sm-12">

                                    <div class="table-responsive">

                                        <asp:GridView ID="GRDListaProceso"
                                            runat="server"
                                            CellPadding="4"
                                            CssClass="table table-striped table-bordered table-hover"
                                            AutoGenerateColumns="False"
                                            ShowHeaderWhenEmpty="True"
                                            AllowPaging="false"
                                            Font-Size="10px">

                                            <Columns>

                                                <asp:BoundField DataField="NUMERO_PROCESO" HeaderText="NUMERO_PROCESO" ReadOnly="true" />
                                                <asp:BoundField DataField="INICIO" HeaderText="INICIO" ReadOnly="true" />
                                                <asp:BoundField DataField="FIN" HeaderText="FIN" ReadOnly="true" />

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div style="height: 10px"></div>
                            <div id="MSG_INFO_PROCESO" class="alert alert-info" style="display: none;"></div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BTN_PROCESO" runat="server"
                                Text="ASIGNAR"
                                OnClick="BTN_PROCESO_Click"
                                CssClass="btn btn-primary"
                                data-backdrop="static" />
                        </div>
                    </div>
                    <!-- FIN Modal content-->


                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_PROCESO" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--==============================================================================================================--%>
    <%-- FIN MODAL                                                                                                    --%>
    <%--==============================================================================================================--%>

    <%--==============================================================================================================--%>
    <%-- INICIO MODAL PROCESOS                                                                                        --%>
    <%--==============================================================================================================--%>
    <div class="modal fade" id="MODAL_PROCESOS" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_PROCESOS" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-tasks" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_PROCESOS" runat="server" Text="EJECUTAR LA CARGA CON ESTOS PROCESOS ?"></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_PROCESOS" class="alert alert-warning" style="display: none;"></div>
                            <div style="height: 10px"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>

                            <asp:TextBox runat="server" Visible="false" ID="TXT_ID_GRUPO_CARGA"></asp:TextBox>
                            <asp:TextBox runat="server" Visible="false" ID="TXT_ID_DETALLE_GRUPO_CARGA"></asp:TextBox>

                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row" style="margin-top: 10px;"></div>
                            <%--===========================================================================================================--%>
                            <%--===========================================================================================================--%>
                            <div class="row">

                                <div class="col-sm-6">
                                    <h4>
                                        <asp:Label ID="Label5" runat="server" Text="PROCESOS"></asp:Label></h4>
                                </div>

                            </div>
                            <%--=========================================================================================--%>
                            <%--=========================================================================================--%>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="table-responsive">

                                        <asp:GridView ID="GRD_PROCESOS" runat="server" AutoGenerateColumns="False"
                                            CellPadding="4"
                                            CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                            ShowHeaderWhenEmpty="true"
                                            OnPreRender="GRD_PROCESOS_PreRender">

                                            <Columns>

                                                <asp:BoundField DataField="FILENAME" HeaderText="ARCHIVO" ReadOnly="true" />
                                                <asp:BoundField DataField="FECHA_CREACION" HeaderText="FECHA CREACION" ReadOnly="true" />
                                                <asp:BoundField DataField="ROW_INICIO" HeaderText="INICIO" ReadOnly="true" />
                                                <asp:BoundField DataField="ROW_FIN" HeaderText="FIN" ReadOnly="true" />

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
                            <div id="MSG_INFO_PROCESOS" class="alert alert-info" style="display: none;"></div>


                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BTN_PROCESOS" runat="server"
                                Text="EJECUTAR"
                                OnClick="BTN_PROCESOS_Click"
                                CssClass="btn btn-primary"
                                data-backdrop="static" />
                        </div>
                    </div>
                    <!-- FIN Modal content -->


                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_PROCESOS" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--==============================================================================================================--%>
    <%-- FIN MODAL PROCESOS                                                                                           --%>
    <%--==============================================================================================================--%>


</asp:Content>
