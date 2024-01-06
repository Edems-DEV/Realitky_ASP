using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication4.Models;

namespace Realitky.Models.Entity;

public class Request
{
    [Key]
    public int Id {get;set;}
    public int IdOffer {get;set;}
    public string text {get;set;}
    public string name {get;set;}
    public string email {get;set;}
    public string phone {get;set;}
    
    //---------------------------
    
    [ForeignKey("IdOffer")]
    public virtual Offer Offer { get; set; }
    
    //---------------------------
    public void IncludeOffer(MyContext context)
    {
        Offer = context.Offers
            .Where(u => u.Id == IdOffer)
            .FirstOrDefault();
    }
}