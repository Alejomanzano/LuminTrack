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
        public string Descripcion { get; set; }

        [Required]
        public string Estado { get; set; }

        // ✅ FECHA DE CREACIÓN
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // ✅ TÉCNICO ASIGNADO (EMAIL)
        public string TecnicoEmail { get; set; }

        // ❌ NO USAR TecnicoAsignado si no existe
        // Usa TecnicoEmail en la vista

        // Relaciones opcionales
        public int? ReporteId { get; set; }
        public int? LuminariaId { get; set; }

        // Evidencia
        public string FotoEvidenciaURL { get; set; }
    }
}