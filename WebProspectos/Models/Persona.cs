using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProspectos.Models
{
    public class Persona
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string PrimerApellido { get; set; }
        [StringLength(50)]
        public string SegundoApellido { get; set; }
        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(15)]
        public string Rfc { get; set; }
        [Required]
        [StringLength(15)]
        public string Estatus { get; set; }
        public ICollection<Direccion> Direcciones { get; set; }
        public ICollection<Archivos> Archivos { get; set; }

    }
}