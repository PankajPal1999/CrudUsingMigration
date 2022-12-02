using CrudUsingMigration.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsingMigration.Data
{
    public interface IJwtSecurity
    {
        Tokens Authenticate(Login login);

    }
}
