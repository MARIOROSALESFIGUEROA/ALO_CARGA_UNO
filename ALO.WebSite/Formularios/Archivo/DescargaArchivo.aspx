<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="DescargaArchivo.aspx.cs" Inherits="ALO.WebSite.Formularios.Archivo.DescargaArchivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- =================================================================================================================== -->
    <!-- ESTILOS                                                                                                             -->
    <!-- =================================================================================================================== -->
    <style type="text/css">
        /* scroll para panel*/
        .scroll-panel {
            height: 300px;
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

        //=====================================================================================
        // FUNCION DE INICIO                                                                
        //=====================================================================================
        function pageLoad() {

            $(document).ready(function () {
                $(".selectpicker").selectpicker();

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


    <%--==============================================================================================================--%>
    <%-- CONTAINER                                                                                                    --%>
    <%--==============================================================================================================--%>
    <div class="container">

        <%--===========================================================================================================--%>
        <%--===========================================================================================================--%>
        <div class="row">
            <ol class="breadcrumb">
                <li class="breadcrumb-item active">Descarga de Archivos de Carga</li>
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
                <asp:DropDownList ID="DDL_INTERFAZ" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%">
                </asp:DropDownList>
            </div>

        </div>
        <%--===========================================================================================================--%>
        <%--===========================================================================================================--%>
        <div class="row" style="margin-top: 25px;"></div>
        <%--===========================================================================================================--%>
        <%--===========================================================================================================--%>
        <div class="row">

            <div class="col-sm-offset-2 col-sm-1">
                <asp:Label ID="Label5" runat="server" Text="PERIODO INICIO" Style="margin-top: 10px;"></asp:Label>
            </div>
            <div class="col-sm-3">
                <asp:TextBox ID="TXT_FECHA_INI" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-sm-1">
                <asp:Label ID="Label1" runat="server" Text="PERIODO FIN" Style="margin-top: 10px;"></asp:Label>
            </div>
            <div class="col-sm-3">
                <asp:TextBox ID="TXT_FECHA_FIN" runat="server" CssClass="form-control"></asp:TextBox>
            </div>


            <div class="col-sm-1">
                <asp:LinkButton ID="LinK_BNT_BUSCAR" runat="server" CssClass="btn btn-primary" ToolTip="BUSCAR" OnClick="BNT_BUSCAR_Click">
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
            <div class="col-sm-6">
                <div class="scroll-panel">

                    <asp:TreeView ID="TREE_ARCHIVO"
                        CssClass="treeview"
                        runat="server"
                        ShowLines="true"
                        ShowExpandCollapse="true"
                        ShowCheckBoxes="Root"
                        NodeIndent="10"
                        OnTreeNodeCheckChanged="TREE_ARCHIVO_TreeNodeCheckChanged">

                        <ParentNodeStyle Font-Bold="false"
                            Font-Underline="false" />

                        <HoverNodeStyle Font-Underline="false" ForeColor="#337ab7" />

                        <SelectedNodeStyle Font-Underline="false"
                            ForeColor="#337ab7"
                            HorizontalPadding="0px"
                            VerticalPadding="0px" />

                        <NodeStyle ForeColor="Black"
                            HorizontalPadding="0px"
                            VerticalPadding="5px"
                            NodeSpacing="0px" />

                    </asp:TreeView>

                </div>
            </div>


            <div class="col-sm-6">
                <div class="row">
                    <div class="col-md-12">
                        <h4 runat="server" id="LBL_TITULO_SELECCION">ARCHIVOS SELECCIONADOS </h4>
                    </div>
                </div>

                <div class="row">
                    <div class="scroll-panel">
                        <div class="col-md-12">
                            <div id="DIV_SELECCIONADOS" runat="server" style="margin-top: 20px"></div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <asp:LinkButton ID="BTN_DESCARGA" runat="server" CssClass="btn btn-primary btn-block btn-sm" ToolTip="DESCARGAR ARCHIVO" OnClick="BTN_DESCARGA_Click"> <i class="fa fa-download" aria-hidden="true">
                                </i>&nbsp;DESCARGAR
                        </asp:LinkButton>

                    </div>
                </div>

            </div>

        </div>

    </div>

    <%--===========================================================================================================--%>
    <%--===========================================================================================================--%>
    <div class="row" style="margin-top: 20px;"></div>
    <%--==============================================================================================================--%>
    <%-- FIN CONTAINER                                                                                                --%>
    <%--==============================================================================================================--%>
</asp:Content>

