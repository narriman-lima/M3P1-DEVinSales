using System.ComponentModel.DataAnnotations;

namespace DevInSales.Enums
{
    public enum Permissoes
    {
        [Display(Name = "usuario")]
        usuario = 1,
        [Display(Name = "gerente")]
        gerente,
        [Display(Name = "administrador")]
        administrador,
    }
}
