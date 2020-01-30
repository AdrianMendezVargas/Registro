using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Registro.Entidades {
    public class Persona {

        [Key]
        public int PersonaID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public decimal Balance { get; }
        public DateTime FechaNacimiento { get; set; }

        public Persona() {

            PersonaID = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Balance = 0.0m;
            FechaNacimiento = DateTime.Now;

        }
    }
}
