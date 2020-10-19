namespace MarsMission.Core.Commands
{
    public class TurnLeftCommand : CommandBase
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