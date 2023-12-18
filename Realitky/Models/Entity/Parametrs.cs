using System.ComponentModel.DataAnnotations;

namespace Realitky.Models.Entity;

public class Parametrs
{
    [Key]
    public int Id {get;set;}
    public string name {get;set;}
    
    //---------------------------
    
    public virtual List<ParametrsOffers> ParametrsOffers { get; set; }
    // public virtual List<Offer> Offers2 { get; set; } //broken
}