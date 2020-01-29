using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALO.Entidades;
using ALO.Servicio;
using ALO.Utilidades;

namespace ALO.WebSite.Formularios.Proceso
{
    public partial class ProcesoWho2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                GRDDetalle.PreRender += new EventHandler(GRDDetalle_PreRender);
                //===========================================================
                // POSTBACK                                               
                //===========================================================
                if (!this.IsPostBack)
                {

                    try
                    {





                    }
                    catch { }

                    //======================================================
                    // FECHAS POR DEFECTO                                 
                    //======================================================
                    tm.Enabled = false;
                    LeerTimer();
                    PNL_MENSAJE.Visible = false;
                    LeerProcesos();

                }

            }
            catch (EServiceRestFulException ex)
            {

                MensajeLOG(ex.Message, "Errores de Servicio");
            }
            catch (System.Exception ex)
            {

                MensajeLOG(UThrowError.MensajeThrow(ex), "Errores Aplicacion");
            }
        }


        /// <summary>
        /// MENSAJE LOG
        /// </summary>
        /// <param name="Mensaje"></param>
        /// <param name="Titulo"></param>
        private void MensajeLOG(string Mensaje, string Titulo)
        {

            try
            {


                //===========================================================
                // CONTENIDO DIV CON RUNAT SERVER                         
                //===========================================================
                MSG_ALERTA.InnerHtml = WebUtility.HtmlDecode(Mensaje);
                PNL_MENSAJE.Visible = true;




            }
            catch { }

        }

        /// <summary>
        /// TIMER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tm_Tick(object sender, EventArgs e)
        {
            try
            {
                Thread.Sleep(1000);
                LeerProcesos();

            }
            catch (EServiceRestFulException ex)
            {

                MensajeLOG(ex.Message, "Errores de Servicio");
            }
            catch (System.Exception ex)
            {

                MensajeLOG(UThrowError.MensajeThrow(ex), "Errores Aplicacion");

            }
        }




        /// <summary>
        /// LEER TIMER 
        /// </summary>
        private void LeerTimer()
        {
            try
            {



                //===========================================================
                // ESTADOS                                                       
                //===========================================================
                List<Item_Seleccion> Lista = new List<Item_Seleccion>();
                Lista.Add(new Item_Seleccion { Id = 0, Nombre = "SIN TIMER" });
                Lista.Add(new Item_Seleccion { Id = 5000, Nombre = "5 SEGUNDOS" });
                Lista.Add(new Item_Seleccion { Id = 10000, Nombre = "10 SEGUNDOS" });
                Lista.Add(new Item_Seleccion { Id = 15000, Nombre = "15 SEGUNDOS" });


                FuncionesGenerales.CDDLCombos(Lista, DDL_TIMER);



            }
            catch
            {
                throw;
            }


        }

        /// <summary>
        /// LEER PROCESOS
        /// </summary>
        private void LeerProcesos()
        {
            try
            {

                //===========================================================
                // PANEL INVISIBLE                                              
                //===========================================================
                PNL_MENSAJE.Visible = false;

                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                SMetodos Servicio = new SMetodos();

                //===========================================================
                // LISTA DE PROCESOS                                            
                //===========================================================
                List<oSP_READ_WHO2> ListaProcesos = new List<oSP_READ_WHO2>();
                ListaProcesos = Servicio.SP_READ_WHO2();
                FuncionesGenerales.Cargar_Grilla(ListaProcesos, GRDDetalle);

            }
            catch
            {
                throw;
            }


        }


        /// <summary>
        /// GRILLA PRERENDER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDDetalle_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRDDetalle.UseAccessibleHeader = true;
                GRDDetalle.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }


        /// <summary>
        /// BUSCAR DATOS SISTEMA Y LLENAR SUS GRILLAS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LINK_BUSCAR_Click(Object sender, EventArgs e)
        {
            try
            {


                //===========================================================
                // LLAMAR CONSULTA                                              
                //===========================================================
                LeerProcesos();


            }
            catch (EServiceRestFulException ex)
            {

                MensajeLOG(ex.Message, "Errores de Servicio");
            }
            catch (System.Exception ex)
            {

                MensajeLOG(UThrowError.MensajeThrow(ex), "Errores Aplicacion");

            }

        }


        /// <summary>
        /// COMBO TIEMPOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_TIMER_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                //===========================================================
                // OPCION                                                       
                //===========================================================
                int OPCION = -1;
                OPCION = Convert.ToInt32(DDL_TIMER.SelectedValue);


                //===========================================================
                //SI LA OPCION ES 0 DETENGO EL TIMER                            
                //===========================================================
                if (OPCION == 0)
                {
                    tm.Enabled = false;
                }
                else
                {
                    tm.Enabled = true;
                    tm.Interval = OPCION;

                }





            }
            catch (EServiceRestFulException ex)
            {

                MensajeLOG(ex.Message, "Errores de Servicio");
            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "Errores Aplicacion");
            }
        }


        /// <summary>
        /// GRILLA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string BLOQUEO = DataBinder.Eval(e.Row.DataItem, "BLKBY").ToString();
                    int BLK = 0;

                    if (BLOQUEO.Trim() == ".")
                    {
                        BLK = 0;
                    }



                    if (BLK > 0)
                    {
                        Color_Al_Bloquear(e.Row);
                    }
                    else
                    {
                        Color_Al_DesMarcar(e.Row);
                    }

                }
            }
            catch (EServiceRestFulException ex)
            {
                MensajeLOG(ex.Message, "Errores de Servicio");
            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "Errores Aplicacion");
            }

        }

        /// <summary>
        /// COLOR INFORMATVO
        /// </summary>
        /// <param name="row"></param>
        private void Color_Informativo(GridViewRow row)
        {
            try
            {
                row.BackColor = System.Drawing.Color.LightGreen;
                row.ForeColor = System.Drawing.Color.Black;

            }
            catch { }
        }


        /// <summary>
        /// COLOR DES-MARCAR  
        /// </summary>
        /// <param name="row"></param>
        private void Color_Al_DesMarcar(GridViewRow row)
        {
            try
            {

                row.BackColor = System.Drawing.Color.White;
                row.ForeColor = System.Drawing.Color.Gray;

            }
            catch { }
        }


        /// <summary>
        /// COLOR DE BLOQUEO
        /// </summary>
        /// <param name="row"></param>
        private void Color_Al_Bloquear(GridViewRow row)
        {
            try
            {
                row.BackColor = System.Drawing.Color.Red;
                row.ForeColor = System.Drawing.Color.White;

            }
            catch { }
        }
    }
}