namespace MarsMission.Core.Commands
{
    internal class TurnLeftCommand : CommandBase
    {
        public TurnLeftCommand(Rover rover) : base(rover)
        {
        }

        public override void Execute()
        {
            Rover.TurnLeft();
        }
    }
}