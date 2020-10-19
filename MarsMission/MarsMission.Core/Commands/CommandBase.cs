namespace MarsMission.Core.Commands
{
    internal abstract class CommandBase
    {
        protected Rover Rover;

        protected CommandBase(Rover rover)
        {
            Rover = rover;
        }

        public abstract void Execute();
    }
}