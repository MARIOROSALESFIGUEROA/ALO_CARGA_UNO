<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AsignacionObjeto.aspx.cs" Inherits="ALO.WebSite.Formularios.Objetos.AsignacionObjeto" %>

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
                        <li class="breadcrumb-item active">Asignación de Objetos</li>
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
                        <asp:LinkButton ID="BNT_NUEVA_ASIGNACION" OnClick="BNT_NUEVA_ASIGNACION_Click" runat="server" CssClass="btn btn-primary" ToolTip="NUEVA ASIGNACIÓN">
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
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
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
</asp:Content>
