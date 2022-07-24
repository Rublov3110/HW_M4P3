using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HW_M4P3
{
    public sealed class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        private string _failconfig;
        public ApplicationContextFactory()
        {
            var configFail = File.ReadAllText(@"C:\Users\Timmy\OneDrive\Рабочий стол\A-Level\Новая папка\HW_M4P3\Config\config.json");
            var config = JsonConvert.DeserializeObject<Config>(configFail);
            var fail = config.ContextFactory.ConnectionString;
            _failconfig = fail;
        }
        public ApplicationContext CreateDbContext(string[] args)
        {
            var connectionString = _failconfig;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            return new ApplicationContext(options);
        }
    }
}
