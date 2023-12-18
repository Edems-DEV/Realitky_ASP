using System.ComponentModel.DataAnnotations;

namespace Realitky.Models.Entity;

public class Role
{
    [Key]
    public int Id {get;set;}
    public string name {get;set;}
}