using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class clsEmpresa
    {

        public List<ConsultarEmpresaResult> ConsultarEmpresa()
        {

            try
            {
                DatosDataContext db = new DatosDataContext();

                List<ConsultarEmpresaResult> datos = db.ConsultarEmpresa().ToList();
                return datos;

            }
            catch (Exception ex)
            {

                throw;
            }


        }



        //


        public ConsultaEmpresaResult ConsultaEmpresa(int IdEmpresa)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();

                ConsultaEmpresaResult datos = db.ConsultaEmpresa(IdEmpresa).FirstOrDefault();
                return datos;

            }
            catch (Exception ex)
            {

                throw;
            }


        }




        public ConsultaEmpresaParaEditaResult ConsultaEmpresaParaEdita(int IdEmpresa)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();

                ConsultaEmpresaParaEditaResult datos = db.ConsultaEmpresaParaEdita(IdEmpresa).FirstOrDefault();
                return datos;

            }
            catch (Exception ex)
            {

                throw;
            }


        }




        public bool EliminaEmpresa(int IdEmpresa)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                db.EliminaEmpresa(IdEmpresa);
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }


        }


        public bool ActualizaEmpresa(int IdEmpresa, String Descripcion, int IdTipoIdentificacion, String Identificacion, String Telefono, String Contacto, bool Estado)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                db.ActualizaEmpresa(IdEmpresa, Descripcion, IdTipoIdentificacion, Identificacion, Telefono, Contacto, Estado);
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }


        }


        public bool CreaEmpresa(int IdEmpresa, String Descripcion, int IdTipoIdentificacion, String Identificacion, String Telefono, String Contacto, bool Estado)
        {

            try
            {
                DatosDataContext db = new DatosDataContext();
                db.CreaEmpresa(IdEmpresa, Descripcion, IdTipoIdentificacion, Identificacion, Telefono, Contacto, Estado);
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }


        }





    }
}

       
    
