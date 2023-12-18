using System.ComponentModel.DataAnnotations.Schema;

namespace Realitky.Models.Entity;

public class ParametrsOffers
{
    public int IdOffer {get;set;}
    public int IdParametr {get;set;}
    public string value {get;set;}
    
    //---------------------------
    
    [ForeignKey("IdOffer")]
    public virtual Offer Offer { get; set; }
    
    [ForeignKey("IdParametr")]
    public virtual Parametrs Parametr { get; set; }
}