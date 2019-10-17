using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalRecord.Models
{
    public class Record
    {
        //Define the members:
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string favoriteColor { get; set; }
        public DateTime dateOfBirth { get; set; }


    }
}
