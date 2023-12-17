using System.ComponentModel.DataAnnotations.Schema;

namespace Realitky.Models.Entity;

public class Offer
{
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
    public virtual List<ParametrsOffers> ParametrsOffers { get; set; }
    public virtual List<Gallery> Gallery { get; set; }
    [NotMapped]
    public bool IsFavorite { get; set; }
}