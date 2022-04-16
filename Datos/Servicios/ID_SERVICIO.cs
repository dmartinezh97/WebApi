using Entidades.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Servicios
{
    public class ID_SERVICIO : IEntityTypeConfiguration<SERVICIOS>
    {
        public void Configure(EntityTypeBuilder<SERVICIOS> builder)
        {
            builder.ToTable("Servicios")
                .HasKey(x => x.IdServicio);
        }
    }
}
