using System;
using NUnit.Framework;

namespace MarsMission.Core.UnitTests
{
    [TestFixture]
    public class RoverTests
    {
        [TestCase('E')]
        [TestCase('e')]
        [TestCase('W')]
        [TestCase('w')]
        [TestCase('N')]
        [TestCase('n')]
        [TestCase('S')]
        [TestCase('s')]
        public void DetermineCurrentState_ValidStates_CurrentStateSetsCorrectly(char head)
        {
            var rover = new Rover(0, 0, head, "M", GetPlateau(1,1));

            StringAssert.AreEqualIgnoringCase(head.ToString(), rover.CurrentState.ToString());
        }

        [TestCase('A')]
        [TestCase('a')]
        public void DetermineCurrentState_InvalidStates_ThrowArgumentException(char head)
        {
            Assert.Throws<ArgumentException>(() => new Rover(0, 0, head, "M", GetPlateau(1, 1)));
        }

        [Test]
        public void Move_WithinBordersOnXCoordinate_ChangedPositionByHeadingState()
        {
            var rover = new Rover(0, 0, 'E', "M", GetPlateau(3, 3));

            Assert.That(rover.XCoordinate, Is.EqualTo(0));

            rover.Move();
            Assert.That(rover.XCoordinate, Is.EqualTo(1));

            rover.Move();
            Assert.That(rover.XCoordinate, Is.EqualTo(2));

            rover.Move();
            Assert.That(rover.XCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void Move_OutOfBordersOnXCoordinate_ThrowArgumentOutOfRangeException()
        {
            var rover = new Rover(0, 0, 'E', "M", GetPlateau(3, 3));

            rover.Move();
            rover.Move();
            rover.Move();

            Assert.Throws<ArgumentOutOfRangeException>(() => rover.Move());
        }

        [Test]
        public void Move_WithinBordersOnYCoordinate_ChangedPositionByHeadingState()
        {
            var rover = new Rover(0, 0, 'N', "M", GetPlateau(3, 3));

            Assert.That(rover.YCoordinate, Is.EqualTo(0));

            rover.Move();
            Assert.That(rover.YCoordinate, Is.EqualTo(1));

            rover.Move();
            Assert.That(rover.YCoordinate, Is.EqualTo(2));

            rover.Move();
            Assert.That(rover.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void Move_OutOfBordersOnYCoordinate_ThrowArgumentOutOfRangeException()
        {
            var rover = new Rover(0, 0, 'N', "M", GetPlateau(3, 3));

            rover.Move();
            rover.Move();
            rover.Move();

            Assert.Throws<ArgumentOutOfRangeException>(() => rover.Move());
        }

        [Test]
        public void TurnLeft_WhenCalled_ChangedStateByHeadingState()
        {
            var rover = new Rover(1, 1, 'E', "M", GetPlateau(3, 3));

            rover.TurnLeft();
            Assert.That(rover.CurrentState.ToString(), Is.EqualTo("N"));

            rover.TurnLeft();
            Assert.That(rover.CurrentState.ToString(), Is.EqualTo("W"));

            rover.TurnLeft();
            Assert.That(rover.CurrentState.ToString(), Is.EqualTo("S"));

            rover.TurnLeft();
            Assert.That(rover.CurrentState.ToString(), Is.EqualTo("E"));
        }

        [Test]
        public void TurnRight_WhenCalled_ChangedStateByHeadingState()
        {
            var rover = new Rover(1, 1, 'E', "M", GetPlateau(3, 3));

            rover.TurnRight();
            Assert.That(rover.CurrentState.ToString(), Is.EqualTo("S"));

            rover.TurnRight();
            Assert.That(rover.CurrentState.ToString(), Is.EqualTo("W"));

            rover.TurnRight();
            Assert.That(rover.CurrentState.ToString(), Is.EqualTo("N"));

            rover.TurnRight();
            Assert.That(rover.CurrentState.ToString(), Is.EqualTo("E"));
        }

        [Test]
        public void CombinationOfCommands_WhenCalled_ReturnExpectedPosition()
        {
            var rover = new Rover(1, 1, 'E', "M", GetPlateau(3, 3));

            rover.TurnLeft();
            Assert.That(rover.ToString(), Is.EqualTo("1 1 N"));

            rover.Move();
            Assert.That(rover.ToString(), Is.EqualTo("1 2 N"));

            rover.TurnRight();
            Assert.That(rover.ToString(), Is.EqualTo("1 2 E"));

            rover.Move();
            Assert.That(rover.ToString(), Is.EqualTo("2 2 E"));
        }


        private Plateau GetPlateau(int weight, int height)
        {
            return new Plateau()
            {
                Weight = weight,
                Height = height
            };
        }
    }
}