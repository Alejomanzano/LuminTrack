using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuminTrack.Models
{
    public class Luminaria
    {
        public int Id { get; set; }

        [Required]
        public string Tipo { get; set; } // LED, solar, vapor de sodio, etc.

        [Required]
        public float Latitud { get; set; }

        [Required]
        public float Longitud { get; set; }

        [Required]
        public int Potencia { get; set; } // watts

        public bool TienePanelSolar { get; set; }

        [Required]
        public string Estado { get; set; } // Funcional, Dañada, EnReparacion, Obsoleta
    }
}