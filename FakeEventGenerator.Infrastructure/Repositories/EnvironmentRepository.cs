﻿using FakeEventGenerator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeEventGenerator.Infrastructure.Repositories
{
    public class EnvironmentRepository : UpdateRepository<EnvironmentVariable>
    {
        public EnvironmentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
