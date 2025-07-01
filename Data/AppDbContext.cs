using Microsoft.EntityFrameworkCore;
using TransporteApp.Models;

namespace TransporteApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Transporte> Transportes => Set<Transporte>();
    public DbSet<Avion> Aviones => Set<Avion>();
    public DbSet<Automovil> Automoviles => Set<Automovil>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relaciones
        modelBuilder.Entity<Transporte>()
            .HasOne(t => t.Avion)
            .WithOne(a => a.Transporte)
            .HasForeignKey<Avion>(a => a.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Transporte>()
            .HasOne(t => t.Automovil)
            .WithOne(au => au.Transporte)
            .HasForeignKey<Automovil>(au => au.Id)
            .OnDelete(DeleteBehavior.Cascade);

        // Validaciones
        modelBuilder.Entity<Transporte>()
            .Property(t => t.Tipo)
            .HasMaxLength(15)
            .IsRequired();

        modelBuilder.Entity<Transporte>()
            .Property(t => t.Largo)
            .HasPrecision(10, 4);

        modelBuilder.Entity<Transporte>()
            .Property(t => t.Ancho)
            .HasPrecision(10, 4);

        // Datos iniciales (desordenados)
        modelBuilder.Entity<Transporte>().HasData(
            new Transporte { Id = 1, Tipo = "Avion", Secuencia = 3, NumeroRuedas = 6, Color = "Blanco", Largo = 32.5m, Ancho = 5.4m, NumeroPasajeros = 180 },
            new Transporte { Id = 2, Tipo = "Automovil", Secuencia = 1, NumeroRuedas = 4, Color = "Rojo", Largo = 4.2m, Ancho = 1.8m, NumeroPasajeros = 5 },
            new Transporte { Id = 3, Tipo = "Avion", Secuencia = 6, NumeroRuedas = 8, Color = "Azul", Largo = 40.0m, Ancho = 6.1m, NumeroPasajeros = 200 },
            new Transporte { Id = 4, Tipo = "Automovil", Secuencia = 2, NumeroRuedas = 4, Color = "Negro", Largo = 4.0m, Ancho = 1.75m, NumeroPasajeros = 4 },
            new Transporte { Id = 5, Tipo = "Avion", Secuencia = 5, NumeroRuedas = 10, Color = "Gris", Largo = 35.3m, Ancho = 5.8m, NumeroPasajeros = 150 },
            new Transporte { Id = 6, Tipo = "Automovil", Secuencia = 4, NumeroRuedas = 4, Color = "Verde", Largo = 4.5m, Ancho = 1.9m, NumeroPasajeros = 5 }
        );

        modelBuilder.Entity<Avion>().HasData(
            new Avion { Id = 1, Piloto = "Luis", Copiloto = "Pedro" },
            new Avion { Id = 3, Piloto = "Carlos", Copiloto = "Marco" },
            new Avion { Id = 5, Piloto = "Andrea", Copiloto = "Jorge" }
        );

        modelBuilder.Entity<Automovil>().HasData(
            new Automovil { Id = 2, Conductor = "Diana" },
            new Automovil { Id = 4, Conductor = "Sofía" },
            new Automovil { Id = 6, Conductor = "Roberto" }
        );
    }


}
