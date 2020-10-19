namespace MarsMission.Core.Commands
{
    internal class MoveCommand : CommandBase
    {
        public MoveCommand(Rover rover) : base(rover)
        {
        }

        public override void Execute()
        {
            Rover.Move();
        }
    }
}