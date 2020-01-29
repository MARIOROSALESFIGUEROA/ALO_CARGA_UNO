<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ProcesoWho2.aspx.cs" Inherits="ALO.WebSite.Formularios.Proceso.ProcesoWho2" %>
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

            $("#<%=DDL_TIMER.ClientID%>").selectpicker();


            $("#<%=GRDDetalle.ClientID%>").DataTable({
                "stateSave": true,
                "pageLength": 15,
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


        }







    </script>
  <!-- =================================================================================================================== -->
  <!-- FIN SCRIPT                                                                                                          -->
  <!-- =================================================================================================================== -->



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:UpdatePanel ID="UPDATE_PANEL_CONTENEDOR" runat="server" >
    <ContentTemplate>

    <asp:Timer ID="tm" Interval="5000" runat="server" ontick="tm_Tick"></asp:Timer>

    <%--==============================================================================================================--%>
    <%-- CONTAINER                                                                                                    --%>
    <%--==============================================================================================================--%>
    <div class="container">
        
        <%--===========================================================================================================--%>
        <%--===========================================================================================================--%>
        <div class="row">
            <ol class="breadcrumb">
                <li class="breadcrumb-item active">SP_WHO2</li>
            </ol>
        </div>

        <%--==============================================================================================================--%>
        <%--==============================================================================================================--%>
        <div class="row" style ="margin-top :10px;">

            <asp:Panel runat="server" ID="PNL_MENSAJE" Visible="false">
                <div id="MSG_ALERTA" class="alert alert-warning" runat="server">
                </div>
            </asp:Panel>
            
        </div>
        <%--===========================================================================================================--%>
        <%--===========================================================================================================--%>
        <div class="row" >
            <hr />
        </div>
        <%--===========================================================================================================--%>
        <%--===========================================================================================================--%>
		<div class="row" style ="margin-top :10px;"></div>
        <div class="row">
        
            <div class="col-sm-2" style=" margin-top :10px;">
                <asp:Label ID="Label3" runat="server" Text="TIMER"></asp:Label>
            </div>       
            <div class="col-sm-4">
               
                <asp:DropDownList ID="DDL_TIMER" class="selectpicker" data-live-search="true" data-width="100%" runat="server" Width ="100%" OnSelectedIndexChanged="DDL_TIMER_SelectedIndexChanged" AutoPostBack ="true"  >
                </asp:DropDownList>

            </div>  
            <div class="col-sm-6">
               

            </div> 				

        </div>
        <%--===========================================================================================================--%>
        <%--===========================================================================================================--%>
		<div class="row" style ="margin-top :10px;"></div>
        <div class="row">
        
            <div class="col-sm-2">
                
            </div>       
            <div class="col-sm-4">
               
                    <asp:LinkButton ID="LINK_BUSCAR" runat="server" CssClass="btn btn-default btn-block btn-sm" ToolTip="BUSCAR" OnClick="LINK_BUSCAR_Click" >
                        <i class="glyphicon glyphicon-search" aria-hidden="true" aria-hidden="true">
                    </i>&nbsp;BUSCAR</asp:LinkButton> 

            </div>  
			<div class="col-sm-6">
				
			</div>  
        </div>
        
        <%--===========================================================================================================--%>
        <%--===========================================================================================================--%>
		<div class="row" style ="margin-top :10px;"></div>
        <div class="row">
        
            <div class="col-sm-12">
               
                <div class="table-responsive">

                <asp:GridView   ID="GRDDetalle" 
                                runat="server" 
                                CellPadding="4"
                                CssClass="table table-striped table-bordered table-hover"
                                AutoGenerateColumns="False"
                                ShowHeaderWhenEmpty="true"
                                OnRowDataBound ="GRDDetalle_RowDataBound">
                                
                <Columns>
                               


                    <asp:TemplateField HeaderText="SPID" Visible ="true" >
                        <ItemTemplate >
                            <asp:Label ID="LBL_SPID" runat="server"  Text='<%# Bind("SPID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="STATUS"      HeaderText="STATUS"         ReadOnly ="true"/>
                    <asp:BoundField DataField="LOGIN"       HeaderText="LOGIN"          ReadOnly ="true"/>
                    <asp:BoundField DataField="HOSTNAME"    HeaderText="HOSTNAME"       ReadOnly ="true"/>
                    <asp:BoundField DataField="BLKBY"       HeaderText="BLKBY"          ReadOnly ="true"/>
                    <asp:BoundField DataField="DBNAME"      HeaderText="DBNAME"         ReadOnly ="true"/>
                    <asp:BoundField DataField="COMMAND"     HeaderText="COMMAND"        ReadOnly ="true"/>
                    <asp:BoundField DataField="CPUTIME"     HeaderText="CPUTIME"        ReadOnly ="true"/>
                    <asp:BoundField DataField="DISKIO"      HeaderText="DISKIO"         ReadOnly ="true"/>
                    <asp:BoundField DataField="LASTBATCH"   HeaderText="LASTBATCH"      ReadOnly ="true"/>
                    <asp:BoundField DataField="PROGRAMNAME" HeaderText="PROGRAMNAME"    ReadOnly ="true"/>
                    <asp:BoundField DataField="SPID_2"      HeaderText="SPID_2"         ReadOnly ="true"/>
                    <asp:BoundField DataField="REQUESTID"   HeaderText="REQUESTID"      ReadOnly ="true"/>
                </Columns>
                </asp:GridView>
        
                </div>
                  



            </div>       
        </div>
        



    </div>
    <%--==============================================================================================================--%>
    <%-- FIN CONTAINER                                                                                                --%>
    <%--==============================================================================================================--%>



    </ContentTemplate>
    </asp:UpdatePanel>


                  


</asp:Content>
