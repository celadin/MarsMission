using System;
using System.Linq;
using NUnit.Framework;

namespace MarsMission.Core.UnitTests
{
    [TestFixture]
    public class SpaceCenterTests
    {
        [TestCase(5, 5, 1, 2, 'N', "LMLMLMLMM", "1 3 N")]
        [TestCase(5, 5, 3, 3, 'E', "MMRMMRMRRM", "5 1 E")]
        public void Launch_WithinBorders_ReturnExpectedPosition(int plateauWeight, int plateauHeight, int roverX,
            int roverY,
            char roverHead, string commandSet,
            string expectedPosition)
        {
            var spaceCenter = new SpaceCenter()
                .SetPlateau(plateauWeight, plateauHeight)
                .AddRover(roverX, roverY, roverHead, commandSet);

            var actualPosition = spaceCenter.Launch().First();

            Assert.That(actualPosition, Is.EqualTo(expectedPosition));
        }

        [TestCase(1, 1, 0, 0, 'N', "MM")]
        [TestCase(2, 2, 1, 1, 'E', "MLMM")]
        public void Launch_OutOfBorders_ThrowArgumentOutOfRangeException(int plateauWeight, int plateauHeight,
            int roverX,
            int roverY,
            char roverHead, string commandSet)
        {
            var spaceCenter = new SpaceCenter()
                .SetPlateau(plateauWeight, plateauHeight)
                .AddRover(roverX, roverY, roverHead, commandSet);

            Assert.Throws<ArgumentOutOfRangeException>(() => spaceCenter.Launch().First());
        }

        [Test]
        public void Launch_PlateauIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SpaceCenter()
                .AddRover(0, 0, 'E', "LR").Launch());
        }

        [TestCase(" ")]
        [TestCase("ab")]
        public void SetRemoteControl_UndefinedCommands_ThrowArgumentException(string commandSet)
        {
            Assert.Throws<ArgumentException>(() => new SpaceCenter().SetPlateau(1,1).AddRover(0,0,'E',commandSet));
        }
    }
}