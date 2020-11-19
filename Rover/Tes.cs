//using Rover.Constants;
//using Rover.Implementation;
//using System;

//namespace Rover
//{
//    public class Tes
//    {
//        //public bool _validate = false;
//        static void Main(string[] args)
//        {
//            //Console.WriteLine("Please enter the start posistion with direction for Rover seperating with a space: ");
//            //var startPosistion = Console.ReadLine().Trim().Split(' ');
//            //var position = new Position();

//            //if (startPosistion.Length != 3) return; //inverted If here, to avoid nesting which is a good practice and will avoid Sonar/Black Duck scan.


//            //position.X = Convert.ToInt32(startPosistion[0]);
//            //position.Y = Convert.ToInt32(startPosistion[1]);

//            //position.Direction = (Directions)Enum.Parse(typeof(Directions),startPosistion[2].ToUpper());
//            //_validate = false;
//            var command = string.Empty;
//            var validate = false;
//            var position = new Position();


//            do
//            {
//                InterpretUser(position);
//            }
//            while (validate);



//            if (validate)
//            {
//                Console.WriteLine("Please enter the command for Rover movement within the coordinates of (0,0) & (40,30) plateau region: ");
//                command = Console.ReadLine().ToUpper();
//            }
//            else
//            {
//                InterpretUser(position);
//            }

//            try
//            {
//                position.Move(command);
//                Console.WriteLine($"{position.X} {position.Y}{position.Direction}");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }

//            Console.ReadLine(); //Added so that the result is displayed and then when user keys in it will exit.
//        }

//        public static void InterpretUser(Position position)
//        {
//            Console.WriteLine("Please enter the start posistion with direction for Rover seperating with a space: ");
//            var startPosistion = Console.ReadLine().Trim().Split(' ');
//            //var position = new Position();

//            if (startPosistion.Length != 3) return; //inverted If here, to avoid nesting which is a good practice and will avoid Sonar/Black Duck scan.

//            position.X = Convert.ToInt32(startPosistion[0]);
//            position.Y = Convert.ToInt32(startPosistion[1]);

//            //_validate = ValidateDirection(startPosistion[2]);
//        }

//        public static bool ValidateDirection(string direction)
//        {
//            if (direction.ToUpper() != "E" || direction.ToUpper() != "W" ||
//                direction.ToUpper() != "N" || direction.ToUpper() != "S")
//            {
//                Console.WriteLine("Excepted directions are E, W, N or S");
//                return false;
//            }

//            return true;
//        }
//    }
//}
