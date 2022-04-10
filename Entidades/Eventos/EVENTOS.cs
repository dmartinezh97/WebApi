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
        public long ID_EVENTO { get; set; }
        public long ID_NEGOCIO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_FIN { get; set; }
        public string ESTADO { get; set; }
        public string URL_IMG_CABECERA { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
        public int MAXIMO_VENTAS { get; set; }

        [ForeignKey("ID_NEGOCIO")]
        public NEGOCIOS NEGOCIO { get; set; }
    }
}
