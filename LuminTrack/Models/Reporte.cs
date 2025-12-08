using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuminTrack.Models
{
    public class Reporte
    {
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        [Required]
        public string Categoria { get; set; }  // apagón, intermitente, poste caído

        public string FotoURL { get; set; }

        [Required]
        public float Latitud { get; set; }

        [Required]
        public float Longitud { get; set; }

        public int PrioridadIA { get; set; } = 0;

        [Required]
        public string Estado { get; set; } = "Enviado";
    }
}