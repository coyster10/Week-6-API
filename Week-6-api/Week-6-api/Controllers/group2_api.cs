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
    }

    public class DataUSA
    {
        public List<data> data { get; set; }
    }
    public class data
    {
        [JsonProperty(PropertyName = "ID Nation")]
        public string IdNation { get; set; }
        public string Nation { get; set; }
        [JsonProperty(PropertyName = "ID Year")]
        public int IdYear { get; set; }
        public string Year { get; set; }
        public int Population { get; set; }
        [JsonProperty(PropertyName = "Slug Nation")]
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
