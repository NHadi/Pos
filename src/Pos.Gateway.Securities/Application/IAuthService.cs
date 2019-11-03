using Pos.Gateway.Securities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Gateway.Securities.Application
{
    public interface IAuthService
    {
        SecurityToken Authenticate(string key);
    }
}
