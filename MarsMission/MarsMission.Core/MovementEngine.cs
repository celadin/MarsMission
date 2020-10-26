using System;
using System.Collections.Generic;
using System.Linq;
using MarsMission.Core.Commands;

namespace MarsMission.Core
{
    internal class MovementEngine
    {
        private readonly List<CommandBase> _commandList;

        public MovementEngine(Rover rover, string commandSet)
        {
            _commandList = new List<CommandBase>();

            SetCommands(rover, commandSet);
        }


        public void Fire()
        {
            foreach (var command in _commandList)
                command.Execute();
        }

        private void SetCommands(Rover rover, string commandSet)
        {
            var commands = commandSet.ToUpper().ToArray();
            if (!commands.Any())
                throw new ArgumentNullException(nameof(commandSet));

            foreach (var command in commands)
                switch (command)
                {
                    case 'L':
                        AddCommand(new TurnLeftCommand(rover));
                        break;
                    case 'R':
                        AddCommand(new TurnRightCommand(rover));
                        break;
                    case 'M':
                        AddCommand(new MoveCommand(rover));
                        break;
                    default:
                        throw new ArgumentException("Undefined Command");
                }
        }

        private void AddCommand(CommandBase command)
        {
            if (command != null)
                _commandList.Add(command);
        }
    }
}