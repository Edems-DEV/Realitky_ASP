namespace Realitky.Models.Entity;

public class Request
{
    public int Id {get;set;}
    public int IdOffer {get;set;}
    public string text {get;set;}
    public string name {get;set;}
    public string email {get;set;}
    public string phone {get;set;}

    public Request(int Id_,int IdOffer_,string text_,string name_,string email_,string phone_)
    {
        this.Id = Id_;
        this.IdOffer = IdOffer_;
        this.text = text_;
        this.name = name_;
        this.email = email_;
        this.phone = phone_;
    }
}