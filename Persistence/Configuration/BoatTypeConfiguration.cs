using Domain.Entities.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class BoatTypeConfiguration : IEntityTypeConfiguration<BoatType>
    {
        public void Configure(EntityTypeBuilder<BoatType> builder)
        {
            builder.Property(e => e.BoatTypeId)
                .HasColumnName("BoatTypeId")
                .UseIdentityColumn<int>(1, 1);

            builder.Property(e => e.BL).HasColumnType("decimal(15,5)");
            builder.Property(e => e.DB).HasColumnType("decimal(15,5)");
            builder.Property(e => e.Crew).HasColumnType("decimal(15,5)");
            builder.Property(e => e.Cargo).HasColumnType("decimal(15,5)");
            builder.Property(e => e.BenchMulti).HasColumnType("decimal(15,5)");

            builder.HasData(
                new BoatType
                {
                    BoatTypeId = 1,
                        Type = "Bridad",
                        Masts = 3,
                        LengthMin = 20,
                        LengthMax = 28,
                        BL = 0.3M,
                        DB = 0.28M,
                        Crew = 0.35M,
                        Cargo = 1.5M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "1.jpg",
                        Seaworthiness = "1T6"
                },
                new BoatType
                {
                    BoatTypeId = 2,
                        Type = "Drakfartyg",
                        Masts = 2,
                        LengthMin = 23,
                        LengthMax = 28,
                        BL = 0.25M,
                        DB = 0.28M,
                        Crew = 0.5M,
                        Cargo = 0.5M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "2.jpg",
                        Seaworthiness = "2T6"
                },
                new BoatType
                {
                    BoatTypeId = 3,
                        Type = "Fiskebåt",
                        Masts = 1,
                        LengthMin = 6,
                        LengthMax = 6,
                        BL = 0.38M,
                        DB = 0.35M,
                        Crew = 0.3M,
                        Cargo = 0.9M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "3.jpg",
                        Seaworthiness = "1T6"
                },
                new BoatType
                {
                    BoatTypeId = 4,
                        Type = "Flodbåt",
                        Masts = 2,
                        LengthMin = 5,
                        LengthMax = 7,
                        BL = 0.44M,
                        DB = 0.15M,
                        Crew = 0.4M,
                        Cargo = 1.8M,
                        BenchMod = 3,
                        BenchMulti = 0.5M,
                        OarsMulti = 2,
                        RowerMulti = -1,
                        ImgSource = "4.jpg",
                        Seaworthiness = "4T6"
                },
                new BoatType
                {
                    BoatTypeId = 5,
                        Type = "Flodpråm",
                        Masts = 2,
                        LengthMin = 17,
                        LengthMax = 27,
                        BL = 0.42M,
                        DB = 0.12M,
                        Crew = 0.2M,
                        Cargo = 2M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "5.jpg",
                        Seaworthiness = "4T6"
                },
                new BoatType
                {
                    BoatTypeId = 6,
                        Type = "Gaffa",
                        Masts = 2,
                        LengthMin = 13,
                        LengthMax = 19,
                        BL = 0.28M,
                        DB = 0.35M,
                        Crew = 0.25M,
                        Cargo = 1M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "6.jpg",
                        Seaworthiness = "1T6"
                },
                new BoatType
                {
                    BoatTypeId = 7,
                        Type = "Galloz",
                        Masts = 3,
                        LengthMin = 22,
                        LengthMax = 35,
                        BL = 0.24M,
                        DB = 0.33M,
                        Crew = 0.35M,
                        Cargo = 1.6M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "7.jpg",
                        Seaworthiness = "2T6"
                },
                new BoatType
                {
                    BoatTypeId = 8,
                        Type = "Jagol",
                        Masts = 1,
                        LengthMin = 7,
                        LengthMax = 11,
                        BL = 0.27M,
                        DB = 0.28M,
                        Crew = 0.4M,
                        Cargo = 1.4M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "8.jpg",
                        Seaworthiness = "1T6"
                },
                new BoatType
                {
                    BoatTypeId = 9,
                        Type = "Jakt",
                        Masts = 2,
                        LengthMin = 12,
                        LengthMax = 17,
                        BL = 0.18M,
                        DB = 0.4M,
                        Crew = 0.4M,
                        Cargo = 1M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "9.jpg",
                        Seaworthiness = "3T6"
                },
                new BoatType
                {
                    BoatTypeId = 10,
                        Type = "Kaga",
                        Masts = 1,
                        LengthMin = 19,
                        LengthMax = 23,
                        BL = 0.21M,
                        DB = 0.35M,
                        Crew = 0.35M,
                        Cargo = 1M,
                        BenchMod = -10,
                        BenchMulti = 0.5M,
                        OarsMulti = 4,
                        RowerMulti = 4,
                        ImgSource = "10.jpg",
                        Seaworthiness = "2T6"
                },
                new BoatType
                {
                    BoatTypeId = 11,
                        Type = "Kagge",
                        Masts = 1,
                        LengthMin = 14,
                        LengthMax = 22,
                        BL = 0.27M,
                        DB = 0.4M,
                        Crew = 0.25M,
                        Cargo = 1.7M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "11.jpg",
                        Seaworthiness = "3T6"
                },
                new BoatType
                {
                    BoatTypeId = 12,
                        Type = "Karack, fyrmastad",
                        Masts = 4,
                        LengthMin = 26,
                        LengthMax = 37,
                        BL = 0.28M,
                        DB = 0.36M,
                        Crew = 0.3M,
                        Cargo = 1.4M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "12.jpg",
                        Seaworthiness = "1T6"
                },
                new BoatType
                {
                    BoatTypeId = 13,
                        Type = "Karack, tremastad",
                        Masts = 3,
                        LengthMin = 17,
                        LengthMax = 29,
                        BL = 0.26M,
                        DB = 0.38M,
                        Crew = 0.33M,
                        Cargo = 1.3M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "13.jpg",
                        Seaworthiness = "2T6"
                },
                new BoatType
                {
                    BoatTypeId = 14,
                        Type = "Lanacka",
                        Masts = 2,
                        LengthMin = 13,
                        LengthMax = 24,
                        BL = 0.32M,
                        DB = 0.2M,
                        Crew = 0.35M,
                        Cargo = 1.4M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "14.jpg",
                        Seaworthiness = "3T6"
                },
                new BoatType
                {
                    BoatTypeId = 15,
                        Type = "Lemirier",
                        Masts = 1,
                        LengthMin = 24,
                        LengthMax = 34,
                        BL = 0.2M,
                        DB = 0.32M,
                        Crew = 0.2M,
                        Cargo = 0.7M,
                        BenchMod = -14,
                        BenchMulti = 1.5M,
                        OarsMulti = 2,
                        RowerMulti = 4,
                        ImgSource = "15.jpg",
                        Seaworthiness = "3T6"
                },
                new BoatType
                {
                    BoatTypeId = 16,
                        Type = "Rundskepp, ett däck",
                        Masts = 1,
                        LengthMin = 12,
                        LengthMax = 25,
                        BL = 0.3M,
                        DB = 0.28M,
                        Crew = 0.36M,
                        Cargo = 1.5M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "16.jpg",
                        Seaworthiness = "2T6"
                },
                new BoatType
                {
                    BoatTypeId = 17,
                        Type = "Rundskepp, två däck",
                        Masts = 2,
                        LengthMin = 25,
                        LengthMax = 36,
                        BL = 0.25M,
                        DB = 0.32M,
                        Crew = 0.38M,
                        Cargo = 1.6M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "17.jpg",
                        Seaworthiness = "2T6"
                },
                new BoatType
                {
                    BoatTypeId = 18,
                        Type = "Sabrier, tremastad",
                        Masts = 3,
                        LengthMin = 23,
                        LengthMax = 33,
                        BL = 0.22M,
                        DB = 0.35M,
                        Crew = 0.4M,
                        Cargo = 1.6M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "18.jpg",
                        Seaworthiness = "2T6"
                },
                new BoatType
                {
                    BoatTypeId = 19,
                        Type = "Sabrier, tvåmastad",
                        Masts = 2,
                        LengthMin = 17,
                        LengthMax = 25,
                        BL = 0.2M,
                        DB = 0.4M,
                        Crew = 0.4M,
                        Cargo = 1.5M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "19.jpg",
                        Seaworthiness = "2T6"
                },
                new BoatType
                {
                    BoatTypeId = 20,
                        Type = "Slurp",
                        Masts = 1,
                        LengthMin = 8,
                        LengthMax = 14,
                        BL = 0.35M,
                        DB = 0.24M,
                        Crew = 0.35M,
                        Cargo = 1.2M,
                        BenchMod = -5,
                        BenchMulti = 0.4M,
                        OarsMulti = 2,
                        RowerMulti = -1,
                        ImgSource = "20.jpg",
                        Seaworthiness = "3T6"
                },
                new BoatType
                {
                    BoatTypeId = 21,
                        Type = "Umbura",
                        Masts = 1,
                        LengthMin = 27,
                        LengthMax = 37,
                        BL = 0.18M,
                        DB = 0.3M,
                        Crew = 0.2M,
                        Cargo = 1M,
                        BenchMod = -17,
                        BenchMulti = 1.8M,
                        OarsMulti = 4,
                        RowerMulti = 4,
                        ImgSource = "21.jpg",
                        Seaworthiness = "3T6"
                },
                new BoatType
                {
                    BoatTypeId = 22,
                        Type = "Vågridare, tremastad",
                        Masts = 3,
                        LengthMin = 14,
                        LengthMax = 21,
                        BL = 0.25M,
                        DB = 0.35M,
                        Crew = 0.28M,
                        Cargo = 1.5M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "22.jpg",
                        Seaworthiness = "2T6"
                },
                new BoatType
                {
                    BoatTypeId = 23,
                        Type = "Vågridare, tvåmastad",
                        Masts = 2,
                        LengthMin = 11,
                        LengthMax = 16,
                        BL = 0.24M,
                        DB = 0.32M,
                        Crew = 0.35M,
                        Cargo = 1.4M,
                        BenchMod = 0,
                        BenchMulti = 0,
                        OarsMulti = 0,
                        RowerMulti = 0,
                        ImgSource = "23.jpg",
                        Seaworthiness = "3T6"
                }
            );
        }
    }
}