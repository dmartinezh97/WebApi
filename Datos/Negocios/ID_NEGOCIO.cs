using Entidades.Negocios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Negocios {
    public class ID_NEGOCIO : IEntityTypeConfiguration<NEGOCIOS> {
        public void Configure(EntityTypeBuilder<NEGOCIOS> builder) {
            builder.ToTable("NEGOCIOS")
                .HasKey(x => x.ID_NEGOCIO);
            builder.HasIndex(x => x.SLUG).IsUnique();
        }
    }
}
