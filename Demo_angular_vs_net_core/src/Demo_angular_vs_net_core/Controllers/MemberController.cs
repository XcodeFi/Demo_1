using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_demo_angular_dotnet.Infrastructure.Repositories.Abstract;
using Web_demo_angular_dotnet.Entities;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_demo_angular_dotnet.Controllers
{
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private IMemberRepository _memRepo;
        // GET: api/values
        private MyContext _context;

        public MemberController(
        MyContext context,
        IMemberRepository memRepo
        )
        {
            _context = context;
            _memRepo = memRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Member> member = _memRepo
           .GetAll();
            return new OkObjectResult(member);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]

        public async Task<IActionResult> Post([FromBody]Member member)
        {
            GenericResult result = null;
            if (!ModelState.IsValid)
            {
                result = new GenericResult()
                {
                    Succeeded = false,
                    Message = "Dữ liệu không hợp lệ"
                };
                return new OkObjectResult(result);
            }

            Member mem = new Member()
            {
                Name = member.Name
            };
            _memRepo.Add(mem);

            try
            {
                _memRepo.Commit();
            }
            catch (DbUpdateException ex)
            {
                result = new GenericResult()
                {
                    Succeeded = false,
                    Message = $"{ex.Message}"
                };
                return new OkObjectResult(result);
            }

            result = new GenericResult()
            {
                Succeeded = true,
                Message = $"{mem.Name} thêm thành công"
            };
            return new OkObjectResult(result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Member mem = _memRepo.FindBy(c => c.Id == id).FirstOrDefault();

            if (mem == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _memRepo.Delete(mem);
                _memRepo.Commit();
                return Ok(mem);
            }
        }
    }
}
