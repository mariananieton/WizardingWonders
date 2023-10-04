using System.ComponentModel.DataAnnotations;

namespace WizardingWonders.Models;

public class Feitico
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    [Display(Name ="Descrição")]
    public string? Descricao { get; set; }
    [Display(Name ="Nível de Dificuldade")]
    public int NivelDificuldade { get; set; }
    [Display(Name ="Tipo de Feitiço")]
    public Tipo Tipo { get; set; }
    [DataType(DataType.Date), Display(Name = "Data da Descoberta")]
    public DateTime DataDescoberta { get; set; }
    [Display(Name ="É necessário utilizar uma varinha")]
    public bool Varinha { get; set; }
}

public enum Tipo
{
    Ataque, Defesa, Cura, Utilidade
}

