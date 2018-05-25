using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PetControl.Domain.Commands.Handlers;
using PetControl.Domain.Commands.Inputs;
using PetControl.Shared.Command;

namespace PetControl.Api.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class PetController : Controller
    {
        private readonly PetCommandHandler _handler;
        
        public PetController(PetCommandHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/identify")]
        public ICommandResult Identify(RegisterPetCommand command)
        {
            return _handler.Handle(command);
        }
    }
}