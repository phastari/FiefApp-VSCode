using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Industries;
using Domain.Entities.Persons;
using Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IFiefAppDbContext
    {
        DbSet<UserLink> UserLinks { get; set; }
        DbSet<GameSession> GameSessions { get; set; }
        DbSet<Fief> Fiefs { get; set; }
        DbSet<Road> Roads { get; set; }
        DbSet<RoadType> RoadTypes { get; set; }
        DbSet<Livingcondition> Livingconditions { get; set; }
        DbSet<LivingconditionType> LivingconditionTypes { get; set; }
        DbSet<Building> Buildings { get; set; }
        DbSet<BuildingType> BuildingTypes { get; set; }
        DbSet<Village> Villages { get; set; }
        DbSet<Industry> Industries { get; set; }
        DbSet<Resident> Residents { get; set; }
        DbSet<Steward> Stewards { get; set; }
        DbSet<Boatbuilder> Boatbuilders { get; set; }
        DbSet<Builder> Builders { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Merchant> Merchants { get; set; }
        DbSet<Soldier> Soldiers { get; set; }
        DbSet<Boat> Boats { get; set; }
        DbSet<BoatType> BoatTypes { get; set; }
        DbSet<EmployeeType> EmployeeTypes { get; set; }
        DbSet<Cargo> Cargos { get; set; }
        DbSet<Market> Markets { get; set; }
        DbSet<Port> Ports { get; set; }
        DbSet<Shipyard> Shipyards { get; set; }
        DbSet<Assignment> Assignments { get; set; }
        DbSet<Development> Developments { get; set; }
        DbSet<Felling> Fellings { get; set; }
        public DbSet<InheritanceType> InheritanceTypes { get; set; }
        public DbSet<Inheritance> Inheritances { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}