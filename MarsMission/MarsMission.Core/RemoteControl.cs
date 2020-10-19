using System.Collections.Generic;
using MarsMission.Core.Commands;

namespace MarsMission.Core
{
    internal class RemoteControl
    {
        private readonly List<CommandBase> _commandList;

        public RemoteControl()
        {
            _commandList = new List<CommandBase>();
        }

        public void AddCommand(CommandBase command)
        {
            if (command != null) 
                _commandList.Add(command);
        }

        public void ExecuteAll()
        {
            foreach (var command in _commandList) 
                command.Execute();
        }
    }
}