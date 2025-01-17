﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Weeklyapp.DAO
{
    public abstract class DaoBase
    {
        protected readonly ILogger<DaoBase> logger;
        protected readonly string connectionString;

        public DaoBase(IConfiguration configuration, ILogger<DaoBase> logger)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
            this.logger = logger;
        }
    }
}
