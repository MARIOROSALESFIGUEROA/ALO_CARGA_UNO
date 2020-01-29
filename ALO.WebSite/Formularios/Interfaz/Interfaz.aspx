<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Interfaz.aspx.cs" Inherits="ALO.WebSite.Formularios.Interfaz.Interfaz" %>

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



            });

            $("#<%=DDL_TIPO_ARCHIVO.ClientID%>").selectpicker();
            $("#<%=DDL_TIPO_DELIMITADOR.ClientID%>").selectpicker();
            $("#<%=DDL_HOJA.ClientID%>").selectpicker();
            $("#<%=DDL_INTERFAZ.ClientID%>").selectpicker();
            $("#<%=DDL_TipoFileSystem.ClientID%>").selectpicker();
            $("#<%=DDL_TIPO_CARGA.ClientID%>").selectpicker();
            $("#<%=DDL_SELECT_CLUSTER.ClientID%>").selectpicker();


            $("#<%=LST_EXTENSIONES.ClientID%>").multiselect({
                includeSelectAllOption: true
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
                        <li class="breadcrumb-item active">Mantenedor Interfaz</li>
                    </ol>
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">

                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="Label4" runat="server" Text="CLUSTER"></asp:Label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="DDL_SELECT_CLUSTER" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_CLUSTER_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>

                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="LBL_INTERFAZ" runat="server" Text="INTERFAZ"></asp:Label>
                    </div>
                    <div class="col-sm-4">

                        <asp:DropDownList ID="DDL_INTERFAZ" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_INTERFAZ_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 10px;"></div>
                <div class="row">

                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="LBL_ESTADO" runat="server" Text="ESTADO INTERFAZ"></asp:Label>
                    </div>
                    <div class="col-sm-4" style="margin-top: 10px;">

                        <asp:CheckBox ID="CHK_ESTADO" runat="server" />

                    </div>


                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 10px;"></div>
                <div class="row">

                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="LBL_TIPO_ARCHIVO" runat="server" Text="TIPO DE ARCHIVO"></asp:Label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="DDL_TIPO_ARCHIVO" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_TIPO_ARCHIVO_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="LBL_MODIFICA_INTERFAZ" runat="server" Text="MODIFICAR INTERFAZ"></asp:Label>
                    </div>
                    <div class="col-sm-4" style="margin-top: 10px;">

                        <asp:CheckBox ID="CHK_MODIFICAR_INTERFAZ" runat="server" OnCheckedChanged="CHK_MODIFICAR_INTERFAZ_OnCheckedChanged" AutoPostBack="true" />

                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 10px;"></div>
                <div class="row">

                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="LBL_TIPO_DELIMITADOR" runat="server" Text="TIPO DE DELIMITADOR"></asp:Label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="DDL_TIPO_DELIMITADOR" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%" OnSelectedIndexChanged="DDL_TIPO_DELIMITADOR_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="LBL_DELIMITADOR" runat="server" Text="DELIMITADOR"></asp:Label>
                    </div>
                    <div class="col-sm-4">

                        <asp:TextBox ID="TXT_DELIMITADOR" CssClass="form-control" runat="server" Height="30px"></asp:TextBox>

                    </div>

                </div>

                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 10px;"></div>
                <div class="row">

                    <div class="col-sm-2">
                        <asp:Label ID="LBL_ENCABEZADO" runat="server" Text="POSEE ENCABEZADOS"></asp:Label>
                    </div>
                    <div class="col-sm-4">
                        <asp:CheckBox ID="CHK_ENCABEZADO" runat="server" />
                    </div>
                    <div class="col-sm-6">
                    </div>

                </div>


                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 10px;"></div>
                <div class="row">

                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="LBL_DESCRIPCION" runat="server" Text="DESCRIPCIÓN"></asp:Label>
                    </div>
                    <div class="col-sm-4">

                        <asp:TextBox ID="TXT_DESCRIPCION" CssClass="form-control" runat="server" Height="30px" Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="LBL_CODIGO_INTERFAZ" runat="server" Text="CODIGO INTERFAZ"></asp:Label>
                    </div>
                    <div class="col-sm-3">

                        <asp:TextBox ID="TXT_CODIGO_INTERFAZ" CssClass="form-control" runat="server" Height="30px" Width="100%"></asp:TextBox>

                    </div>
                    <div class="col-sm-1" style="margin-top: 5px;">

                        <asp:CheckBox ID="CHK_OPCION" runat="server" AutoPostBack="true" OnCheckedChanged="CHK_OPCION_OnCheckedChanged" />

                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 10px;"></div>
                <div class="row">

                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="LBL_TipoFile" runat="server" Text="TIPO DE CODIFICACIÓN"></asp:Label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="DDL_TipoFileSystem" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%">
                        </asp:DropDownList>
                    </div>

                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 10px;"></div>
                <div class="row">

                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="LBL_EXTENSIONES" runat="server" Text="EXTENSIONES DE ARCHIVOS"></asp:Label>
                    </div>
                    <div class="col-sm-4">

                        <asp:ListBox ID="LST_EXTENSIONES" runat="server" SelectionMode="Multiple"></asp:ListBox>

                    </div>
                    <div class="col-sm-2" style="margin-top: 10px;">
                        <asp:Label ID="LBL_TIPO_CARGA" runat="server" Text="TIPO DE CARGA"></asp:Label>
                    </div>
                    <div class="col-sm-4">

                        <asp:DropDownList ID="DDL_TIPO_CARGA" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width="100%">
                        </asp:DropDownList>


                    </div>

                </div>

                <%--==============================================================================================================--%>
                <%--==============================================================================================================--%>
                <div class="row" style="margin-top: 25px;"></div>

                <%--==============================================================================================================--%>
                <%--==============================================================================================================--%>
                <div class="row">

                    <div class="col-sm-10"></div>
                    <div class="col-sm-2">

                        <asp:LinkButton ID="BTN_ACTUALIZAR" runat="server" CssClass="btn btn-primary btn-block btn-sm" ToolTip="ACTUALIZAR" OnClick="BTN_ACTUALIZAR_Click" Visible="false">
                        <i class="fa fa-list-alt" aria-hidden="true">
                    </i>&nbsp;ACTUALIZAR</asp:LinkButton>

                    </div>

                </div>
                <%--==============================================================================================================--%>
                <%--==============================================================================================================--%>

                <asp:Panel ID="PNL_FILE" runat="server" Visible="false">
                    <%--===========================================================================================================--%>
                    <%--===========================================================================================================--%>
                    <div class="row">
                        <hr />
                    </div>
                    <%--==============================================================================================================--%>
                    <%--==============================================================================================================--%>
                    <div class="row" style="margin-top: 15px;">

                        <div class="col-sm-2">
                        </div>
                        <div class="col-sm-8">
                            <div class="alert alert-success btn-xs">
                                <asp:Label ID="LBL_Archivo" runat="server" Text="" Style="font-size: 10px; font-weight: bold"></asp:Label>
                            </div>

                        </div>
                        <div class="col-sm-2">
                            <asp:LinkButton ID="LinkbtnInterfaces" runat="server" CssClass="btn btn-primary btn-block btn-sm" ToolTip="VER INTERFAZ" OnClick="btnInterfaces_Click">
                    <i class="fa fa-list" aria-hidden="true">
                </i>&nbsp;INTERFAZ</asp:LinkButton>
                        </div>

                    </div>

                    <%--==============================================================================================================--%>
                    <%--==============================================================================================================--%>
                    <div class="row">

                        <div class="col-sm-2" style="margin-top: 5px;">
                            <asp:Label ID="Label6" runat="server" Text="INDIQUE ARCHIVO"></asp:Label>
                        </div>
                        <div class="col-sm-8">
                            <asp:FileUpload ID="FileUploadToServer" runat="server" Width="100%" Height="25px" />
                        </div>
                        <div class="col-sm-2">

                            <asp:LinkButton ID="LinkbtnUploadExcel" runat="server" CssClass="btn btn-primary btn-block btn-sm" ToolTip="UPLOAD" OnClick="btnUploadExcel_Click">
                    <i class="fa fa-upload" aria-hidden="true">
                </i>&nbsp;SUBIR</asp:LinkButton>
                        </div>

                    </div>

                    <%--==============================================================================================================--%>
                    <%--==============================================================================================================--%>
                    <div class="row" style="margin-top: 5px;">
                    </div>

                    <%--==============================================================================================================--%>
                    <%--==============================================================================================================--%>
                    <div class="row">

                        <div class="col-sm-2" style="margin-top: 10px;">
                            <asp:Label ID="Label7" runat="server" Text="HOJA"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="DDL_HOJA" class="selectpicker" data-live-search="true" data-width="100%" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                        </div>
                        <div class="col-sm-2">

                            <asp:LinkButton ID="LinkbtnLeerExcel" runat="server" CssClass="btn btn-primary btn-block btn-sm" ToolTip="LEER ARCHIVO" OnClick="btnLeerExcel_Click">
                    <i class="fa fa-book" aria-hidden="true">
                </i>&nbsp;LEER</asp:LinkButton>

                        </div>

                    </div>
                </asp:Panel>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">
                    <hr />
                </div>
                <%--==============================================================================================================--%>
                <%--==============================================================================================================--%>
                <div class="row" style="margin-top: 25px;">

                    <div class="table-responsive">
                        <asp:GridView ID="GRDExcel"
                            runat="server"
                            CellPadding="4"
                            CssClass="table table-striped table-bordered table-hover"
                            ShowHeaderWhenEmpty="true"
                            AllowPaging="true"
                            PageSize="10"
                            AutoGenerateColumns="false"
                            OnPageIndexChanging="GRDExcel_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="ORDEN" DataField="ORDEN" />
                                <asp:BoundField HeaderText="CAMPO" DataField="CAMPO" />
                                <asp:BoundField HeaderText="DATO" DataField="DATO" />
                                <asp:BoundField HeaderText="FORMATO" DataField="FORMATO" />
                                <asp:BoundField HeaderText="LARGO" DataField="LARGO" />
                                <asp:BoundField HeaderText="MISCELANEOS" DataField="MISCELANEOS" />
                            </Columns>
                        </asp:GridView>
                    </div>

                </div>

                <%--==============================================================================================================--%>
                <%--==============================================================================================================--%>
                <div class="row" style="margin-top: 25px;"></div>

                <%--==============================================================================================================--%>
                <%--==============================================================================================================--%>
                <div class="row">

                    <div class="col-sm-10"></div>
                    <div class="col-sm-2">

                        <asp:LinkButton ID="LinkbtnVerificar" runat="server" CssClass="btn btn-primary btn-block btn-sm" ToolTip="VERIFICAR" OnClick="btnVerificar_Click" Visible="false">
                        <i class="fa fa-list-alt" aria-hidden="true">
                    </i>&nbsp;VERIFICAR</asp:LinkButton>

                    </div>

                </div>
                <%--==============================================================================================================--%>
                <%--==============================================================================================================--%>
                <div class="row" style="margin-top: 10px;">

                    <div class="col-sm-10"></div>
                    <div class="col-sm-2">


                        <asp:LinkButton ID="LinkbtnImportarDatos" runat="server" CssClass="btn btn-primary btn-block btn-sm" ToolTip="GUARDAR" OnClick="btnImportarDatos_Click" Visible="false">
                        <i class="fa fa-floppy-o" aria-hidden="true">
                    </i>&nbsp;GUARDAR</asp:LinkButton>

                    </div>

                </div>

            </div>
            <%--==============================================================================================================--%>
            <%-- FIN CONTAINER                                                                                                --%>
            <%--==============================================================================================================--%>




            <%--==============================================================================================================--%>
            <%--==============================================================================================================--%>
            <div class="modal fade" id="ModalInterfaz" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h3>ESTRUCTURA DE ARCHIVO EXCEL</h3>
                        </div>
                        <div class="modal-body">

                            <div class="table-responsive">
                                <asp:GridView ID="GRDInterfaz"
                                    runat="server"
                                    CellPadding="4"
                                    CssClass="table table-striped"
                                    ShowHeaderWhenEmpty="true">
                                </asp:GridView>
                            </div>


                        </div>
                        <div class="modal-footer">
                            <a href="#" data-dismiss="modal" class="btn btn-danger">Cerrar</a>
                        </div>
                    </div>
                </div>
            </div>
            <%--==============================================================================================================--%>
            <%--==============================================================================================================--%>
        </ContentTemplate>
        <Triggers>

            <asp:PostBackTrigger ControlID="LinkbtnUploadExcel" />

        </Triggers>
    </asp:UpdatePanel>


</asp:Content>
