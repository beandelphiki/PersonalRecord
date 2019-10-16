using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Newtonsoft.Json;

namespace PersonalRecordAPI.Models
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        protected static RecordEntryContext _context = new RecordEntryContext();

        // GET api/records/gender
        [HttpGet("gender/")]
        public ActionResult<string> GetByGender()
        {
            var returnData = _context.recordListAPI.OrderBy(x => x.gender)
                .ThenBy(x => x.lastName)
                .ToList();

            if (returnData.Count == 0 || returnData == null)
            {
                return NoContent();
            }


            else
            {
                var json = JsonConvert.SerializeObject(returnData);
                return Ok(json);

            }
        }


        // GET api/records/birthdate
        [HttpGet("birthdate/")]
        public ActionResult<string> GetByBirthdate()
        {
             var returnData = _context.recordListAPI.OrderBy(x => x.dateOfBirth)
               .ToList();

             if (returnData.Count == 0 || returnData == null)
             {

                return NoContent();
             }


            else
            {
                var json = JsonConvert.SerializeObject(returnData);
                return Ok(json);

            }
        }


        // GET api/records/name
        [HttpGet("name/")]
        public ActionResult<string> GetByName()
        {
             var returnData = _context.recordListAPI
               .OrderByDescending(x => x.lastName)
               .ToList();


            if (returnData.Count == 0 || returnData == null)
            {

                return NoContent();
            }


            else
            {
                var json = JsonConvert.SerializeObject(returnData);
                return Ok(json);

            }
        }



        // POST api/records
        [HttpPost]
        public ActionResult<string> RawStringFormatter([FromBody] string value)
        {
            
            //Setting up variables 
            char[] delimiterChars = { ',', '|', '\t', ' ' };
            char[] charsToTrim = { ' ', '\t' };

            var values = value.Split(delimiterChars);

            if (values.Length == 0 || values == null || values.Length > 5 ||
                values.Length < 5)
            {
                return NoContent();

            }

            else
            {
                var recordEntry = new RecordEntry();
                recordEntry.firstName = values[0].ToString().Trim(charsToTrim);
                recordEntry.lastName = values[1].ToString().Trim(charsToTrim);
                recordEntry.gender = values[2].ToString().Trim(charsToTrim);
                recordEntry.favoriteColor = values[3].ToString().Trim(charsToTrim);
                recordEntry.dateOfBirth = DateTime.Parse(values[4].ToString());

                _context.recordListAPI.Add(recordEntry);
                _context.SaveChanges();

                var json = JsonConvert.SerializeObject(recordEntry);
                return Ok(json);

            }
        }


    }
}
