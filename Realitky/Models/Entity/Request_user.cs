using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realitky.Models.Entity;

public class Request_user
{
    [Key]
    public int Id {get;set;}
    public int IdOffer {get;set;}
    public int IdUser {get;set;}
    
    //---------------------------
    
    [ForeignKey("IdOffer")]
    public virtual Offer Offer { get; set; }
    
    [ForeignKey("IdUser")]
    public virtual User User { get; set; }
    
    public virtual List<Message> Messages { get; set; }
}