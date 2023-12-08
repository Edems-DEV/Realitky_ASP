namespace Realitky.Models.Entity;

public class Gallery
{
    public int Id {get;set;}
    public int IdOffer {get;set;}
    public string path {get;set;}

    public Gallery(int Id_,int IdOffer_,string path_)
    {
        this.Id = Id_;
        this.IdOffer = IdOffer_;
        this.path = path_;
    }
}