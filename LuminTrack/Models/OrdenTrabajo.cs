using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuminTrack.Models
{
    public class OrdenTrabajo
    {
        public int Id { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        [Required]
        public string Estado { get; set; } // Asignada, EnProceso, Finalizada, Cancelada

        public string FotoEvidenciaURL { get; set; }

        // Relación opcional con técnico (cuando creemos Usuarios)
        public string TecnicoAsignado { get; set; }

        // Relación opcional con reporte
        public int? ReporteId { get; set; }

        // Relación opcional con luminaria
        public int? LuminariaId { get; set; }
    }
}