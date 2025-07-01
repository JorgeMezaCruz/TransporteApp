using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TransporteApp.Data;
using TransporteApp.Services;

var builder = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<TransporteService>();
    })
    .Build();

using var scope = builder.Services.CreateScope();
var transporteService = scope.ServiceProvider.GetRequiredService<TransporteService>();

while (true)
{
    try
    {
        Console.WriteLine("\n===== Sistema de Transporte Andes (.NET 8 + EF Core) =====");
        Console.WriteLine("1. Listar transportes");
        Console.WriteLine("2. Insertar transporte");
        Console.WriteLine("3. Actualizar transporte");
        Console.WriteLine("4. Eliminar transporte");
        Console.WriteLine("5. Salir");
        Console.Write("Seleccione una opción: ");
        Console.WriteLine("\n===========================================================");

        var opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                Console.WriteLine("📋 Listando transportes...");
                await transporteService.ListarAsync();
                break;
            case "2":
                Console.WriteLine("📝 Insertando transporte...");
                await transporteService.InsertarAsync();
                break;
            case "3":
                Console.WriteLine("✏️ Actualizando transporte...");
                await transporteService.ActualizarAsync();
                break;
            case "4":
                Console.WriteLine("🗑 Eliminando transporte...");
                await transporteService.EliminarAsync();
                break;
            case "5":
                Console.WriteLine("👋 Saliendo del programa. ¡Hasta pronto!");
                return;
            default:
                MostrarError("❌ Opción no válida. Por favor ingrese un número del 1 al 5.");
                break;
        }
    }
    catch (Exception ex)
    {
        MostrarError("⚠️ Error inesperado: " + ex.Message);
        Console.WriteLine("📌 Detalles técnicos: ");
        Console.WriteLine(ex.StackTrace);
    }
}

static void MostrarError(string mensaje)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(mensaje);
    Console.ResetColor();
}
