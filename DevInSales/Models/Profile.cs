using DevInSales.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevInSales.Models;

public class Profile
{
    [Column("id")]
    public int Id { get; set; }
    [Column("role")]
    public string Role { get; set; }
    [Column("permissao")]
    public Permissoes Permissao { get; set; }

    public Profile()
    {
    }

    public Profile(int id, string role, Permissoes permissao)
    {
        Id = id;
        Permissao = permissao;
        Role = role;
    }
}