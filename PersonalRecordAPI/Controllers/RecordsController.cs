using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PersonalRecordAPI.Models
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        /// <summary>
        /// This is the context for the data being used. It is an inmemory database.
        /// </summary>
        protected static RecordEntryContext _context = new RecordEntryContext();

        /// <summary>
        /// These are the settings for the JSON Serializer used to modify the
        /// date to the desired format.
        /// </summary>
        readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            DateFormatString = "MM/dd/yyyy"
        };





        /// <summary>
        /// This returns the collection sorted by gender where females are first, then males.
        /// </summary>
        /// <returns>
        ///The rerturn type is a JSON Object that has the collection sorted by gender.
        /// </returns>
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
                var json = JsonConvert.SerializeObject(returnData, settings);
                return Ok(json);

            }
        }




        /// <summary>
        /// This returns the collection sorted by birthdate.
        /// </summary>
        /// <returns>
        ///The rerturn type is a JSON Object that has the collection sorted by birthdate.
        /// </returns>
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
                var json = JsonConvert.SerializeObject(returnData, settings);
                return Ok(json);

            }
        }



        /// <summary>
        /// This returns the collection sorted by last name descending.
        /// </summary>
        /// <returns>
        ///The rerturn type is a JSON Object that has the collection sorted by last name descending.
        /// </returns>
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
                var json = JsonConvert.SerializeObject(returnData, settings);
                return Ok(json);

            }
        }

        /// <summary>
        /// This posts a record formatted as a string into the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// 
        ///This returns a JSON representation of the object applied to the data set.
        ///
        /// </returns>
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




        [HttpDelete]
        public NoContentResult Delete()
        {
            var itemsToDelete = _context.recordListAPI.Where(x => x.id >= 1);
            _context.recordListAPI.RemoveRange(itemsToDelete);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
