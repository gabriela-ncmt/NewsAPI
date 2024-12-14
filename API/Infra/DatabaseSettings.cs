using static NewsAPI.Infra.DatabaseSettings;

namespace NewsAPI.Infra
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get ; set ; }

        public interface IDatabaseSettings
        {
            string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }
    }
}
