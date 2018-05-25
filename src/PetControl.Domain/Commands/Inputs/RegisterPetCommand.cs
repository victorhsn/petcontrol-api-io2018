using Microsoft.AspNetCore.Http;
using PetControl.Shared.Command;

namespace PetControl.Domain.Commands.Inputs
{
    public class RegisterPetCommand : ICommand
    {
        public IFormFile File { get; set; }
    }
}