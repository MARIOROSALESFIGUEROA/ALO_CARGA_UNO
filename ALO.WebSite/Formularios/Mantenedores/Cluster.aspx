<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.Master" CodeBehind="Cluster.aspx.cs" Inherits="ALO.WebSite.Formularios.Mantenedores.Cluster" %>

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
                    "pageLength": 10,
                    "paging": true,
                    "lengthChange": false,
                    "searching": true,
                    "ordering": true,
                    "info": true,
                    "autoWidth": false,

                });

            });

        }

    </script>
    <!-- =================================================================================================================== -->
    <!-- FIN SCRIPT                                                                                                          -->
    <!-- =================================================================================================================== -->


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UPDATE_PANEL_CONTENEDOR" runat="server" >
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
                    <li class="breadcrumb-item active">MANTENEDOR DE CLÚSTER </li>
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
        
            <div class="col-sm-12">      
                <asp:LinkButton ID="LINK_NuevoCluster" runat="server" CssClass="btn btn-primary" ToolTip="AGREGAR NUEVO CLÚSTER" OnClick="LINK_NuevoCluster_Click" >
                    <i class="glyphicon glyphicon-plus">
                </i></asp:LinkButton>
            </div>
        </div>
        <%--===========================================================================================================--%>
        <%--===========================================================================================================--%>
        <div class="row" style ="margin-top :10px;">
        
            <div class="col-sm-12">
                <div class="table-responsive">

                    <asp:GridView ID="GRDCluster" 
                                        runat="server"
									    CellPadding="4"
									    CssClass="table table-striped table-bordered table-hover tablaConBuscador"
									    AutoGenerateColumns="False"
									    ShowHeaderWhenEmpty="True"
									    AllowPaging="false"
                                        font-size = "10px"
                                        OnRowcommand="GRDCluster_RowCommand">

                                        
                                         
                    <Columns>


                          
                            <asp:BoundField DataField="PAIS" HeaderText= "PAÍS" ReadOnly ="true"/>
                            <asp:BoundField DataField="CODIGO" HeaderText= "CÓDIGO" ReadOnly ="true"/>
                            <asp:BoundField DataField="DESCRIPCION" HeaderText= "DESCRIPCIÓN" ReadOnly ="true"/>
                            <asp:BoundField DataField="STR_ESTADO" HeaderText= "VIGENTE" ReadOnly ="true"/>

                            <asp:TemplateField HeaderText="ACCIONES" SortExpression="c.ID">
                                    <ItemTemplate>
                               
                               
                                    <asp:LinkButton ID="LINK_EditarData" runat="server" CssClass="btn btn-primary" CommandName="EditarData" CommandArgument='<%# Eval("ID_CLUSTER") %>' ToolTip="EDITAR CLÚSTER">
                                        <i class="glyphicon glyphicon-edit">
                                    </i></asp:LinkButton>

                                    <asp:LinkButton ID="LINK_Elimina"  runat="server" CssClass="btn btn-danger" CommandName="EliminarData" CommandArgument='<%# Eval("ID_CLUSTER") %>' ToolTip="ELIMINAR CLÚSTER">
                                        <i class="glyphicon glyphicon-trash">
                                    </i></asp:LinkButton>

                                    </ItemTemplate>
                            </asp:TemplateField>


                    </Columns>
                    </asp:GridView>  


               
                </div>
            </div>
                                        
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
    <%-- MODIFICAR EN GRILLA                                                                                          --%>
    <%--==============================================================================================================--%>
    <div class="modal fade" id="MODAL_CLUSTER" role="dialog">
        <asp:UpdatePanel ID="UPDATE_PANEL_MODIFICAR" runat="server" >
        <ContentTemplate>
        <div class="modal-dialog">

    
                <!-- Modal content-->
                <div class="modal-content">
                <div class="modal-header">
					<h4 class="modal-title">
						<i class="glyphicon glyphicon-menu-hamburger"></i>
						<asp:Label ID="LBL_TITULO_CLUSTER" runat="server" Text=""></asp:Label>
					</h4>
                </div>
                <div class="modal-body">

                    <%--*********************************************************************************************--%>
                    <%--*********************************************************************************************--%>
                    <div id="MSG_CLUSTER_ALERTA" class="alert alert-warning" style ="display: none;"  ></div>
                    <%--*********************************************************************************************--%>
                    <%--*********************************************************************************************--%>
                    <form>

                        <div class="row">
                           <asp:TextBox ID="TXT_ID" runat="server" Visible ="false"></asp:TextBox>
                        </div>
                        <div class="row" style ="height :10px"></div>
                        <div class="row">
        
                            <div class="col-sm-3">
                                <asp:Label ID="Label3" runat="server" Text="PAIS"></asp:Label>
                            </div>  
                            <div class="col-sm-1"></div>          
                            <div class="col-sm-8">
                               <asp:DropDownList ID="DDL_PAIS" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width ="100%">
                                </asp:DropDownList>
                            </div> 
                        </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <asp:Label ID="Label1" runat="server" Text="CÓDIGO"></asp:Label>
                            </div>  
                            <div class="col-sm-1"></div>          
                            <div class="col-sm-7">
                                <asp:TextBox ID="TXT_CODIGO" CssClass="form-control" runat="server" Width ="100%" ></asp:TextBox>
                            </div> 
                            <div class="col-sm-1">
                                <asp:CheckBox ID="CHK_OPCION" runat="server" AutoPostBack ="true" OnCheckedChanged="CHK_OPCION_OnCheckedChanged"/>
                            </div> 
                        </div>
                        <div class="row">
        
                            <div class="col-sm-3">
                                <asp:Label ID="Label2" runat="server" Text="DESCRIPCIÓN DE GRUPO"></asp:Label>
                            </div>  
                            <div class="col-sm-1"></div>          
                            <div class="col-sm-8">
                                <asp:TextBox ID="TXT_DESCRIPCION" CssClass="form-control" runat="server" Width ="100%" ></asp:TextBox>
                            </div> 
                        </div>
                        <div class="row" style ="height :10px"></div>
                        <div class="row">
        
                            <div class="col-sm-3">
                                <asp:Label ID="Label6" runat="server" Text="ESTADO"></asp:Label>
                            </div>  
                            <div class="col-sm-1"></div>          
                            <div class="col-sm-8">
                                
                                <asp:CheckBox ID="CHK_ESTADO" runat="server" />

                            </div> 
                        </div>



                    </form>
                    <%--*********************************************************************************************--%>
                    <%--*********************************************************************************************--%>
                    <div id="MSG_CLUSTER_INFO" class="alert alert-info" style ="display: none;" ></div>


                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="BTN_EditGrilla" runat="server" 
                                Text="Actualizar" 
                                onclick="BTN_EditGrilla_Click"
                                CssClass="btn btn-primary" 
                                data-backdrop="static"/>
                </div>
                </div>
                <!-- FIN Modal content-->   
                  
                     
        </div>
        </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BTN_EditGrilla" EventName="Click" />
             </Triggers>
        </asp:UpdatePanel>
    </div>

    <%--==============================================================================================================--%>
    <%-- FIN MODIFICAR EN GRILLA                                                                                      --%>
    <%--==============================================================================================================--%>

	<%--==============================================================================================================--%>
	<%-- ELIMINA                                                                                                      --%>
	<%--==============================================================================================================--%>
	<div class="modal fade" id="MODAL_GRID_ELIMINA" role="dialog">
		<asp:UpdatePanel ID="UPDATE_PANEL_ELIMINA" runat="server">
			<ContentTemplate>
				<div class="modal-dialog">


					<!-- Modal content-->
					<div class="modal-content">
						<div class="modal-header">
							<button type="button" class="close" data-dismiss="modal">&times;</button>
							<h4 class="modal-title">
                                <i class="glyphicon glyphicon-trash" aria-hidden="true"></i>
								<asp:Label ID="LBL_ELIMINAR" runat="server" Text="ELIMINACIÓN DEL USUARIO"></asp:Label>
							</h4>
						</div>
						<div class="modal-body">


							<%--*********************************************************************************************--%>
							<%--*********************************************************************************************--%>
							<div id="MSG_ALERTA_ELIMINA" class="alert alert-warning" style="display: none;"></div>
							<%--*********************************************************************************************--%>
							<%--*********************************************************************************************--%>
							<form>


								<%--=========================================================================================--%>
								<%--=========================================================================================--%>
								<div class="row">
									<div class="col-sm-12">
										<asp:Label ID="LBL_MENSAJE_ELIMINA" runat="server" Text="Label"></asp:Label>
									</div>
								</div>

								<%--=========================================================================================--%>
								<%--=========================================================================================--%>
								<div class="row" style="margin-top: 5px;">

									<div class="col-sm-12">
										<asp:TextBox ID="TXT_ID_ELIMINA" runat="server" Visible="false"></asp:TextBox>
									</div>

								</div>

							</form>
							<%--*********************************************************************************************--%>
							<%--*********************************************************************************************--%>
							<div id="MSG_INFO_ELIMINA" class="alert alert-info" style="display: none;"></div>

						</div>
						<div class="modal-footer">
							<button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
							<asp:Button ID="BTN_ELIMINA" runat="server"
								Text="ELIMINAR"
								OnClick="BTN_ELIMINA_Click"
								CssClass="btn btn-danger"
								data-backdrop="static" />
						</div>
					</div>
					<!-- FIN Modal content-->


				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
	</div>
	<%--==============================================================================================================--%>
	<%-- FIN ELIMINA                                                                                                  --%>
	<%--==============================================================================================================--%>
        
</asp:Content>

