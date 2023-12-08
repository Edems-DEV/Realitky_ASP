namespace Realitky.Models.Entity;

public class Role
{
    public int Id {get;set;}
    public string name {get;set;}

    public Role(int Id_,string name_)
    {
        this.Id = Id_;
        this.name = name_;
    }
}