using System;
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
                .SetRover(roverX, roverY, roverHead)
                .SetRemoteControl(commandSet);

            var actualPosition = spaceCenter.Launch();

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
                .SetRover(roverX, roverY, roverHead)
                .SetRemoteControl(commandSet);

            Assert.Throws<ArgumentOutOfRangeException>(() => spaceCenter.Launch());
        }

        [Test]
        public void Launch_PlateauIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SpaceCenter()
                .SetRover(0, 0, 'E')
                .SetRemoteControl("").Launch());
        }

        [Test]
        public void Launch_RemoteControlIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SpaceCenter()
                .SetPlateau(5, 5)
                .SetRover(0, 0, 'E').Launch());
        }

        [Test]
        public void Launch_RoverIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SpaceCenter()
                .SetPlateau(5, 5)
                .SetRemoteControl("").Launch());
        }

        [TestCase(" ")]
        [TestCase("ab")]
        public void SetRemoteControl_UndefinedCommands_ThrowArgumentException(string commandSet)
        {
            Assert.Throws<ArgumentException>(() => new SpaceCenter().SetRemoteControl(commandSet));
        }
    }
}