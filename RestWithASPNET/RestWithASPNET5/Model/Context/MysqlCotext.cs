using Microsoft.EntityFrameworkCore;

namespace RestWithASPNET5.Model.Context
{
    public class MysqlCotext : DbContext
    {
        public MysqlCotext()
        {

        }

        public MysqlCotext(DbContextOptions<MysqlCotext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set;}
    }
}
