using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using Proyecto.Models;
namespace Proyecto.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa


        clsEmpresa ObjEmpresa = new clsEmpresa();


        public ActionResult Index()
        {
           


            try
            {
                //variable  de session 
               // Session["Empresa"] = 1;

                var datos = ObjEmpresa.ConsultarEmpresa();

                //Instaciar el Objeto
                List<Empresa> ListaEmpresas = new List<Empresa>();

                foreach (var item in datos)
                {
                    Empresa empresa = new Empresa();

                    empresa.IdEmpresa = item.IdEmpresa;
                    empresa.Descripcion = item.Descripcion;
                    empresa.IdTipoIdentificacion = item.IdTipoIdentificacion;
                    empresa.Identificacion = item.Identificacion;
                    empresa.Telefono = item.Telefono;
                    empresa.Contacto = item.Contacto;
                    empresa.Estado = item.Estado;

                    ListaEmpresas.Add(empresa);


                }
                return View(ListaEmpresas);
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


                var dato = ObjEmpresa.ConsultaEmpresaParaEdita(id);


                Empresa empresa = new Empresa();

                empresa.IdEmpresa = dato.IdEmpresa;
                empresa.Descripcion = dato.Descripcion;
                empresa.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                empresa.Identificacion = dato.Identificacion;
                empresa.Telefono = dato.Telefono;
                empresa.Contacto = dato.Contacto;
                empresa.Estado = dato.Estado;

                ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
              
                return View(empresa);
            }
            catch (Exception ex)
            {

                return new HttpNotFoundResult("Error al Editar La Linea");

            }


        }



       

        [HttpPost]
        public ActionResult Editar(Empresa empresa)
        {

            try
            {
               


                if (ObjEmpresa.ActualizaEmpresa(empresa.IdEmpresa, empresa.Descripcion, empresa.IdTipoIdentificacion, empresa.Identificacion, empresa.Telefono, empresa.Contacto, empresa.Estado))
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();

                    
                    return View();
                }

            }
            catch (Exception ex)
            {

                return new HttpNotFoundResult("Error al Editar La Linea");

            }


        }





        public ActionResult Crear()
        {

            try
            {






                ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
               

                return View();
            }


            catch (Exception ex)
            {

                return new HttpNotFoundResult("Error al Editar La Linea");

            }


        }


        [HttpPost]
        public ActionResult Crear(Empresa empresa)
        {

            try
            {
              


                if (ObjEmpresa.CreaEmpresa(empresa.IdEmpresa, empresa.Descripcion, empresa.IdTipoIdentificacion, empresa.Identificacion, empresa.Telefono, empresa.Contacto, empresa.Estado))
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                    
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
               

                var dato = ObjEmpresa.ConsultaEmpresaParaEdita(id);


                Empresa empresa = new Empresa();

                empresa.IdEmpresa = dato.IdEmpresa;
                empresa.Descripcion = dato.Descripcion;
                empresa.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                empresa.Identificacion = dato.Identificacion;
                empresa.Telefono = dato.Telefono;
                empresa.Contacto = dato.Contacto;
                empresa.Estado = dato.Estado;



                return View(empresa);
            }
            catch (Exception ex)
            {

                return new HttpNotFoundResult("Error al Eliminar La Linea");

            }


        }


        [HttpPost]

        public ActionResult Eliminar(Empresa empresa)
        {

            try
            {
                //variable  de session 
              


                if (ObjEmpresa.EliminaEmpresa(empresa.IdEmpresa))
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.Empresas = ObjEmpresa.ConsultarEmpresa();
                   
                    return View();
                }

            }
            catch (Exception ex)
            {

                return new HttpNotFoundResult("Error al Editar La Linea");

            }


        }






    }
}