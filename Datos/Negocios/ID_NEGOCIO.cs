using Entidades.Negocios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Negocios {
    public class ID_NEGOCIO : IEntityTypeConfiguration<Entidades.Negocios.NEGOCIOS> {
        public void Configure(EntityTypeBuilder<Entidades.Negocios.NEGOCIOS> builder) {
            builder.ToTable("Negocios")
                .HasKey(x => x.IdNegocio);
            builder.HasIndex(x => x.Slug).IsUnique();
        }
    }
}
