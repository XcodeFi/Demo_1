using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_demo_angular_dotnet.Entities;
using Web_demo_angular_dotnet.Infrastructure.Repositories.Abstract;

namespace Web_demo_angular_dotnet.Infrastructure.Repositories
{
    public class MemberRepository : EntitiesBaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(MyContext context) : base(context) { }
    }
}
