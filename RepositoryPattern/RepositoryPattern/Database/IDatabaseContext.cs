﻿using Microsoft.EntityFrameworkCore;
using System;

namespace RepositoryPattern.Database
{
    /// <summary>
    /// Interface for EF Core DbContext file to follow IOC and allow mocking
    /// </summary>
    public interface IDatabaseContext : IDisposable
    {
        DbContext Instance { get; }
    }
}
