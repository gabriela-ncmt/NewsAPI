﻿using static API.Infra.DatabaseSettings;

namespace API.Infra
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public interface IDatabaseSettings
        {
            string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
    }
}