namespace MarsMission.Core.Commands
{
    internal class TurnRightCommand : CommandBase
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