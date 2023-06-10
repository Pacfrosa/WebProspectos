using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProspectos.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Calle { get; set; }
        [Required]
        [StringLength(50)]
        public string Numero { get; set; }
        [Required]
        [StringLength(50)] 
        public string Colonia { get; set; }
        [Required]
        [StringLength(50)] 
        public string CodigoPostal { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
    }
}