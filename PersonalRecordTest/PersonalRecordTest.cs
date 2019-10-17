using NUnit.Framework;



namespace PersonalRecord.Models
{
    [TestFixture]
    public class PersonalRecordTest
    {
        #region Test the private methods in the console application
        [TestCase("/Users/digital1/Documents/import_csv.csv")]
        [TestCase("/Users/digital1/Documents/import_space.csv")]
        [TestCase("/Users/digital1/Documents/import.csv")]
        public void TestValidFiles(string input)
        {
           Assert.IsTrue(Program.ImportFile(input));

        }



        [TestCase("")]
        public void TestInvalidPath(string input)
        {
            Assert.IsFalse(Program.ImportFile(input));

        }


        [TestCase("~/blank.csv")]
        public void TestNonexistance(string input)
        {
            Assert.IsFalse(Program.ImportFile(input));

        }


        #endregion


        #region Test Personal Record Operations Class


        [Test]
        public void TestPersonalRecOpsGenderFalse()
        {
            PersonalRecordOperations ops = new PersonalRecordOperations();
            bool test = ops.SortByGender();
            Assert.IsFalse(ops.SortByGender());

        }


        [Test]
        public void TestPersonalRecOpsBirthdateFalse()
        {
            PersonalRecordOperations ops = new PersonalRecordOperations();
            Assert.IsFalse(ops.SortByBirthDate());

        }



        [Test]
        public void TestPersonalRecOpNamesFalse()
        {
            PersonalRecordOperations ops = new PersonalRecordOperations();
            Assert.IsFalse(ops.SortByLastName());

        }



        [Test]
        public void TestPersonalRecOpsGenderTrue() {
            Program.ImportFile("/Users/digital1/Documents/import_csv.csv");

            PersonalRecordOperations ops = new PersonalRecordOperations();
            Assert.IsTrue(ops.SortByGender());

        }



        [Test]
        public void TestPersonalRecOpsBirthdateTrue()
        {
            Program.ImportFile("/Users/digital1/Documents/import_csv.csv");

            PersonalRecordOperations ops = new PersonalRecordOperations();
            Assert.IsTrue(ops.SortByBirthDate());

        }



        [Test]
        public void TestPersonalRecOpsNamesTrue()
        {
            Program.ImportFile("/Users/digital1/Documents/import_csv.csv");

            PersonalRecordOperations ops = new PersonalRecordOperations();
            Assert.IsTrue(ops.SortByLastName());

        }

        #endregion


    }
}