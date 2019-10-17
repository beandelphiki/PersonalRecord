using System;
using PersonalRecord.Models;
using System.IO;



namespace PersonalRecord
{
   public class Program
    {
        /// <summary>
        /// This gives us the ability to manage a single context and run operations on those records.
        /// </summary>
        protected static PersonalRecordOperations recOps = new PersonalRecordOperations();


        public static void Main(string[] args)
        {
            string input;

            #region Handle the import

            if (args.Length == 0) {

                Console.WriteLine("Nothing was imported. Please run again.");

                return;
            }



           else if (args.Length > 1)
            {
                Console.WriteLine("There were too many parameters passed in. " +
                    "—  Ignoring the input.");
                return;
                
            }

            else
            {
                //Attempt to read in the file and see if it is valid.
                bool success = ImportFile(args[0]);

                if (!success)
                {
                    return;
                }

            }
            #endregion




            #region Menu Generation
            //Show the menu
            Console.WriteLine(CreateMenu());
       
            do
            {

                input = Console.ReadLine();

                switch (input)
                {
                    case "B":
                    case "b":

                        Console.WriteLine("Reached the sort by birth date method!");
                        Console.WriteLine(Environment.NewLine);
                        recOps.SortByBirthDate();
                        break;

                    case "G":
                    case "g":

                        Console.WriteLine("Reached the sort by gender method!");
                        Console.WriteLine(Environment.NewLine);
                        recOps.SortByGender();
                        break;

                    case "N":
                    case "n":
                        Console.WriteLine("Reached the sort by name method!");
                        Console.WriteLine(Environment.NewLine);
                        recOps.SortByLastName();
                        break;

                    default:
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine(Environment.NewLine);
                        break;
                }


            }
            while (input != "q");
            #endregion


            Console.WriteLine("Goodbye!");

            return;
        }





        #region Create the menu
        private static string CreateMenu() {
            string menuWelcome = "Welcome to the Personal Record System! — Hit q to quit";
            string menuOptOne = "1: View entries sorted by gender (females before males) then by last name ascending. — Type G for sort by gender ";
            string menuOptTwo = "2: View entries sorted by birth date, ascending — Type B for sort by birth date";
            string menuOptThree = "3: View entries sorted by last name, descending.— Type  N for sort by last name";


            string ConcatenatedMenu = menuWelcome +
                Environment.NewLine + Environment.NewLine + Environment.NewLine +
                menuOptOne +
                Environment.NewLine +
                menuOptTwo +
                Environment.NewLine +
                menuOptThree +
                Environment.NewLine;


            return ConcatenatedMenu;

        }
        #endregion





        #region file import functionality
        /// <summary>
        /// This method imports files for use in the system.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>
        /// Returns true if the file can be imported; returns false if it can't import the file.
        /// </returns>

        public static bool ImportFile(string filename)
        {
            //Setting up variables 
            char[] delimiterChars = { ',', '|', '\t', ' ' };

            //Valdiate the file is there and can be accessed.

            if (filename == null || filename.Length == 0)
            {
                return false;
            }


            if (!File.Exists(filename))
            {
                Console.WriteLine("File does not exist! - Quitting.");
                return false;

            }
                





            else
            {
                var fileReader = new StreamReader(filename);

                //Process the input
                while (!fileReader.EndOfStream)
                {
                    var inputData = new Record();
                    var line = fileReader.ReadLine();
                    var values = line.Split(delimiterChars);
                    char[] charsToTrim = { ' ', '\t' };

                    inputData.lastName = values[0].ToString().Trim(charsToTrim);
                    inputData.firstName = values[1].ToString().Trim(charsToTrim);
                    inputData.gender = values[2].ToString().Trim(charsToTrim);
                    inputData.favoriteColor = values[3].ToString().Trim(charsToTrim);
                    inputData.dateOfBirth = DateTime.Parse(values[4].ToString());


                    recOps.Save(inputData);
                }
                Console.WriteLine("File imported successfully!");
                return true;
            }
        }
        #endregion




    }
}
