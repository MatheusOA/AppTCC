using AppTCC.Models;
using AppTCC.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTCC.Services
{
    public class LoginService
    {
        public LoginRepository _loginRepository = new LoginRepository();

        public async Task<AuthenticateResponse> Authenticate(string username, string password)
        {
            AuthenticateModel login = new AuthenticateModel()
            {
                Username = username,
                Password = password
            };

            return await _loginRepository.Authenticate(login); ;
        }
    }
}
