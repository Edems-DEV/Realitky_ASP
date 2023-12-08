namespace Realitky.Models.Entity;

public class Parametrs
{
    public int Id {get;set;}
    public string name {get;set;}

    public Parametrs(int Id_,string name_)
    {
        this.Id = Id_;
        this.name = name_;
    }
}