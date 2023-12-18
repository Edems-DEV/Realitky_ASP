using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication4.Models;

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
    
    [NotMapped] // 1h bug :)
    public virtual List<Message> Messages { get; set; }
    [NotMapped] //request / first message
    public virtual string Text { get; set; }

    public void IncludeMessages(MyContext context)
    {
        Messages = context.Message
            .Where(x => x.IdThread == Id)
            .ToList(); 
    }
    public void IncludeOffer(MyContext context)
    {
        Offer = context.Offers
            .Where(o => o.Id == IdOffer)
            .FirstOrDefault();
    }
}