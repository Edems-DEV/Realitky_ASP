using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace Realitky.Models.Entity;

public class Offer
{
    [Key]
    public int Id {get;set;}
    public string? title {get;set;}
    public int? price {get;set;}
    public string? thumbnail {get;set;}
    public string? summary {get;set;}
    public int? IdType {get;set;}
    public int? IdRegion {get;set;}
    public bool IsRent {get;set;}
    public int? size {get;set;}
    public string? body {get;set;}
    public string? address {get;set;}
    public int? IdDealer {get;set;}
    public bool IsVisible {get;set;}
    //-------------------------------------------------
    [NotMapped]
    public virtual List<ParametrsOffers> ParametrsOffers { get; set; }
    [NotMapped]
    public virtual List<Gallery> Gallery { get; set; }
    [NotMapped]
    public bool IsFavorite { get; set; }
    //-------------------------------------------------
    
    [ForeignKey("IdType")]
    public virtual Type Type { get; set; }
    [ForeignKey("IdRegion")]
    public virtual Region Region { get; set; }
    [ForeignKey("IdDealer")]
    public virtual User Dealer { get; set; }
    
    public void IncludeParametrs(MyContext context)
    {
        ParametrsOffers = context.ParametrsOffers
            .Where(x => x.IdOffer == Id)
            .Include(po => po.Parametr)
            .ToList(); 
    }
    public void IncludeGallery(MyContext context)
    {
        Gallery = context.Gallery
            .Where(x => x.IdOffer == Id)
            .ToList(); 
    }
    public void IncludeDealer(MyContext context)
    {
        Dealer = context.Users
            .Where(u => u.Id == IdDealer)
            .FirstOrDefault();
    }
    
    public void IncludeFavorite(MyContext context, int idUser)
    {
        IsFavorite = context.Favorite
            .Where(f => f.IdUser == idUser && f.IdOffer == Id)
            .FirstOrDefault() != null;
    }
}