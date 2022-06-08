using DevInSales.Enums;
using DevInSales.Models;

namespace DevInSales.Repositories
{
    public class UserRepository
    {
        public static User VerificarUsuarioESenha(string username, string password)
        {
            var users = new List<User>();

            users.Add(new User() { Id = 1, Name = "Paula", Password = "P123!@", Role = "usuario", Permissao = Permissoes.Usuario });
            users.Add(new User() { Id = 2, Name = "Marcio", Password = "M123!@", Role = "gerente", Permissao = Permissoes.Gerente });
            users.Add(new User() { Id = 3, Name = "Renata", Password = "R123!@", Role = "administrador", Permissao = Permissoes.Administrador });

            return users.Where(x => x.Name.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }
    }
}

