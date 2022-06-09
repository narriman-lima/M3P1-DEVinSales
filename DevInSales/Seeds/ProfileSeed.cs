using DevInSales.Enums;
using DevInSales.Models;

namespace DevInSales.Seeds
{
    public class ProfileSeed
    {
        public static List<Profile> Seed { get; set; } = new List<Profile>() { new Profile(1, "usuario", Permissoes.usuario), new Profile(2, "gerente", Permissoes.gerente), new Profile(3, "administrador", Permissoes.administrador) };
    }
}
