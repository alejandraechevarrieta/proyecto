using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace Proyecto.Controllers
{
    public class ClimaController : ApiController
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "af5128b58a59474d52d5659588188a42";

        public ClimaController()
        {
            _httpClient = new HttpClient();
        }

        [HttpPost]
        [Route("ConsultarClima")]
        public async Task<IHttpActionResult> ConsultarClima([FromBody] ClimaRequest request)
        {
            try
            {
                string ciudad = request.Ciudad;
                string url = $"http://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={ApiKey}";

                HttpResponseMessage response = await _httpClient.GetAsync(url);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode(response.StatusCode);
                }

                JObject data = JObject.Parse(responseContent);
                double temperatura = Convert.ToDouble(data["main"]["temp"]);

                return Ok(new { temperatura });
            }
            catch (Exception ex)
            {
                return StatusCode(System.Net.HttpStatusCode.NotFound);
            }
        }
    }

    public class ClimaRequest
    {
        public string Ciudad { get; set; }
    }
}
