using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProspectos.Models
{
    public class Archivos
    {
        public int Id { get; set; }
        [Required]
        public Persona Persona { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public byte[] DatosArchivo { get; set; }
    }
}