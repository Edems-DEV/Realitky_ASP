namespace Realitky.Models.Entity;

public class Type
{
    public int Id {get;set;}
    public string name {get;set;}

    public Type(int Id_,string name_)
    {
        this.Id = Id_;
        this.name = name_;
    }
}