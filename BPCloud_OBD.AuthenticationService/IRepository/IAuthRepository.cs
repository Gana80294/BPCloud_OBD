using BPCloud_OBD.AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPCloud_OBD.AuthenticationService.IRepository
{
    public interface IAuthRepository
    {
        Client FindClient(string clientId);
        Task<AuthenticationResult> AuthenticateUser(string UserName, string Password);
    }
}
