using System;

namespace MarsMission.Core.States
{
    public class WestState : HeadingStateBase
    {
        public WestState(Rover rover) : base(rover)
        {
        }

        public override void Move()
        {
            if (Rover.XCoordinate > 0)
                --Rover.XCoordinate;
            else
                throw new ArgumentOutOfRangeException("Mission Failed");
        }

        public override void TurnLeft()
        {
            Rover.CurrentState = Rover.SouthState;
        }

        public override void TurnRight()
        {
            Rover.CurrentState = Rover.NorthState;
        }

        public override string ToString()
        {
            return "W";
        }
    }
}