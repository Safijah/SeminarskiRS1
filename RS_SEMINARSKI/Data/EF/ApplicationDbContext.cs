using Data.EFModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF
{
    public class ApplicationDbContext : IdentityDbContext<Korisnik>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Bend> Bendovi { get; set; }
        public DbSet<Cvijece> Cvijece { get; set; }
        public DbSet<Dekoracija> Dekoracije { get; set; }
        public DbSet<Evidencija> Evidencije { get; set; }
        public DbSet<Fotograf> Fotografi { get; set; }
        public DbSet<Fotografija> Fotografije { get; set; }
        public DbSet<Konobar> Konobari { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Kuhar> Kuhari { get; set; }
        public DbSet<KuharMeni> KuharMeni { get; set; }
        public DbSet<Meni> Meniji { get; set; }
        public DbSet<Muzika> Muzika { get; set; }
        public DbSet<MuzikaBend> MuzikaBendovi { get; set; }
        public DbSet<Pozivnica> Pozivnice { get; set; }
        public DbSet<Racun> Racuni { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<RezervacijaCvijece> RezervacijaCvijece { get; set; }
        public DbSet<RezervacijaDekoracija> RezervacijaDekoracije { get; set; }
        public DbSet<RezervacijaFotograf> RezervacijaFotografi { get; set; }
        public DbSet<RezervacijaKorisnik> RezervacijaKorisnici { get; set; }
        public DbSet<RezervacijaSala> RezervacijaSale { get; set; }
        public DbSet<Sala> Sale { get; set; }
        public DbSet<SalaKonobar> SalaKonobari { get; set; }
        public DbSet<Stavka> Stavke { get; set; }
        public DbSet<StavkaUlaz> StavkaUlaz { get; set; }
        public DbSet<Sto> Stolovi { get; set; }
        public DbSet<TipCvijeca> TipCvijeca { get; set; }
        public DbSet<TipDekoracije> TipDekoracija { get; set; }
        public DbSet<TipMenija> TipMenija { get; set; }
        public DbSet<Rola> Rola { get; set; }
        public DbSet<NacinPlacanja> NacinPlacanja { get; set; }
        public DbSet<KreditnaKartica> KreditnaKartica { get; set; }
        public DbSet<StatusRezervacije> StatusRezervacije { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<MuzikaBend>()
            //   .HasKey(pp => new { pp.MuzikaID, pp.BendID });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<KuharMeni>()
                .HasKey(pp => new { pp.MeniID, pp.KuharID });

            modelBuilder.Entity<RezervacijaCvijece>()
                .HasKey(pp => new { pp.CvijeceID, pp.RezervacijaID });

            modelBuilder.Entity<RezervacijaDekoracija>()
             .HasKey(pi => new { pi.RezervacijaID, pi.DekoracijaID });

            modelBuilder.Entity<RezervacijaFotograf>()
             .HasKey(up => new { up.RezervacijaID, up.FotografID });

            modelBuilder.Entity<RezervacijaKorisnik>()
             .HasKey(uu => new { uu.KorisnikID, uu.RezervacijaID });

            modelBuilder.Entity<RezervacijaSala>()
             .HasKey(bl => new { bl.RezervacijaID, bl.SalaID });

            // modelBuilder.Entity<SalaKonobar>()
            //.HasKey(bl => new { bl.SalaID, bl.KonobarID });


        }
    }
   
}
