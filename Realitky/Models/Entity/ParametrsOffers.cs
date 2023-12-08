namespace Realitky.Models.Entity;

public class ParametrsOffers
{
    public int IdOffer {get;set;}
    public int IdParametr {get;set;}
    public string value {get;set;}

    public ParametrsOffers(int IdOffer_,int IdParametr_,string value_)
    {
        this.IdOffer = IdOffer_;
        this.IdParametr = IdParametr_;
        this.value = value_;
    }
}