namespace Realitky.Models.Entity;

public class User
{
    public int Id {get;set;}
    public int? IdRole {get;set;}
    public string? username {get;set;}
    public string? password {get;set;}
    public string? name {get;set;}
    public string? email {get;set;}
    public string? phone {get;set;}
    public string? avatar {get;set;}
}