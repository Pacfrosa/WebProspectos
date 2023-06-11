using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProspectos.Models.TableViewModels
{
    public class TablaProspectosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Estatus { get; set; }
    }
}