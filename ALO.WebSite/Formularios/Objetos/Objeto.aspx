<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Objeto.aspx.cs" Inherits="ALO.WebSite.Formularios.Objetos.Objeto" %>

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
                        <li class="breadcrumb-item active">CREACIÓN DE OBJETOS</li>
                    </ol>
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-offset-4 col-sm-1" style="margin-top: 10px;">
                        <asp:Label ID="Label4" runat="server" Text="CLUSTER"></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="DDL_SELECT_CLUSTER" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_CLUSTER_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 20px;"></div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-1">
                        <asp:LinkButton ID="BNT_NUEVO_OBJETO" OnClick="BNT_NUEVO_OBJETO_Click" runat="server" CssClass="btn btn-primary" ToolTip="NUEVO OBJETO">
                            <i class="glyphicon glyphicon-plus" >
                        </i></asp:LinkButton>
                    </div>
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 25px;"></div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>

                <div class="row" style="margin-top: 20px;">
                    <div class="col-sm-12">
                        <div class="table-responsive">

                            <asp:GridView ID="GRD_OBJETO" runat="server" AutoGenerateColumns="False"
                                CellPadding="4"
                                CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                ShowHeaderWhenEmpty="true"
                                OnPreRender="GRD_OBJETO_PreRender"
                                OnRowCommand="GRD_OBJETO_RowCommand">
                                <Columns>

                                    <asp:BoundField DataField="CODIGO_OBJETO" HeaderText="CODIGO DE OBJETO" ReadOnly="true" />
                                    <asp:BoundField DataField="DESCRIPCION_OBJETO" HeaderText="DESCRIPCION DEL OBJETO" ReadOnly="true" />

                                    <asp:TemplateField HeaderText="OBLIGATORIO" SortExpression="OBLIGATORIO">
                                        <ItemTemplate><%# (Boolean.Parse(Eval("OBLIGATORIO").ToString())) ? "SI" : "NO" %></ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ACCIONES">

                                        <ItemTemplate>

                                            <asp:LinkButton ID="LINK_editar"
                                                runat="server"
                                                Visible="true"
                                                CssClass='btn btn-primary'
                                                CommandName="EditarObjeto"
                                                CommandArgument='<%# Eval("ID_OBJETO")%>'
                                                ToolTip='EDITAR OBJETO'>
                                                <i class='glyphicon glyphicon-pencil'></i>                                
                                            </asp:LinkButton>

                                            <asp:LinkButton ID="LINK_delete"
                                                runat="server"
                                                Visible="true"
                                                CssClass='btn btn-danger'
                                                CommandName="EliminarObjeto"
                                                CommandArgument='<%# Eval("ID_OBJETO")%>'
                                                ToolTip='ELIMINAR  OBJETO'>
                                                <i class='glyphicon glyphicon-trash'></i>                                
                                            </asp:LinkButton>   

                                        </ItemTemplate>

                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>

                <%--==============================================================================================================--%>
                <%--==============================================================================================================--%>
                <div class="row" style="margin-top: 25px;"></div>
                <%--==============================================================================================================--%>
                <%--==============================================================================================================--%>
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
    <div class="modal fade" id="MODAL_GRID_OBJETO" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_OBJETO" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-tasks" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_OBJETO" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">


                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_OBJETO" class="alert alert-warning" style="display: none;"></div>
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
                                    <div class="checkbox checkbox-primary">
                                        <asp:CheckBox ID="CHK_OBLIGATORIO" runat="server" Text="OBLIGATORIO" Style="color: black;" />
                                    </div>
                                </div>

                            </div>

                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div style="height: 10px"></div>
                            <div id="MSG_INFO_OBJETO" class="alert alert-info" style="display: none;"></div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BTN_OBJETO" runat="server"
                                Text=""
                                OnClick="BTN_OBJETO_Click"
                                CssClass="btn btn-primary"
                                data-backdrop="static" />
                        </div>
                    </div>
                    <!-- FIN Modal content-->


                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_OBJETO" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <%--==============================================================================================================--%>
    <%-- FIN MODAL                                                                                                    --%>
    <%--==============================================================================================================--%>


    <%--=======================================================================================================================--%>
    <%-- INICIO MODAL ELIMINA OBJETO                                                                        --%>
    <%--=======================================================================================================================--%>
    <div class="modal fade" id="MODAL_ELIMINA_OBJETO" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_ELIMINA_OBJETO_" runat="server">
            <ContentTemplate>
                <div class="modal-dialog">


                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">
                                <i class="glyphicon glyphicon-trash" aria-hidden="true"></i>
                                <asp:Label ID="LBL_TITULO_ELIMINA_OBJETO" runat="server" Text="ELIMINAR OBJETO"></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">


                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_ALERTA_ELIMINA_OBJETO" class="alert alert-warning" style="display: none;"></div>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <form>


                                <%--=========================================================================================--%>
                                <%--=========================================================================================--%>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:Label ID="LBL_TITULO_MENSAJE_ELIMINA_OBJETO" runat="server" Text="Label"></asp:Label>
                                    </div>
                                </div>

                                <%--=========================================================================================--%>
                                <%--=========================================================================================--%>
                                <div class="row" style="margin-top: 5px;">

                                    <div class="col-sm-12">
                                        <asp:TextBox ID="TXT_ID_ELIMINA_OBJETO" runat="server" Visible="false"></asp:TextBox>
                                    </div>

                                </div>

                            </form>
                            <%--*********************************************************************************************--%>
                            <%--*********************************************************************************************--%>
                            <div id="MSG_INFO_ELIMINA_OBJETO" class="alert alert-info" style="display: none;"></div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BTN_ELIMINA_OBJETO" runat="server"
                                Text="ELIMINAR"
                                OnClick="BTN_ELIMINA_OBJETO_Click"
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

   

