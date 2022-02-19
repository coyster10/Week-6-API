using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Week_6_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class group2_api : ControllerBase
    {
        [HttpGet(Name = "getBeerData")]
        public ActionResult<List<PunkAPI>> GetBeerData()
        {
            HttpClient client = new HttpClient();
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

            List<PunkAPI> results = JsonConvert.DeserializeObject<List<PunkAPI>>(result);

            return Ok(results);
        }

    }
    
    public class DataUSA
    {
        public string IdNation { get; set; }
        public string Nation { get; set; }
        public int IdYear { get; set; }
        public int Year { get; set; }
        public int Population { get; set; }
        public string SlugNation { get; set; }
    }

    public class PunkAPI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TagLine { get; set; }
        public DateTime FirstBrewed { get; set; }
        public string Description { get; set; }
    }
}


