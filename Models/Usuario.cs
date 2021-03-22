using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaVentasMVC.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Venta = new HashSet<Ventum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
