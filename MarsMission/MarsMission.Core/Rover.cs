using System;
using MarsMission.Core.States;

namespace MarsMission.Core
{
    public class Rover
    {
        private readonly MovementEngine _movementEngine;
        private readonly Plateau _plateau;
        private int _xCoordinate;
        private int _yCoordinate;

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
            _movementEngine = new MovementEngine(this, commandSet);
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
            _movementEngine.Fire();
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

        public override string ToString()
        {
            return $"{XCoordinate} {YCoordinate} {CurrentState}";
        }
    }
}