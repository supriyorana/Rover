namespace Rover.Test
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Rover.Constants;
    using Rover.Implementation;
    using System;

    [TestClass]
    public class When_Moving_Rover
    {
        Position _position;

        public void Setup(int x, int y, Directions direction)
        {
            _position = new Position { X = x, Y = y, Direction = direction };
        }

        [TestMethod]
        [TestCategory("RoverTest")]
        public void Valid_Command_Sequence_Movement_Is_Successful()
        {
            //Test for North Directiom
            var command = "LMLMLMLMM";
            Setup(1,2, Directions.N);
            _position.Move(command);
            var actualOutput = $"{_position.X} {_position.Y} {_position.Direction}";
            var expectedOutput = "1 3 N";
            Assert.AreEqual(expectedOutput, actualOutput);

            //Test for East Directiom
            Setup(3,3, Directions.E);
            command = "MRRMMRMRRM";
            _position.Move(command);
            actualOutput = $"{_position.X} {_position.Y} {_position.Direction}";
            expectedOutput = "2 3 S";
            Assert.AreEqual(expectedOutput, actualOutput);

            //Test for West Directiom
            Setup(4, 5, Directions.W);
            command = "LMLMLMLMM";
            _position.Move(command);
            actualOutput = $"{_position.X} {_position.Y} {_position.Direction}";
            expectedOutput = "3 5 W";
            Assert.AreEqual(expectedOutput, actualOutput);

            //Test for South Directiom
            Setup(2, 7, Directions.S);
            command = "MRRMMRMRRM";
            _position.Move(command);
            actualOutput = $"{_position.X} {_position.Y} {_position.Direction}";
            expectedOutput = "2 8 W";
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [TestCategory("RoverTest")]
        public void Impermissible_Command_Sequence_Causes_Fall_Off_Plateau()
        {
            try
            {
                Setup(53, 73, Directions.E);
                var command = "LMLMLMLMM";
                _position.Move(command);
            }
            catch(Exception ex)
            {
                ex.Message.Should().NotBeNullOrEmpty();
                ex.Message.Should().Be("Position can not be beyond bounderies (0, 0) and (40, 30)");
            }
        }
    }
}
