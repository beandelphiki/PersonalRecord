using System;
using PersonalRecord.Models;
using System.IO;



namespace PersonalRecord
{
    class Program
    {
        /// <summary>
        /// These are the data members for the program.
        /// </summary>
        protected static PersonalRecordOperations recOps = new PersonalRecordOperations();
        
        const string fileInput = "/Users/digital1/Documents/import_space.csv";





        static void Main(string[] args)
        {
            string input;

            #region Handle the import

            if (args.Length == 0) {

                Console.WriteLine("Nothing was imported. Please select an item from the menu below");
            
                
                //obtaining test input
                 recOps.testInsertAndReturn();
            }



           else if (args.Length > 1)
            {
                Console.WriteLine("There were too many parameters passed in. " +
                    "—  Ignoring the input.");
                Console.WriteLine("Parameters passed in were the following : ");

                foreach (string param in args) {

                    Console.WriteLine(param);

                }
                
            }

            else
            {
                //Attempt to read in the file and see if it is valid.
                bool success = importFile(args[0]);

                if (!success)
                {
                    Console.WriteLine("Files not imported successfully.");
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
                        Console.WriteLine("Reached the sort by birth date method!");
                        Console.WriteLine(Environment.NewLine);
                        recOps.SortByBirthDate();
                        break;

                    case "G":
                        Console.WriteLine("Reached the sort by gender method!");
                        Console.WriteLine(Environment.NewLine);
                        recOps.SortByGender();
                        break;

                    case "N":
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






        /// <summary>
        /// This method imports files for use in the system.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>
        /// Returns true if the file can be imported; returns false if it can't import the file.
        /// </returns>


        private static bool importFile(string filename)
        {
            //Setting up variables 
            char[] delimiterChars = { ',', '|', '\t', ' ' };

          


            if (!File.Exists(fileInput))
            {
                Console.WriteLine("The file does not exist — Quitting");
                return false;
            }



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
}
