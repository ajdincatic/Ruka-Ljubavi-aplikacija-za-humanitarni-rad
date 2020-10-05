﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RukaLjubavi.Api.Database;

namespace RukaLjubavi.Api.Migrations
{
    [DbContext(typeof(RukaLjubaviDbContext))]
    [Migration("20201005174353_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RukaLjubavi.Api.Models.Benefiktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("NazivKompanije")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pdvbroj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Benefiktori");
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.BenefiktorKategorija", b =>
                {
                    b.Property<int>("BenefiktorId")
                        .HasColumnType("int");

                    b.Property<int>("KategorijaId")
                        .HasColumnType("int");

                    b.HasKey("BenefiktorId", "KategorijaId");

                    b.HasIndex("KategorijaId");

                    b.ToTable("BenefiktorKategorije");
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.Donacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BenefiktorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<int>("DonatorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPrihvacena")
                        .HasColumnType("bit");

                    b.Property<int>("KategorijaId")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DonatorId");

                    b.HasIndex("BenefiktorId", "KategorijaId");

                    b.ToTable("Donacije");
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.Donator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jmbg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("MjestoRodjenjaId")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("MjestoRodjenjaId");

                    b.ToTable("Donatori");
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.DonatorKategorija", b =>
                {
                    b.Property<int>("DonatorId")
                        .HasColumnType("int");

                    b.Property<int>("KategorijaId")
                        .HasColumnType("int");

                    b.HasKey("DonatorId", "KategorijaId");

                    b.HasIndex("KategorijaId");

                    b.ToTable("DonatorKategorije");
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drzave");
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Gradovi");
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategorije");
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRegistracije")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerifikovan")
                        .HasColumnType("bit");

                    b.Property<string>("LozinkaHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LozinkaSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MjestoPrebivalistaId")
                        .HasColumnType("int");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipKorisnika")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MjestoPrebivalistaId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.Notifikacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DatumPregleda")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumSlanja")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("Sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Notifikacije");
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.OcjenaDonacije", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrzinaDostavljanja")
                        .HasColumnType("int");

                    b.Property<int>("DonacijaId")
                        .HasColumnType("int");

                    b.Property<string>("Komentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("Ocjenjivac")
                        .HasColumnType("int");

                    b.Property<int>("PostivanjeDogovora")
                        .HasColumnType("int");

                    b.Property<int>("Povjerljivost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonacijaId");

                    b.ToTable("OcjeneDonacija");
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.Benefiktor", b =>
                {
                    b.HasOne("RukaLjubavi.Api.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.BenefiktorKategorija", b =>
                {
                    b.HasOne("RukaLjubavi.Api.Models.Benefiktor", "Benefiktor")
                        .WithMany()
                        .HasForeignKey("BenefiktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RukaLjubavi.Api.Models.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.Donacija", b =>
                {
                    b.HasOne("RukaLjubavi.Api.Models.Donator", "Donator")
                        .WithMany()
                        .HasForeignKey("DonatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RukaLjubavi.Api.Models.BenefiktorKategorija", "BenefiktorKategorije")
                        .WithMany()
                        .HasForeignKey("BenefiktorId", "KategorijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.Donator", b =>
                {
                    b.HasOne("RukaLjubavi.Api.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RukaLjubavi.Api.Models.Grad", "MjestoRodjenja")
                        .WithMany()
                        .HasForeignKey("MjestoRodjenjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.DonatorKategorija", b =>
                {
                    b.HasOne("RukaLjubavi.Api.Models.Donator", "Donator")
                        .WithMany()
                        .HasForeignKey("DonatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RukaLjubavi.Api.Models.Kategorija", "Kategorija")
                        .WithMany()
                        .HasForeignKey("KategorijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.Grad", b =>
                {
                    b.HasOne("RukaLjubavi.Api.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.Korisnik", b =>
                {
                    b.HasOne("RukaLjubavi.Api.Models.Grad", "MjestoPrebivalista")
                        .WithMany()
                        .HasForeignKey("MjestoPrebivalistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.Notifikacija", b =>
                {
                    b.HasOne("RukaLjubavi.Api.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RukaLjubavi.Api.Models.OcjenaDonacije", b =>
                {
                    b.HasOne("RukaLjubavi.Api.Models.Donacija", "Donacija")
                        .WithMany()
                        .HasForeignKey("DonacijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
