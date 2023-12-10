namespace Realitky.Models.Entity;

public class ParametrsOffers
{
    public int IdOffer {get;set;}
    public virtual Offer Offer { get; set; }
    public int IdParametr {get;set;}
    public virtual Parametrs Parametr { get; set; }
    public string value {get;set;}
}