using System.Threading;
using System.Threading.Tasks;
using Application;
using Domain.Entities;
using Domain.Entities.Industries;
using Domain.Entities.Persons;
using Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class FiefAppDbContext : DbContext, IFiefAppDbContext
    {
        public FiefAppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<Fief> Fiefs { get; set; }
        public DbSet<Road> Roads { get; set; }
        public DbSet<RoadType> RoadTypes { get; set; }
        public DbSet<Livingcondition> Livingconditions { get; set; }
        public DbSet<LivingconditionType> LivingconditionTypes { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<BuildingType> BuildingTypes { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Steward> Stewards { get; set; }
        public DbSet<Boatbuilder> Boatbuilders { get; set; }
        public DbSet<Builder> Builders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<BoatType> BoatTypes { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Shipyard> Shipyards { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Development> Developments { get; set; }
        public DbSet<Felling> Fellings { get; set; }
        public DbSet<InheritanceType> InheritanceTypes { get; set; }
        public DbSet<Inheritance> Inheritances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(FiefAppDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}