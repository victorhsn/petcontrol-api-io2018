using PetControl.Shared.Command;

namespace PetControl.Domain.Commands.Outputs
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        
        public bool Success { get; private set; }
        public string Message { get; private set;  }
        public object Data { get; private set;  }
    }
}