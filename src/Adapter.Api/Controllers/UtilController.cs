using Adapter.Api.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Adapter.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UtilController : ControllerBase
    {
        private readonly IMapper _mapper;

        public UtilController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
