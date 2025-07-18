using AcademyProject_API.Model.Entities;
using AcademyProject_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstractorController : BaseController<Instractor>
    {
        public InstractorController(IGenaricRepo<Instractor> service) : base(service)
        {
        }
    }
}
