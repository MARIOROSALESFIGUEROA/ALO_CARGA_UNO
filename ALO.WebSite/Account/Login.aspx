<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ALO.WebSite.Account.Login" %>

<!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="icon" href="favicon.ico" />
    <title> Login </title>

  <!-- =================================================================================================================== -->
  <!-- BOOTSTRAP                                                                                                           -->
  <!-- =================================================================================================================== -->
    <%=CSSLink("~/lib/bootstrap-3.3.7/css/bootstrap.min.css")%>
    <%=JSLink("~/lib/jquery-3.2.0/jquery-3.2.0.min.js")%>
    <%=JSLink("~/lib/bootstrap-3.3.7/js/bootstrap.min.js")%>

	<!-- =================================================================================================================== -->
	<!-- ESTILOS                                                                                                             -->
	<!-- =================================================================================================================== -->
	<style type="text/css">
		html, body {
			margin: 0;
			padding: 0;
		}


		body {
			font-size: 8px;
		}

		.btn-primary {
			color: #fff;
			background-color: #5993ff;
			border-color: #5993ff;
			box-shadow: 2px 2px 5px #999;
		}

		.well {
			min-height: 20px;
			padding: 19px;
			margin-bottom: 20px;
			background-color: #f5f5f5;
			border: 1px solid #e3e3e3;
			border-radius: 4px;
			-webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.05);
			box-shadow: inset 0 1px 1px rgba(0,0,0,.05);
			box-shadow: 3px 3px 11px 0px #999;
		}

		.input-group-addon {
			padding: 6px 12px;
			font-size: 14px;
			font-weight: 400;
			line-height: 1;
			color: #2758b3;
			text-align: center;
			background-color: #fff;
			border: 1px solid #ccc;
			border-radius: 4px;
		}

		.checkbox input[type=checkbox], .checkbox-inline input[type=checkbox], .radio input[type=radio], .radio-inline input[type=radio] {
			position: absolute;
			margin-left: 1px;
			MARGIN-TOP: -1px;
		}

		.h4, .h5, .h6, h4, h5, h6 {
			margin-top: 10px;
			margin-bottom: 10px;
			MARGIN-LEFT: 18px;
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
        // MOSTRAR DETALLE DE MENSAJE  EN EL POPUP DE ERRORES                               
        //=====================================================================================
        function MostrarThrow() {
            document.getElementById("OcultoThrowError").style.display = "block";
            document.getElementById("IMG_MostrarError").style.display = "none";
            document.getElementById("IMG_OcultarError").style.display = "block";

        }
        function OcultarThrow() {
            document.getElementById("OcultoThrowError").style.display = "none";
            document.getElementById("IMG_MostrarError").style.display = "block";
            document.getElementById("IMG_OcultarError").style.display = "none";
        }


        //=====================================================================================
        // MENSAJE LOG POR PANTALLA                                                         
        //=====================================================================================
        function MensajeLOG(Titulo) {


            //===========================================================
            // CAMBIO TITULO DEL MODAL                                      
            //===========================================================


            $("#TituloModal").html(Titulo);
            //===========================================================
            // RELLENO LOS DATOS                                            
            //===========================================================
            var ObjetoServer = document.getElementById("<%=LOG_MENSAJE_SERVER.ClientID%>");
            $("#LOG_MENSAJE_DIALOG").html(ObjetoServer.innerHTML);

            //===========================================================
            // MOSTRAR INFORMACION MODAL                                    
            //===========================================================
            $("#mostrarmodal").modal("show");
            ObjetoServer.innerHTML = '';

        }



    </script>
  <!-- =================================================================================================================== -->
  <!-- FIN SCRIPT                                                                                                          -->
  <!-- =================================================================================================================== -->

</head>
<body>

	<form id="form1" runat="server">


		<!-- ===========================================================================================================================-->
		<!-- LOGIN                                                                                                                      -->
		<!-- ===========================================================================================================================-->
		<div id="login-overlay" class="modal-dialog">

			<div class="modal-content">


				<div class="modal-header">
					<div class="row ">
						<div class="col-sm-8">
						<p class="h3">
							<img style="max-width: 250px; margin-left: 1px; height: 70px" alt="Logo"
								src='<%=Href("~/images/LOGO_B.png")%>' />
							<asp:Label ID="LBL_TITULO" runat="server" Text="Inicio de Sesión"></asp:Label>
						</p>
					</div>
						<div class="col-sm-3"></div>
					</div>
				</div>
				<div class="modal-body">
					<div class="row">

						<div class="col-sm-6">
							<div class="well">



								<span class="help-block"></span>

								<span class="help-block"></span>
								<div class="input-group">
									<span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
									<asp:TextBox ID="TXT_LOGIN" type="text" CssClass="form-control"
										runat="server" placeholder="Usuario" required="required">
									</asp:TextBox>
								</div>
								<span class="help-block"></span>
								<div class="input-group">
									<span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
									<asp:TextBox ID="TXT_PASSWORD" TextMode="Password" CssClass="form-control"
										runat="server" placeholder="Contraseña" required="required">
									</asp:TextBox>
								</div>
								<span class="help-block"></span>
								<span class="help-block"></span>
								<asp:Button ID="BTN_Login" runat="server" Text="Iniciar Sesión"
									CssClass="btn btn-primary btn-block" OnClick="BTN_Login_Click" />

								<span class="help-block"></span>
								<asp:CheckBox ID="RememberMe" runat="server" CssClass="checkbox" />
								<h6>Recordar</h6>
							</div>
						</div>
						<div class="col-sm-6">
							<div class="row">
								<div class="col-sm-12 text-center">
									<h4 class="form-signin-heading text-muted">MÓDULO DE CARGAS FILE</h4>
								</div>
							</div>
							<div class="row" style="margin-top:20px">
								<div class="col-sm-12 text-center">
									<p class="h4">
										<img style="max-width: 300px; margin-right:30px;  height: 100px" alt="Logo"
											src='<%=Href("~/images/LOGO_A.png")%>' />
									</p>
								</div>
							</div>
						</div>

					</div>
				</div>


			</div>
		</div>



		<!-- ===========================================================================================================================-->
		<!-- MODAL DIALOG                                                                                                               -->
		<!-- ===========================================================================================================================-->
		<div id="LOG_MENSAJE_SERVER" runat="server" style="display: none;">
		</div>

		<div class="modal fade" id="mostrarmodal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
						<h3 id="TituloModal"></h3>
					</div>
					<div class="modal-body">

						<div id="LOG_MENSAJE_DIALOG">
						</div>

					</div>
					<div class="modal-footer">
						<a href="#" data-dismiss="modal" class="btn btn-danger">Cerrar</a>
					</div>
				</div>
			</div>
		</div>
		<!-- ===========================================================================================================================-->
		<!-- FIN MODAL DIALOG                                                                                                           -->
		<!-- ===========================================================================================================================-->

	</form>
</body>
</html>									
							