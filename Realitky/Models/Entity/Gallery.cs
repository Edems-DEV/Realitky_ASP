using System.ComponentModel.DataAnnotations.Schema;

namespace Realitky.Models.Entity;

public class Gallery
{
    public int Id {get;set;}
    [ForeignKey("Offer")]
    public int IdOffer {get;set;}
    public string path {get;set;}
    
    public virtual Offer Offer { get; set; }
}