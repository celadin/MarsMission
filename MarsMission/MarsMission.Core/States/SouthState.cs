using System;

namespace MarsMission.Core.States
{
    public class SouthState : HeadingStateBase
    {
        public SouthState(Rover rover) : base(rover)
        {
        }

        public override void Move()
        {
            if (Rover.YCoordinate > 0)
                --Rover.YCoordinate;
            else
                throw new ArgumentOutOfRangeException("Mission Failed");
        }

        public override void TurnLeft()
        {
            Rover.CurrentState = Rover.EastState;
        }

        public override void TurnRight()
        {
            Rover.CurrentState = Rover.WestState;
        }

        public override string ToString()
        {
            return "S";
        }
    }
}