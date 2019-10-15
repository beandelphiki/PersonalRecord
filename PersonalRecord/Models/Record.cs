using System;
using System.Collections;

namespace PersonalRecord.Models
{
    public class Record
    {
        //Define the members:
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string favoriteColor { get; set; }
        public DateTime dateOfBirth { get; set; }
        
    }
}
