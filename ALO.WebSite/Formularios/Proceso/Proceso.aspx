<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Proceso.aspx.cs" Inherits="ALO.WebSite.Formularios.Proceso.Proceso" %>

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

                //==============================================================================
                // CALENDARIO JQUERY                                           
                //==============================================================================
                $("#<%=TXT_FECHA_INI.ClientID%>").datepicker({
                    showOn: 'button',
                    dateFormat: 'd-mm-yy',
                    buttonImageOnly: true,
                    buttonImage: '<%=UrlWeb("~/IMAGES/date.png")%>'
                });

                $("#<%=DDL_TIMER.ClientID%>").selectpicker();
                $("#<%=DDL_INTERFAZ.ClientID%>").selectpicker();
                $("#<%=DDL_CAMPANA.ClientID%>").selectpicker();

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

            <asp:Timer ID="tm" Interval="5000" runat="server" OnTick="tm_Tick"></asp:Timer>

            <%--==============================================================================================================--%>
            <%-- CONTAINER                                                                                                    --%>
            <%--==============================================================================================================--%>
            <div class="container">

                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">
                    <div class="col-sm-12">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item active">PROCESOS</li>
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

                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="Label2" runat="server" Text="CAMPAÑA"></asp:Label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="DDL_CAMPANA" CssClass="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_CAMPANA_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="Label1" runat="server" Text="INTERFAZ"></asp:Label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="DDL_INTERFAZ" CssClass="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_INTERFAZ_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">
                    <hr />
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-2">
                        <asp:Label ID="Label5" runat="server" Text="PERIODO"></asp:Label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TXT_FECHA_INI" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="DDL_TIMER" CssClass="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_TIMER_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 5px;"></div>
                <div class="row">

                    <div class="col-sm-8">
                    </div>
                    <div class="col-sm-4">
                        <asp:LinkButton ID="LinK_BNT_BUSCAR" runat="server" CssClass="btn btn-default btn-block btn-sm" ToolTip="CONSULTAR" OnClick="BNT_BUSCAR_Click">
                            <i class="glyphicon glyphicon-search" aria-hidden="true">
                        </i>&nbsp;CONSULTAR</asp:LinkButton>
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
                <div class="row" style="margin-top: 10px;">

                    <div class="col-sm-12">
                        <div class="table-responsive">

                            <asp:GridView ID="GRDData" runat="server" AutoGenerateColumns="False"
                                CellPadding="4"
                                CssClass="table table-striped table-bordered table-hover tablaConBuscador"
                                ShowHeaderWhenEmpty="true">

                                <Columns>

                                    <asp:BoundField DataField="INTERFAZ" HeaderText="INTERFAZ" ReadOnly="true" />
                                    <asp:BoundField DataField="FILA" HeaderText="FILA" ReadOnly="true" />
                                    <asp:BoundField DataField="PROCESADOS" HeaderText="PROCESADOS" ReadOnly="true" />
                                    <asp:BoundField DataField="PORCENTAJE" HeaderText="PORCENTAJE" ReadOnly="true" />

                                </Columns>
                            </asp:GridView>
                        </div>
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
</asp:Content>
