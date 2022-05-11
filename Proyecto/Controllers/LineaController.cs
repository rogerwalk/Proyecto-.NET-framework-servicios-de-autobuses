using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//se incorpora el BLL Y Models

using BLL;
using DAL;
using Proyecto.Models;


namespace Proyecto.Controllers
{
    public class LineaController : Controller
    {

        // se hace una instancia de la clsLinea

        clsLinea ObjLinea = new clsLinea();
        clsEmpresa ObjEmpresa = new clsEmpresa();
        clsConsulta ObjConsulta = new clsConsulta();


        // GET: Linea
        public ActionResult Index()
        {

            try
            {
                //variable  de session 
                Session["Empresa"] = 1;

                var datos = ObjLinea.ConsultarLinea(Convert.ToInt32(Session["Empresa"].ToString()));

                //Instaciar el Objeto
                List<Linea> ListaLineas = new List<Linea>();

                foreach (var item in datos)
                {
                    Linea linea = new Linea();

                    linea.IdEmpresa = item.IdEmpresa;
                    linea.IdLinea = item.IdLinea;
                    linea.Descripcion = item.Descripcion;
                    linea.CodigoCTP = item.CodigoCTP;
                    linea.Provincia = (char)item.Provincia;
                    linea.Canton = item.Canton;
                    linea.Distrito = item.Distrito;
                    linea.Estado = item.Estado;

                    ListaLineas.Add(linea);


                }
                return View(ListaLineas);
            }
            catch (Exception ex)
            {

                return new HttpNotFoundResult("Error a Consultar Las Lineas");

            }

        }


        public ActionResult Editar(int id)
        {

            try
            {
                //variable  de session 
                Session["Empresa"] = 1;

                var dato = ObjLinea.ConsultaLinea(Convert.ToInt32(Session["Empresa"].ToString()), id);


                Linea linea = new Linea();

                linea.IdEmpresa = dato.IdEmpresa;
                linea.IdLinea = dato.IdLinea;
                linea.Descripcion = dato.Descripcion;
                linea.CodigoCTP = dato.CodigoCTP;
                linea.Provincia = (char)dato.Provincia;
                linea.Canton = dato.Canton;
                linea.Distrito = dato.Distrito;
                linea.Estado = dato.Estado;

                ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                ViewBag.Provincias = ObjConsulta.ListaProvincias();
                ViewBag.Cantones = ObjConsulta.ListaCantones(linea.Provincia);
                ViewBag.Distritos = ObjConsulta.ListaDistritos(linea.Provincia, linea.Canton);
                return View(linea);
            }
            catch (Exception ex)
            {

                return new HttpNotFoundResult("Error al Editar La Linea");

            }

       
        }


        [HttpPost]
        public ActionResult Editar(Linea linea)
        {

            try
            {
                //variable  de session 
                Session["Empresa"] = 1;


                if (ObjLinea.ActualizaLinea(Convert.ToInt32(Session["Empresa"].ToString()), linea.IdLinea, linea.Descripcion, linea.CodigoCTP, linea.Provincia, linea.Canton, linea.Distrito, linea.Estado))
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();

                    ViewBag.Provincias = ObjConsulta.ListaProvincias();
                    ViewBag.Cantones = ObjConsulta.ListaCantones(linea.Provincia);
                    ViewBag.Distritos = ObjConsulta.ListaDistritos(linea.Provincia, linea.Canton);

                    return View();
                }

            }
            catch (Exception ex)
            {

                return new HttpNotFoundResult("Error al Editar La Linea");

            }


        }



       
        public ActionResult Crear( )
        {

            try
            {


             
                    ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                ViewBag.Provincias = ObjConsulta.ListaProvincias();

                return View();
                }

            
            catch (Exception ex)
            {

                return new HttpNotFoundResult("Error al Editar La Linea");

            }


        }


        [HttpPost]
        public ActionResult Crear(Linea linea)
        {

            try
            {
                //variable  de session 
                Session["Empresa"] = 1;


                if (ObjLinea.CreaLinea(linea.IdLinea,linea.Descripcion, linea.CodigoCTP, linea.Provincia, linea.Canton, linea.Distrito, linea.Estado))
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                    ViewBag.Provincias = ObjConsulta.ListaProvincias();
                    ViewBag.Cantones = ObjConsulta.ListaCantones(linea.Provincia);
                    ViewBag.Distritos = ObjConsulta.ListaDistritos(linea.Provincia, linea.Canton);
                    return View();
                }

            }
            catch (Exception ex)
            {

                return new HttpNotFoundResult("Error al Editar La Linea");

            }


        }



        public ActionResult Eliminar(int id)
        {

            try
            {
                //variable  de session 
                Session["Empresa"] = 1;

                var dato = ObjLinea.ConsultaLinea(Convert.ToInt32(Session["Empresa"].ToString()), id);


                Linea linea = new Linea();

                linea.IdEmpresa = dato.IdEmpresa;
                linea.IdLinea = dato.IdLinea;
                linea.Descripcion = dato.Descripcion;
                linea.CodigoCTP = dato.CodigoCTP;
                linea.Provincia = (char)dato.Provincia;
                linea.Canton = dato.Canton;
                linea.Distrito = dato.Distrito;
                linea.Estado = dato.Estado;


                return View(linea);
            }
            catch (Exception ex)
            {

                return new HttpNotFoundResult("Error al Eliminar La Linea");

            }


        }


        [HttpPost]

        public ActionResult Eliminar(Linea linea)
        {

            try
            {
                //variable  de session 
                Session["Empresa"] = 1;


                if (ObjLinea.EliminaLinea(Convert.ToInt32(Session["Empresa"].ToString()), linea.IdLinea))
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                    ViewBag.Provincias = ObjConsulta.ListaProvincias();
                    ViewBag.Cantones = ObjConsulta.ListaCantones(linea.Provincia);
                    ViewBag.Distritos = ObjConsulta.ListaDistritos(linea.Provincia, linea.Canton);
                    return View();
                }

            }
            catch (Exception ex)
            {

                return new HttpNotFoundResult("Error al Editar La Linea");

            }


        }




        /// <summary>
        /// Cargar Cantones hacia la pantalla
        /// </summary>
        /// <param name="provincia"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CargaCantones(char provincia)
        {
            List<CantonesResult> cantones = ObjConsulta.ListaCantones(provincia);
            return Json(cantones, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Cargar Disttritos hacia la pantalla
        /// </summary>
        /// <param name="provincia"></param>
        /// <param name="canton"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CargaDistritos(char provincia, string canton)
        {
            List<DistritosResult> distritos = ObjConsulta.ListaDistritos(provincia, canton);
            return Json(distritos, JsonRequestBehavior.AllowGet);
        }






    }
}



    

