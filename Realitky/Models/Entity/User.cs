namespace Realitky.Models.Entity;

public class User
{
    public int Id {get;set;}
    public int IdRole {get;set;}
    public string username {get;set;}
    public string password {get;set;}
    public string name {get;set;}
    public string email {get;set;}
    public string phone {get;set;}
    public string avatar {get;set;}

    public User(int Id_,int IdRole_,string username_,string password_,string name_,string email_,string phone_,string avatar_)
    {
        this.Id = Id_;
        this.IdRole = IdRole_;
        this.username = username_;
        this.password = password_;
        this.name = name_;
        this.email = email_;
        this.phone = phone_;
        this.avatar = avatar_;
    }
}