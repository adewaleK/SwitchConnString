using Microsoft.EntityFrameworkCore;

namespace SwitchConn2.Data
{
    public static class DbContextFactory
    {
        public static Dictionary<string, string> ConnectionStrings { get; set; }
        public static void SetConnectionString(Dictionary<string, string> ConnStrs)
        {
            ConnectionStrings = ConnStrs;
        }

        public static ApplicationDbContext Create(string connid)
        {
            if (!string.IsNullOrEmpty(connid))
            {
                var connStr = ConnectionStrings[connid];
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer(connStr);
                return new ApplicationDbContext(optionsBuilder.Options);
            }
            else
            {
                throw new ArgumentNullException("connectionId");
            }

        }
    }
}
