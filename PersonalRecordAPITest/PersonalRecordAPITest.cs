using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Web;
using Microsoft.AspNetCore.Mvc;

using PersonalRecordAPI.Models;

namespace PersonalRecordAPI
{
    [TestFixture]
    public class PersonalRecordAPITest
    {
        protected static RecordEntryContext _context = new RecordEntryContext();

        [Test]
        public void TestGenderFalse()
        {
            var test = new RecordsController();
            test.Delete(); //Make sure there is nothing in the datasource.
            ActionResult<String> actionResult = test.GetByGender();

            var status = (actionResult.Result as StatusCodeResult).StatusCode;

            int expectedStatus = 204;

            Assert.AreEqual(status, expectedStatus);

        }

        [Test]
        public void TestBirthdateFalse()
        {
            var test = new RecordsController();
            test.Delete(); //Make sure there is nothing in the datasource.
            ActionResult<String> actionResult = test.GetByBirthdate();

            var status = (actionResult.Result as StatusCodeResult).StatusCode;

            int expectedStatus = 204;

            Assert.AreEqual(status, expectedStatus);
        }


        [Test]
        public void TestNameFalse()
        {
            var test = new RecordsController();
            test.Delete(); //Make sure there is nothing in the datasource.
            ActionResult<String> actionResult = test.GetByName();

            var status = (actionResult.Result as StatusCodeResult).StatusCode;

            int expectedStatus = 204;

            Assert.AreEqual(status,expectedStatus);
        }
    



        [Test]
        public void TestGenderTrue()
        {
            var test = new RecordsController();
            test.Delete(); //Make sure there is nothing in the datasource.
            test.RawStringFormatter("Testing,Orlando,Male,Grey,05/01/1982");
            test.RawStringFormatter("Testing,Monica,Female,Turquoise,05/12/1989");
            test.RawStringFormatter("Testing,Orlando,Male,Grey,05/01/1982");
            ActionResult<String> actionResult = test.GetByGender();

            Assert.IsNotNull(actionResult);

        }



        [Test]
        public void TestBirthdateTrue()
        {
            var test = new RecordsController();
            test.Delete(); //Make sure there is nothing in the datasource.
            test.RawStringFormatter("Testing,Orlando,Male,Grey,05/01/1982");
            test.RawStringFormatter("Testing,Monica,Female,Turquoise,05/12/1989");
            test.RawStringFormatter("Testing,Orlando,Male,Grey,05/01/1982");

            ActionResult<String> actionResult = test.GetByBirthdate();

            Assert.IsNotNull(actionResult);

        }


        [Test]
        public void TestNameTrue()
        {
            var test = new RecordsController();
            test.Delete(); //Make sure there is nothing in the datasource.
            test.RawStringFormatter("Testing,Orlando,Male,Grey,05/01/1982");
            test.RawStringFormatter("Testing,Monica,Female,Turquoise,05/12/1989");
            test.RawStringFormatter("Testing,Orlando,Male,Grey,05/01/1982");


            ActionResult<String> actionResult = test.GetByName();

            Assert.IsNotNull(actionResult);

        }
    }
}