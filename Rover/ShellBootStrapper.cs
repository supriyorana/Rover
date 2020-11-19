using Rover.Constants;
using Rover.Implementation;
using System;

namespace Rover
{
    public class ShellBootStrapper
    {
        static void Main(string[] args)
        {
            var command = string.Empty;
            var position = new Position();
            bool validate;

            do
            {
                validate = InterpretUser(position);
            }
            while (!validate);

            if (validate)
            {
                Console.WriteLine("Please enter the command for Rover movement within the coordinates of (0,0) & (40,30) plateau region: ");
                command = Console.ReadLine().ToUpper();
            }

            try
            {
                position.Move(command);
                Console.WriteLine($"{position.X} {position.Y} {position.Direction}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine(); //Added so that the result is displayed and then when user enter any key in it will exit.
        }

        public static bool InterpretUser(Position position)
        {
            Console.WriteLine("Please enter the start posistion with direction for Rover seperating with a space: ");
            var startPosistion = Console.ReadLine().Trim().Split(' ');

            if (startPosistion.Length != 3) return false; //inverted If here, to avoid nesting which is a good practice and will avoid Sonar/Black Duck scan.

            position.X = Convert.ToInt32(startPosistion[0]);
            position.Y = Convert.ToInt32(startPosistion[1]);

            if(ValidateDirection(startPosistion[2]))
            {
                position.Direction = (Directions)Enum.Parse(typeof(Directions), startPosistion[2].ToUpper());
                return true;
            }
            return false;
        }

        public static bool ValidateDirection(string direction)
        {
            if (direction.ToUpper() == "E" || direction.ToUpper() == "W" ||
                direction.ToUpper() == "N" || direction.ToUpper() == "S")
                return true;

                Console.WriteLine("Excepted directions are E, W, N or S");
                return false;
        }
    }
}
