using Entidades.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Eventos
{
    public class EVENTOS
    {
        [Key]
        public long IdEvento { get; set; }
        public long IdNegocio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public string ImgCabecera { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int MaximoVentas { get; set; }

        [ForeignKey("IdNegocio")]
        public NEGOCIOS NEGOCIO { get; set; }
    }
}
