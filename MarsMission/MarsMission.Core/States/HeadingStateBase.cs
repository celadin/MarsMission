namespace MarsMission.Core.States
{
    public abstract class HeadingStateBase
    {
        protected Rover Rover;

        protected HeadingStateBase(Rover rover)
        {
            Rover = rover;
        }

        public abstract void TurnLeft();
        public abstract void TurnRight();
        public abstract void Move();
    }
}