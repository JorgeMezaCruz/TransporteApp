using Microsoft.EntityFrameworkCore;
using TransporteApp.Data;
using TransporteApp.Models;

namespace TransporteApp.Services;

public class TransporteService
{
    private readonly AppDbContext _context;

    public TransporteService(AppDbContext context)
    {
        _context = context;
    }

    public async Task ListarAsync()
    {
        var transportes = await _context.Transportes
            .Include(t => t.Avion)
            .Include(t => t.Automovil)
            .OrderBy(t => t.Secuencia)
            .ToListAsync();

        Console.WriteLine("\n+----+------------+-----------+--------+--------------+---------------------------+");
        Console.WriteLine("| ID |   Tipo     | Secuencia | Color  | Pasajeros    | Detalle                   |");
        Console.WriteLine("+----+------------+-----------+--------+--------------+---------------------------+");

        foreach (var t in transportes)
        {
            string detalle = t.Tipo.ToLower() == "avion"
                ? $"Piloto: {t.Avion?.Piloto} / Copiloto: {t.Avion?.Copiloto}"
                : $"Conductor: {t.Automovil?.Conductor}";

            Console.WriteLine($"| {t.Id,2} | {t.Tipo,-10} | {t.Secuencia,9} | {t.Color,-6} | {t.NumeroPasajeros,12} | {detalle,-25} |");
        }

        Console.WriteLine("+----+------------+-----------+--------+--------------+---------------------------+\n");
    }

    public async Task InsertarAsync()
    {
        Console.Write("\nTipo (Avion/Automovil): ");
        string tipo = Console.ReadLine()!.Trim();

        if (!tipo.Equals("Avion", StringComparison.OrdinalIgnoreCase) &&
            !tipo.Equals("Automovil", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("❌ Solo se puede registrar un transporte de tipo 'Avion' o 'Automovil'.");
            return;
        }

        int secuencia = PedirEntero("Secuencia");
        int ruedas = PedirEntero("Número de ruedas");
        string color = PedirTexto("Color");
        decimal largo = PedirDecimal("Largo");
        decimal ancho = PedirDecimal("Ancho");
        int pasajeros = PedirEntero("Número de pasajeros");

        var transporte = new Transporte
        {
            Tipo = tipo,
            Secuencia = secuencia,
            NumeroRuedas = ruedas,
            Color = color,
            Largo = largo,
            Ancho = ancho,
            NumeroPasajeros = pasajeros
        };

        _context.Transportes.Add(transporte);
        await _context.SaveChangesAsync();

        if (tipo.Equals("Avion", StringComparison.OrdinalIgnoreCase))
        {
            var avion = new Avion
            {
                Id = transporte.Id,
                Piloto = PedirTexto("Piloto"),
                Copiloto = PedirTexto("Copiloto")
            };
            _context.Aviones.Add(avion);
        }
        else
        {
            var auto = new Automovil
            {
                Id = transporte.Id,
                Conductor = PedirTexto("Conductor")
            };
            _context.Automoviles.Add(auto);
        }

        await _context.SaveChangesAsync();
        Console.WriteLine("✅ Transporte insertado con éxito.\n");
    }

    public async Task ActualizarAsync()
    {
        int id = PedirEntero("ID del transporte a actualizar");

        var transporte = await _context.Transportes
            .Include(t => t.Avion)
            .Include(t => t.Automovil)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (transporte == null)
        {
            Console.WriteLine("❌ Transporte no encontrado.");
            return;
        }

        transporte.Color = PedirTexto("Nuevo color");
        transporte.NumeroPasajeros = PedirEntero("Nuevo número de pasajeros");

        if (transporte.Tipo.Equals("Avion", StringComparison.OrdinalIgnoreCase))
        {
            transporte.Avion!.Piloto = PedirTexto("Nuevo piloto");
            transporte.Avion.Copiloto = PedirTexto("Nuevo copiloto");
        }
        else if (transporte.Tipo.Equals("Automovil", StringComparison.OrdinalIgnoreCase))
        {
            transporte.Automovil!.Conductor = PedirTexto("Nuevo conductor");
        }

        await _context.SaveChangesAsync();
        Console.WriteLine("✅ Transporte actualizado.\n");
    }

    public async Task EliminarAsync()
    {
        int id = PedirEntero("ID del transporte a eliminar");

        var transporte = await _context.Transportes.FindAsync(id);

        if (transporte == null)
        {
            Console.WriteLine("❌ Transporte no encontrado.");
            return;
        }

        _context.Transportes.Remove(transporte);
        await _context.SaveChangesAsync();
        Console.WriteLine("🗑 Transporte eliminado con éxito.\n");
    }

    // Métodos auxiliares de entrada segura
    private string PedirTexto(string label)
    {
        Console.Write($"{label}: ");
        return Console.ReadLine()!.Trim();
    }

    private int PedirEntero(string label)
    {
        Console.Write($"{label}: ");
        return int.TryParse(Console.ReadLine(), out int valor) ? valor : 0;
    }

    private decimal PedirDecimal(string label)
    {
        Console.Write($"{label}: ");
        return decimal.TryParse(Console.ReadLine(), out decimal valor) ? valor : 0;
    }
}
