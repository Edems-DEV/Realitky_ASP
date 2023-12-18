using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realitky.Models.Entity;

public class Gallery
{
    [Key]
    public int Id {get;set;}
    
    public int IdOffer {get;set;}
    public string path {get;set;}
    
    //---------------------------
    
    [ForeignKey("IdOffer")]
    public virtual Offer Offer { get; set; }
}