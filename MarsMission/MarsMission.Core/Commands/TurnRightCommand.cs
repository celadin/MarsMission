namespace MarsMission.Core.Commands
{
    public class TurnRightCommand : CommandBase
    {
        public TurnRightCommand(Rover rover) : base(rover)
        {
        }

        public override void Execute()
        {
            Rover.TurnRight();
        }
    }
}