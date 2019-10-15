using System;
using System.Linq;
using System.Collections.Generic;
using PersonalRecord.Models;
using Newtonsoft.Json;


namespace PersonalRecord
{
    class Program
    {
        private static RecordDBContext _context = new RecordDBContext();


        static void Main(string[] args)
        {
            string input;


            #region Handle the import

            if (args.Length == 0) {

                Console.WriteLine("Nothing was imported. Please select an item from the menu below");

                //obtaining test input

                List<Record> testList = testInsertAndReturn();

                foreach (Record recordItem in testList)
                {

                    Console.WriteLine(recordItem.id);
                    Console.WriteLine(recordItem.firstName);
                    Console.WriteLine(recordItem.lastName);
                    Console.WriteLine(recordItem.gender);
                    Console.WriteLine(recordItem.favoriteColor);
                    Console.WriteLine(recordItem.dateOfBirth);
                }

                //Generating Test Output
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
                        SortByBirthDate();
                        break;

                    case "G":
                        Console.WriteLine("Reached the sort by gender method!");
                        Console.WriteLine(Environment.NewLine);
                        SortByGender();
                        break;

                    case "N":
                        Console.WriteLine("Reached the sort by name method!");
                        Console.WriteLine(Environment.NewLine);
                        SortByLastName();
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
            string menuWelcome = "Welcome to the Personal Record System!";
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



        #region private methods used in the main driver program

     /// <summary>
     /// This function takes the data that is in the datastore and returns the list sorted by gender
     /// </summary>
     /// <returns>
     /// The data store sorted by gender as a string
     /// </returns>

        private static void SortByGender() {
       
            
        var returnData = _context.recordList.OrderBy(x => x.gender).ThenBy(x=>x.lastName).ToList();

        if (returnData.Count == 0 || returnData == null) {

            Console.WriteLine("There was no data to return — Empty Set.");
            return;

            }


        else {
                /*
                 *  string json = "";
                 *  json = JsonConvert.SerializeObject(returnData);
                 *  Console.WriteLine(json);
                 *  return json;
                */


                string concatentatedData = "";
                foreach (Record item in returnData) {
                    concatentatedData += item.id + ", " + item.lastName + ", " + item.firstName + ", " + item.dateOfBirth + ", " + item.favoriteColor + ", " + item.gender;
                    concatentatedData += Environment.NewLine;
                }
                Console.WriteLine(concatentatedData);
                return;

                
            }

        }


        /// <summary>
        /// This function takes the data that is in the datastore and returns the list sorted by birthdate
        /// </summary>
        /// <returns>
        /// The data store sorted by birthdate as a string
        /// </returns>

        private static void SortByBirthDate()
        {
            var returnData = _context.recordList.OrderBy(x => x.dateOfBirth).ToList();

            if (returnData.Count == 0 || returnData == null)
            {

                Console.WriteLine("There was no data to return — Empty Set.");
                return;

            }


            else
            {
                /*json = JsonConvert.SerializeObject(returnData);
                Console.WriteLine(json);
                return json;*/

                string concatentatedData = "";
                foreach (Record item in returnData)
                {
                    concatentatedData += item.id + ", " + item.lastName + ", " + item.firstName + ", " + item.dateOfBirth + ", " + item.favoriteColor + ", " + item.gender;
                    concatentatedData += Environment.NewLine;
                }
                Console.WriteLine(concatentatedData);
                return;

            }

        }


        /// <summary>
        /// This function takes the data that is in the datastore and returns the list sorted by last name
        /// </summary>
        /// <returns>
        ///The data store sorted by last name as a string
        /// </returns>

        private static void SortByLastName()
        {
            

            var returnData = _context.recordList
                .OrderByDescending(x => x.lastName).ToList();

            if (returnData.Count == 0 || returnData == null)
            {

                Console.WriteLine("There was no data to return — Empty Set.");
                return;

            }


            else
            {
                //json = JsonConvert.SerializeObject(returnData);
                //Console.WriteLine(json);
                //return json;

                string concatentatedData = "";
                foreach (Record item in returnData)
                {
                    concatentatedData += item.id + ", " + item.lastName + ", " + item.firstName + ", " + item.dateOfBirth + ", " + item.favoriteColor + ", " + item.gender;
                    concatentatedData += Environment.NewLine;
                }
                Console.WriteLine(concatentatedData);
                return;

            }

        }



        /*@TODO: Create importer
         *
         *
         */



        /// <summary>
        /// This is a test method that makes sure my database connection works as expected.
        /// </summary>
        /// <returns>
        /// This returns a list of records that are manually created and inserted into
        /// the dataset.
        /// </returns>
        private static List<Record> testInsertAndReturn() {



            var testInput = new Record();
            testInput.id = 100;
            testInput.firstName = "Orlando";
            testInput.lastName = "Medina";
            testInput.favoriteColor = "grey";
            testInput.gender = "Male";
            testInput.dateOfBirth = DateTime.Parse("January 31, 1983");

            var testInput2 = new Record();
            testInput2.id = 200;
            testInput2.firstName = "Tim";
            testInput2.lastName = "Roberts";
            testInput2.favoriteColor = "grey";
            testInput2.gender = "Male";
            testInput2.dateOfBirth = DateTime.Parse("December 31, 1983");



            var otherInput = new Record();
            otherInput.id = 300;
            otherInput.firstName = "Jessica";
            otherInput.lastName = "Marie";
            otherInput.favoriteColor = "pink";
            otherInput.gender = "Female";
            otherInput.dateOfBirth = DateTime.Parse("May 10, 1979");




            var otherInput2 = new Record();
            otherInput2.id = 400;
            otherInput2.firstName = "Zulma";
            otherInput2.lastName = "Lopez";
            otherInput2.favoriteColor = "pink";
            otherInput2.gender = "Female";
            otherInput2.dateOfBirth = DateTime.Parse("May 12, 1950");

            _context.recordList.Add(testInput);
            _context.recordList.Add(testInput2);
            _context.recordList.Add(otherInput);
            _context.recordList.Add(otherInput2);


            _context.SaveChanges();


            return _context.recordList.Where(x => x.id.Equals(200)).ToList();


        }

        #endregion


    }
}
