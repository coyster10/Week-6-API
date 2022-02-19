using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using Newtonsoft;
using Newtonsoft.Json;

namespace Week_6_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class group2_api : ControllerBase
    {
        [HttpGet(Name = "Data_From_USA")]
        public ActionResult<DataUSA> Get()
        {
            HttpClient client = new HttpClient();
            dynamic? obj = new ExpandoObject();

            string result;

            try
            {
                HttpResponseMessage response = client.GetAsync("https://datausa.io/api/data?drilldowns=Nation&measures=Population").Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var list = JsonConvert.DeserializeObject<DataUSA>(result);
            return Ok(list.data);
        }

        /*public ActionResult<List<PunkAPI>> Get()
        {
            HttpClient client = new HttpClient();
            dynamic? obj = new ExpandoObject();

            string result;

            try
            {
                HttpResponseMessage response = client.GetAsync("https://api.punkapi.com/v2/beers").Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var list = JsonConvert.DeserializeObject<List<PunkAPI>>(result);
            return Ok(list);
        }*/

    }

    public class DataUSA
    {
        public List<data> data { get; set; }
    }
    public class data
    {
        public string IdNation { get; set; }
        public string Nation { get; set; }
        public int IdYear { get; set; }
        public string Year { get; set; }
        public int Population { get; set; }
        public string SlugNation { get; set; }
    }

    public class PunkAPI
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tagLine { get; set; }
        public DateOnly firstBrewed { get; set; }
        public string description { get; set; }
    }
}
