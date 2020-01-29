<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.Master" CodeBehind="CambioPassword.aspx.cs" Inherits="ALO.WebSite.Account.CambioPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


  <!-- =================================================================================================================== -->
  <!-- SCRIPT                                                                                                              -->
  <!-- =================================================================================================================== -->
    <script type="text/javascript">


 


    </script>
  <!-- =================================================================================================================== -->
  <!-- FIN SCRIPT                                                                                                          -->
  <!-- =================================================================================================================== -->


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:UpdatePanel ID="UPDATE_PANEL_CONTENEDOR" runat="server" >
    <ContentTemplate>


        <%--===========================================================================================================--%>
        <%--===========================================================================================================--%>
        <div class="container">



        <%--===========================================================================================================--%>
        <%--===========================================================================================================--%>
        <div class="row">
        
            <div class="col-sm-12"></div>       

        </div>
        <%--===========================================================================================================--%>
        <%--===========================================================================================================--%>
        <div class="row">
        
			<div class="col-sm-4">

			</div>
			<div class="col-sm-4">
				<div class="modal-content" id="password_modal">
					<div class="modal-header">
						<h3>Cambiar Contraseña <span class="extra-title muted"></span></h3>
					</div>
					<div class="modal-body">
						<div class="control-group">
								<div class="input-group">
									<span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
									<asp:TextBox ID="TXT_PASSWORD_ACTUAL" TextMode="Password" Cssclass="form-control" runat="server" placeholder="Contraseña Actual" required="required" MaxLength="15"></asp:TextBox>
								</div>
						</div>
						<span class="help-block"></span>
						<div class="control-group"><div class="container"></div>
								<div class="input-group">
									<span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
									<asp:TextBox ID="TXT_PASSWORD_NUEVA" TextMode="Password" Cssclass="form-control" runat="server" placeholder="Nueva Contraseña" required="required" MaxLength="15"></asp:TextBox>
								</div>
						</div>
						<span class="help-block"></span>
						<div class="control-group">
								<div class="input-group">
									<span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
									<asp:TextBox ID="TXT_PASSWORD_CONFIRMAR" TextMode="Password" Cssclass="form-control" runat="server" placeholder="Confirmar Contraseña" required="required" MaxLength="15"></asp:TextBox>
								</div>
						</div>      
					</div>
					<div class="modal-footer">
						<asp:Button runat="server" 
							Class="btn btn-primary" ID="BTN_GUARDAR_PASSWORD" 
							Text="Guardar Cambios"
							OnClick="BTN_GUARDAR_PASSWORD_Click"></asp:Button>
					</div>
				</div>
			</div>
			<div class="col-sm-8">

			</div>
	
                                                     
        </div>
        <%--===========================================================================================================--%>
        <%--===========================================================================================================--%>
     




        </div>

     


    </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>

