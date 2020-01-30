using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Registro.Entidades {
    public class Inscripcion {

        [Key]
        public int InscripcionId { get; set; }
        public int PersonaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }

        public Inscripcion() {
            InscripcionId = 0;
            PersonaId = 0;
            Fecha = DateTime.Now;
            Comentario = String.Empty;
            Monto = 0.0m;
            Balance = 0.0m;
        }
    }
}
