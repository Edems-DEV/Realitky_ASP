namespace Realitky.Models.Entity;

public class Parametrs
{
    public int Id {get;set;}
    public string name {get;set;}
    public virtual List<ParametrsOffers> ParametrsOffers { get; set; }
}