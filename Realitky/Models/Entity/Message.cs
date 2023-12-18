using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realitky.Models.Entity;

public class Message
{
    [Key]
    public int Id {get;set;}
    public int IdThread{get;set;}
    public int IdSender {get;set;}
    public string content {get;set;}
    public DateTime sent_at {get;set;}
    
    //---------------------------
    
    [ForeignKey("IdThread")]
    public virtual Offer Thread { get; set; }
    
    [ForeignKey("IdSender")]
    public virtual User Sender { get; set; }
}