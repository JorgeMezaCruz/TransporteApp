using System;

namespace TransporteApp.Models;

public class Transporte
{
    public int Id { get; set; }
    public string Tipo { get; set; } = null!;
    public int Secuencia { get; set; }
    public int NumeroRuedas { get; set; }
    public string Color { get; set; } = null!;
    public decimal Largo { get; set; }
    public decimal Ancho { get; set; }
    public int NumeroPasajeros { get; set; }

    public Avion? Avion { get; set; }
    public Automovil? Automovil { get; set; }
}
