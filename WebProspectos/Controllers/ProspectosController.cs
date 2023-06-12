﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Nuevo(ProspectoViewModel objProspectos, IEnumerable<HttpPostedFileBase>  lsArchivos)
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
                    Estatus = "Enviado",
                    Archivos = new List<Archivos>()
                };
                if (lsArchivos != null)
                {
                    foreach (HttpPostedFileBase archivo in lsArchivos)
                    {
                        byte[] contenido;
                        using (var lector = new BinaryReader(archivo.InputStream))
                        {
                            contenido = lector.ReadBytes(archivo.ContentLength);
                        }
                        objPersona.Archivos.Add
                            (
                                new Archivos()
                                {
                                    Nombre = archivo.FileName,
                                    DatosArchivo= contenido
                                }
                            );
                    }
                }
                db.Personas.Add(objPersona);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Prospectos/"));
        }
        [HttpGet]
        public ActionResult Editar(int Id)
        {
            EditarProspectoViewModel model = new EditarProspectoViewModel();
            List<string> listaDeElementos = new List<string>
            {
                "Autorizado",
                "Rechazado"
            };
            ViewBag.ListaDeElementos = new SelectList(listaDeElementos);
            using (var db = new WebContext())
            {
                var objResultado = db.Personas.Find(Id);
                if (objResultado == null)
                {
                    return Redirect(Url.Content("~/Prospectos/"));
                }
                model.Id = Id;
                model.Nombre = objResultado.Nombre;
                model.PrimerApellido = objResultado.PrimerApellido;
                model.SegundoApellido = objResultado.SegundoApellido;
                Direccion objDireccion = db.Direcciones.Where(d => d.PersonaId == Id).First();
                model.Calle = objDireccion.Calle;
                model.Numero = objDireccion.Numero;
                model.Colonia = objDireccion.Colonia;
                model.CodigoPostal = objDireccion.CodigoPostal;
                model.Telefono = objResultado.Telefono;
                model.Rfc = objResultado.Rfc;
                model.Estatus = objResultado.Estatus;
            }
            return View(model);
        }
    }
}