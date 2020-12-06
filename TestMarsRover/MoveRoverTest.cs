using System;
using MarsRover;
using NUnit.Framework;

namespace TestMarsRover
{
    public class Tests
    {
        [Test]
        public void ApplyInstructions()
        {
            // Given
            var actualRover = new Rover(1, 2, Direction.E);
            var nasaDirectionInstructions = "LMM";
            var expectedRover = new Rover(1, 0, Direction.S);
            var plateau = new Plateau(5, 5);

            // When
            actualRover.ApplyInstructions(nasaDirectionInstructions, plateau);

            // Then
            Assert.AreEqual(expectedRover.Y, actualRover.Y);
            Assert.AreEqual(expectedRover.X, actualRover.X);
            Assert.AreEqual(expectedRover.Direction, actualRover.Direction);
        }

        [Test]
        public void ApplyInstructions_ThrowsException()
        {
            // Given
            var actualRover = new Rover(5, 5, Direction.E);
            var nasaDirectionInstructions = "RMM";
            var plateau = new Plateau(5, 5);

            // Then
            Assert.Throws<Exception>((() => actualRover.ApplyInstructions(nasaDirectionInstructions, plateau)));
        }

        [Test]
        public void TurnRoverToLeft()
        {
            // Given
            var rover = new Rover(1, 2, Direction.E);
            var expectedDirection = Direction.S;

            // When
            rover.Turn(NasaInstruction.L);

            // Then
            Assert.AreEqual(expectedDirection, rover.Direction);
        }

        [Test]
        public void TurnRoverToRight()
        {
            // Given
            var rover = new Rover(1, 2, Direction.E);
            var expectedDirection = Direction.N;

            // When
            rover.Turn(NasaInstruction.R);

            // Then
            Assert.AreEqual(expectedDirection, rover.Direction);
        }

        [Test]
        public void MoveRoverToNorth()
        {
            // Given
            var actualRover = new Rover(1, 2, Direction.N);
            var expectedRover = new Rover(1, 3, Direction.N);
            var plateau = new Plateau(5, 5);

            // When
            actualRover.MoveRover(plateau);

            // Then
            Assert.AreEqual(expectedRover.Y, actualRover.Y);
            Assert.AreEqual(expectedRover.X, actualRover.X);
            Assert.AreEqual(expectedRover.Direction, actualRover.Direction);
        }

        [Test]
        public void MoveRoverToEast()
        {
            // Given
            var actualRover = new Rover(1, 2, Direction.E);
            var expectedRover = new Rover(0, 2, Direction.E);
            var plateau = new Plateau(5, 5);

            // When
            actualRover.MoveRover(plateau);

            // Then
            Assert.AreEqual(expectedRover.Y, actualRover.Y);
            Assert.AreEqual(expectedRover.X, actualRover.X);
            Assert.AreEqual(expectedRover.Direction, actualRover.Direction);
        }

        [Test]
        public void MoveRoverToSouth()
        {
            // Given
            var actualRover = new Rover(1, 2, Direction.S);
            var expectedRover = new Rover(1, 1, Direction.S);
            var plateau = new Plateau(5, 5);

            // When
            actualRover.MoveRover(plateau);

            // Then
            Assert.AreEqual(expectedRover.Y, actualRover.Y);
            Assert.AreEqual(expectedRover.X, actualRover.X);
            Assert.AreEqual(expectedRover.Direction, actualRover.Direction);
        }

        [Test]
        public void MoveRoverToWest()
        {
            // Given
            var actualRover = new Rover(1, 2, Direction.W);
            var expectedRover = new Rover(2, 2, Direction.W);
            var plateau = new Plateau(5, 5);

            // When
            actualRover.MoveRover(plateau);

            // Then
            Assert.AreEqual(expectedRover.Y, actualRover.Y);
            Assert.AreEqual(expectedRover.X, actualRover.X);
            Assert.AreEqual(expectedRover.Direction, actualRover.Direction);
        }

        [Test]
        public void MoveRover_ThrowException()
        {
            // Given
            var actualRover = new Rover(5, 5, Direction.W);
            var plateau = new Plateau(5, 5);

            // Then
            Assert.Throws<Exception>((() => actualRover.MoveRover(plateau)));
        }
    }
}