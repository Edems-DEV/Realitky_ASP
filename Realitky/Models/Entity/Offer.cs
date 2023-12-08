namespace Realitky.Models.Entity;

public class Offer
{
    public int Id {get;set;}
    public string title {get;set;}
    public int price {get;set;}
    public string thumbnail {get;set;}
    public string summary {get;set;}
    public int IdType {get;set;}
    public int IdRegion {get;set;}
    public bool IsRent {get;set;}
    public int size {get;set;}
    public string body {get;set;}
    public string address {get;set;}
    public int IdDealer {get;set;}
    public bool IsVisible {get;set;}

    public Offer(int Id_,string title_,int price_,string thumbnail_,string summary_,int IdType_,int IdRegion_,bool IsRent_,int size_,string body_,string address_,int IdDealer_,bool IsVisible_)
    {
        this.Id = Id_;
        this.title = title_;
        this.price = price_;
        this.thumbnail = thumbnail_;
        this.summary = summary_;
        this.IdType = IdType_;
        this.IdRegion = IdRegion_;
        this.IsRent = IsRent_;
        this.size = size_;
        this.body = body_;
        this.address = address_;
        this.IdDealer = IdDealer_;
        this.IsVisible = IsVisible_;
    }
}