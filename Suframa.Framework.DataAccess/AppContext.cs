using Microsoft.EntityFrameworkCore;
using Suframa.DemoSuframa.DataAccess.Database.Entities;
using Suframa.FrameworkSuframa.DataAccess.Database.Entities;
using Suframa.Sciex.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suframa.DemoSuframa.DataAccess
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<FabricanteEntity> Fabricante { get; set; }
        public DbSet<PaisEntity> Pais { get; set; }

        public DbSet<PessoaEntity> Pessoa { get; set; }

    }
}
