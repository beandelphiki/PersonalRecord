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

    }
}
