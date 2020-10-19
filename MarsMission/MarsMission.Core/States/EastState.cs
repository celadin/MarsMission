using System;

namespace MarsMission.Core.States
{
    public class EastState : HeadingStateBase
    {
        public EastState(Rover rover) : base(rover)
        {
        }

        public override void Move()
        {
            if (Rover.XCoordinate < Rover.GetPlateauWeight())
                ++Rover.XCoordinate;
            else
                throw new ArgumentOutOfRangeException("Mission Failed");
        }

        public override void TurnLeft()
        {
            Rover.CurrentState = Rover.NorthState;
        }

        public override void TurnRight()
        {
            Rover.CurrentState = Rover.SouthState;
        }

        public override string ToString()
        {
            return "E";
        }
    }
}