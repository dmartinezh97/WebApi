using Entidades.TipoNegocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.TipoNegocio {
    public class ID_TIPO_NEGOCIO : IEntityTypeConfiguration<TIPO_NEGOCIO> {
        public void Configure(EntityTypeBuilder<TIPO_NEGOCIO> builder) {
            builder.ToTable("TIPO_NEGOCIO")
                .HasKey(x => x.ID_TIPO_NEGOCIO);
        }
    }
}
