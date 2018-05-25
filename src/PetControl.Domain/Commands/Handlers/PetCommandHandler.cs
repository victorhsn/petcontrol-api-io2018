using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using PetControl.Domain.Commands.Inputs;
using PetControl.Domain.Commands.Outputs;
using PetControl.Domain.Services;
using PetControl.Shared.Command;
using Feature = PetControl.Domain.Entities.Feature;

namespace PetControl.Domain.Commands.Handlers
{
    public class PetCommandHandler : Notifiable, ICommandHandler<RegisterPetCommand>
    {
        private readonly IVisionService _visionService;

        public PetCommandHandler(IVisionService visionService)
        {
            _visionService = visionService;
        }

        public ICommandResult Handle(RegisterPetCommand command)
        {
            var result = _visionService.Identify(command.File);

            if (!thereIsPug(result))
                AddNotification("Feature", $"It {result[0].Description} is not a Pug! :(");

            if (Invalid)
                return new CommandResult(false, $"This isn't a Pug!", result);
            
          
            return new RegisterPetCommandResult(true, 
                "This is a Pug!", 
                result);
        }

        private static bool thereIsPug(IEnumerable<Feature> featuries)
        {
       
            return featuries.Any(feature => feature.Description == "pug");
        }

    }
}