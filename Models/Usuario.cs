using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SistemaVentasMVC.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Venta = new HashSet<Ventum>();
        }

        [Key]
        [Display(Name = "ID Usuario")]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="El nombre es requerido")]
        [Display(Name = "Nombre(s)")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los epellidos son requeridos")]
        [Display(Name = "Apellido(s)")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El correo electronico es requerido")]
        [Display(Name = "Correo electronico")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Contraseña")]
        [StringLength(15, ErrorMessage = "Longitud entre 6 y 15 caracteres.",
                      MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
