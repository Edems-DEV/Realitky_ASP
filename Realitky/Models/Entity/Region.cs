namespace Realitky.Models.Entity;

public class Region
{
    public int Id {get;set;}
    public string name {get;set;}

    public Region(int Id_,string name_)
    {
        this.Id = Id_;
        this.name = name_;
    }
}