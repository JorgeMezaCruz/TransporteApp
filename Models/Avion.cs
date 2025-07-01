namespace TransporteApp.Models;

public class Avion
{
    public int Id { get; set; }
    public string Piloto { get; set; } = null!;
    public string Copiloto { get; set; } = null!;

    public Transporte Transporte { get; set; } = null!;
}

