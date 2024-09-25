using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MvcProject.Models;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MvcProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<Gebruiker, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Gebruiker> Gebruikers { get; set; } = default!;
        public DbSet<GebruikerRol> GebruikerRolen { get; set; } = default!;
        public DbSet<Rol> Rollen { get; set; } = default!;
        public DbSet<Afwezigheid> Afwezigheden { get; set; } = default!;
        public DbSet<GebruikerNavorming> GebruikerNavormingen { get; set; } = default!;
        public DbSet<Navorming> Navormingen { get; set; } = default!;
        public DbSet<FotoAlbum> FotoAlbums { get; set; } = default!;
        public DbSet<Foto> Fotos { get; set; } = default!;
        public DbSet<Begeleiding> Begeleidingen { get; set; } = default!;
        public DbSet<Studiebezoek> Studiebezoeken { get; set; } = default!;
        public DbSet<KlasStudiebezoek> KlasStudiebezoeken { get; set; } = default!;
        public DbSet<Klas> Klassen { get; set; } = default!;
        public DbSet<Vak> Vakken { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gebruiker>().ToTable("Gebruiker");
            modelBuilder.Entity<GebruikerRol>().ToTable("GebruikerRol");
            modelBuilder.Entity<Rol>().ToTable("Rol");
            modelBuilder.Entity<Afwezigheid>().ToTable("Afwezigheid");
            modelBuilder.Entity<GebruikerNavorming>().ToTable("GebruikerNavorming");
            modelBuilder.Entity<Navorming>().ToTable("Navorming").Property(k => k.Kostprijs).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<FotoAlbum>().ToTable("FotoAlbum");
            modelBuilder.Entity<Foto>().ToTable("Foto");
            modelBuilder.Entity<Begeleiding>().ToTable("Begeleiding");
            modelBuilder.Entity<Studiebezoek>().ToTable("Studiebezoek").Property(p => p.KostprijsStudiebezoek).HasColumnType("decimal(18,4)"); 
            modelBuilder.Entity<KlasStudiebezoek>().ToTable("KlasStudiebezoek");
            modelBuilder.Entity<Klas>().ToTable("Klas");
            modelBuilder.Entity<Vak>().ToTable("Vak");



            modelBuilder.Entity<Afwezigheid>()
             .HasOne(a => a.Gebruiker)
             .WithMany(g => g.Afwezigheden)
             .HasForeignKey(a => a.GebruikerId)
             .IsRequired(true).OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<KlasStudiebezoek>()
             .HasKey(ks => ks.KlasStudiebezoekId); // Assuming KlasStudiebezoekId is the primary key

            modelBuilder.Entity<KlasStudiebezoek>()
                .HasOne(ks => ks.Klas)
                .WithMany(k => k.KlasStudiebezoeken)
                .HasForeignKey(ks => ks.KlasId)
                .IsRequired(true).OnDelete(DeleteBehavior.Restrict); // Adjust this based on your requirements

            modelBuilder.Entity<KlasStudiebezoek>()
                .HasOne(ks => ks.Studiebezoek)
                .WithMany(s => s.KlasStudiebezoeken)
                .HasForeignKey(ks => ks.StudiebezoekId)
                .IsRequired(true).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Studiebezoek>()
                .HasKey(sb => sb.StudiebezoekId); // Assuming StudiebezoekId is the primary key

            modelBuilder.Entity<Studiebezoek>()
                .HasOne(sb => sb.Vak)
                .WithMany(v => v.Studiebezoeken)
                .HasForeignKey(sb => sb.VakId)
                .IsRequired(true).OnDelete(DeleteBehavior.Restrict); // Adjust this based on your requirements

            modelBuilder.Entity<Studiebezoek>()
                .HasOne(sb => sb.Gebruiker)
                .WithMany(sb => sb.Studiebezoeken)
                .HasForeignKey(sb => sb.GebruikerId)
                .IsRequired(true); // Adjust this based on your requirements


            //modelBuilder.Entity<Studiebezoek>()
            //   .HasOne(sb => sb.st)
            //   .WithMany(v => v.Studiebezoeken)
            //   .HasForeignKey(sb => sb.BijlageId)
            //   .IsRequired(true); //



            modelBuilder.Entity<GebruikerNavorming>()
             .HasKey(gn => gn.GebruikerNavormingId); // Assuming GebruikerNavormingId is the primary key

            modelBuilder.Entity<GebruikerNavorming>()
                .HasOne(gn => gn.Gebruiker)
                .WithMany(g => g.GebruikerNavormingen)
                .HasForeignKey(gn => gn.GebruikerId)
                .IsRequired(true); // Adjust this based on your requirements

            modelBuilder.Entity<GebruikerNavorming>()
                .HasOne(gn => gn.Navorming)
                .WithMany(n => n.GebruikerNavormingen)
                .HasForeignKey(gn => gn.NavormingId)
                .IsRequired(true).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Navorming>()
            .HasOne(n => n.Gebruiker)
            .WithMany(g => g.Navormingen)
            .HasForeignKey(n => n.GebruikerId)
            .IsRequired(true).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Foto>()
                .HasKey(f => f.FotoId); // Assuming FotoId is the primary key

            modelBuilder.Entity<Foto>()
                .HasOne(f => f.FotoAlbum)
                .WithMany(fa => fa.Fotos)
                .HasForeignKey(f => f.FotoAlbumId)
                .IsRequired(true).OnDelete(DeleteBehavior.Restrict); // Adjust this based on your requirements

            modelBuilder.Entity<FotoAlbum>()
                .HasKey(fa => fa.FotoAlbumId); // Assuming FotoAlbumId is the primary key

            modelBuilder.Entity<FotoAlbum>()
                .HasOne(fa => fa.Studiebezoek)
                .WithMany(g => g.FotoAlbums)
                .HasForeignKey(fa => fa.StudiebezoekId)
                .IsRequired(true).OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<GebruikerRol>()
            //    .HasKey(gr => gr.Id); // Assuming GebruikerRolId is the primary key

            modelBuilder.Entity<GebruikerRol>()
                .HasOne(gr => gr.Gebruiker)
                .WithMany(g => g.GebruikerRollen)
                .HasForeignKey(gr => gr.UserId)
                .IsRequired(); // Adjust this based on your requirements

            modelBuilder.Entity<GebruikerRol>()
                .HasOne(gr => gr.Rol)
                .WithMany(r => r.GebruikerRollen)
                .HasForeignKey(gr => gr.RoleId)
                .IsRequired();

            modelBuilder.Entity<Bijlage>()
            .HasKey(b => b.BijlageId); // Assuming BijlageId is the primary key

            modelBuilder.Entity<Bijlage>()
                .HasOne(b => b.Studiebezoek)
                .WithMany(s => s.Bijlagen)
                .HasForeignKey(b => b.StudiebezoekId)
                .IsRequired(true);

            modelBuilder.Entity<Begeleiding>()
            .HasOne(b => b.Gebruiker)
            .WithMany(g => g.Begeleidingen)
            .HasForeignKey(b => b.GebruikerId)
            .IsRequired(true).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Begeleiding>()
            .HasOne(b => b.Studiebezoek)
            .WithMany(g => g.Begeleidingen)
            .HasForeignKey(b => b.StudiebezoekId)
            .IsRequired(true).OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<GebruikerRol>().ToTable("Product").Property(p => p.Prijs).HasColumnType("decimal(18,2)");

        }
    }
}