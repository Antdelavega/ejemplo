using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DesarrolloTallerMecanico.Models.Data.DDL;

namespace DesarrolloTallerMecanico.Models
{
    public class DesarrolloTallerMecanicoContext : DbContext
    {
        public DesarrolloTallerMecanicoContext (DbContextOptions<DesarrolloTallerMecanicoContext> options)
            : base(options)
        {
        }

        public DbSet<DesarrolloTallerMecanico.Models.Data.DDL.Mecanico> Mecanico { get; set; }

        public DbSet<DesarrolloTallerMecanico.Models.Data.DDL.Clientes> Clientes { get; set; }

        public DbSet<DesarrolloTallerMecanico.Models.Data.DDL.ServicioMecanico> ServicioMecanico { get; set; }

        public DbSet<DesarrolloTallerMecanico.Models.Data.DDL.TipoServicio> TipoServicio { get; set; }

        public DbSet<DesarrolloTallerMecanico.Models.Data.DDL.TipoVehiculo> TipoVehiculo { get; set; }

        public DbSet<DesarrolloTallerMecanico.Models.Data.DDL.Vehiculo> Vehiculo { get; set; }
    }
}
