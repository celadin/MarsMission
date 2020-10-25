using System;
using System.Linq;
using MarsMission.Core.Commands;
using MarsMission.Core.States;

namespace MarsMission.Core
{
    public class Rover
    {
        private int _xCoordinate;
        private int _yCoordinate;
        private readonly Plateau _plateau;
        private RemoteControl _remoteControl;

        public Rover(int xCoordinate, int yCoordinate, char head, string commandSet, Plateau plateau)
        {
            _plateau = plateau ?? throw new ArgumentNullException(nameof(plateau));

            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;

            EastState = new EastState(this);
            WestState = new WestState(this);
            NorthState = new NorthState(this);
            SouthState = new SouthState(this);

            DetermineCurrentState(head);
            SetRemoteControl(commandSet);
        }

        public int XCoordinate
        {
            get => _xCoordinate;
            internal set
            {
                if (value < 0 || value > _plateau.Weight)
                    throw new ArgumentOutOfRangeException("Mission Failed");

                _xCoordinate = value;
            }
        }

        public int YCoordinate
        {
            get => _yCoordinate;
            internal set
            {
                if (value < 0 || value > _plateau.Height)
                    throw new ArgumentOutOfRangeException("Mission Failed");

                _yCoordinate = value;
            }
        }

        internal HeadingStateBase EastState { get; }
        internal HeadingStateBase WestState { get; }
        internal HeadingStateBase NorthState { get; }
        internal HeadingStateBase SouthState { get; }

        public HeadingStateBase CurrentState { get; internal set; }

        public int GetPlateauWeight()
        {
            return _plateau.Weight;
        }

        public int GetPlateauHeight()
        {
            return _plateau.Height;
        }

        public void TurnLeft()
        {
            CurrentState.TurnLeft();
        }

        public void TurnRight()
        {
            CurrentState.TurnRight();
        }

        public void Move()
        {
            CurrentState.Move();
        }

        public void Drive()
        {
            _remoteControl.ExecuteAll();
        }

        private void DetermineCurrentState(char head)
        {
            head = char.ToUpper(head);

            CurrentState = head switch
            {
                'E' => EastState,
                'W' => WestState,
                'N' => NorthState,
                'S' => SouthState,
                _ => throw new ArgumentException("Uncertain Head")
            };
        }

        private void SetRemoteControl(string commandSet)
        {
            var commands = commandSet.ToUpper().ToArray();
            if (!commands.Any())
                throw new ArgumentNullException(nameof(commandSet));

            var remoteControl = new RemoteControl();

            foreach (var command in commands)
                switch (command)
                {
                    case 'L':
                        remoteControl.AddCommand(new TurnLeftCommand(this));
                        break;
                    case 'R':
                        remoteControl.AddCommand(new TurnRightCommand(this));
                        break;
                    case 'M':
                        remoteControl.AddCommand(new MoveCommand(this));
                        break;
                    default:
                        throw new ArgumentException("Undefined Command");
                }

            this._remoteControl = remoteControl;
        }

        public override string ToString()
        {
            return $"{XCoordinate} {YCoordinate} {CurrentState}";
        }
    }
}