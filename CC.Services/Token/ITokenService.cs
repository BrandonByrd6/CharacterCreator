using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Models.Token;

namespace CC.Services.Token
{
    public interface ITokenService
    {
        Task<TokenResponse?> GetTokenAsync(TokenRequest model);
    }
}