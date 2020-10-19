using System;
using System.Collections.Generic;

namespace MarsMission.Core
{
    public class SpaceCenter
    {
        private readonly IList<Rover> _rovers;
        private Plateau _plateau;

        public SpaceCenter()
        {
            _rovers = new List<Rover>();
        }

        public SpaceCenter SetPlateau(int weight, int height)
        {
            _plateau = new Plateau
            {
                Weight = weight,
                Height = height
            };

            return this;
        }

        public SpaceCenter AddRover(int x, int y, char head, string commandSet)
        {
            var rover = new Rover(x, y, head, commandSet, _plateau);
            _rovers.Add(rover);
            return this;
        }


        public IEnumerable<string> Launch()
        {
            if (_plateau == null)
                throw new ArgumentNullException(nameof(_plateau));

            foreach (var rover in _rovers)
            {
                rover.ExecuteAllCommands();
                yield return rover.ToString();
            }
        }
    }
}