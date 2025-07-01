namespace TransporteApp.Models;

public class Automovil
{
    public int Id { get; set; }
    public string Conductor { get; set; } = null!;

    public Transporte Transporte { get; set; } = null!;
}
