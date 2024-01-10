using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkepBank.Contracts.Authentication
{
    public record RegisterRequest(
        string userName,
        string password);
}
