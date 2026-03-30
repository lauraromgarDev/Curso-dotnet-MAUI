using System;
using System.Collections.Generic;
using System.Text;

namespace PatriarcaHomes02.Repositories
{
    public interface ILoginRepository
    {
        Task<bool> LoginAsync(string email, string password);
        Task<bool> LogoutAsync();
    }
}
