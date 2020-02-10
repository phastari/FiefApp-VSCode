using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                });

            migrationBuilder.CreateTable(
                name: "BoatTypes",
                columns: table => new
                {
                    BoatTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Masts = table.Column<int>(nullable: false),
                    LengthMin = table.Column<int>(nullable: false),
                    LengthMax = table.Column<int>(nullable: false),
                    BL = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    DB = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    Crew = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    Cargo = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    BenchMod = table.Column<int>(nullable: false),
                    BenchMulti = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    OarsMulti = table.Column<int>(nullable: false),
                    RowerMulti = table.Column<int>(nullable: false),
                    Seaworthiness = table.Column<string>(nullable: true),
                    ImgSource = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatTypes", x => x.BoatTypeId);
                });

            migrationBuilder.CreateTable(
                name: "BuildingTypes",
                columns: table => new
                {
                    BuildingTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Upkeep = table.Column<double>(nullable: false),
                    Woodwork = table.Column<int>(nullable: false),
                    Stonework = table.Column<int>(nullable: false),
                    Smithswork = table.Column<int>(nullable: false),
                    Wood = table.Column<int>(nullable: false),
                    Stone = table.Column<int>(nullable: false),
                    Iron = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingTypes", x => x.BuildingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    CargoId = table.Column<Guid>(nullable: false),
                    Silver = table.Column<int>(nullable: false),
                    Base = table.Column<int>(nullable: false),
                    Luxury = table.Column<int>(nullable: false),
                    Wood = table.Column<int>(nullable: false),
                    Iron = table.Column<int>(nullable: false),
                    Stone = table.Column<int>(nullable: false),
                    Other = table.Column<int>(nullable: false),
                    OtherInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.CargoId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    EmployeeTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    BaseCost = table.Column<int>(nullable: false),
                    LuxuryCost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.EmployeeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "GameSessions",
                columns: table => new
                {
                    GameSessionId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastUsed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSessions", x => x.GameSessionId);
                });

            migrationBuilder.CreateTable(
                name: "InheritanceTypes",
                columns: table => new
                {
                    InheritanceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InheritanceTypes", x => x.InheritanceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LivingconditionTypes",
                columns: table => new
                {
                    LivingconditionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    BaseCost = table.Column<int>(nullable: false),
                    LuxuryCost = table.Column<int>(nullable: false),
                    FocusGain = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingconditionTypes", x => x.LivingconditionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MineType",
                columns: table => new
                {
                    MineTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    SilverProduction = table.Column<int>(nullable: false),
                    IronProduction = table.Column<int>(nullable: false),
                    LuxuryProduction = table.Column<int>(nullable: false),
                    Crime = table.Column<int>(nullable: false),
                    PopulationModifier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MineType", x => x.MineTypeId);
                });

            migrationBuilder.CreateTable(
                name: "QuarryType",
                columns: table => new
                {
                    QuarryTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Crime = table.Column<int>(nullable: false),
                    PopulationModifier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarryType", x => x.QuarryTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RoadTypes",
                columns: table => new
                {
                    RoadTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    UpgradeBaseCost = table.Column<int>(nullable: false),
                    UpgradeStoneCost = table.Column<int>(nullable: false),
                    ModificationFactor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadTypes", x => x.RoadTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SoldierType",
                columns: table => new
                {
                    SoldierTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    SilverCost = table.Column<int>(nullable: false),
                    BaseCost = table.Column<int>(nullable: false),
                    Accommodation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldierType", x => x.SoldierTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SubsidiaryType",
                columns: table => new
                {
                    SubsidiaryTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    IncomeFactor = table.Column<double>(nullable: false),
                    IncomeInSilver = table.Column<double>(nullable: false),
                    IncomeInBase = table.Column<double>(nullable: false),
                    IncomeInLuxury = table.Column<double>(nullable: false),
                    SpringModification = table.Column<double>(nullable: false),
                    SummerModification = table.Column<double>(nullable: false),
                    FallModification = table.Column<double>(nullable: false),
                    WinterModification = table.Column<double>(nullable: false),
                    DaysworkBuild = table.Column<int>(nullable: false),
                    DaysworkUpkeep = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubsidiaryType", x => x.SubsidiaryTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Developments",
                columns: table => new
                {
                    DevelopmentId = table.Column<Guid>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developments", x => x.DevelopmentId);
                    table.ForeignKey(
                        name: "FK_Developments_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Fiefs",
                columns: table => new
                {
                    FiefId = table.Column<Guid>(nullable: false),
                    GameSessionId = table.Column<Guid>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: true),
                    Acres = table.Column<int>(nullable: false),
                    FarmlandAcres = table.Column<int>(nullable: false),
                    PastureAcres = table.Column<int>(nullable: false),
                    WoodlandAcres = table.Column<int>(nullable: false),
                    UnusableAcres = table.Column<int>(nullable: false),
                    AnimalHusbandryQuality = table.Column<int>(nullable: false),
                    AgriculturalQuality = table.Column<int>(nullable: false),
                    FishingQuality = table.Column<int>(nullable: false),
                    OreQuality = table.Column<int>(nullable: false),
                    AnimalHusbandryDevelopmentLevel = table.Column<int>(nullable: false, defaultValue: 1),
                    AgriculturalDevelopmentLevel = table.Column<int>(nullable: false, defaultValue: 1),
                    FishingDevelopmentLevel = table.Column<int>(nullable: false, defaultValue: 1),
                    WoodlandDevelopmentLevel = table.Column<int>(nullable: false, defaultValue: 1),
                    OreDevelopmentLevel = table.Column<int>(nullable: false, defaultValue: 1),
                    EducationDevelopmentLevel = table.Column<int>(nullable: false, defaultValue: 1),
                    HealthcareDevelopmentLevel = table.Column<int>(nullable: false, defaultValue: 1),
                    MilitaryDevelopmentLevel = table.Column<int>(nullable: false, defaultValue: 1),
                    SeafaringDevelopmentLevel = table.Column<int>(nullable: false),
                    InheritanceTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiefs", x => x.FiefId);
                    table.ForeignKey(
                        name: "FK_Fiefs_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Fiefs_GameSessions_GameSessionId",
                        column: x => x.GameSessionId,
                        principalTable: "GameSessions",
                        principalColumn: "GameSessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fiefs_InheritanceTypes_InheritanceTypeId",
                        column: x => x.InheritanceTypeId,
                        principalTable: "InheritanceTypes",
                        principalColumn: "InheritanceTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Builders",
                columns: table => new
                {
                    BuilderId = table.Column<Guid>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: true),
                    FiefId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Skill = table.Column<int>(nullable: false),
                    Resources = table.Column<int>(nullable: false),
                    Loyalty = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builders", x => x.BuilderId);
                    table.ForeignKey(
                        name: "FK_Builders_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(nullable: false),
                    EmployeeTypeId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    FiefId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Skill = table.Column<int>(nullable: false),
                    Resources = table.Column<int>(nullable: false),
                    Loyalty = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "EmployeeTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    IndustryId = table.Column<Guid>(nullable: false),
                    FiefId = table.Column<Guid>(nullable: true),
                    AssignmentId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IndustryType = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    AmountLandclearing = table.Column<int>(nullable: true),
                    AmountLandclearingOfFelling = table.Column<int>(nullable: true),
                    AmountFelling = table.Column<int>(nullable: true),
                    AmountClearUseless = table.Column<int>(nullable: true),
                    IsBeingDeveloped = table.Column<bool>(nullable: true),
                    DevelopmentId = table.Column<Guid>(nullable: true),
                    MineTypeId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Silver = table.Column<int>(nullable: true),
                    Luxury = table.Column<int>(nullable: true),
                    Iron = table.Column<int>(nullable: true),
                    YearsLeft = table.Column<int>(nullable: true),
                    Guards = table.Column<int>(nullable: true),
                    FirstYear = table.Column<bool>(nullable: true),
                    Mine_IsBeingDeveloped = table.Column<bool>(nullable: true),
                    Mine_DevelopmentId = table.Column<Guid>(nullable: true),
                    QuarryTypeId = table.Column<int>(nullable: true),
                    Quarry_Type = table.Column<string>(nullable: true),
                    Stone = table.Column<int>(nullable: true),
                    IsFirstYear = table.Column<bool>(nullable: true),
                    Quarry_YearsLeft = table.Column<int>(nullable: true),
                    Quarry_Guards = table.Column<int>(nullable: true),
                    Quarry_IsBeingDeveloped = table.Column<bool>(nullable: true),
                    Quarry_DevelopmentId = table.Column<Guid>(nullable: true),
                    SubsidiaryTypeId = table.Column<int>(nullable: true),
                    Quality = table.Column<int>(nullable: true),
                    DevelopmentLevel = table.Column<int>(nullable: true),
                    Subsidiary_Silver = table.Column<int>(nullable: true),
                    Base = table.Column<int>(nullable: true),
                    Subsidiary_Luxury = table.Column<int>(nullable: true),
                    DaysworkThisYear = table.Column<int>(nullable: true),
                    Subsidiary_IsBeingDeveloped = table.Column<bool>(nullable: true),
                    Subsidiary_DevelopmentId = table.Column<Guid>(nullable: true),
                    SpringModifier = table.Column<double>(nullable: true),
                    SummerModifier = table.Column<double>(nullable: true),
                    FallModifier = table.Column<double>(nullable: true),
                    WinterModifier = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.IndustryId);
                    table.ForeignKey(
                        name: "FK_Industries_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Industries_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Industries_MineType_MineTypeId",
                        column: x => x.MineTypeId,
                        principalTable: "MineType",
                        principalColumn: "MineTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Industries_QuarryType_QuarryTypeId",
                        column: x => x.QuarryTypeId,
                        principalTable: "QuarryType",
                        principalColumn: "QuarryTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Industries_SubsidiaryType_SubsidiaryTypeId",
                        column: x => x.SubsidiaryTypeId,
                        principalTable: "SubsidiaryType",
                        principalColumn: "SubsidiaryTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inheritances",
                columns: table => new
                {
                    InheritanceId = table.Column<Guid>(nullable: false),
                    InheritanceTypeId = table.Column<int>(nullable: false),
                    FiefId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inheritances", x => x.InheritanceId);
                    table.ForeignKey(
                        name: "FK_Inheritances_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inheritances_InheritanceTypes_InheritanceTypeId",
                        column: x => x.InheritanceTypeId,
                        principalTable: "InheritanceTypes",
                        principalColumn: "InheritanceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livingconditions",
                columns: table => new
                {
                    LivingconditionId = table.Column<Guid>(nullable: false),
                    LivingconditionTypeId = table.Column<int>(nullable: true),
                    FiefId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livingconditions", x => x.LivingconditionId);
                    table.ForeignKey(
                        name: "FK_Livingconditions_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livingconditions_LivingconditionTypes_LivingconditionTypeId",
                        column: x => x.LivingconditionTypeId,
                        principalTable: "LivingconditionTypes",
                        principalColumn: "LivingconditionTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    MarketId = table.Column<Guid>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: true),
                    FiefId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DevelopmentLevel = table.Column<int>(nullable: false),
                    Merchandise = table.Column<int>(nullable: false),
                    IncomeSilver = table.Column<int>(nullable: false),
                    IncomeBase = table.Column<int>(nullable: false),
                    Taxes = table.Column<int>(nullable: false),
                    Bailiffs = table.Column<int>(nullable: false),
                    Crime = table.Column<int>(nullable: false),
                    IsBeingDeveloped = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.MarketId);
                    table.ForeignKey(
                        name: "FK_Markets_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Markets_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    PortId = table.Column<Guid>(nullable: false),
                    FiefId = table.Column<Guid>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DevelopmentLevel = table.Column<int>(nullable: false),
                    Merchandise = table.Column<int>(nullable: false),
                    IncomeSilver = table.Column<int>(nullable: false),
                    Taxes = table.Column<int>(nullable: false),
                    Bailiffs = table.Column<int>(nullable: false),
                    Crime = table.Column<int>(nullable: false),
                    IsBeingDeveloped = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.PortId);
                    table.ForeignKey(
                        name: "FK_Ports_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Ports_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Residents",
                columns: table => new
                {
                    ResidentId = table.Column<Guid>(nullable: false),
                    FiefId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Skill = table.Column<int>(nullable: false),
                    Resources = table.Column<int>(nullable: false),
                    Loyalty = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Information = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residents", x => x.ResidentId);
                    table.ForeignKey(
                        name: "FK_Residents_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roads",
                columns: table => new
                {
                    RoadId = table.Column<Guid>(nullable: false),
                    FiefId = table.Column<Guid>(nullable: false),
                    RoadTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roads", x => x.RoadId);
                    table.ForeignKey(
                        name: "FK_Roads_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roads_RoadTypes_RoadTypeId",
                        column: x => x.RoadTypeId,
                        principalTable: "RoadTypes",
                        principalColumn: "RoadTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stewards",
                columns: table => new
                {
                    StewardId = table.Column<Guid>(nullable: false),
                    FiefId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Skill = table.Column<int>(nullable: false),
                    Resources = table.Column<int>(nullable: false),
                    Loyalty = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: false),
                    GameSessionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stewards", x => x.StewardId);
                    table.ForeignKey(
                        name: "FK_Stewards_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stewards_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stewards_GameSessions_GameSessionId",
                        column: x => x.GameSessionId,
                        principalTable: "GameSessions",
                        principalColumn: "GameSessionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                columns: table => new
                {
                    VillageId = table.Column<Guid>(nullable: false),
                    FiefId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Serfdoms = table.Column<int>(nullable: false),
                    Farmers = table.Column<int>(nullable: false),
                    Burgess = table.Column<int>(nullable: false),
                    Boatbuilders = table.Column<int>(nullable: false),
                    Tanners = table.Column<int>(nullable: false),
                    Millers = table.Column<int>(nullable: false),
                    Furriers = table.Column<int>(nullable: false),
                    Tailors = table.Column<int>(nullable: false),
                    Blacksmiths = table.Column<int>(nullable: false),
                    Carpenters = table.Column<int>(nullable: false),
                    Innkeepers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.VillageId);
                    table.ForeignKey(
                        name: "FK_Villages_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<Guid>(nullable: false),
                    BuilderId = table.Column<Guid>(nullable: true),
                    FiefId = table.Column<Guid>(nullable: true),
                    BuildingTypeId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    WoodworkThisYear = table.Column<int>(nullable: false),
                    StoneworkThisYear = table.Column<int>(nullable: false),
                    SmithsworkThisYear = table.Column<int>(nullable: false),
                    WoodThisYear = table.Column<int>(nullable: false),
                    StoneThisYear = table.Column<int>(nullable: false),
                    IronThisYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_Buildings_Builders_BuilderId",
                        column: x => x.BuilderId,
                        principalTable: "Builders",
                        principalColumn: "BuilderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buildings_BuildingTypes_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingTypes",
                        principalColumn: "BuildingTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buildings_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    MerchantId = table.Column<Guid>(nullable: false),
                    CargoId = table.Column<Guid>(nullable: true),
                    PortId = table.Column<Guid>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Skill = table.Column<int>(nullable: false),
                    Resources = table.Column<int>(nullable: false),
                    Loyalty = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    MarketId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.MerchantId);
                    table.ForeignKey(
                        name: "FK_Merchants_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Merchants_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "MarketId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Merchants_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "PortId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shipyards",
                columns: table => new
                {
                    ShipyardId = table.Column<Guid>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: true),
                    PortId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DevelopmentLevel = table.Column<int>(nullable: false),
                    IsBeingDeveloped = table.Column<bool>(nullable: false),
                    IncomeSilver = table.Column<int>(nullable: false),
                    SmallDocks = table.Column<int>(nullable: false),
                    MediumDocks = table.Column<int>(nullable: false),
                    LargeDocks = table.Column<int>(nullable: false),
                    PopulationModifier = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipyards", x => x.ShipyardId);
                    table.ForeignKey(
                        name: "FK_Shipyards_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Shipyards_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "PortId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boatbuilders",
                columns: table => new
                {
                    BoatbuilderId = table.Column<Guid>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: true),
                    ShipyardId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Skill = table.Column<int>(nullable: false),
                    Resources = table.Column<int>(nullable: false),
                    Loyalty = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boatbuilders", x => x.BoatbuilderId);
                    table.ForeignKey(
                        name: "FK_Boatbuilders_Shipyards_ShipyardId",
                        column: x => x.ShipyardId,
                        principalTable: "Shipyards",
                        principalColumn: "ShipyardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    BoatId = table.Column<Guid>(nullable: false),
                    BoatTypeId = table.Column<int>(nullable: false),
                    BoatbuilderId = table.Column<Guid>(nullable: true),
                    CargoId = table.Column<Guid>(nullable: true),
                    ShipyardId = table.Column<Guid>(nullable: true),
                    FiefId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Length = table.Column<int>(nullable: false),
                    Width = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    Depth = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    CrewNeeded = table.Column<int>(nullable: false),
                    Seamens = table.Column<int>(nullable: false),
                    Mariners = table.Column<int>(nullable: false),
                    Rowers = table.Column<int>(nullable: false),
                    RowersNeeded = table.Column<int>(nullable: false),
                    MaxCargo = table.Column<int>(nullable: false),
                    Sailors = table.Column<int>(nullable: false),
                    Officers = table.Column<int>(nullable: false),
                    Navigators = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    CostWhenFinishedSilver = table.Column<int>(nullable: false),
                    NextFinishedDays = table.Column<int>(nullable: false),
                    BuildTimeInDays = table.Column<int>(nullable: false),
                    BuildTimeInDaysAll = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    BackIn = table.Column<int>(nullable: false),
                    PortId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.BoatId);
                    table.ForeignKey(
                        name: "FK_Boats_BoatTypes_BoatTypeId",
                        column: x => x.BoatTypeId,
                        principalTable: "BoatTypes",
                        principalColumn: "BoatTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boats_Boatbuilders_BoatbuilderId",
                        column: x => x.BoatbuilderId,
                        principalTable: "Boatbuilders",
                        principalColumn: "BoatbuilderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boats_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boats_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boats_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "PortId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boats_Shipyards_ShipyardId",
                        column: x => x.ShipyardId,
                        principalTable: "Shipyards",
                        principalColumn: "ShipyardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Soldiers",
                columns: table => new
                {
                    SoldierId = table.Column<Guid>(nullable: false),
                    FiefId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Skill = table.Column<int>(nullable: false),
                    Resources = table.Column<int>(nullable: false),
                    Loyalty = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    SoldierTypeId = table.Column<int>(nullable: false),
                    MerchantId = table.Column<Guid>(nullable: true),
                    BoatId = table.Column<Guid>(nullable: true),
                    MarketId = table.Column<Guid>(nullable: true),
                    PortId = table.Column<Guid>(nullable: true),
                    RoadId = table.Column<Guid>(nullable: true),
                    MineIndustryId = table.Column<Guid>(nullable: true),
                    QuarryIndustryId = table.Column<Guid>(nullable: true),
                    IsResident = table.Column<bool>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soldiers", x => x.SoldierId);
                    table.ForeignKey(
                        name: "FK_Soldiers_Boats_BoatId",
                        column: x => x.BoatId,
                        principalTable: "Boats",
                        principalColumn: "BoatId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldiers_Fiefs_FiefId",
                        column: x => x.FiefId,
                        principalTable: "Fiefs",
                        principalColumn: "FiefId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldiers_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "MarketId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldiers_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "MerchantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldiers_Industries_MineIndustryId",
                        column: x => x.MineIndustryId,
                        principalTable: "Industries",
                        principalColumn: "IndustryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldiers_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "PortId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldiers_Industries_QuarryIndustryId",
                        column: x => x.QuarryIndustryId,
                        principalTable: "Industries",
                        principalColumn: "IndustryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldiers_Roads_RoadId",
                        column: x => x.RoadId,
                        principalTable: "Roads",
                        principalColumn: "RoadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldiers_SoldierType_SoldierTypeId",
                        column: x => x.SoldierTypeId,
                        principalTable: "SoldierType",
                        principalColumn: "SoldierTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BoatTypes",
                columns: new[] { "BoatTypeId", "BL", "BenchMod", "BenchMulti", "Cargo", "Crew", "DB", "DisplayName", "ImgSource", "LengthMax", "LengthMin", "Masts", "OarsMulti", "RowerMulti", "Seaworthiness", "Type" },
                values: new object[,]
                {
                    { 1, 0.3m, 0, 0m, 1.5m, 0.35m, 0.28m, null, "1.jpg", 28, 20, 3, 0, 0, "1T6", "Bridad" },
                    { 23, 0.24m, 0, 0m, 1.4m, 0.35m, 0.32m, null, "23.jpg", 16, 11, 2, 0, 0, "3T6", "Vågridare, tvåmastad" },
                    { 22, 0.25m, 0, 0m, 1.5m, 0.28m, 0.35m, null, "22.jpg", 21, 14, 3, 0, 0, "2T6", "Vågridare, tremastad" },
                    { 21, 0.18m, -17, 1.8m, 1m, 0.2m, 0.3m, null, "21.jpg", 37, 27, 1, 4, 4, "3T6", "Umbura" },
                    { 19, 0.2m, 0, 0m, 1.5m, 0.4m, 0.4m, null, "19.jpg", 25, 17, 2, 0, 0, "2T6", "Sabrier, tvåmastad" },
                    { 18, 0.22m, 0, 0m, 1.6m, 0.4m, 0.35m, null, "18.jpg", 33, 23, 3, 0, 0, "2T6", "Sabrier, tremastad" },
                    { 17, 0.25m, 0, 0m, 1.6m, 0.38m, 0.32m, null, "17.jpg", 36, 25, 2, 0, 0, "2T6", "Rundskepp, två däck" },
                    { 16, 0.3m, 0, 0m, 1.5m, 0.36m, 0.28m, null, "16.jpg", 25, 12, 1, 0, 0, "2T6", "Rundskepp, ett däck" },
                    { 15, 0.2m, -14, 1.5m, 0.7m, 0.2m, 0.32m, null, "15.jpg", 34, 24, 1, 2, 4, "3T6", "Lemirier" },
                    { 14, 0.32m, 0, 0m, 1.4m, 0.35m, 0.2m, null, "14.jpg", 24, 13, 2, 0, 0, "3T6", "Lanacka" },
                    { 13, 0.26m, 0, 0m, 1.3m, 0.33m, 0.38m, null, "13.jpg", 29, 17, 3, 0, 0, "2T6", "Karack, tremastad" },
                    { 20, 0.35m, -5, 0.4m, 1.2m, 0.35m, 0.24m, null, "20.jpg", 14, 8, 1, 2, -1, "3T6", "Slurp" },
                    { 11, 0.27m, 0, 0m, 1.7m, 0.25m, 0.4m, null, "11.jpg", 22, 14, 1, 0, 0, "3T6", "Kagge" },
                    { 12, 0.28m, 0, 0m, 1.4m, 0.3m, 0.36m, null, "12.jpg", 37, 26, 4, 0, 0, "1T6", "Karack, fyrmastad" },
                    { 2, 0.25m, 0, 0m, 0.5m, 0.5m, 0.28m, null, "2.jpg", 28, 23, 2, 0, 0, "2T6", "Drakfartyg" },
                    { 3, 0.38m, 0, 0m, 0.9m, 0.3m, 0.35m, null, "3.jpg", 6, 6, 1, 0, 0, "1T6", "Fiskebåt" },
                    { 5, 0.42m, 0, 0m, 2m, 0.2m, 0.12m, null, "5.jpg", 27, 17, 2, 0, 0, "4T6", "Flodpråm" },
                    { 4, 0.44m, 3, 0.5m, 1.8m, 0.4m, 0.15m, null, "4.jpg", 7, 5, 2, 2, -1, "4T6", "Flodbåt" },
                    { 7, 0.24m, 0, 0m, 1.6m, 0.35m, 0.33m, null, "7.jpg", 35, 22, 3, 0, 0, "2T6", "Galloz" },
                    { 8, 0.27m, 0, 0m, 1.4m, 0.4m, 0.28m, null, "8.jpg", 11, 7, 1, 0, 0, "1T6", "Jagol" },
                    { 9, 0.18m, 0, 0m, 1m, 0.4m, 0.4m, null, "9.jpg", 17, 12, 2, 0, 0, "3T6", "Jakt" },
                    { 10, 0.21m, -10, 0.5m, 1m, 0.35m, 0.35m, null, "10.jpg", 23, 19, 1, 4, 4, "2T6", "Kaga" },
                    { 6, 0.28m, 0, 0m, 1m, 0.25m, 0.35m, null, "6.jpg", 19, 13, 2, 0, 0, "1T6", "Gaffa" }
                });

            migrationBuilder.InsertData(
                table: "BuildingTypes",
                columns: new[] { "BuildingTypeId", "Iron", "Smithswork", "Stone", "Stonework", "Type", "Upkeep", "Wood", "Woodwork" },
                values: new object[,]
                {
                    { 19, 8, 8, 63, 1300, "Litet stentorn, runt", 1.0, 4, 88 },
                    { 24, 120, 120, 1700, 34000, "Borgkärna, rund", 8.0, 58, 1900 },
                    { 20, 42, 42, 210, 4200, "Stentorn, runt", 2.0, 21, 290 },
                    { 21, 60, 60, 1175, 23500, "Stort stentorn, runt", 4.0, 31, 1250 },
                    { 22, 160, 160, 2200, 44000, "Borgkärna, fyrkantig", 8.0, 74, 2500 },
                    { 23, 280, 280, 3400, 68000, "Stor borgkärna, fyrkantig", 16.0, 140, 4000 },
                    { 25, 340, 340, 5100, 102000, "Sammansatt borgkärna", 16.0, 170, 5700 },
                    { 30, 130, 130, 1200, 47000, "Tempel/Kyrka", 0.0, 66, 1700 },
                    { 27, 8, 8, 22, 440, "Stenhus", 0.025000000000000001, 4, 16 },
                    { 28, 8, 8, 27, 0, "Tvåvånings trähus", 0.050000000000000003, 12, 48 },
                    { 29, 8, 8, 44, 880, "Tvåvånings stenhus", 0.050000000000000003, 4, 60 },
                    { 31, 400, 400, 3500, 140000, "Stort tempel/kyrka", 0.0, 200, 5100 },
                    { 32, 2000, 2000, 18000, 700000, "Katedral", 0.0, 1000, 26000 },
                    { 18, 80, 80, 1500, 30000, "Stort stentorn, fyrkantigt", 4.0, 40, 1600 },
                    { 26, 0, 0, 0, 0, "Trähus", 0.025000000000000001, 6, 24 },
                    { 17, 52, 52, 270, 5400, "Stentorn, fyrkantigt", 2.0, 26, 370 },
                    { 6, 0, 0, 0, 0, "Dubbel palissad", 0.20000000000000001, 15, 60 },
                    { 15, 44, 44, 0, 0, "Trätorn", 1.0, 22, 88 },
                    { 1, 0, 0, 14, 280, "Bageri", 3.0, 60, 920 },
                    { 2, 8, 8, 27, 540, "Kvarn", 4.0, 100, 1533 },
                    { 3, 0, 0, 0, 40, "Vall", 0.10000000000000001, 0, 0 },
                    { 4, 0, 0, 0, 60, "Vall och grav", 0.20000000000000001, 0, 0 },
                    { 5, 0, 0, 0, 0, "Palissad", 0.10000000000000001, 5, 20 },
                    { 16, 12, 12, 87, 1700, "Litet stentorn, fyrkantigt", 1.0, 6, 110 },
                    { 7, 0, 0, 53, 1100, "Mur", 0.40000000000000002, 0, 53 },
                    { 9, 0, 0, 750, 5000, "Tjock mur", 0.80000000000000004, 0, 750 },
                    { 10, 0, 0, 4000, 35000, "Massiv mur", 1.0, 0, 4000 },
                    { 11, 0, 0, 58, 1200, "Mur med stävpelare", 0.45000000000000001, 0, 58 },
                    { 12, 12, 12, 68, 1400, "Litet porttorn", 1.0, 6, 92 },
                    { 13, 24, 24, 220, 4400, "Porttorn", 2.0, 12, 270 },
                    { 14, 24, 42, 220, 28000, "Stort porttorn", 4.0, 21, 1500 },
                    { 8, 0, 0, 150, 3000, "Dubbel mur", 0.59999999999999998, 100, 150 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "EmployeeTypeId", "BaseCost", "LuxuryCost", "Type" },
                values: new object[,]
                {
                    { 7, 2, 1, "Cupbearer" },
                    { 8, 2, -1, "Prospector" },
                    { 6, 3, 1, "Scholar" },
                    { 5, 3, 3, "Physician" },
                    { 4, 2, 0, "Hunter" },
                    { 3, 4, 1, "Herald" },
                    { 2, 3, 1, "Bailiff" },
                    { 1, 2, 1, "Falconer" }
                });

            migrationBuilder.InsertData(
                table: "InheritanceTypes",
                columns: new[] { "InheritanceTypeId", "Description", "Type" },
                values: new object[,]
                {
                    { 1, "Kallas även län på ed. Vasallen får sin förläning mot att han utför eller utfört länsherren en tjänst, exempelvis vapentjänst. Länet är ärftligt, det vill säga går vidare till vasallens son vid vasallens frånfall.", "Län på tjänst, ärftligt" },
                    { 2, "Kallas även län på ed. Vasallen får sin förläning mot att han utför eller utfört länsherren en tjänst, exempelvis vapentjänst. Länet är inte ärftligt utan går tillbaka till länsherren då vasallen dör.", "Län på tjänst, icke ärftligt" },
                    { 3, "Vasallen betalar en fast avgift till sin länsherre mot att han fritt får disponera länets inkomster.", "Län på avgift" },
                    { 4, "Ibland händer det att en länsherre måste låna pengar, till exempel i tider av ofred. Länsherren kan då skänka långivaren ett län att disponera fritt tills dess att lånet är återbetlat.", "Pantlän" }
                });

            migrationBuilder.InsertData(
                table: "LivingconditionTypes",
                columns: new[] { "LivingconditionTypeId", "BaseCost", "Description", "FocusGain", "LuxuryCost", "Type" },
                values: new object[,]
                {
                    { 1, 2, "Denna levnadsstandard innebär två usla mål mat om dagen, utspätt öl att dricka och ofta små marginaler från svält och sjukdom. Det finns inga tjänare i hushållet. Möblemanget är gammalt och lagat. Så här lever de flesta ofria bondefamiljer, och det är således långt under en länsherres värdighet.", -4, 0, "Nödtorftig" },
                    { 2, 3, "Denna levnadsstandard innebär två mål mat om dagen, öl eller billigt vin att dricka och någon enstaka utsvävning med fest eller gamman. Det finns inga tjänare i hushållet, förutom en kokerska. Möblemanget är robust, men inte särskilt vackert. Så här lever de flesta borgarfamiljer, och det är således under en länsherres värdighet.", 0, 1, "Gemen" },
                    { 3, 5, "Denna levnadsstandard innebär två rediga mål mat om dagen, varav ett är en mindre bankett med ett flertal rätter. Öl eller vin serveras vid samtliga måltider, och länsherren är god för åtminstone månatliga utsvävningar med fest och gamman. Det finns en handfull tjänare i hushållet och ett flertal kokerskor och kökspigor. Möblemanget är veckert. Så här lever rika borgarfamiljer och måttfulla länsherrar.", 4, 2, "God" },
                    { 4, 7, "Denna levnadsstandard innebär tre eller fler ypperliga mål mat om dagen, varav två är banketter med ett dussintal rätter. Obegränsade mängder synnerligen fint öl och välsmakande vin serveras vid samtliga måltider, och länsherren är god för utsvävningar med fest och gamman närhelst han så önskar. Det finns massvis av tjänare i hushållet, en eller flera kammarherrar och ett hov av damer och kavaljerer. Möblemanget är exklusivt. Så här lever endast de rikaste i samhället - kungen, de rikaste adelsmännen och ett exklusivt fåtal av handelsfurstar.", 8, 4, "Lyxliv" }
                });

            migrationBuilder.InsertData(
                table: "MineType",
                columns: new[] { "MineTypeId", "Crime", "DisplayName", "IronProduction", "LuxuryProduction", "PopulationModifier", "SilverProduction", "Type" },
                values: new object[,]
                {
                    { 6, 400, "Ädelstenar", 0, 200, 1200, 256000, "Gemstones" },
                    { 5, 300, "Guld", 0, 100, 900, 228000, "Gold" },
                    { 4, 200, "Silver", 0, 50, 600, 164000, "Silver" },
                    { 2, 40, "Järn", 800, 0, 120, 0, "Iron" },
                    { 1, 24, "Tenn", 0, 0, 72, 24000, "Tin" },
                    { 3, 120, "Koppar", 0, 10, 360, 112800, "Copper" }
                });

            migrationBuilder.InsertData(
                table: "QuarryType",
                columns: new[] { "QuarryTypeId", "Crime", "DisplayName", "PopulationModifier", "Type" },
                values: new object[,]
                {
                    { 1, 6, "Litet", 24, "Small" },
                    { 3, 54, "Stort", 162, "Large" },
                    { 2, 18, "", 72, "Medium" }
                });

            migrationBuilder.InsertData(
                table: "RoadTypes",
                columns: new[] { "RoadTypeId", "ModificationFactor", "Type", "UpgradeBaseCost", "UpgradeStoneCost" },
                values: new object[,]
                {
                    { 1, 0.40000000000000002, "Stigar", 20, 0 },
                    { 2, 1.0, "Väg", 64, 15000 },
                    { 3, 2.7999999999999998, "Stenlagdväg", 128, 30000 },
                    { 4, 8.4000000000000004, "Kunglig landsväg", -1, -1 }
                });

            migrationBuilder.InsertData(
                table: "SoldierType",
                columns: new[] { "SoldierTypeId", "Accommodation", "BaseCost", "DisplayName", "SilverCost", "Type" },
                values: new object[,]
                {
                    { 24, false, 6, "Kavalleri spejare", 480, "CavalryScouts" },
                    { 19, false, 2, "Vapenmästare", 2400, "Weaponmasters" },
                    { 20, false, 6, "Kavalleri, bågskyttar", 320, "CavalryBowmen" },
                    { 21, false, 4, "Kurirryttare", 320, "CavalryCourier" },
                    { 22, false, 6, "Lätt kavalleri", 320, "CavalryLight" },
                    { 23, true, 4, "Riddare", 3260, "CavalryKnights" },
                    { 6, false, 2, "Infanteri", 480, "Infantry" },
                    { 26, false, 6, "Tungt kavalleri", 1660, "CavalryHeavy" },
                    { 27, false, 6, "Elit kavalleri", 2040, "CavalryElite" },
                    { 28, true, 0, "Korporal", 2340, "OfficerCorporal" },
                    { 29, true, 0, "Sergeant", 3120, "OfficerSergeant" },
                    { 30, true, 0, "Kapten", 4680, "OfficerCaptain" },
                    { 18, false, 2, "Vakter", 320, "Guards" },
                    { 25, true, 4, "Kavalleri, tempelriddare", 2360, "CavalryKnightTemplars" },
                    { 17, true, 2, "Tempelriddare", 2360, "KnightTemplars" },
                    { 4, false, 2, "Skicklig fältskär", 4480, "MedicsSkilled" },
                    { 15, false, 2, "Spejare", 320, "Scouts" },
                    { 14, false, 2, "Spjutmän", 320, "Spearmen" },
                    { 13, false, 2, "Maskinister", 1360, "Engineers" },
                    { 12, false, 2, "Elit legoknektar", 1840, "MercenaryElite" },
                    { 11, false, 2, "Bågskyttar, legoknektar", 480, "MercenaryBowmen" },
                    { 10, false, 2, "Legoknektar", 560, "Mercenary" },
                    { 9, false, 2, "Långbågsskyttar", 320, "Longbowmen" },
                    { 8, false, 2, "Elit infanteri", 1360, "InfantryElite" },
                    { 7, false, 2, "Tungt infanteri", 800, "InfantryHeavy" },
                    { 5, false, 2, "Lätt infanteri", 320, "InfantryLight" },
                    { 3, false, 2, "Fältskär", 2920, "Medics" },
                    { 2, false, 2, "Bågskyttar", 160, "Bowmen" },
                    { 1, false, 2, "Armborstskyttar", 320, "Crossbowmen" },
                    { 16, false, 2, "Skickliga spejare", 480, "SkilledScouts" }
                });

            migrationBuilder.InsertData(
                table: "SubsidiaryType",
                columns: new[] { "SubsidiaryTypeId", "DaysworkBuild", "DaysworkUpkeep", "DisplayName", "FallModification", "IncomeFactor", "IncomeInBase", "IncomeInLuxury", "IncomeInSilver", "SpringModification", "SummerModification", "Type", "WinterModification" },
                values: new object[,]
                {
                    { 4, 5320, 1460, "Olivlundar", 0.25, 20.0, 0.59999999999999998, 0.20000000000000001, 0.20000000000000001, 0.25, 0.34999999999999998, "Olivegrove", 0.14999999999999999 },
                    { 3, 4225, 365, "Glasbruk", 0.0, 0.20000000000000001, 0.0, 1.0, 0.0, 0.0, 0.0, "Glassworks", 0.0 },
                    { 5, 5320, 2920, "Vindistrikt", 0.25, 20.0, 0.25, 0.40000000000000002, 0.34999999999999998, 0.25, 0.29999999999999999, "Wineregion", 0.20000000000000001 },
                    { 1, 730, 365, "Biodling", 0.10000000000000001, 15.0, 0.34999999999999998, 0.25, 0.40000000000000002, 0.34999999999999998, 0.5, "Beekeeping", 0.050000000000000003 },
                    { 2, 1095, 365, "Fiskdammar", 0.25, 0.20000000000000001, 1.0, 0.0, 0.0, 0.34999999999999998, 0.34999999999999998, "Fishfarms", 0.050000000000000003 },
                    { 6, 3285, 730, "Äppellundar", 0.29999999999999999, 20.0, 1.0, 0.0, 0.0, 0.29999999999999999, 0.29999999999999999, "Applegrove", 0.10000000000000001 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boatbuilders_ShipyardId",
                table: "Boatbuilders",
                column: "ShipyardId");

            migrationBuilder.CreateIndex(
                name: "IX_Boats_BoatTypeId",
                table: "Boats",
                column: "BoatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Boats_BoatbuilderId",
                table: "Boats",
                column: "BoatbuilderId");

            migrationBuilder.CreateIndex(
                name: "IX_Boats_CargoId",
                table: "Boats",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Boats_FiefId",
                table: "Boats",
                column: "FiefId");

            migrationBuilder.CreateIndex(
                name: "IX_Boats_PortId",
                table: "Boats",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_Boats_ShipyardId",
                table: "Boats",
                column: "ShipyardId");

            migrationBuilder.CreateIndex(
                name: "IX_Builders_FiefId",
                table: "Builders",
                column: "FiefId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_BuilderId",
                table: "Buildings",
                column: "BuilderId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_BuildingTypeId",
                table: "Buildings",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_FiefId",
                table: "Buildings",
                column: "FiefId");

            migrationBuilder.CreateIndex(
                name: "IX_Developments_AssignmentId",
                table: "Developments",
                column: "AssignmentId",
                unique: true,
                filter: "[AssignmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FiefId",
                table: "Employees",
                column: "FiefId");

            migrationBuilder.CreateIndex(
                name: "IX_Fiefs_AssignmentId",
                table: "Fiefs",
                column: "AssignmentId",
                unique: true,
                filter: "[AssignmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fiefs_GameSessionId",
                table: "Fiefs",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fiefs_InheritanceTypeId",
                table: "Fiefs",
                column: "InheritanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Industries_AssignmentId",
                table: "Industries",
                column: "AssignmentId",
                unique: true,
                filter: "[AssignmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Industries_FiefId",
                table: "Industries",
                column: "FiefId");

            migrationBuilder.CreateIndex(
                name: "IX_Industries_MineTypeId",
                table: "Industries",
                column: "MineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Industries_QuarryTypeId",
                table: "Industries",
                column: "QuarryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Industries_SubsidiaryTypeId",
                table: "Industries",
                column: "SubsidiaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inheritances_FiefId",
                table: "Inheritances",
                column: "FiefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inheritances_InheritanceTypeId",
                table: "Inheritances",
                column: "InheritanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Livingconditions_FiefId",
                table: "Livingconditions",
                column: "FiefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livingconditions_LivingconditionTypeId",
                table: "Livingconditions",
                column: "LivingconditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_AssignmentId",
                table: "Markets",
                column: "AssignmentId",
                unique: true,
                filter: "[AssignmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_FiefId",
                table: "Markets",
                column: "FiefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_CargoId",
                table: "Merchants",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_MarketId",
                table: "Merchants",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_PortId",
                table: "Merchants",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_Ports_AssignmentId",
                table: "Ports",
                column: "AssignmentId",
                unique: true,
                filter: "[AssignmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ports_FiefId",
                table: "Ports",
                column: "FiefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Residents_FiefId",
                table: "Residents",
                column: "FiefId");

            migrationBuilder.CreateIndex(
                name: "IX_Roads_FiefId",
                table: "Roads",
                column: "FiefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roads_RoadTypeId",
                table: "Roads",
                column: "RoadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipyards_AssignmentId",
                table: "Shipyards",
                column: "AssignmentId",
                unique: true,
                filter: "[AssignmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Shipyards_PortId",
                table: "Shipyards",
                column: "PortId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_BoatId",
                table: "Soldiers",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_FiefId",
                table: "Soldiers",
                column: "FiefId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_MarketId",
                table: "Soldiers",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_MerchantId",
                table: "Soldiers",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_MineIndustryId",
                table: "Soldiers",
                column: "MineIndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_PortId",
                table: "Soldiers",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_QuarryIndustryId",
                table: "Soldiers",
                column: "QuarryIndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_RoadId",
                table: "Soldiers",
                column: "RoadId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_SoldierTypeId",
                table: "Soldiers",
                column: "SoldierTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stewards_AssignmentId",
                table: "Stewards",
                column: "AssignmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stewards_FiefId",
                table: "Stewards",
                column: "FiefId");

            migrationBuilder.CreateIndex(
                name: "IX_Stewards_GameSessionId",
                table: "Stewards",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Villages_FiefId",
                table: "Villages",
                column: "FiefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Developments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Inheritances");

            migrationBuilder.DropTable(
                name: "Livingconditions");

            migrationBuilder.DropTable(
                name: "Residents");

            migrationBuilder.DropTable(
                name: "Soldiers");

            migrationBuilder.DropTable(
                name: "Stewards");

            migrationBuilder.DropTable(
                name: "Villages");

            migrationBuilder.DropTable(
                name: "Builders");

            migrationBuilder.DropTable(
                name: "BuildingTypes");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "LivingconditionTypes");

            migrationBuilder.DropTable(
                name: "Boats");

            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "Roads");

            migrationBuilder.DropTable(
                name: "SoldierType");

            migrationBuilder.DropTable(
                name: "BoatTypes");

            migrationBuilder.DropTable(
                name: "Boatbuilders");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "MineType");

            migrationBuilder.DropTable(
                name: "QuarryType");

            migrationBuilder.DropTable(
                name: "SubsidiaryType");

            migrationBuilder.DropTable(
                name: "RoadTypes");

            migrationBuilder.DropTable(
                name: "Shipyards");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "Fiefs");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "GameSessions");

            migrationBuilder.DropTable(
                name: "InheritanceTypes");
        }
    }
}
