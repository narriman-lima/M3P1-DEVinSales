using System.ComponentModel.DataAnnotations;

namespace DevInSales.Enums
{
    public enum Permissoes
    {
        [Display(Name = "Funcionario")]
        Funcionario = 1,
        [Display(Name = "Gerente")]
        Gerente = 2,
        [Display(Name = "Administrador")]
        Administrador = 3,
    }
}
