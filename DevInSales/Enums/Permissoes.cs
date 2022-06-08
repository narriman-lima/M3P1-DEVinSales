using System.ComponentModel.DataAnnotations;

namespace DevInSales.Enums
{
    public enum Permissoes
    {
        [Display(Name = "Usuario")]
        Usuario = 1,
        [Display(Name = "Gerente")]
        Gerente = 2,
        [Display(Name = "Administrador")]
        Administrador = 3,
    }
}
