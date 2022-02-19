using Microsoft.AspNetCore.Mvc;

namespace Week_6_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class group2_api : ControllerBase
    {
        [HttpGet(Name = "group2_api")]

    }
}

public class DataUSA
{
    public string idNation { get; set; }
    public string nation { get; set; }
    public int idYear { get; set; }
    public int year { get; set; }
    public int population { get; set; }
    public string slugNation { get; set; }
}

public class PunkAPI
{
    public int id { get; set; }
    public string name { get; set; }
    public string tagLine { get; set; }
    public DateOnly firstBrewed { get; set; }
    public string description { get; set; }
}
