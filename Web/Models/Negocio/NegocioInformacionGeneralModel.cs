using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Negocio {
    public class NegocioInformacionGeneralModel {
        public long idnegocio { get; set; }
        public string nombre { get; set; }
        public string slug { get; set; }
        public string descripcion { get; set; }
        public long tipo_negocio { get; set; }
        public string ubicacion { get; set; }
        public string img_logo { get; set; }
        public string img_cabecera { get; set; }
    }
}
