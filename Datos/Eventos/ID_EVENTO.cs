using Entidades.Eventos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Eventos
{
    public class ID_EVENTO : IEntityTypeConfiguration<EVENTOS>
    {
        public void Configure(EntityTypeBuilder<EVENTOS> builder)
        {
            builder.ToTable("EVENTOS")
                .HasKey(x => x.ID_EVENTO);
        }
    }
}
