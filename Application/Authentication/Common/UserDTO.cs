﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.Common
{
    public record UserDTO(string Id,
        string FirstName,
        string LastName,
        string UserName,
        string Email);
}
