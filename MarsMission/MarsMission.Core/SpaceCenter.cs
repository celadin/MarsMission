using System;
using System.Linq;
using MarsMission.Core.Commands;

namespace MarsMission.Core
{
    public class SpaceCenter
    {
        private Plateau _plateau;
        private RemoteControl _remoteControl;
        private Rover _rover;

        public SpaceCenter SetPlateau(int weight, int height)
        {
            _plateau = new Plateau
            {
                Weight = weight,
                Height = height
            };

            return this;
        }

        public SpaceCenter SetRover(int x, int y, char head)
        {
            _rover = new Rover(x, y, head, _plateau);
            return this;
        }

        public SpaceCenter SetRemoteControl(string commandSet)
        {
            var commands = commandSet.ToUpper().ToArray();
            if (!commands.Any())
                throw new ArgumentNullException(nameof(commandSet));

            _remoteControl = new RemoteControl();

            foreach (var command in commands)
                switch (command)
                {
                    case 'L':
                        _remoteControl.AddCommand(new TurnLeftCommand(_rover));
                        break;
                    case 'R':
                        _remoteControl.AddCommand(new TurnRightCommand(_rover));
                        break;
                    case 'M':
                        _remoteControl.AddCommand(new MoveCommand(_rover));
                        break;
                    default:
                        throw new ArgumentException("Undefined Command");
                }


            return this;
        }

        public string Launch()
        {
            if (_plateau == null)
                throw new ArgumentNullException(nameof(_plateau));

            if (_rover == null)
                throw new ArgumentNullException(nameof(_rover));

            if (_remoteControl == null)
                throw new ArgumentNullException(nameof(_remoteControl));

            _remoteControl.ExecuteAll();

            return _rover.ToString();
        }
    }
}