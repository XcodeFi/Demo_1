using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_demo_angular_dotnet.Entities
{
    public class InitData
    {
        private static MyContext _context;
        public static async Task InitializeDatabaseAsync(IServiceProvider serviceProvider)
        {
            _context = (MyContext)serviceProvider.GetService(typeof(MyContext));
            InsertData();
        }

        public static void InsertData()
        {
            using (var context = new MyContext())
            {
                // Create database
                context.Database.EnsureCreated();

                // Init sample data
                var mem = new List<Member>()
                {
                    new Member() { Name = "Gianglt", Skills = new List<string>() { "Test", "dev" } },
                    new Member() { Name = "Truongpv", Skills = new List<string>() { "Test", "dev" } },
                    new Member() { Name = "Trungtq", Skills = new List<string>() { "Test", "dev" } }
                };
                context.AddRange(mem);
                context.SaveChanges();

                // Changing and save json object #1
                //blog1.Tags.Object.Clear();
                //context.SaveChanges();

                //// Changing and save json object #2
                //blog1.Tags.Object.Add("Pomelo");
                //context.SaveChanges();
            }
        }
    }
}
