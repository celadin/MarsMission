namespace MarsMission.Core.Commands
{
    public class MoveCommand : CommandBase
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