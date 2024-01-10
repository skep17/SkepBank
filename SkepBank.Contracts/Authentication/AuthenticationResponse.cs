using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkepBank.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid id,
        string username,
        string token);
}
