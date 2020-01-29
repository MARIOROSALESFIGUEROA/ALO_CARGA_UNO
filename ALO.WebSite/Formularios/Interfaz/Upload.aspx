<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="ALO.WebSite.Formularios.Interfaz.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" href="favicon.ico" />
    <title>UPLOAD</title>

    <%=CSSLink("~/lib/bootstrap-3.3.7/css/bootstrap.min.css")%>
    <%=JSLink("~/lib/jquery-3.2.0/jquery-3.2.0.min.js")%>
    <%=JSLink("~/lib/bootstrap-3.3.7/js/bootstrap.min.js")%>


    <!-- =================================================================================================================== -->
    <!-- ESTILOS                                                                                                             -->
    <!-- =================================================================================================================== -->
    <style type="text/css">
        .upload-drop-zone
        {
            height: 200px;
            border-width: 2px;
            margin-bottom: 20px;
        }


        .upload-drop-zone
        {
            color: #ccc;
            border-style: dashed;
            border-color: #ccc;
            line-height: 200px;
            text-align: center;
        }

            .upload-drop-zone.drop
            {
                color: #222;
                border-color: #222;
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



        $("document").ready(function () {

            



            var DROP_ZONE = document.getElementById('drop-zone');
            var FILE_UP = document.getElementById('FILE_UPLOAD');
            //===========================================================
            // DRAG AND DROP                                                         
            //===========================================================
            DROP_ZONE.ondrop = function (evt) {

                evt.preventDefault();
                FILE_UP.files = evt.dataTransfer.files;
                DibujarFiles();
            }

            DROP_ZONE.ondragover = function (evt) {
                evt.preventDefault();
            }

            //===========================================================
            // FUNCION SIZE                                                        
            //===========================================================
            function bytesToSize(bytes) {
                var sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
                if (bytes == 0) return 'n/a';
                var i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)));
                if (i == 0) return bytes + ' ' + sizes[i];
                return (bytes / Math.pow(1024, i)).toFixed(1) + ' ' + sizes[i];
            }

            //===========================================================
            // AL SUBIR ARCHIVOS                                                   
            //===========================================================
            $("#BTN_UPLOAD").click(function (evt) {

                //=======================================================
                // EXTRACCION DE REGISTROS SOBRE EL OBJETO INPUT           
                //=======================================================
                var files = document.getElementById("FILE_UPLOAD").files;
                var OPCION = "<%=HD_OPCION.Value%>";
                var CODIGO_INTERFAZ = "<%=HD_CODIGO_INTERFAZ.Value%>";
                var ID_INTERFAZ = "<%=HD_ID_INTERFAZ.Value%>";
                var ID_GRUPO_CARGA = "<%=HD_ID_GRUPO_CARGA.Value%>";

                var PERMITIDO = 1610612736;
                //var PERMITIDO = 21474836480;
                for (var i = 0; i < files.length; i++) {

                    //===================================================
                    // ARCHIVO                                             
                    //===================================================  
                    var fecha = new Date();
                    var fechaHora = fecha.getFullYear() + "_" + (fecha.getMonth() + 1) + "_" + fecha.getDate() + "_" + fecha.getHours() + "_" + fecha.getMinutes() + "_" + fecha.getSeconds() + "_" + fecha.getMilliseconds();                    

                    var formData = new FormData();
                    formData.append(files[i].name, files[i]);
                    formData.append("OPCION", OPCION);
                    formData.append("CODIGO_INTERFAZ", CODIGO_INTERFAZ);
                    formData.append("ID_INTERFAZ", ID_INTERFAZ);
                    formData.append("ID_GRUPO_CARGA", ID_GRUPO_CARGA);
                    formData.append("FILA", i); 
                    formData.append("FECHA_HORA", fechaHora);


                    //===================================================
                    // AJAX UPLOAD                                         
                    //===================================================
                    $.ajax({
                        url: '<%=UrlWeb("~/ashx/FileUploadHandler.ashx")%>',
                        type: "POST",
                        data: formData,
                        cache: false,
                        contentType: false,
                        processData: false,
                        xhr: function () {

                            var ObjetoMensaje = document.getElementById('MENSAJE_' + i);
                            var ObjetoLoading = document.getElementById('LOADING_' + i);
                            var ObjetoProgress = document.getElementById('FILEUP_' + i);


                            if (files[i].size <= PERMITIDO) {
                                var xhr = new XMLHttpRequest();

                                ObjetoLoading.style.display = "block";
                                ObjetoMensaje.style.display = "none";

                                xhr.upload.addEventListener("progress", function (e) {

                                    if (e.lengthComputable) {
                                        var pourc = Math.round(e.loaded / e.total) * 100;
                                        $(ObjetoProgress).attr('style', 'width: ' + pourc + '%').attr('aria-valuenow', pourc).text(pourc + '%');
                                    }
                                }, true);

                                xhr.upload.addEventListener("load", function (e) {
                                    ObjetoLoading.style.display = "none";
                                }, false);

                                xhr.upload.addEventListener("error", function (e) {
                                    ObjetoLoading.style.display = "none";
                                    ObjetoMensaje.style.display = "block";
                                    ObjetoMensaje.innerHTML = "Error : " + xhr.status;
                                }, false);

                                return xhr;
                            }
                            else {
                                ObjetoLoading.style.display = "none";
                                ObjetoMensaje.style.display = "block";
                                ObjetoMensaje.innerHTML = "ARCHIVO SUPERA LO PERMITIDO : " + bytesToSize(PERMITIDO);
                            }

                        },
                        success: function (data) {

                            var ELEMENTOS = data.split('|');

                            OPCION = ELEMENTOS[0];
                            FILA = ELEMENTOS[1];
                            MENSAJE = ELEMENTOS[2];

                            var ObjetoMensaje = document.getElementById('MENSAJE_' + FILA);
                            var ObjetoLoading = document.getElementById('LOADING_' + FILA);

                            ObjetoLoading.style.display = "none";
                            ObjetoMensaje.style.display = "block";

                            ObjetoMensaje.innerHTML = OPCION + " : " + MENSAJE;

                        },
                        error: function (xhr, textStatus, errorThrown) {

                            var MENSAJE = "";
                            var ARRAY;

                            if (xhr.responseText != "") {

                                var PARSER = new DOMParser();
                                var XMLDOC = PARSER.parseFromString(xhr.responseText, "text/xml");
                                MENSAJE = XMLDOC.getElementsByTagName('title')[0].innerHTML;
                                ARRAY = MENSAJE.split('|');
                                MENSAJE = ARRAY[1];

                                var ObjetoMensajeM = document.getElementById('MENSAJE_' + ARRAY[0]);
                                ObjetoMensajeM.style.display = "none";
                                ObjetoMensajeM.style.display = "block";
                                ObjetoMensajeM.innerHTML = MENSAJE;

                            }
                        }
                    });
                }

            });

            //===========================================================
            // AL SELECCIONAR LOS ARCHIVOS                                         
            //===========================================================
            $('input[type=file]#FILE_UPLOAD').change(function () {

                DibujarFiles();
            });

            //===========================================================
            // DIBUJAR TABLA                                                         
            //===========================================================
            function DibujarFiles() {

                //===========================================================
                // EXTRACCION DE REGISTROS SOBRE EL OBJETO INPUT           
                //===========================================================
                var files = document.getElementById("FILE_UPLOAD").files;

                //===========================================================
                // ITERACION DE ARCHIVOS Y DIBUJA TABLAS                   
                // FILEUP_ NUMBER SERA LA LLAVE                            
                //===========================================================
                var TABLA = '<div class="table-responsive">';
                TABLA = TABLA + '<table class="table">';
                TABLA = TABLA + '<thead><tr>';
                TABLA = TABLA + '<th>FILE</th>'
                TABLA = TABLA + '<th>SIZE</th>'
                TABLA = TABLA + '<th>DETALLE</th>'
                TABLA = TABLA + '<th>UPLOAD</th>'
                TABLA = TABLA + '</tr></thead>';
                TABLA = TABLA + '<tbody>';

                for (var i = 0; i < files.length; i++) {

                    TABLA = TABLA + '<tr>';

                    TABLA = TABLA + '<td>';
                    TABLA = TABLA + files[i].name;
                    TABLA = TABLA + '</td>';

                    TABLA = TABLA + '<td>';
                    TABLA = TABLA + bytesToSize(files[i].size);
                    TABLA = TABLA + '</td>';

                    TABLA = TABLA + '<td>';
                    TABLA = TABLA + '<div id="LOADING_' + i + '" style ="display: none;">'
                    TABLA = TABLA + '<img src=' + '<%=UrlWeb("~/images/loading_X.gif")%>' + ' alt="loading">';
                    TABLA = TABLA + '</div>';
                    TABLA = TABLA + '<div id="MENSAJE_' + i + '" style ="display: none;">'
                    TABLA = TABLA + '</div>';
                    TABLA = TABLA + '</td>';

                    TABLA = TABLA + '<td>';
                    TABLA = TABLA + '<div class="progress">'
                    TABLA = TABLA + '<div id="FILEUP_' + i + '" class="progress-bar" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%">0%</div>';
                    TABLA = TABLA + '</div>';
                    TABLA = TABLA + '</td>';

                    TABLA = TABLA + '</tr>';
                }
                TABLA = TABLA + '</tbody>';
                TABLA = TABLA + '</table>';
                TABLA = TABLA + '</div>';
                document.getElementById("TABLA").innerHTML = TABLA;

            }

        });

    </script>
    <!-- =================================================================================================================== -->
    <!-- FIN SCRIPT                                                                                                          -->
    <!-- =================================================================================================================== -->

</head>
<body>
    <form id="form1" runat="server">

        <asp:HiddenField ID="HD_OPCION" runat="server"/>
        <asp:HiddenField ID="HD_CODIGO_INTERFAZ" runat="server" Value="0" />
        <asp:HiddenField ID="HD_ID_INTERFAZ" runat="server" Value="0" />
        <asp:HiddenField ID="HD_ID_GRUPO_CARGA" runat="server" Value="0" />

        <%--==============================================================================================================--%>
        <%-- CONTAINER                                                                                                    --%>
        <%--==============================================================================================================--%>
        <div class="container">

            <div class="col-md-12">
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 5px;">

                    <div class="alert alert-success btn-xs">
                        <asp:Label ID="LBL_MENSAJE" runat="server" Text="" Style="font-size: 10px; font-weight: bold"></asp:Label>
                    </div>


                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 5px;">


                    <div class="col-sm-12">

                        <div class="form-group">
                            <label class="control-label">ARCHIVO</label>
                            <input id="FILE_UPLOAD" type="file" name="ARCHIVOS" style="margin-bottom: 10px;" multiple="multiple" />
                            <div class="upload-drop-zone" id="drop-zone">
                                ARRASTRE Y SUELTE EN ESTA ZONA
                            </div>
                        </div>
                    </div>
                </div>


                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row" style="margin-top: 10px;">

                    <div class="col-sm-12">
                        <div id="TABLA"></div>
                    </div>
                </div>
                <%--===========================================================================================================--%>
                <%--===========================================================================================================--%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-6 col-xs-6 text-left">
                            <input type="button" id="BTN_UPLOAD" class="btn btn-primary" value="SUBIR" />
                        </div>
                        <div class="col-md-6 col-xs-6 text-right">
                            <asp:Button runat="server" ID="BTN_VOLVER" CssClass="btn btn-primary" Text="CONTINUAR" OnClick="BTN_VOLVER_Click"/>
                        </div>
                    </div>

                </div>

            </div>

        </div>
        <%--==============================================================================================================--%>
        <%-- FIN CONTAINER                                                                                                --%>
        <%--==============================================================================================================--%>
    </form>
</body>

</html>
