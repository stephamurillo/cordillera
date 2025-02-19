public class Ubicacion
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    public TimeSpan HorarioApertura { get; set; }
    public TimeSpan HorarioCierre { get; set; }
    public double Latitud { get; set; }
    public double Longitud { get; set; }
}