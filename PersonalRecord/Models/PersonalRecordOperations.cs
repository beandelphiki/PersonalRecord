using System;
using System.Linq;
using System.Collections.Generic;


namespace PersonalRecord.Models

{
    public class PersonalRecordOperations
    {
        /// <summary>
        /// This is the DB context used for the console application.
        /// It is an in-memory database.
        /// </summary>
        protected static RecordDBContext context = new RecordDBContext();


        public PersonalRecordOperations()
        {
            if (context == null)
            {
                context = new RecordDBContext();
            }
        }



        /// <summary>
        /// This function takes the data that is in the datastore and returns the list sorted by gender
        /// </summary>
        /// <returns>
        /// The data store sorted by gender as a string
        /// </returns>

        public void SortByGender()
        {


            var returnData = context.recordList.OrderBy(x => x.gender).ThenBy(x => x.lastName).ToList();

            if (returnData.Count == 0 || returnData == null)
            {
                Console.WriteLine("There was no data to return — Empty Set.");
                return;
            }

            else
            {
                outputResults(returnData);
                return;

            }

        }


        /// <summary>
        /// This function takes the data that is in the datastore and returns the list sorted by birthdate
        /// </summary>
        /// <returns>
        /// The data store sorted by birthdate as a string
        /// </returns>

        public void SortByBirthDate()
        {
            var returnData = context.recordList.OrderBy(x => x.dateOfBirth).ToList();

            if (returnData.Count == 0 || returnData == null)
            {

                Console.WriteLine("There was no data to return — Empty Set.");
                return;

            }


            else
            {
                outputResults(returnData);
                return;
            }

        }


        /// <summary>
        /// This function takes the data that is in the datastore and returns the list sorted by last name
        /// </summary>
        /// <returns>
        ///The data store sorted by last name as a string
        /// </returns>

        public void SortByLastName()
        {

            var returnData = context.recordList
                .OrderByDescending(x => x.lastName).ToList();

            if (returnData.Count == 0 || returnData == null)
            {
                Console.WriteLine("There was no data to return — Empty Set.");
                return;
            }


            else
            {
                outputResults(returnData);
                return;
            }

        }




        /// <summary>
        /// This takes in a Record and posts it to the context.
        /// </summary>
        /// <param name="input"></param>
        public void Save(Record input) {

            context.recordList.Add(input);
            context.SaveChanges();

        }



        /// <summary>
        /// This takes in a record and outputs the results.
        /// </summary>
        /// <param name="input"></param>
        public void outputResults(List<Record> input) {

            string concatentatedData = "";
            foreach (Record item in input)
            {
                concatentatedData += item.lastName + ", " + item.firstName + ", " + item.dateOfBirth.ToString("M/d/yyyy") + ", " + item.favoriteColor + ", " + item.gender;
                concatentatedData += Environment.NewLine;
            }
            Console.WriteLine(concatentatedData);

            return;
        }



        


        /// <summary>
        /// This is a test method that makes sure my database connection works as expected.
        /// </summary>
        /// <returns>
        /// This returns a list of records that are manually created and inserted into
        /// the dataset.
        /// </returns>
        public void testInsertAndReturn()
        {


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
            testInput.id = 300;
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

            context.recordList.Add(testInput);
            context.recordList.Add(testInput2);
            context.recordList.Add(otherInput);
            context.recordList.Add(otherInput2);


            context.SaveChanges();


            return;

        }

    }
}
