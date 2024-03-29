﻿using System.Collections.Generic;
using System.Security.Claims;

namespace BlaccEnterprise.Interview.Infrastructure
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}