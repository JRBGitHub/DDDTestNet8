namespace DDDTestNet8.Domain;

public class AcumuladoDivisa
{
    public int IdHost { get; set; }
    public string Canal { get; set; } = string.Empty; // Origen del llamado, string de 4
    public decimal AcumuladoDiario { get; set; }
    public decimal AcumuladoSemanal { get; set; }
    public decimal AcumuladoMensual { get; set; }
}
