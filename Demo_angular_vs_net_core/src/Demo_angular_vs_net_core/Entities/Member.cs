using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_demo_angular_dotnet.Entities
{
    public class Member: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(32)]
        public string Name { get; set; }
        public string Content { get; set; }
        public JsonObject<List<string>> Skills { get; set; } // Json storage (MySQL 5.7 only)
    }

    public class MyContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=localhost;database=membermanager;uid=root;pwd=123123;");
    }
}
