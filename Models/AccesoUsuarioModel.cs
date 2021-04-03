using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVentasMVC.Models
{
    [Serializable]
    public class AccesoUsuarioModel : Usuario
    {
        [Required(ErrorMessage = "Confirmar la contraseña es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "El Password y la confirmación del password no son iguales.")]
        public string ConfirmarPassword { get; set; }
    }
    
}
