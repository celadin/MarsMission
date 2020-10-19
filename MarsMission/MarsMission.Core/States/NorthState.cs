using System;

namespace MarsMission.Core.States
{
    internal class NorthState : HeadingStateBase
    {
        public NorthState(Rover rover) : base(rover)
        {
        }

        public override void Move()
        {
            if (Rover.YCoordinate < Rover.GetPlateauHeight())
                ++Rover.YCoordinate;
            else
                throw new ArgumentOutOfRangeException("Mission Failed");
        }

        public override void TurnLeft()
        {
            Rover.CurrentState = Rover.WestState;
        }

        public override void TurnRight()
        {
            Rover.CurrentState = Rover.EastState;
        }

        public override string ToString()
        {
            return "N";
        }
    }
}