using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProspectos.Models;
using WebProspectos.Models.TableViewModels;

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
    }
}