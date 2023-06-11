using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProspectos.Models;
using WebProspectos.Models.TableViewModels;
using WebProspectos.Models.ViewModels;

namespace WebProspectos.Controllers
{
    public class ProspectosController : Controller
    {
        // GET: Prospectos
        public ActionResult Index()
        {
            List<TablaProspectosViewModel> lsProspectos = null;
            using (WebContext db = new WebContext())
            {
                lsProspectos = (from d in db.Personas
                               select new TablaProspectosViewModel
                               {
                                   Id = d.Id,
                                   Nombre = d.Nombre,
                                   PrimerApellido = d.PrimerApellido,
                                   SegundoApellido = d.SegundoApellido,
                                   Estatus = d.Estatus
                               }).ToList();
            }
            return View(lsProspectos);
        }
        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(ProspectoViewModel objProspectos)
        {
            if (!ModelState.IsValid)
            {
                return View(objProspectos);
            }
            using (var db = new WebContext())
            {
                Persona objPersona = new Persona()
                {
                    Nombre = objProspectos.Nombre,
                    PrimerApellido = objProspectos.PrimerApellido,
                    SegundoApellido = objProspectos.SegundoApellido,
                    Direcciones = new List<Direccion>()
                    {
                        new Direccion() 
                        {
                            Calle = objProspectos.Calle,
                            Numero = objProspectos.Numero,
                            Colonia = objProspectos.Colonia,
                            CodigoPostal = objProspectos.CodigoPostal
                        }
                    },
                    Telefono = objProspectos.Telefono,
                    Rfc = objProspectos.Rfc,
                    Estatus = "Activo"
                };
                db.Personas.Add(objPersona);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Prospectos/"));
        }
    }
}