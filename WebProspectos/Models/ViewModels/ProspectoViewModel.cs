using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProspectos.Models.ViewModels
{
    public class ProspectoViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Primer apellido")]
        public string PrimerApellido { get; set; }

        [StringLength(50)]
        [Display(Name = "Segundo apellido")]
        public string SegundoApellido { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        [Display(Name = "Codigo postal")]
        [RegularExpression("^\\d{5}$")]
        public string CodigoPostal { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 10)]
        [Display(Name = "Telefono")]
        [Phone]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "RFC")]
        [StringLength(15, MinimumLength = 13)]
        [RegularExpression("^([A-ZÑ\\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([A-Z\\d]{3})?$")]
        public string Rfc { get; set; }
        [Required]
        [StringLength(15)]
        public string Estatus { get; set; } = "Enviado";
    }
    public class EditarProspectoViewModel
    {
        public int Id { get; set; }   
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Primer apellido")]
        public string PrimerApellido { get; set; }

        [StringLength(50)]
        [Display(Name = "Segundo apellido")]
        public string SegundoApellido { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        [Display(Name = "Codigo postal")]
        [RegularExpression("^\\d{5}$")]
        public string CodigoPostal { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 10)]
        [Display(Name = "Telefono")]
        [Phone]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "RFC")]
        [StringLength(15, MinimumLength = 13)]
        [RegularExpression("^([A-ZÑ\\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([A-Z\\d]{3})?$")]
        public string Rfc { get; set; }
        [Required]
        [StringLength(15)]
        public string Estatus { get; set; }
        [Display(Name = "Comentarios")]
        [StringLength(50)]
        public string Comentarios { get; set; }
        public IEnumerable<Archivos> lsArchivos { get; set; }
    }
}